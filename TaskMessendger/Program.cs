using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMessendger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем команду
            Employee Alina = new Employee("Алина");
            Employee Zarina = new Employee("Зарина");
            Employee Dasha = new Employee("Даша");
            Employee Sergey = new Employee("Сергей");
            Employee Mikhail = new Employee("Михаил");
            Employee Kamil = new Employee("Камиль");
            Employee Emil = new Employee("Эмиль");
            Employee Radmir = new Employee("Радмир");
            Employee Ulyana = new Employee("Ульяна");
            Employee Angela = new Employee("Анжела");
            Employee Andrey = new Employee("Андрей");
            List<Employee> team = new List<Employee> { Alina, Zarina, Dasha, Sergey, Mikhail, Kamil, Emil, Radmir, Ulyana, Angela, Andrey };
            // Создаем проект
            Project game = new Project("создание игры", DateTime.Now.AddDays(100), Alina.Name, Zarina.Name);
            // Создаем задачи
            TaskEmp task1 = new TaskEmp("выбрать движок", DateTime.Now.AddDays(10), game.TeamLead, Dasha.Name);
            TaskEmp task2 = new TaskEmp("создать модели", DateTime.Now.AddDays(19), game.TeamLead, Sergey.Name);
            TaskEmp task3 = new TaskEmp("переписать гвинт", DateTime.Now.AddDays(32), game.TeamLead, Mikhail.Name);
            TaskEmp task4 = new TaskEmp("сидеть на зп", DateTime.Now.AddDays(90), game.TeamLead, Kamil.Name);
            TaskEmp task5 = new TaskEmp("написать логику", DateTime.Now.AddDays(40), game.TeamLead, Emil.Name);
            TaskEmp task6 = new TaskEmp("настроить сервера", DateTime.Now.AddDays(50), game.TeamLead, Radmir.Name);
            TaskEmp task7 = new TaskEmp("много думать", DateTime.Now.AddDays(19), game.TeamLead,Ulyana.Name);
            TaskEmp task8 = new TaskEmp("подать кофе", DateTime.Now.AddDays(32), game.TeamLead, Angela.Name);
            TaskEmp task9 = new TaskEmp("помыть пол", DateTime.Now.AddDays(90), game.TeamLead, Andrey.Name);
            TaskEmp task10 = new TaskEmp("ничего не ломать", DateTime.Now.AddDays(40), game.TeamLead, Zarina.Name);
            TaskEmp task11 = new TaskEmp("что-нить сделать", DateTime.Now.AddDays(50), game.TeamLead, Alina.Name);
            // Назначаем задачи сотрудникам
            Zarina.AddTask(game, task1);
            Zarina.AddTask(game, task2);
            Zarina.AddTask(game, task3);
            Zarina.AddTask(game, task4);
            Zarina.AddTask(game, task5);
            Zarina.AddTask(game, task6);
            Zarina.AddTask(game, task7);
            Zarina.AddTask(game, task8);
            Zarina.AddTask(game, task9);
            Zarina.AddTask(game, task10);
            Zarina.AddTask(game, task11);

            Emil.PrintInfo();
            task11.PrintInfo();

            game.Start();

            // Делегирование задачи
            Emil.DelegerenTask(task5, Radmir);
            Emil.PrintInfo();
            task5.PrintInfo();
            Radmir.TaskRejected(task5);
            task5.PrintInfo();
            Zarina.RemoveTask(game, task5);
            game.PrintTasks();

            // Выполнение задач и создание отчетов
            task1.CompleteTask(game, new Report("выполнена", Dasha.Name));
            task2.CompleteTask(game, new Report("выполнена", Sergey.Name));
            task3.CompleteTask(game, new Report("выполнена", Mikhail.Name));
            task4.CompleteTask(game, new Report("выполнена", Kamil.Name));
            task6.CompleteTask(game, new Report("выполнена", Emil.Name));
            task7.CompleteTask(game, new Report("выполнена", Radmir.Name));
            task8.CompleteTask(game, new Report("выполнена", Ulyana.Name));
            task9.CompleteTask(game, new Report("выполнена", Angela.Name));
            task10.CompleteTask(game, new Report("выполнена", Andrey.Name));
            task11.CompleteTask(game, new Report("выполнена", Alina.Name));


            Console.WriteLine(game);
        }
    }
}
