using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace tumakov
{
    internal class BankTransaction
    {
        // Класс для хранения информации о банковской операции
            public readonly DateTime Timestamp; // Дата и времени транзакции (только для чтения)
            public readonly decimal Amount;     // Сумма транзакции (только для чтения)
            public readonly string Description; //Описание транзакции
            public BankTransaction(decimal amount, string description = "")
            {
                Timestamp = DateTime.Now;
                Amount = amount;
                Description = description;
            }
        
    }
}
