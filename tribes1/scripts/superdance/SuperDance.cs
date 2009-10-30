// Script: SuperDance.cs
// Author: powdahound
// Website: http://hosted.tribes-universe.com/powda
// Email: powdahound@gamer-insight.com
// Date: 6-2-02
// Function: do a random animation ever 5 seconds so you're always dancin!

Event::Attach(eventConnectionAccepted, powda::dance);

function powda::dance()
{
	%taunt = floor(getRandom() * 14);

	remoteEval(2048,playAnimWav, %taunt);

	schedule::Add("powda::dance();",5);
}
