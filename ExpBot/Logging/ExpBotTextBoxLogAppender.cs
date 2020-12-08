using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExpBot.Logging
{
    public class ExpBotTextBoxLogAppender : IAppender
    {
        private TextBox txtConsole;
        private readonly object lockObj = new object();
        public ExpBotTextBoxLogAppender(TextBox txtConsole)
        {
            Form form = txtConsole.FindForm();
            if (form == null)
            {
                return;
            }

            form.FormClosing += delegate
            {
                Close();
            };

            this.txtConsole = txtConsole;
            Name = "ExpBotTextBoxLogAppender";
        }

        public string Name { get; set; }

        public static void ConfigureExpBotTextBoxLogAppender(TextBox txtConsole)
        {
            ((Hierarchy)LogManager.GetRepository()).Root.AddAppender(new ExpBotTextBoxLogAppender(txtConsole));
        }
        public void Close()
        {
            try
            {
                lock (lockObj)
                {
                    this.txtConsole = null;
                }

                ((Hierarchy)LogManager.GetRepository()).Root.RemoveAppender(this);
            }
            catch
            {
            }
        }
        public void DoAppend(LoggingEvent loggingEvent)
        {
            try
            {
                if (txtConsole == null)
                {
                    return;
                }

                if (loggingEvent.LoggerName.Contains("NHibernate"))
                {
                    return;
                }

                string msg = string.Concat(loggingEvent.RenderedMessage, "\r\n");

                lock (lockObj)
                {
                    if (txtConsole == null)
                    {
                        return;
                    }

                    txtConsole.BeginInvoke((Action)(() => txtConsole.AppendText(msg)), msg);
                }
            }
            catch
            {
            }
        }
    }
}