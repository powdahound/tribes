// Script: PowPoint)stripped.cs
// Author: powdahound
// Website: http://hosted.tribes-universe.com/powdahound
// Email: powdahound@gamer-insight.com
// Date: 11/07/02
// Function: Smart waypointer, here's how it works:
//
// 1. If your mode is "defense"
//    1. If enemy has your flag: waypoint enemy with your flag...
//    2. Otherwise If teammate has flag: waypoint friendly flag carrier...
//    3. Otherwise: waypoint friendly flag stand
// 2. If your mode is "offense"
//    1. If teammate has flag: waypoint friendly flag carrier...
//    2. Otherwise If enemy has your flag: waypoint enemy with your flag...
//    3. Otherwise: waypoint enemy flag stand
// 3. If your mode is "manual"
//    1. If you waypoint friendly:
//       1. If teammate has flag: will waypoint friendly carrier
//       2. Otherwise: will waypoint friendly flag stand
//    2. If you waypoint enemy:
//       1. If enemy has your flag: will waypoint enemy with your flag
//       2. Otherwise: will waypoint enemy flag stand
//
// Credits:	THANKS TO z0dd for letting me use his waypointing script
//			for flag stand waypointing support. also thanks to
//			Superslug for keeping his waypoints current
// Updates:
// [11-7-02]
//   Removed extra info in z0dd_waypoints.cs.
//   Made manual waypoint functions waypoint stands as well as flaggers.

// load z0dds script for support!!!!!!!!!
exec("z0dd_waypoints.cs");
//STRIPPED
// by HotCheese Xyster@phreaker.net
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
// preferences
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
bindcommand(keyboard0, make, alt, "1", TO, "ppt::togglemode();");
bindcommand(keyboard0, make, alt, "f", TO, "ppt::wptFriendly();");
bindcommand(keyboard0, make, alt, "e", TO, "ppt::wptEnemy();");

// this is the mode the script will start out in
// offense is 0, 1 is defense, and 2 is manual
$ppt::current = 0;

// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
// Script Below
// * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
// i think these events are only for presto... not sure though
Event::Attach(eventFlagd, ppt::parse);
Event::Attach(eventFlagCaptured, ppt::parse);

function ppt::parse()
{
  if ($MyTeam == 1)
    %oteam = 0;
  else
    %oteam = 1;
    
	%friendly = $Flag::Status[$MyTeam];
	%enemy = $Flag::Status[%oteam];

	// observers get no waypoints
	if ($MyTeam  == "-1" || $ppt::mode == "manual")
    return;

	// if we're the carrier of the enemy flag we want to waypoint home!
	if (%enemy == client::getname(getManagerId()))
		ppt::wptFlag("friendly");

	else if ($ppt::mode == "defense")
	{
		if (%friendly != "Home" && %friendly != "Dropped")	// waypoint enemy carrier if home flag is taken
			ppt::wptEnemy();
		else if (%enemy != "Home" && %enemy != "Dropped")		// otherwise help the O and escort the friendly carrier
			ppt::wptFriendly();
		else
			ppt::wptFlag("friendly");						// otherwise waypoint our base
	}
	else if ($ppt::mode == "offense")
	{
		if (%enemy != "home" && %enemy != "Dropped")			// waypoint our teammate and help him/her!
			ppt::wptFriendly();
		else if (%friendly != "home" && %friendly != "Dropped")	// otherwise kill the foo with your flag
			ppt::wptEnemy();
		else
			ppt::wptFlag("enemy");							// otherwise help us get to the enemy base, because
															// we haven't been playing t1 long enough to know already ;)
	}
}

function ppt::wptFriendly()
{
  if ($MyTeam == 1)
    %oteam = 0;
  else
    %oteam = 1;

  %taker = $Flag::Status[%oteam];
	%clientId = getClientByName(%taker);

	if (%taker == "Home" || %taker == "")
		ppt::wptFlag("friendly");
	else
	{
		%msg = "ESCORT ---> " @ %taker;// @ "~wescfr";
		remoteEval(2048, "IssueTargCommand", 0, %msg, %clientID - 2048, getManagerId());
	}
}

function ppt::wptEnemy()
{
	%taker = $Flag::Status[$MyTeam];
	%clientId = getClientByName(%taker);

	if (%clientId == getManagerId())
		ppt::wptFlag("friendly");
	else if (%taker == "Home" || %taker == "")
		ppt::wptFlag("enemy");
	else
	{
		%msg = "KILL ---> " @ %taker;// @ "~wattway";
		remoteEval(2048, "IssueTargCommand", 0, %msg, %clientID - 2048, getManagerId());
	}
}

function ppt::wptFlag(%team)
{
	//		 getTeam	z0dd
	// DS:	   1	   1
	// BE:	   0     0
	%side = Client::getTeam(getManagerId());

	if (%team == "friendly")
	{
		%teamStr = "Friendly flag stand.";

		if (%side == 1)
			%wptid = 2;
		else
			%wptid = 1;
	}
	else if (%team == "enemy")
	{
		%teamStr = "Enemy flag stand.";

		if (%side == 1)
			%wptid = 1;
		else
			%wptid = 2;
	}

	//echo("****** Team: "@%team);
	//echo("****** Side: "@%side);
	//echo("****** Index: "@%wptid);

	// thanks z0dd!!!
	remoteEval(2048, "issueCommand", 1, "WP: " @ %teamStr,
	  $z0ddWPs::data[$servermission, %wptid, x],
  	$z0ddWPs::data[$servermission, %wptid, y],
	  getManagerId());
}



// Yes, it looks like MrPoop's code from AutoPoint.
// aren't too many ways to set up a simple task like this :)
$ppt::options[0] = "offense";
$ppt::options[1] = "defense";
$ppt::options[2] = "manual";

$ppt::max = 2;

$ppt::mode = $ppt::options[$ppt::current];

function ppt::togglemode()
{
	$ppt::current++;

	if($ppt::current > $ppt::max)
		$ppt::current = 0;

	$ppt::mode = $ppt::options[$ppt::current];

	remoteCP(2048, "<L5>PowPoint waypoint mode is: <f2>" @ $ppt::mode, 2);
}
