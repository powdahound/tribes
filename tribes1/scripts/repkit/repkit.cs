//- Auto-Buy 6 Repair Kits on Station Enter
//- By PowdaHound
//- Just add: 
//-  exec("repkit.cs"); 
//- to your autoexec!
//---------------------------------------------
$powda::RepKitsToBuy = 6;

Event::Attach(eventEnterStation, "powda::BuyRepKits();");

function powda::BuyRepKits()
{
for (%i = 0; %i < $powda::RepKitsToBuy; %i++)
{
remoteEval(2048, useItem, 39);
remoteEval(2048, buyItem, 39);

}
}
//---------------------------------------------------- 