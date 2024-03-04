// Script: Yap.cs
// Author: powdahound
// Website: http://powda.tribes2.org
// Email: powdahound@nitrousonline.net
// Date: 8-12-02
// Function: Different things you can say. ;)
// Comments: ___Needs___ Presto :(

Include("Presto\\Menu.cs");

EditActionMap("playMap.sae");
bindCommand(keyboard0, make, "4", TO, "Menu::Display(menuYap);");

// main menu
Menu::New(menuYap, "Yap menu:");
	Menu::AddMenu(menuYap, "dDance", menuDance);
	Menu::AddMenu(menuYap, "sShazbot", menuShaz);
	Menu::AddMenu(menuYap, "1Fidelio 1", menuTaunts1);
	Menu::AddMenu(menuYap, "2Fidelio 2", menuTaunts2);
	Menu::AddMenu(menuYap, "3Fidelio 3", menuTaunts3);
	Menu::AddMenu(menuYap, "4Fidelio 4", menuTaunts4);

Menu::New(menuDance, "Yap menu: Dance!");
	Menu::AddChoice(menuDance, "hCome get some dance over here!", "yap::come_here(\"taunt3\");");
	Menu::AddChoice(menuDance, "dGo on the dance!", "yap::go_dance();");
	Menu::AddChoice(menuDance, "cCan anyone bring me some dance!", "yap::bring_me(\"taunt3\");");
	Menu::AddChoice(menuDance, "nI need dance!", "yap::i_need(\"taunt3\");");
	Menu::AddChoice(menuDance, "wWe need more dance!", "yap::we_need(\"taunt3\");");
	Menu::AddChoice(menuDance, "gHit the dance!", "yap::hit_the(\"taunt3\");");
	Menu::AddChoice(menuDance, "rHurry up with that dance!", "yap::hurry_up(\"taunt3\");");
	Menu::AddChoice(menuDance, "iI've had dance!", "yap::ive_had(\"taunt3\");");
	Menu::AddChoice(menuDance, "tWatch where you dance!", "yap::watch_dance();");
	Menu::AddChoice(menuDance, "qWait for my signal to dance!", "yap::wait_dance();");
	Menu::AddChoice(menuDance, "eDestroy the enemy dance!", "yap::destroy_enemy(\"taunt3\");");
	Menu::AddChoice(menuDance, "aAPC waiting for dance!", "yap::apc(\"taunt3\");");
	Menu::AddChoice(menuDance, "fIncoming dance!", "yap::incoming(\"taunt3\");");
	Menu::AddChoice(menuDance, "vThe enemy is attacking our dance!", "yap::enemy_attack(\"taunt3\");");
	Menu::AddChoice(menuDance, "sDeploy dance over here!!", "yap::deploy(\"taunt3\");");
	Menu::AddChoice(menuDance, "bWe need more dance defending our base!", "yap::defending(\"taunt3\");");

Menu::New(menuShaz, "Yap menu: Shzabot!");
	Menu::AddChoice(menuShaz, "hCome get some shazbot over here!", "yap::come_here(\"color2\");");
	Menu::AddChoice(menuShaz, "cCan anyone bring me some shazbot!", "yap::bring_me(\"color2\");");
	Menu::AddChoice(menuShaz, "nI need shazbot!", "yap::i_need(\"color2\");");
	Menu::AddChoice(menuShaz, "wWe need more shazbot!", "yap::we_need(\"color2\");");
	Menu::AddChoice(menuShaz, "gHit the shazbot!", "yap::hit_the(\"color2\");");
	Menu::AddChoice(menuShaz, "rHurry up with that shazbot!", "yap::hurry_up(\"color2\");");
	Menu::AddChoice(menuShaz, "iI've had shazbot!", "yap::ive_had(\"color2\");");
	Menu::AddChoice(menuShaz, "eDestroy the enemy shazbot!", "yap::destroy_enemy(\"color2\");");
	Menu::AddChoice(menuShaz, "aAPC waiting for shazbot!", "yap::apc(\"color2\");");
	Menu::AddChoice(menuShaz, "fIncoming shazbot!", "yap::incoming(\"color2\");");
	Menu::AddChoice(menuShaz, "vThe enemy is attacking our shazbot!", "yap::enemy_attack(\"color2\");");
	Menu::AddChoice(menuShaz, "sDeploy shazbot over here!!", "yap::deploy(\"color2\");");
	Menu::AddChoice(menuShaz, "bWe need more shazbot defending our base!", "yap::defending(\"color2\");");

