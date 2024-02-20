// Version 3.1 (11-28-01)
// Chanserv Script by powdahound
// Put this script in your mirc directory and then enter "/load -rs powdaserv.mrc" in any mirc window.

on *:load:{ 
  /echo -a 11••• Thanks for loading powdaserv v3.1 by powdahound.
  /echo -a 11••• Designed on and for irc.dynamix.com:6667. May work with other servers running chanserv.
  /echo -a 11••• Please report bugs to powda@gis.net
  /echo -a 11••• http://united.dnsprotect.com/~lightin/powdahound/powdaserv.php - for information, downloads!

  /set %preset1 5
  /set %preset2 10
  /set %preset3 15
  /set %preset4 20
  /set %preset5 9999
  /set %console on
  /set %concol 8,2
}

menu channel {
  Chanserv Commands
  .Script
  ..About:/aboutpowda
  ..Console
  ...Toggle
  ....Console is %console:/echo $chan I'm not kidding, the console is %console $+ !
  ....-
  ....Turn Off:/set %console off | /echo 8,12Console now %console
  ....Turn On:/set %console on | /echo 8,12Console now %console
  ...Colors
  ....Set Console Colors:/set %concol $$?="Hit Ctrl+k. First number is text, followed by comma, then second number is background. Then hit enter."
  .Control
  ..Register:/chanserv register # $?="Enter a password for the chan:" $?="Enter a description of the chan:"
  ..Drop:/chanserv drop $$?="Enter Chan to Drop (You must be a founder)"
  ..Identify:/chanserv identify # $?="Enter the password for this chan:"
  .Set Options
  ..Founder:/chanserv set # founder $?="Enter new founder's nick"
  ..Successor:/chanserv set # successor $?="Enter successor's nick"
  ..Chan Password:/chanserv set # password $?="Enter new password"
  ..Description:/chanserv set # desc $?="Enter chan description"
  ..URL:/chanserv set # url $?="Enter URL for this chan"
  ..E-Mail:/chanserv set # email $?="Enter E-Mail for this chan"
  ..Entry Message:/chanserv set # entrymsg $?="Enter entry message:"
  ..Topic
  ...Set Topic:/chanserv set # topic $?="Enter New Topic:"
  ...Keep Topic
  ....On:/chanserv set # keeptopic on
  ....Off:/chanserv set # keeptopic off
  ...Topic Lock
  ....On:/chanserv set # topiclock on
  ....Off:/chanserv set # topiclock off
  ..Lock Chan Modes
  ...On:/chanserv set # mlock $?="Enter modelocks:"
  ...Off:/chanserv set # mlock off
  ..Private
  ...On:/chanserv set # private on
  ...Off:/chanserv set # private off
  ..Restricted
  ...On:/chanserv set # restricted on
  ...Off:/chanserv set # restricted off
  ..Ops
  ...Secure Ops
  ....On:/chanserv set # secureops on
  ....Off:/chanserv set # secureops off
  ...Leave Ops
  ....On:/chanserv set # leaveops on
  ....Off:/chanserv set # leaveops off
  ...Op Notice
  ....On:/chanserv set # opnotice on
  ....Off:/chanserv set # opnotice off
  .Access Levels
  ..Auto Op:/chanserv levels # set autoop $?="Enter Level Number:"
  ..Auto Voice:/chanserv levels # set autovoice $?="Enter Level Number:"
  ..Auto Deop:/chanserv levels # set autodeop $?="Enter Level Number:"
  ..No Join:/chanserv levels # set nojoin $?="Enter Level Number:"
  ..Invite:/chanserv levels # set invite $?="Enter Level Number:"
  ..Auto Kick:/chanserv levels # set akick $?="Enter Level Number:"
  ..Set:/chanserv levels # set set $?="Enter Level Number:"
  ..Clear:/chanserv levels # set clear $?="Enter Level Number:"
  ..Unban:/chanserv levels # set unban $?="Enter Level Number:"
  ..Op / Deop:/chanserv levels # set opdeop $?="Enter Level Number:"
  ..Kick:/chanserv levels # set kick $?="Enter Level Number:"
  ..Access List:/chanserv levels # set Acc-List $?="Enter Level Number:"
  ..Access Change:/chanserv levels # set Acc-Change $?="Enter Level Number:"
  ..Memo
  ...Memo Read:/chanserv levels # set memoread $?="Enter Level Number:"
  ...Memo Send:/chanserv levels # set memosend $?="Enter Level Number:"
  ...Memo Delete:/chanserv levels # set memodel $?="Enter Level Number:"
  ..Protect:/chanserv levels # set protect $?="Enter Level Number:"
  ..Disable:/chanserv levels # disable
  ..List
  ..Reset
  .Access List Management
  ..Add to List:/chanserv access # add $?="Enter nick" $?="Enter Level"
  ..Delete from List:/chanserv access # del $?="Enter nick"
  ..List Users*:/chanserv access # list
  .Other
  ..Info:/chanserv info #
  ..Invite:/chanserv invite $$?="Enter chan you want to be invited into (you must have >0 access)"
  ..Op:/chanserv op # $$?="Enter nick to op in this chan"
  ..Deop:/chanserv deop # $$?="Enter nick to deop in this chan"
  ..Unban:/chanserv unban $$?="Enter chan to unban yourself in"
  ..Kick:/chanserv kick # $$?="Enter nick to kick in this chan" $?="Enter reason:"
  ..Clear
  ...Modes:/chanserv clear # modes
  ...Bans:/chanserv clear # bans
  ...Ops:/chanserv clear # ops
  ...Voices:/chanserv clear # voices
  ...Users:/chanserv clear # users
}

