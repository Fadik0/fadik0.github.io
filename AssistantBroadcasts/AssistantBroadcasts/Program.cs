using System;
using System.Threading;
using System.Windows.Forms;

namespace AssistantBroadcasts
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        static Mutex mutex;

        static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting("AssistantBroadcasts");
            }
            catch
            {
                Program.mutex = new Mutex(true, "AssistantBroadcasts");
                return true;
            }
            return false;
        }

        [STAThread]
        static void Main()
        {
            if (IsSingleInstance())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_main());
            }
            else
                MessageBox.Show("Assistant Broadcasts уже запущен.");
        }
    }
}
