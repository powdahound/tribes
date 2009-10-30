// Name: LlamaJump
// By: PowdaHound
// Date: 2-3-01
// For: {VV}Gomez
// Installing: add the line:
// 	exec("llamajump.cs");
// to your autoexec.cs at the very end.

EditActionMap("playMap.sae");

bindCommand(keyboard0, make, shift, "space", TO, "discjump();"); // Set this to whatever you want.

// Tables
$WeaponRealName[Blaster] = "Blaster";
$WeaponRealName[PlasmaGun] = "Plasma Gun";
$WeaponRealName[Chaingun] = "Chaingun";
$WeaponRealName[DiscLauncher] = "Disc Launcher";
$WeaponRealName[GrenadeLauncher] = "Grenade Launcher";
$WeaponRealName[Mortar] = "Mortar";
$WeaponRealName[LaserRifle] = "Laser Rifle";
$WeaponRealName[EnergyRifle] = "ELF gun";
$WeaponRealName[TargetingLaser] = "Targeting Laser";

$Ammo[Blaster] = "";
$Ammo[Chaingun] = "Bullet";
$Ammo[PlasmaGun] = "Plasma Bolt";
$Ammo[GrenadeLauncher] = "GrenadeAmmo";
$Ammo[Mortar] = "MortarAmmo";
$Ammo[DiscLauncher] = "Disc";
$Ammo[TargetingLaser] = "";
$Ammo[EnergyRifle] = "";

$WeaponSlot[11] = "Blaster";
$WeaponSlot[13] = "Chaingun";
$WeaponSlot[15] = "PlasmaGun";
$WeaponSlot[17] = "GrenadeLauncher";
$WeaponSlot[19] = "Mortar";
$WeaponSlot[21] = "DiscLauncher";
$WeaponSlot[23] = "TargetingLaser";
$WeaponSlot[24] = "EnergyRifle";

$BackpackSlot[27] = "InventoryStation";
$BackpackSlot[28] = "AmmoStation";
$BackpackSlot[29] = "EnergyPack";
$BackpackSlot[30] = "RepairPack";
$BackpackSlot[31] = "ShieldPack";
$BackpackSlot[32] = "SensorJammerPack";
$BackpackSlot[33] = "MotionSensor";
$BackpackSlot[34] = "AmmoPack";
$BackpackSlot[35] = "PulseSensor";
$BackpackSlot[36] = "SensorJammer";
$BackpackSlot[37] = "Camera";
$BackpackSlot[38] = "Turret";

function discjump()
{
	%old = $WeaponSlot[getMountedItem(0)];

    if(getItemCount("Disc Launcher"))
	{
		if(getItemCount("Disc"))
		{	
    			%lagdelay = 0.06;
    			if($WeaponSlot[getMountedItem(0)] == "DiscLauncher") 
    			{ 
    				%timedelay = 0;
    			}
    			else 
    			{ 
    				%timedelay = 0.5;
    				schedule("use(\"Disc Launcher\");", 0.1);
    			}
    			schedule("postAction(2048, IDACTION_LOOKDOWN, 1);", 0.0 + %timedelay + %lagdelay);
    			schedule("postAction(2048, IDACTION_MOVEUP, -0);", 0.1 + %timedelay + %lagdelay);
    			schedule("postAction(2048, IDACTION_FIRE1, -0);", 0.2 + %timedelay + %lagdelay);
			schedule("postAction(2048, IDACTION_JET, 1.0);",0.3 + %timedelay + %lagdelay);
    			schedule("postAction(2048, IDACTION_BREAK1, -0);", 0.3 + %timedelay + %lagdelay);
    			schedule("postAction(2048, IDACTION_LOOKDOWN, -0);", 0.4 + %timedelay + %lagdelay);
    			schedule("postAction(2048, IDACTION_CENTERVIEW, -0);", 0.5 + %timedelay + %lagdelay);
    			schedule("use($WeaponRealName[%old]);", 1.1 + %timedelay + %lagdelay);
//			schedule("postAction(2048, IDACTION_JET, 0.0);",0.3 + %timedelay + %lagdelay);
    		}
    		else
		{
			Client::centerPrint("You don't have any discs j00 llama", 1); 
    		schedule("Client::centerPrint(\"\", 1);", 3);
		}
	}
	else 
	{ 
			Client::centerPrint("How are you gonna discjump without a disc launcher?", 1); 
			schedule("Client::centerPrint(\"\", 1);", 3);
	}
} 