menu nicklist {
  Chanserv
  .Access
  ..Add to List [Presets]
  ...Preset1 < %preset1 >:/chanserv access # add $$1 %preset1
  ...Preset2 < %preset2 >:/chanserv access # add $$1 %preset2
  ...Preset3 < %preset3 >:/chanserv access # add $$1 %preset3
  ...Preset4 < %preset4 >:/chanserv access # add $$1 %preset4
  ...Preset5 < %preset5 >:/chanserv access # add $$1 %preset5
  ...Change Presets
  ....Set Preset 1:/set %preset1 $?="Enter level"
  ....Set Preset 2:/set %preset2 $?="Enter level"
  ....Set Preset 3:/set %preset3 $?="Enter level"
  ....Set Preset 4:/set %preset4 $?="Enter level"
  ....Set Preset 5:/set %preset5 $?="Enter level"
  ..Add $$1 to List:/chanserv access # add $$1 $?="Enter Level"
  ..Delete $$1 from List:/chanserv access # del $$1
  ..List Users [Status window]:/chanserv access # list
  .Auto-Kick
  ..Add $$1:/chanserv akick # add $$1 | /set %lastakick $$1
  ..Delete:/chanserv akick # del $?="Enter Nick:"
  ..Remove last person ( %lastakick ) added to akick:/chanserv akick # del %lastakick
  .Op $$1:/chanserv op # $$1
  .Deop $$1:/chanserv deop # $$1
  .Kick $$1:/chanserv kick # $$1 $$?="Enter Reason"
}

;Dialog Commands
on *:notice:*:?: {
  if (%console == off) {
    if ($nick == ChanServ) { 
      echo -a %concol Chanserv Message: $1-
    }
  } 
  else {
    window -aeo @chanserv_console 0 0 500 600
    aline -c @chanserv_console %concol $+ - $1-
  }
}

alias aboutpowda var %§.d = $dialog(aboutpowda,aboutpowda,-4)

dialog aboutpowda {
  title "About powdaserv v3.1"
  size -1 -1 265 115
  box "", 250, 5 0 255 110
  text "-Author:", 2, 10 10 129 15
  text "powdahound", 10, 60 10 129 15
  text "-Email:", 4, 10 25 35 15
  text "-Site:", 8, 10 40 35 15
  text "powda@giss.net", 6, 60 25 157 25
  text "http://powda.tribes2.org", 7, 60 40 200 15
  text "*Made specifically for irc.dynamix.com:6667", 12, 10 55 250 15
  button "OK", 50, 100 75 60 25, OK default
  ;  icon 5, 230 10 60 60, mirc32.exe
}
