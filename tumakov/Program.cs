using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
        }
        static void Task1()
        {
            // Создаем два объекта BankAccount.
            BankAccount account1 = new BankAccount(AccountType.Current, 1000);
            BankAccount account2 = new BankAccount(AccountType.Savings, 500);

            Console.WriteLine("Информация о счетах до перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();

            try
            {
                // Выполняем перевод денег.
                BankAccount.Transfer(account1, account2, 200);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            Console.WriteLine("\nИнформация о счетах после перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();

            // Примеры обработки исключений.
            try
            {
                account1.Withdraw(1500); //Попытка снять больше, чем есть на счете.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            try
            {
                account1.Deposit(-100); //Попытка положить отрицательную сумму
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }
        }
        static void Task2()
        {
            Console.WriteLine("Упражнение 9.2");
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU"); // Установка региональных настроек для корректного форматирования валюты

            BankAccount account1 = new BankAccount(AccountType.Current, 1000m);
            BankAccount account2 = new BankAccount(AccountType.Savings, 500m);
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            try
            {
                BankAccount.Transfer(account1, account2, 200m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }
            Console.WriteLine("\nИнформация о счетах после перевода:");
            account1.PrintAccountInfo();
            account2.PrintAccountInfo();
            try
            {
                account1.Withdraw(900m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nОшибка: {ex.Message}");
            }

            account1.Deposit(500m);
            account1.PrintAccountInfo();
        }
        static void Task3()
        {
            Console.WriteLine("Упражнение 9.3");
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            BankAccount account1 = new BankAccount(AccountType.Current, 1000m);
            account1.Deposit(500m);
            account1.Withdraw(200m);
            //Использование IDisposable
            using (BankAccount account2 = new BankAccount(AccountType.Savings, 500m))
            {
                account2.Deposit(100m);
                account2.Withdraw(50m);
                account2.PrintAccountInfo();
            } // Dispose вызывается автоматически при выходе из using блока
            account1.PrintAccountInfo();
        }
        static void Task4()
        {
            Console.WriteLine("Домашнее задание 9.1");
            // Создание объекта mySong с использованием конструктора с тремя параметрами.
            Song song1 = new Song("Песня 1", "Автор 1");
            Song mySong = new Song("Песня 2", "Автор 2", song1);
            mySong.PrintSongInfo();
            Console.WriteLine();
            song1.PrintSongInfo();
            Console.WriteLine();
            // Пример вызова конструктора без параметров
            Song mySong3 = new Song();
            mySong3.PrintSongInfo();
            Console.WriteLine();
            //Пример использования операторов == и !=
            bool areEqualOperator = song1 == mySong;
            Console.WriteLine($"\nПесня 1 и Песня 2 равны (с использованием оператора ==): {areEqualOperator}");
            bool areNotEqualOperator = song1 != mySong;
            Console.WriteLine($"\nПесня 1 и Песня 2 не равны (с использованием оператора !=): {areNotEqualOperator}");

        }
    }
}
