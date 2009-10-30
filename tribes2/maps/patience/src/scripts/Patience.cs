// don't want this executing when building graphs
if($OFFLINE_NAV_BUILD)
   return;

echo(".....Running Patience script!");

//Script for Patience
//===================================================================================


// package and callbacks
activatePackage(Patience);

// Mission Variables

game.LavaGen = nameToId("LavaGen");
game.LavaPoolID = nameToID("LavaPool");
game.OriginalScale = game.LavaPoolID.Scale;

package Patience {
//=======================================================================

   function Generator::onDisabled(%data, %obj, %prevState)
   {
      %obj.decPowerCount();

      if (%obj == game.LavaGen)
         game.PowerIsUp = "0";
      Parent::onDisabled(%data, %obj, %prevState);
   }

   function Generator::onEnabled(%data, %obj, %prevState)
   {
      %obj.incPowerCount();
      

      if (%obj == game.LavaGen)
         game.PowerIsUp = "1";
      Parent::onEnabled(%data, %obj, %prevState);
   }  

   function SiegeGame::gameOver(%game)
   {
      cancel(game.PatienceSched);

      //call the default
      DefaultGame::gameOver(%game);

      cancel(%game.timeThread);
      messageAll('MsgClearObjHud', "");
   }




};

//End Patience Package


   function HalfTimeResetCheck(%game)
   {
      if (game.firstHalf == 1)  //If it's the First Half, schedule another check in 1 second.
         schedule (1000, 0 , HalfTimeResetCheck, %game);  
      else  //If it is not the FirstHalf (2nd half), then set original variable, and resize the lava, then return.
      {
        //reset lava pool
        game.PowerIsUp = "1";
        ReSizeWater(nameToID("LavaPool"), game.OriginalScale);
        return 0;
      }  
   }


//The following functions were taken from "Polar Dip", by [HvC]Scuba and [HvC]Dev.  Much thanks, Scuba and Dev.

   function AdjustWaterLevel(%Water)
   {
      // If the Object you specified to increase in size is not water, just
      // note that in the console and log and quit
      if (%Water.getType() != 16)
      {
         logEcho("Attempting to raise/lower water level on non-water object.");
         Echo("Attempting to raise/lower water level on non-water object.");
      return;
      }

      %Water.Locked = true;
   
      game.PatienceSched = Schedule(1000, 0, SizeWater, %Water);
   }

   function ReSizeWater(%Water, %OriginalScale)
   {

      %Water.Scale = %OriginalScale;
      %Water.setTransform(%Water.getTransform());
      game.halftimeresized = 1;
   }


   function SizeWater(%Water)
   {
      if (game.powerIsUp == "1")
      {
         AdjustWaterLevel(%Water);
         return;
      }
      else
      {
         %ScaleXY = getWords(%Water.Scale, 0, 1);
         %ScaleZ = getWord(%Water.Scale, 2) - 0.13333;
   
         %Water.Scale = %ScaleXY @ " " @ %ScaleZ;
   
         // Just needed to cause a refresh
         %Water.setTransform(%Water.getTransform());
         AdjustWaterLevel(%Water);
      }
   }

