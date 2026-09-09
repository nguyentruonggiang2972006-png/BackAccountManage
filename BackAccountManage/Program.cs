using System;

namespace OOP_Practice.Exercise1
{
    public class BankAccount
    {
        private static long _nextAccountNumber = 1000000001;

        public long AccountNumber { get; init; }

        private string _accountHolder;
        public string AccountHolder
        {
            get => _accountHolder;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ten chu tai khoan khong duoc de trong hoac null.");
                _accountHolder = value;
            }
        }

        private decimal _balance;
        public decimal Balance
        {
            get => _balance;
            private set => _balance = value;
        }

        public BankAccount(string accountHolder, decimal initialBalance)
        {
            if (initialBalance < 50_000)
                throw new ArgumentException("So du ban dau khong duoc thap hon 50,000 VND.");

            AccountHolder = accountHolder;
            Balance = initialBalance;

            AccountNumber = _nextAccountNumber++;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("So tien nap phai lon hon 0.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Nap thanh cong {amount:N0} VND. So du: {Balance:N0} VND.");
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("So tien rut phai lon hon 0.");
                return false;
            }

            if (Balance - amount < 50_000)
            {
                Console.WriteLine("Rut tien that bai! So du sau khi rut khong duoc duoi 50,000 VND.");
                return false;
            }

            Balance -= amount;
            Console.WriteLine($"Rut thanh cong {amount:N0} VND. So du: {Balance:N0} VND.");
            return true;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[STK: {AccountNumber}] | Chu the: {AccountHolder} | So du: {Balance:C0}");
        }
    }

    public class Program1
    {
        public static void Main()
        {
            Console.WriteLine("--- TEST BAI 1 ---");
            try
            {
                BankAccount acc1 = new BankAccount("Nguyen Van A", 100000);
                acc1.DisplayInfo();

                BankAccount acc2 = new BankAccount("Tran Thi B", 500000);
                acc2.DisplayInfo();

                acc1.Deposit(20000);
                acc1.Withdraw(30000);
                acc1.Withdraw(50000);

                BankAccount invalidAcc = new BankAccount("Le Van C", 30000);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi khoi tao: {ex.Message}");
            }
        }
    }
}