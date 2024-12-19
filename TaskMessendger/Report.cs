using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMessendger
{
    internal class Report
    {
        public readonly string Text;
        public readonly DateTime CompletionDate;
        public readonly string Executor;
        public Report(string text, string executor)
        {
            Text = text;
            CompletionDate = DateTime.Now;
            Executor = executor;
        }
        public override string ToString() => $"{CompletionDate:yyyy-MM-dd HH:mm:ss} - {Executor} - {Text}";
    }
}
