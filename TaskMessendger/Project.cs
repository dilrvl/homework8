using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMessendger
{
    internal class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Initiator { get; set; }
        public string TeamLead { get; set; }
        public ProjectStatus Status { get; set; } = ProjectStatus.Project;
        public List<TaskEmp> Tasks { get; } = new List<TaskEmp>();

        public Project(string description, DateTime deadline, string initiator, string teamLead)
        {
            Description = description;
            Deadline = deadline;
            Initiator = initiator;
            TeamLead = teamLead;
        }
        public void AddTask(TaskEmp task) => Tasks.Add(task);
        public void SetStatus(ProjectStatus status) => Status = status;
        public void Start() => Status = ProjectStatus.Execution;
        public void PrintTasks()
        {
            Console.WriteLine("Задачи проекта:");
            foreach (var task in Tasks)
            {
                task.PrintInfo();
            }
        }
        public override string ToString()
        {
            return $"Описание: {Description}\n" +
                   $"Срок: {Deadline:yyyy-MM-dd}\n" +
                   $"Инициатор: {Initiator}\n" +
                   $"Тимлид: {TeamLead}\n" +
                   $"Статус: {Status}\n";
        }
    }
}