Menu::New(menuTaunts1, "Fidelio 1: Local Taunts");
	Menu::AddLetter(menuTaunts1, "a", "Sorry unable to dance.", "sutcad();");
	Menu::AddLetter(menuTaunts1, "b", "Come shit over here.", "csoh();");
	Menu::AddLetter(menuTaunts1, "c", "Hey you shit over here, damnit.", "hysohd();");
	Menu::AddLetter(menuTaunts1, "d", "Can anyone fire on my dance?", "cafomd();");
	Menu::AddLetter(menuTaunts1, "e", "We need more APC waiting, yeah!", "wnmawy();");
	Menu::AddLetter(menuTaunts1, "f", "Hey wait!", "hw();");
	Menu::AddLetter(menuTaunts1, "g", "Deploy Turret over here.", "drtoh();");
	Menu::AddLetter(menuTaunts1, "t", "Shit Yeah!", "shityeah();");
	Menu::AddLetter(menuTaunts1, "r", "Is our Shazbot ready?", "iosr();");

Menu::New(menuTaunts2, "Fidelio 2: Local Taunts");
	Menu::AddLetter(menuTaunts2, "a", "Oh Shazbot", "os();");
	Menu::AddLetter(menuTaunts2, "b", "Oh shit, sorry!", "oss();");
	Menu::AddLetter(menuTaunts2, "c", "I know no problem.", "iknp();");
	Menu::AddLetter(menuTaunts2, "d", "The enemy is no problem.", "teinp();");
	Menu::AddLetter(menuTaunts2, "e", "You need help!", "ynh();");
	Menu::AddLetter(menuTaunts2, "f", "Fart....", "fart();");
	Menu::AddLetter(menuTaunts2, "g", "Hey I have the oops.", "hihto();");
	Menu::AddLetter(menuTaunts2, "t", "I have no dough!", "ihnd();");
	Menu::AddLetter(menuTaunts2, "r", "Can anyone go over here?", "cagoh();");

Menu::New(menuTaunts3, "Fidelio 3: Local Taunts");
	Menu::AddLetter(menuTaunts3, "a", "Wait for my signal to proceed ahead!", "wfmstpa();");
	Menu::AddLetter(menuTaunts3, "b", "Wait for my signal to deploy beacon!", "wfmstdb();");
	Menu::AddLetter(menuTaunts3, "c", "Can you destroy enemy, I don't know?", "cydeidk();");
	Menu::AddLetter(menuTaunts3, "d", "Go on, hurry up, can anyone Dance?!", "gohucd();");
	Menu::AddLetter(menuTaunts3, "e", "Can anyone help you dance?", "cahyd();");
	Menu::AddLetter(menuTaunts3, "f", "Can you take dance help?", "cytdh();");
	Menu::AddLetter(menuTaunts3, "g", "You need dance help!", "yndh();");
	Menu::AddLetter(menuTaunts3, "t", "Yeah you can dance alright!", "yycda();");
	Menu::AddLetter(menuTaunts3, "r", "Can anyone deploy motion sensor dance?", "cadmsd();");

Menu::New(menuTaunts4, "Fidelio 4: Local Taunts");
	Menu::AddLetter(menuTaunts4, "a", "Repair our base damnit!", "robd();");
	Menu::AddLetter(menuTaunts4, "b", "Unable to ackowledge objective, sorry.", "utaos();");
	Menu::AddLetter(menuTaunts4, "c", "I need a dance!", "inad();");
	Menu::AddLetter(menuTaunts4, "d", "The mines have been defending our base.", "tmhbdob();");
	Menu::AddLetter(menuTaunts4, "e", "Come get our flag over here!", "cgofoh();");
	Menu::AddLetter(menuTaunts4, "f", "Is our base going offense?", "iobgo();");
	Menu::AddLetter(menuTaunts4, "g", "Sorry, I don't defend our base.", "siddob();");
	Menu::AddLetter(menuTaunts4, "t", "I have the enemy flag, sorry you missed me!", "ihtefsymm();");
	Menu::AddLetter(menuTaunts4, "r", "No I don't miss-fire damnit!", "nidmfd();");

function yap::defending(%word)
{
	schedule::add("localMessage(needdef);",0);		// we need more
	schedule::add("localMessage("@%word@");",0.83);		 
	schedule::add("localMessage(defend);",1.4);		// definding our base
}

