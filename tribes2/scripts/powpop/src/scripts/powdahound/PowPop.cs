// #autoload
// #name = PowPop
// #version = 1.3
// #date = May 31, 2002
// #author = Garret Heaton
// #warrior = powdahound
// #email = powdahound@nitrousonline.net
// #web = http://hosted.tribes-universe.com/powda/
// #description = Displays pop-ups for kills, deaths, flag events, and repair kit pickup.
// #credit = Halide, co-author
// #readme = scripts/powdahound/PowPop.txt
// #include = support/callback.cs
// #include = support/mute_tools.cs
// #config = PowPopGui

if(!isObject(PowPop))
{
	new ScriptObject(PowPop)
	{
		class = PowPop;
		version = "1.3";
		displayTime = 3000;
		// weapon names
		weaponText[0] = "default";
		weaponText[1] = "blaster";
		weaponText[2] = "plasma";
		weaponText[3] = "chaingun";
		weaponText[4] = "disc";
		weaponText[5] = "grenade";
		weaponText[6] = "laser rifle";
		weaponText[7] = "ELF";
		weaponText[8] = "mortar";
		weaponText[9] = "missile";
		weaponText[10] = "shocklance";
		weaponText[11] = "mine";
		weaponText[12] = "explosion";
		weaponText[13] = "impact";
		weaponText[14] = "ground";
		weaponText[15] = "turret";
		weaponText[16] = "plasma turret";
		weaponText[17] = "AA turret";
		weaponText[18] = "ELF turret";
		weaponText[19] = "mortar turret";
		weaponText[20] = "missile turret";
		weaponText[21] = "clamp turret";
		weaponText[22] = "spike turret";
		weaponText[23] = "sentry turret";
		weaponText[24] = "out of bounds";
		weaponText[25] = "lava";
		weaponText[26] = "shrike blaster";
		weaponText[27] = "bomber turret";
		weaponText[28] = "bomb";
		weaponText[29] = "tank chaingun";
		weaponText[30] = "tank mortar";
		weaponText[31] = "satchel charge";
		weaponText[32] = "MPB missile";
		weaponText[33] = "lighting";
		weaponText[35] = "ForceField";
		weaponText[36] = "crash";
		weaponText[98] = "nexus camping";
		weaponText[99] = "suicide";
	};
}

