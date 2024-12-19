using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMessendger
{
    internal class TaskEmp
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string Executor { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Assigned;
        public Report Report { get; set; } // Один отчет на задачу
        public Project Project { get; set; }


        public TaskEmp(string description, DateTime deadline, string initiator, string executor)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            Executor = executor;
        }

        public void AssignTo(string executor) => Executor = executor;

        public void SetStatus(TaskStatus status) => Status = status;

        public void CompleteTask(Project project, Report report)
        {
            Report = report;
            Status = TaskStatus.Completed;
            Project = project;
        }


        public void PrintInfo()
        {
            Console.WriteLine($"Описание: {Description}");
            Console.WriteLine($"Срок: {Deadline:yyyy-MM-dd}");
            Console.WriteLine($"Инициатор: {Initiator}");
            Console.WriteLine($"Исполнитель: {Executor}");
            Console.WriteLine($"Статус: {Status}");
            Console.WriteLine($"Отчет: {Report?.ToString() ?? "Отчет отсутствует"}");
            Console.WriteLine();
        }
    }
}