function yap::deploy(%word)
{
	schedule::add("localMessage(wshoot1);",0.00);	//hey
	schedule::add("localMessage(dsgst2);",0.30);	//you
	schedule::add("localMessage(taunt4);",0.60);	//come
	schedule::add("localMessage(depcam);",0.90);	//deploy 
	schedule::add("localMessage("@%word@");",1.3);	//dance
	schedule::add("localMessage(ovrhere);",1.90);	//over here
}

function yap::come_here(%word)	// by somebody else, can't remember who, sorry!
{
	remoteEval(2048,playAnimWav,"1", wshoot1);		//hey
	schedule::add("localMessage(dsgst2);",0.50);	//you
	schedule::add("anim1();",0.95);					//come get some
	schedule::add("localMessage("@%word@");",1.60);	//dance 
	schedule::add("localMessage(ovrhere);",2.30);	//over here
	schedule::add("anim2();", 3.30);				//karate
	schedule::add("anim3();", 6.50);
	schedule::add("anim4();", 10.00);
	schedule::add("anim5();", 12.69);
	schedule::add("anim6();", 17.00);

	function anim1(){ remoteEval(2048,playAnimWav,"6", taunt4); }
	function anim2(){ remoteEval(2048,playAnimWav,"8", karate); }
	function anim3(){ remoteEval(2048,playAnimWav,"9", ""); }
	function anim4(){ remoteEval(2048,playAnimWav,"7", ""); }
	function anim5(){ remoteEval(2048,playAnimWav,"5", ""); }
	function anim6(){ remoteEval(2048,playAnimWav,"3", ""); }
}

function yap::go_dance()
{
	schedule::add("localMessage(godef);",0);	// go on the 
	schedule::add("localMessage(taunt3);",0.5);	 
}

function yap::wait_dance()
{
	schedule::add("localMessage(waitsig);",0);	// wait for my signal
	schedule::add("localMessage(taunt3);",1.1);	 
}

function yap::watch_dance()
{
	schedule::add("localMessage(wshoot3);",0);	// watch where you 
	schedule::add("localMessage(taunt3);",0.72);	 
}

function yap::hit_the(%word)
{
	schedule::add("localMessage(hitdeck);",0);	// hit the 
	schedule::add("localMessage("@%word@");",0.5);	 
}

function yap::hurry_up(%word)
{
	schedule::add("localMessage(hurystn);",0);	// hurry up with that
	schedule::add("localMessage("@%word@");",0.9);	 
}

function yap::i_need(%word)
{
	schedule::add("localMessage(needpku);",0);		// I need 
	schedule::add("localMessage("@%word@");",0.35);	 
}

function yap::ive_had(%word)
{
	schedule::add("localMessage(tautn11);",0);		// I need 
	schedule::add("localMessage("@%word@");",0.6);	 
}

function yap::bring_me(%word)
{
	schedule::add("localMessage(needamo);",0);		// can anyone bring me some
	schedule::add("localMessage("@%word@");",1.15);	 
}

function yap::we_need(%word)
{
	schedule::add("localMessage(needdef);",0);		// we need more
	schedule::add("localMessage("@%word@");",0.83);		 
}

function yap::destroy_enemy(%word)
{
	schedule::add("localMessage(desgen);",0);	// hit the 
	schedule::add("localMessage("@%word@");",1.1);	 
}

function yap::apc(%word)
{
	schedule::add("localMessage(waitpas);",0);		// apc ready to go, waiting for...
	schedule::add("localMessage("@%word@");",2.0); 
}

function yap::incoming(%word)
{
	schedule::add("localMessage(incom2);",0);		// incoming...
	schedule::add("localMessage("@%word@");",0.65); 
}

function yap::enemy_attack(%word)
{
	schedule::add("localMessage(basundr);",0);		// incoming...
	schedule::add("localMessage("@%word@");",1.5); 
}


// FROM Miles O'Fidelio -------------------------------------------------->
//_________________________The Taunts Fun-Code____________________________//

//____________ Shit yeah.
function shityeah()
{
schedule::add("localMessage(color2);",0.1);
schedule::add("localMessage(hitdeck);",0.35);
schedule::add("localMessage(cheer1);",0.55);
//Schedule::Cancel(shityeah);
}

//____________ Is our shabot ready?
function iosr()
{
schedule::add("localMessage(isbsclr);",0.1);
schedule::add("localMessage(color2);",0.5);
schedule::add("localMessage(ready);",1.26);
//Schedule::Cancel(iosr);
}

//____________ I have no doh!
function ihnd()
{
schedule::add("localMessage(haveflg);",0.1);
schedule::add("localMessage(no);",0.45);
schedule::add("localMessage(oops1);",0.8);
//Schedule::Cancel(ihnd);
}