// START package PowPop
package	PowPop
{

	function PowPop::handleJoin(%this, %msgType, %msgString, %clientName, %clientId, %targetId, %isAI, %isAdmin, %isSuperAdmin, %isSmurf, %guid)
	{
		if(StrStr(%msgString, "Welcome to Tribes") != -1)
		{
			%this.clientId = %clientId;
			%this.playerName = detag(%clientName);
		}
	}

	function PowPop::isManager(%this, %clientName)
	{
		%clientName = detag(%clientName);

		return %clientName $= %this.playerName;
	}

	function PowPop::getClientTeamId(%this, %clientId)
	{
		%clientId = detag(%clientId);
		%player = $PlayerList[%clientId];

		return %player.teamId;
	}

        function PowPop::handleClientNameChanged( %this, %msgType, %msgString, %oldName, %newName, %clientId )
        {
		%clientId = detag(%clientId);
                if(%clientId == %this.clientId)
                {
			%this.clientId = %clientId;
			%this.playerName = detag(%newName);
                }
        }

	function PowPop::handleKillMsg(%this, %msgType, %msgString, %victimName, %vgen, %vposs, %killerName, %kgen, %kposs, %damageType)
	{
		if(!%this.doKillsDeaths)
			return;

		%damageType = detag(%damageType);

		%this.weapon = %this.weaponText[%damageType];	// the damage type
		%this.msgType = detag(%msgType);				// type of the message (defines the action)
		%this.killerName = detag(%killerName);			// name of the killer
		%this.victimName = detag(%victimName);			// name of the victim

		// if i didn't kill or get killed, exit
		if(!%this.isManager(%this.victimName) && !%this.isManager(%this.killerName) || %damageType == 0)
			return;	

		if(%this.msgType $= "MsgTeamKill")
		{
			// teamkill message handling
			if(%this.isManager(%this.killerName)) // i teamkilled!
				%this.schedule(%this.queue(), display, "\c0You team killed!" NL "\c1Victim: " @ %this.victimName NL "\c1Weapon: \c2" @ %this.weapon, 3);
			else if(%this.isManager(%this.victimName)) // i was teamkilled!
				%this.schedule(%this.queue(), display, "\c0You were team killed!" NL "\c1Killer: " @ %this.killerName NL "\c1Weapon: \c2" @ %this.weapon, 3);
		}
		else
		{
			// kill message handling
			if(%this.isManager(%this.victimName)) // if i'm the victim, and it's some sort of kill
				%this.schedule(%this.queue(), display, "\c0You died!" NL (%this.killerName !$= "" ? "\c1Killer: " @ %this.killerName @ "\n" : "") @ "\c1Weapon: \c2" @ %this.weapon, 3);
			else if(%this.isManager(%this.killerName)) // if i'm the killer
				%this.schedule(%this.queue(), display, "\c0Kill!" NL "\c1Victim: " @ %this.victimName NL "\c1Weapon: \c2" @ %this.weapon, 3);
		}
	}

	function PowPop::handleSuicide(%this, %msgType, %msgString, %victimName, %vgen, %vposs, %killerName, %kgen, %kposs, %damageType)
	{
		if(!%this.doKillsDeaths)
			return;

		%damageType = detag(%damageType);

		%this.weapon = %this.weaponText[%damageType];	// the damage type
		%this.msgType = detag(%msgType);				// type of the message (defines the action)
		%this.killerName = detag(%killerName);			// name of the killer
		%this.victimName = detag(%victimName);			// name of the victim

		// suicide message handling
		if(%this.isManager(%this.victimName))
		{
		   if(%damageType == 99)
			  %this.schedule(%this.queue(), display, "\c0You killed yourself.", 1);
		   else if(%damageType == 14)
			  %this.schedule(%this.queue(), display, "\c0You landed too hard.", 1);
		   else if(%damageType != 14)
			  %this.schedule(%this.queue(), display, "\c0You killed yourself!" NL "\c1Weapon: \c2" @ %this.weapon, 2);
		}
	}

	function PowPop::handleTurret(%this, %msgType, %msgString, %victimName, %vgen, %vposs, %killerName, %kgen, %kposs, %damageType)
	{
		if(!%this.doKillsDeaths)
			return;

		%damageType = detag(%damageType);

		%this.weapon = %this.weaponText[%damageType];	// the damage type
		%this.msgType = detag(%msgType);				// type of the message (defines the action)
		%this.killerName = detag(%killerName);			// name of the killer
		%this.victimName = detag(%victimName);			// name of the victim

		if(%this.isManager(%this.victimName))
		   %this.schedule(%this.queue(), display, "\c0You died!" NL "\c1Killer: \c2" @ %this.weapon, 2);
	}

	function PowPop::handleOdd(%this, %msgType, %msgString, %victimName, %vgen, %vposs, %killerName, %kgen, %kposs, %damageType)
	{
		if(!%this.doKillsDeaths)
			return;

		%damageType = detag(%damageType);

		%this.weapon = %this.weaponText[%damageType];	// the damage type
		%this.msgType = detag(%msgType);				// type of the message (defines the action)
		%this.killerName = detag(%killerName);			// name of the killer
		%this.victimName = detag(%victimName);			// name of the victim

		if(%this.isManager(%this.victimName))
		{
			switch$(%this.msgType)
			{
				case "msgCarKill":
					%this.schedule(%this.queue(), display, "\c0You died on impact.", 1);
				case "msgExplosionKill":
					%this.schedule(%this.queue(), display, "\c0You were killed" NL "by an explosion.", 2);
				case "msgLavaKill":
					%this.schedule(%this.queue(), display, "\c0You fell into the lava.", 1);
				case "msgVehicleSpawnKill":
					%this.schedule(%this.queue(), display, "\c0Some momo" NL "spawned a vehicle" NL "on top of you.", 3);
				case "msgVehicleCrash":
					%this.schedule(%this.queue(), display, "\c0You crashed your vehicle.", 1);
				case "msgOOBKill":
					%this.schedule(%this.queue(), display, "\c0You gotta stay" NL "in-bounds buddy.", 2);
				case "msgCampKill":
					%this.schedule(%this.queue(), display, "\c0You were killed" NL "for nexus camping.", 2);
				case "msgLightningKill":
					%this.schedule(%this.queue(), display, "\c0You got zapped by lightning.", 1);
				case "msgRogueMineKill":
					%this.schedule(%this.queue(), display, "\c0You were killed" NL "by a rogue mine.", 2);
			}
		}
	}

	function PowPop::handleFlagReturned(%this, %msgType, %msgStr, %clientName, %teamName, %teamId)
	{
		if(!%this.doFlagEvents)
			return;

		%flagTeam = detag(%teamId);
		%clientTeam = %this.getClientTeamId(%this.clientId);
		
		if(%flagTeam == %clientTeam)
			%this.schedule(%this.queue(), display, "\c0Your flag has been returned.", 1);
		else
			%this.schedule(%this.queue(), display, "\c0The enemy flag" NL "has been returned.", 2);
	}

	function PowPop::handleFlagTaken(%this, %msgType, %msgStr, %clientName, %teamName, %teamId, %taker)
	{
		if(!%this.doFlagEvents)
			return;

		%flagTeam = detag(%teamId);
		%clientTeam = %this.getClientTeamId(%this.clientId);
		%flagger = detag(%clientName);

		if(%flagTeam == %clientTeam)
			 %this.schedule(%this.queue(), display, "\c0Enemy " @ %flagger NL "has taken your flag!", 2);
		else
		{
			if(%this.isManager(%flagger))
				%this.schedule(%this.queue(), display, "\c0You have the enemy flag!", 1);
			else
				%this.schedule(%this.queue(), display, "\c0Teammate " @ %flagger NL "has taken the enemy flag!", 2);
		}
	}

	function PowPop::handleFlagDropped(%this, %msgType, %msgStr, %clientName, %teamName, %teamId)
	{
		if(!%this.doFlagEvents)
			return;

		%flagTeam = detag(%teamId);
		%clientTeam = %this.getClientTeamId(%this.clientId);

		if(%flagTeam == %clientTeam)
			 %this.schedule(%this.queue(), display, "\c0Your flag was" NL "dropped in the field!", 2);
		else
			 %this.schedule(%this.queue(), display, "\c0The enemy flag was" NL "dropped in the field!", 2);
	}

	// thanks to Yogi and his matchstats script for this, nobody was telling me how to get the cappers name in irc!
	// thnx yogi!!
	function PowPop::handleFlagCap(%this, %msgType, %msgString, %capper, %a2, %flagTeamId)
	{
		if(!%this.doFlagEvents)
			return;

		%capper = detag(%capper);
		%flagTeam = detag(%flagTeamId);
		%clientTeam = %this.getClientTeamId(%this.clientId);

		if(%flagTeam == %clientTeam)
			%this.schedule(%this.queue(), display, "\c0Enemy " @ %capper NL "captured your flag!", 2);
		else
		{
		   if(StrStr(%msgString, "You captured the") != -1)
			   %this.schedule(%this.queue(), display, "\c0You captured the enemy flag!", 1);
		   else
			   %this.schedule(%this.queue(), display, "\c0Teammate " @ %capper NL "captured the enemy flag!", 2);
		}
	}

	function PowPop::handleRepKit(%this, %msgType, %msgString)
	{
		if(!%this.doRepKits)
			return;

		if(strStr(%msgString, "You picked up a repair kit.") != -1)
		{
			 %this.schedule(%this.queue(), display, "\c0You picked up a repair kit!", 1);
			 return mute;
		}
	}

	function PowPop::setup(%this)
	{
		if(%this.setup)
			return;

		if(!exec("prefs/PowPopPrefs.cs"))
			%this.setDefaults();

		%this.buildOptions();
		%this.setPrefs();

		callback.add(CallbackMsgClientJoin,			"PowPop.handleJoin");
		callback.add(CallbackMsgItemPickup,			"PowPop.handleRepKit");
                callback.add(CallbackMsgClientNameChanged,              "PowPop.handleClientNameChanged");

		// suicide callbacks
		callback.add(CallbackMsgSuicide,			"PowPop.handleSuicide");
		callback.add(CallbackMsgSelfKill,			"PowPop.handleSuicide");
		callback.add(CallbackMsgTurretSelfKill,		"PowPop.handleSuicide");

		// normal kill callbacks
		callback.add(CallbackMsgLegitKill,			"PowPop.handleKillMsg");
		callback.add(CallbackMsgTeamKill,			"PowPop.handleKillMsg");
		callback.add(CallbackMsgHeadShotKill,		"PowPop.handleKillMsg");
		callback.add(CallbackMsgVehicleKill,		"PowPop.handleKillMsg");
		callback.add(CallbackMsgCTurretKill,		"PowPop.handleKillMsg");
		callback.add(CallbackMsgHeadshotKill,		"PowPop.handleKillMsg");
		callback.add(CallbackMsgTurretKill,			"PowPop.handleTurret");

		// other kill callbacks
		callback.add(CallbackMsgCarKill,			"PowPop.handleOdd");
		callback.add(CallbackMsgExplosionKill,		"PowPop.handleOdd");
		callback.add(CallbackMsgVehicleSpawnKill,	"PowPop.handleOdd");
		callback.add(CallbackMsgVehicleCrash,		"PowPop.handleOdd");
		callback.add(CallbackMsgOOBKill,			"PowPop.handleOdd");
		callback.add(CallbackMsgCampKill,			"PowPop.handleOdd");
		callback.add(CallbackMsgLavaKill,			"PowPop.handleOdd");
		callback.add(CallbackMsgLightningKill,		"PowPop.handleOdd");
		callback.add(CallbackMsgRogueMineKill,		"PowPop.handleOdd");

		// ctf events
		callback.add(CallbackMsgCTFFlagDropped,		"PowPop.handleFlagDropped");
		callback.add(CallbackMsgCTFFlagTaken,		"PowPop.handleFlagTaken");
		callback.add(CallbackMsgCTFFlagReturned,	"PowPop.handleFlagReturned");
		callback.add(CallbackMsgCTFFlagCapped,		"PowPop.handleFlagCap");

		%this.buildHud();
		
		%this.setup = true;
	}

	function PowPop::buildOptions(%this)
	{
		exec("gui/PowPopGui.gui");

		PowPopGui.setRGB("Title");

		mnuPowPopFontFace.setActive(false);
	}
	
	function PowPop::buildHud(%this)
	{
		if(isObject(PowPopHud))
			PowPopHud.delete();

		new GuiControlProfile("PowPopHudText")
		{
			fontType = "Verdana";
			fontSize = 14;
			fontColor = "255 255 255";
			justify = "center";
			fontColors[0] = %this.color[Title];
			fontColors[1] = %this.color[Cat];
			fontColors[2] = %this.color[Info];
			fontColors[6] = $PlayerNameColor;
			fontColors[7] = $TribeTagColor;
			fontColors[8] = $SmurfNameColor;
			fontColors[9] = $BotNameColor;
		};

		new GuiControl(PowPopHud)
		{
			profile = "GuiDefaultProfile";
			horizSizing = "center";
			vertSizing = "bottom";
			extent = "240 70";
			minExtent = "8 8";
			visible = "0";
			hideCursor = "0";
			bypassHideCursor = "0";
			helpTag = "0";

			new ShellFieldCtrl(PowPopHudBG)
			{
				profile = "GuiChatBackProfile";
				horizSizing = "center";
				vertSizing = "center";
				position = "0 0";
				extent = "240 70";
				minExtent = "8 8";
				visible = "1";
				setFirstResponder = "0";
			};
			new GuiMLTextCtrl(PowPopHudText)
			{
				profile = "PowPopHudText";
				horizSizing = "center";
				vertSizing = "bottom";
				position = "5 5";
				extent = "230 60";
				minExtent = "8 8";
				visible = "1";
				helpTag = "0";
				lineSpacing = "0";
				allowColorChars = "1";
				maxChars = "-1";
			};
		};

		if($hudPos[PowPopHud] $= "")
		{
			%xpos = mFloor(getWord($pref::video::resolution, 0) / 2) - mFloor(getWord(PowPopHud.extent, 0) / 2);
			%ypos = getWord($pref::video::resolution, 1) * 0.65;

			PowPopHud.position = %xpos SPC %ypos;
		}

		PowPopHudBG.setVisible(!%this.transPop);
		
		PlayGui.add(PowPopHud);
	}

	function PowPopGui::setRGB(%this, %sel)
	{
		if(%this.tab !$= "")
			%this.tab.setValue(false);

		%this.sel = %sel;
		%this.tab = "tabPowPop" @ %sel @ "Text";
		%this.tab.setValue(true);

		sldPowPopRed.setValue(getWord(PowPop.color[%this.sel], 0));
		sldPowPopGreen.setValue(getWord(PowPop.color[%this.sel], 1));
		sldPowPopBlue.setValue(getWord(PowPop.color[%this.sel], 2));
	}

	function PowPopGui::saveRGB(%this)
	{
		%r = mFloor(sldPowPopRed.getValue());
		%g = mFloor(sldPowPopGreen.getValue());
		%b = mFloor(sldPowPopBlue.getValue());

		PowPop.color[%this.sel] = %r SPC %g SPC %b;
	}

	function PowPopGui::updateRGB(%this)
	{
		%r = mFloor(sldPowPopRed.getValue());
		%g = mFloor(sldPowPopGreen.getValue());
		%b = mFloor(sldPowPopBlue.getValue());

		PowPopColorPreview.fillColor = (%r / 255) SPC (%g / 255) SPC (%b / 255);
		canvas.repaint();
	}

	function PowPop::queue(%this)
	{
		%deltaTime = getSimTime() - %this.lastTime;
		%this.queueNum++;
		%this.queueTime += mFloor((%this.displayTime / %this.queueNum) - %deltaTime);
		if(%this.queueTime < 0)
		{
			%this.queueTime = 0;
			%this.queueNum = 0;
		}
		%this.lastTime = getSimTime();
		return %this.queueTime;
	}

	function PowPop::display(%this, %text, %lines)
	{
		PowPopHudText.setText("<just:center>" @ %text);
		%width = getWord(PowPopHud.extent, 0);
		%height = %lines * 15 + 10;
		PowPopHudBG.extent = %width SPC %height;
		PowPopHud.extent = %width SPC %height;
		PowPopHud.setVisible(true);

		if(isEventPending(%this.scheduleId))
			cancel(%this.scheduleId);

		%this.scheduleId = PowPopHud.schedule(%this.hudTimeOut, setVisible, false);
	}

	function PowPop::setDefaults(%this)
	{
		%this.transPop = true;
		%this.doKillsDeaths = true;
		%this.doFlagEvents = true;
		%this.doRepKits = true;
		%this.hudTimeOut = 5000;

		%this.color[Title] = "255 255 255";
		%this.color[Cat] = "50 150 255";
		%this.color[Info] = "180 180 180";

		%this.setPrefs();
		%this.buildHud();
	}

	function PowPop::setPrefs(%this)
	{
		tglPowPopTransPop.setValue(%this.transPop);
		tglPowPopKillsDeaths.setValue(%this.doKillsDeaths);
		tglPowPopFlagEvents.setValue(%this.doFlagEvents);
		tglPowPopRepKits.setValue(%this.doRepKits);
	}
	
	function PowPop::savePrefs(%this)
	{
		%this.file = new FileObject();
		%this.file.openForWrite("prefs/PowPopPrefs.cs");
		%this.file.writeline("// PowPop Prefs - version: "	@ %this.version);
		%this.file.writeline(%this @ ".transPop = "			@ %this.transPop @ ";");
		%this.file.writeline(%this @ ".doKillsDeaths = "	@ %this.doKillsDeaths @ ";");
		%this.file.writeline(%this @ ".doFlagEvents = "		@ %this.doFlagEvents @ ";");
		%this.file.writeline(%this @ ".doRepKits = "		@ %this.doRepKits @ ";");
		%this.file.writeline(%this @ ".hudTimeOut = "		@ %this.hudTimeOut @ ";");
		%this.file.writeline(%this @ ".color[Title] = \""	@ %this.color[Title] @ "\";");
		%this.file.writeline(%this @ ".color[Cat] = \""		@ %this.color[Cat] @ "\";");
		%this.file.writeline(%this @ ".color[Info] = \""	@ %this.color[Info] @ "\";");
		%this.file.close();
		%this.file.delete();
	}

	function LoadingGui::onWake(%this)
	{
		parent::onWake(%this);

		// labrat's hudmover support
		if(isObject(HM) && isObject(HudMover))
			hudmover::addhud(PowPopHud,"PowPop Pop-up");
	}

	function quit()
	{
		PowPop.savePrefs();

		parent::quit();
	}

// END package PowPop
};
activatePackage(PowPop);

PowPop.setup();