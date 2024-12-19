using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tumakov
{
    public class BankAccount : IDisposable
    {
        private static int nextAccountNumber = 1000; // Статическая переменная для генерации уникальных номеров счетов.  Начинается с 1000.
        private int Number;                     // Номер счета (уникальный).
        private decimal Balance;                     // Баланс счета.
        private AccountType Type;              // Тип счета (текущий или сберегательный).
        private readonly Queue transactions = new Queue(); // Очередь для хранения транзакций

        // Конструкторы для создания объектов BankAccount с различными параметрами.
        public BankAccount() : this(AccountType.Current, 0) { } // Конструктор по умолчанию. Создает текущий счет с нулевым балансом.
        public BankAccount(decimal initialBalance) : this(AccountType.Current, initialBalance) { } // Создает текущий счет с указанным начальным балансом.
        public BankAccount(AccountType Type) : this(Type, 0) { } // Создает счет с указанным типом и нулевым балансом.
        public BankAccount(AccountType Type, decimal initialBalance)
        {
            Number = GenerateAccountNumber(); // Генерируем уникальный номер счета при создании объекта.
            this.Type = Type;         // Устанавливаем тип счета.
            Balance = initialBalance;               // Устанавливаем начальный баланс.
        }
        // Метод для генерации следующего уникального номера счета.
        private int GenerateAccountNumber()
        {
            return nextAccountNumber++; // Возвращаем текущее значение nextAccountNumber и увеличиваем его на 1.
        }
        // Свойства для доступа к полям класса (только для чтения).  Обеспечивает инкапсуляцию данных.
        public int AccountNumber { get { return Number; } }
        public decimal AccountBalance { get { return Balance; } }
        public AccountType AccountType { get { return Type; } }

        // Метод для вывода информации о банковском счете на консоль.
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"Тип счета: {AccountType}");
            Console.WriteLine($"Баланс: {AccountBalance:F2}"); //Форматирование для вывода валюты
            Console.WriteLine("\nИстория транзакций:");
            if (transactions.Count == 0)
            {
                Console.WriteLine("Транзакции отсутствуют.");
            }
            else
            {
                foreach (BankTransaction transaction in transactions)
                {
                    Console.WriteLine($"{transaction.Timestamp:yyyy-MM-dd HH:mm:ss} - {transaction.Amount:F2} - {transaction.Description}");
                }
            }
            Console.WriteLine();
        }
        // Метод для пополнения счета.
        public void Deposit(decimal amount, string description = "Пополнение")
        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Enqueue(new BankTransaction(amount, description));
                Console.WriteLine($"Пополнение счета на {amount:F2} успешно выполнено. Новый баланс: {Balance:F2}");
            }
            else
            {
                throw new ArgumentException("Сумма пополнения должна быть положительной.");
            }
        }
        // Метод для снятия средств со счета.
        public void Withdraw(decimal amount, string description = "Снятие")
        {
            if (amount > 0)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    transactions.Enqueue(new BankTransaction(-amount, description));
                    Console.WriteLine($"Снятие {amount:F2} со счета успешно выполнено. Новый баланс: {Balance:F2}");
                }
                else
                {
                    throw new InvalidOperationException("Недостаточно средств на счете.");
                }
            }
            else
            {
                throw new ArgumentException("Сумма снятия должна быть положительной.");
            }
        }
        public static void Transfer(BankAccount source, BankAccount destination, decimal amount)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Счет не может быть null.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма перевода должна быть положительной.");
            }
            if (source.Balance < amount)
            {
                throw new InvalidOperationException("Недостаточно средств на счете отправителя.");
            }
            try
            {
                source.Withdraw(amount); // Снимаем деньги с исходного счета.
                destination.Deposit(amount); // Добавляем деньги на целевой счет.
                Console.WriteLine($"Перевод {amount:F2} успешно выполнен со счета {source.AccountNumber} на счет {destination.AccountNumber}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при переводе: {ex.Message}");
            }
        }
        // Метод для записи транзакций в файл
        public void SaveTransactionsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (BankTransaction transaction in transactions)
                {
                    writer.WriteLine($"{transaction.Timestamp:yyyy-MM-dd HH:mm:ss},{transaction.Amount:F2},{transaction.Description}");
                }
            }
            Console.WriteLine($"Транзакции успешно сохранены в файл: {filePath}");
        }
        // Метод Dispose для освобождения ресурсов
        public void Dispose()
        {
            SaveTransactionsToFile("transactions.txt"); // Сохраняем транзакции в файл при dispose
            GC.SuppressFinalize(this); // Предотвращаем вызов финализатора
        }
        ~BankAccount() //Финализатор (вызывается сборщиком мусора)
        {
            Dispose(); //Вызываем Dispose в финализаторе
            Console.WriteLine("Финализатор BankAccount вызван.");
        }
    }
}