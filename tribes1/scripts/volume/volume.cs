// Name: Volume Control
// By: PowdaHound
// Date: 1-30-01
// Installing: add the line:
// 	exec("volume.cs");
// to your autoexec.cs at the very end.

EditActionMap("playMap.sae");
bindCommand(keyboard0, make, shift, "v", TO, "powda::next();");  // Volume toggle key bind, Change this to whatever you like.

$powda::Option[0] = "0%";
$powda::Option[1] = "10%";
$powda::Option[2] = "20%";
$powda::Option[3] = "30%";
$powda::Option[4] = "40%";
$powda::Option[5] = "50%";
$powda::Option[6] = "60%";
$powda::Option[7] = "70%";
$powda::Option[8] = "80%";
$powda::Option[9] = "90%";
$powda::Option[10] = "100%";
	
$powda::maxitem = 10;
$powda::current = 0;
$powda::maxvol = 1;
$powda::volume = 0;

$powda::item = $powda::Option[$powda::current];

function powda::next()
{
	$powda::current++;
	if($powda::current > $powda::maxitem)
	$powda::current = 0;
	$powda::item = $powda::Option[$powda::current];
	remoteBP(2048, "<jc><L5>Volume set to: <f2>" @ $powda::item, 5);
	$pref::sfx3dVolume = $powda::current/10;
	$pref::sfx2dVolume = $powda::current/10;
}


// Script by PowdaHound
// Use it in any pack if you want but just mention me