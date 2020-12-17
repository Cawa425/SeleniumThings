using AutoItX3Lib;

namespace ConsoleApp1
{
    public class AutoltScipt
    {
        public static void AutoScriptMain()
        {
            var auto = new AutoItX3();
            auto.Run("notepad.exe", "", 1);
            auto.WinWaitNotActive("[CLASS:Notepad]");
            auto.WinActivate("[CLASS:Notepad]");
            auto.Send("Task to create script on Autolt.{ENTER}Kazakov Alex 11-809{ENTER}");
            auto.Sleep(500);
            auto.Send("+{UP 2}");
            auto.Sleep(500);
            auto.Send("!f");
            auto.Sleep(500);
            auto.Send("{DOWN 6} a {ENTER}");
            auto.WinClose("[CLASS:Notepad]");
            auto.Send("{TAB}{ENTER}");
        }
    }
}