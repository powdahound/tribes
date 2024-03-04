// Script: capdrop.cs
// Author: powdahound
// Website: http://hosted.tribalwar.com/powdahound
// Email: powdahound@gamer-insight.com
// Date: 3/09/01
// Function: Binds a key to drop a mass of things. The main
//   purpose is to unload mines/ammo/etc before you go for
//   the flag so the LD don't get your stuff. :)
// Comments: DOES NOT NEED PRESTO!


//
// preferences
//
bindCommand(keyboard0, make, "3", TO, "powda::capdrop();");		// set drop key
$powda::announcemsg = 0;										// announce to team: 1 for yes, 0 for no

//
// main function
//
function powda::capdrop()
{
	// In the following function calls, the number inside the parentheses is the ammount of the item to drop.
	// ex: powda::drop("Item", 3) would drop 3 of "Item".
	
	// Items to drop
    powda::drop("Mine",			3);
    powda::drop("Beacon",		3);
    powda::drop("Grenade",		0);
    powda::drop("Repair Kit",	0);   // for those of you super l33t who don't need a repair kit :P

    // Ammo to drop (not always in single quantities. ex: you can't drop 1 chain bullet, only 1 pack)
    powda::drop("Bullet",		10);	// chaingun ammo
    powda::drop("Disc",			0);		// disc ammo
    powda::drop("Plasma Bolt",	10);	// plasma ammo
    powda::drop("Grenade Ammo",	0);		// grenade ammo
    powda::drop("Mortar Ammo",	10);	// mortar ammo
    
    // Weapons to drop
    powda::drop("Laser Rifle",	1);
    powda::drop("Blaster",		1);
    powda::drop("ELF Gun",		1);
    powda::drop("Plasma Gun",	1);
    
    use("Disc Launcher");

	// announce message below
	if ($powda::announcemsg == 1)
		say(1, "I have just dropped supplies that I don't need for capping! ~wovrhere");
}

//
// simple drop items function
//
function powda::drop(%item, %times)
{
    for (%i = 0; %i < %times; %i++)
        drop(%item);
}