//____________ Can anyone go over here?
function cagoh()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(gooff);",0.8);
schedule::add("localMessage(ovrhere);",1.1);
//Schedule::Cancel(cagoh);
}

//____________ Sorry, unable to complete a dance.
function sutcad()
{
schedule::add("localMessage(sorry);",0.1);
schedule::add("localMessage(objxcmp);",0.65);
schedule::add("localMessage(taunt3);",1.43);
//Schedule::Cancel(sutcad);
}

//____________ Come shit over here
function csoh()
{
schedule::add("localMessage(taunt4);",0.1);
schedule::add("localMessage(color2);",0.55);
schedule::add("localMessage(hitdeck);",0.82);
schedule::add("localMessage(ovrhere);",0.98);
//Schedule::Cancel(csoh);
}

//____________ Hey you shit over here damnit
function hysohd()
{
schedule::add("localMessage(wshoot1);",0.1);
schedule::add("localMessage(dsgst2);",0.7);
schedule::add("localMessage(color2);",1);
schedule::add("localMessage(hitdeck);",1.25);
schedule::add("localMessage(ovrhere);",1.45);
schedule::add("localMessage(color6);",2.5);
//Schedule::Cancel(hysohd);
}

//____________ Can anyone fire on my dance
function cafomd()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(firetgt);",0.8);
schedule::add("localMessage(taunt3);",1.85);
//Schedule::Cancel(cafomd);
}

//____________ We need more APC waiting over here
function wnmawy()
{
schedule::add("localMessage(needdef);",0.1);
schedule::add("localMessage(waitpas);",1.2);
schedule::add("localMessage(wait2);",1.85);
schedule::add("localMessage(cheer1);",2.4);
//Schedule::Cancel(wnmawy);
}

//____________ Hey wait
function hw()
{
schedule::add("localMessage(wshoot1);",0.1);
schedule::add("localMessage(wait1);",0.6);
//Schedule::Cancel(hw);
}

//____________ Deploy remote turret over here
function drtoh()
{
schedule::add("localMessage(deptur);",0.1);
schedule::add("localMessage(ovrhere);",1.15);
//Schedule::Cancel(drtoh);
}

//____________oh shazbot
function os()
{
schedule::add("localMessage(ovrhere);",0.1);
schedule::add("localMessage(color2);",0.35);
//Schedule::Cancel(os);
}

//____________Oh shit sorry
function oss()
{
schedule::add("localMessage(ovrhere);",0.1);
schedule::add("localMessage(color2);",0.35);
schedule::add("localMessage(hitdeck);",0.55);
schedule::add("localMessage(sorry);",0.75);
//Schedule::Cancel(oss);
}

//____________I know no problem
function iknp()
{
schedule::add("localMessage(dontkno);",0.1);
schedule::add("localMessage(no);",0.35);
schedule::add("localMessage(noprob);",0.8);
//Schedule::Cancel(iknp);
}

//____________The enemy is no problem.
function teinp()
{
schedule::add("localMessage(basundr);",0.1);
schedule::add("localMessage(isbsclr);",0.61);
schedule::add("localMessage(noprob);",0.74);
//Schedule::Cancel(teinp);
}

//____________You need help
function ynh()
{
schedule::add("localMessage(dsgst2);",0.1);
schedule::add("localMessage(needrep);",0.4);
schedule::add("localMessage(help);",0.7);
//Schedule::Cancel(ynh);
}

//____________Hey I have thier oops (strange)
function hihto()
{
schedule::add("localMessage(watchsh);",0.1);
schedule::add("localMessage(offflg);",0.4);
schedule::add("localMessage(oops);",0.8);
//Schedule::Cancel(hihto);
}

//____________farts
function fart()
{
schedule::add("localMessage(ind2);",0.1);
schedule::add("localMessage(dsgst5);",3.7);
//Schedule::Cancel(fart);
}

//____________Wait for my signal to proceed ahead
function wfmstpa()
{
schedule::add("localMessage(waitsig);",0.1);
schedule::add("localMessage(proceed);",1.25);
//Schedule::Cancel(wfmstpa);
}

//____________Wait for my signal to deploy beacon
function wfmstdb()
{
schedule::add("localMessage(waitsig);",0.1);
schedule::add("localMessage(depbecn);",1.2);
//Schedule::Cancel(wfmstdb);
}

//____________Can you destroy enemy, I don't know.
function	cydeidk()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(dsgst2);",0.33);
schedule::add("localMessage(destur);",0.7);
schedule::add("localMessage(dontkno);",1.7);
//Schedule::Cancel(cydeidk);
}

