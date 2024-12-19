using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMessendger
{
    internal class Employee
    {
        public string Name { get; set; }
        public List<TaskEmp> Tasks { get; } = new List<TaskEmp>();
        public Employee(string name) => Name = name;
        public void AddTask(Project project, TaskEmp task)
        {
            Tasks.Add(task);
            task.Project = project;
        }
        public void DelegerenTask(TaskEmp task, Employee employee)
        {
            Tasks.Remove(task);
            employee.Tasks.Add(task);
            task.Executor = employee.Name;
            task.Status = TaskStatus.Assigned;
        }
        public void TaskRejected(TaskEmp task)
        {
            Tasks.Remove(task);
            task.Executor = null;
            task.Status = TaskStatus.Assigned;

        }
        public void RemoveTask(Project project, TaskEmp task)
        {
            Tasks.Remove(task);
            project.Tasks.Remove(task);
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Работник: {Name}");
            Console.WriteLine("Список задач:");
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Задачи отсутствуют.");
                return;
            }
            foreach (var task in Tasks)
            {
                task.PrintInfo();
            }
            Console.WriteLine();
        }
    }
}
