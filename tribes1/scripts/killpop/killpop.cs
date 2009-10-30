// Name: KillPop
// By: PowdaHound
// Date: 2-2-01
// Installing: add the line:
// 	exec("killpop.cs");
// to your autoexec.cs at the very end.

$powda::time =  5; //Change this to change the duration of the popups.

Include("Presto\\Event.cs");
Include("Presto\\TeamTrak.cs");

Event::Attach(eventKillTrak, powda::onDeath);

function powda::onDeath(%killer, %victim, %weapon) {

	%me = getManagerID();
	%sKiller = Client::getName(%killer);
	%sVictim = Client::getName(%victim);

	if( %victim == %me && %weapon == "Suicide" ) {
		remoteBP(2048, "<JC><F1>You killed yourself.", $powda::time); // SUCIDE
	} else if( %victim == %me && %weapon == "Team Kill" ) {
		remoteBP(2048, "<JC><F1>You were team killed by <f2>"@%sKiller, $powda::time); // ME IS TKED
	} else if( %victim == %me && %weapon == "Turret" ) {
		remoteBP(2048, "<JC><F1>You were killed by a turret.", $powda::time); // TURRET OWNED
	} else if( %killer == %me && %weapon == "Team Kill" ) {
		remoteBP(2048, "<JC><F1>You team killed <F2>"@%sVictim, $powda::time); // ME TKS
	} else if( %victim == %me ) {
		remoteBP(2048, "<JC><F2>"@%sKiller@"<F1> killed you with their <f2>"@%weapon, $powda::time); // ME IS OWNED
	} else if( %killer == %me ) {
		remoteBP(2048, "<JC><F1>You killed <f2>"@%sVictim@"<f1> with your <f2>"@%weapon, $powda::time); // ME IS OWNING
	}
}