//____________Go on, hurry up, can anyone Dance?!
function gohucd()
{
schedule::add("localMessage(gooff);",0.1);
schedule::add("localMessage(hurystn);",0.5);
schedule::add("localMessage(needamo);",1);
schedule::add("localMessage(taunt3);",1.65);
//Schedule::Cancel(gohucd);
}

//____________Can anyone help you dance?
function cahyd()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(help);",0.9);
schedule::add("localMessage(dsgst2);",1.7);
schedule::add("localMessage(taunt3);",2.1);
//Schedule::Cancel(cahyd);
}

//____________Can you take dance help?
function cytdh()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(dsgst2);",0.33);
schedule::add("localMessage(takcovr);",0.7);
schedule::add("localMessage(taunt3);",1.2);
schedule::add("localMessage(help);",1.8);
//Schedule::Cancel(cytdh);
}

//____________You need dance help!
function yndh()
{
schedule::add("localMessage(dsgst2);",0.1);
schedule::add("localMessage(needrep);",0.5);
schedule::add("localMessage(taunt3);",0.8);
schedule::add("localMessage(help);",1.4);
//Schedule::Cancel(yndh);
}

//____________Yeah you can dance alright!
function yycda()
{
schedule::add("localMessage(cheer1);",0.1);
schedule::add("localMessage(dsgst2);",0.65);
schedule::add("localMessage(needamo);",1);
schedule::add("localMessage(taunt3);",1.2);
schedule::add("localMessage(cheer3);",1.7);
//Schedule::Cancel(yycda);
}

//____________Can anyone deploy motion sensor dance?
function cadmsd()
{
schedule::add("localMessage(needamo);",0.1);
schedule::add("localMessage(depmot);",0.9);
schedule::add("localMessage(taunt3);",2.2);
//Schedule::Cancel(cadmsd);
}

//____________Repair our base damnit!
function robd()
{
schedule::add("localMessage(repobj);",0.1);
schedule::add("localMessage(bsclr2);",0.8);
schedule::add("localMessage(color6);",1.35);
//Schedule::Cancel(robd);
}

//____________Unable to ackowledge objective, sorry.
function utaos()
{
schedule::add("localMessage(objxcmp);",0.1);
schedule::add("localMessage(acknow);",0.9);
schedule::add("localMessage(objcomp);",1.6);
schedule::add("localMessage(sorry);",2.15);
//Schedule::Cancel(utaos);
}

//____________I need a dance!
function inad()
{
schedule::add("localMessage(needtgt);",0.1);
schedule::add("localMessage(taunt3);",0.7);
//Schedule::Cancel(inad);
}

//____________The mines have been defending our base.
function tmhbdob()
{
schedule::add("localMessage(flgtkm2);",0.1);
schedule::add("localMessage(mineclr);",0.25);
schedule::add("localMessage(defend);",0.9);
//Schedule::Cancel(tmhbdob);
}

//____________Come get our flag over here!
function cgofoh()
{
schedule::add("localMessage(taunt4);",0.1);
schedule::add("localMessage(flgtkn1);",0.6);
schedule::add("localMessage(ovrhere);",1.3);
//Schedule::Cancel(cgofoh);
}

//____________Is our base going offense?
function iobgo()
{
schedule::add("localMessage(isbsclr);",0.1);
schedule::add("localMessage(ono);",0.9);
//Schedule::Cancel(iobgo);
}

//____________Sorry, I don't defend our base.
function siddob()
{
schedule::add("localMessage(sorry);",0.1);
schedule::add("localMessage(dontkno);",0.7);
schedule::add("localMessage(defbase);",1.3);
//Schedule::Cancel(siddob);
}

//____________I have the enemy flag, sorry you missed me!
function ihtefsymm()
{
schedule::add("localMessage(haveflg);",0.1);
schedule::add("localMessage(sorry);",1.3);
schedule::add("localMessage(dsgst2);",1.9);
schedule::add("localMessage(taunt2);",2.3);
//Schedule::Cancel(ihtefsymm);
}

//____________No I don't miss-fire damnit!
function nidmfd()
{
schedule::add("localMessage(no);",0.1);
schedule::add("localMessage(dontkno);",0.5);
schedule::add("localMessage(taunt2);",1.1);
schedule::add("localMessage(firetgt);",1.4);
schedule::add("localMessage(color6);",1.9);
//Schedule::Cancel(nidmfd);
}
// end fidelio ----------------------------------------<<<
