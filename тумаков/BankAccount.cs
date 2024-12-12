using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков
{
    public enum AccountType
    {
        текущий,
        накопительный
    }
    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;
        public void WriteAccount(string accountNumber, decimal balance, AccountType accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = accountType;
        }
        public string GetAccountInfo()
        {
            return $"Номер счета: {accountNumber}, Баланс: {balance}, Тип счета: {accountType}";
        }
        public void Transaction(BankAccount account, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной и не равна нулю");
                return;
            }
            if (balance < amount)
            {
                Console.WriteLine("Недостаточно средств на счету");
                return;
            }
            balance -= amount;
            account.balance += amount;
            Console.WriteLine($"Успешно переведено {amount} с счета {accountNumber} на счет {account.accountNumber}.");
        }
    }
}


