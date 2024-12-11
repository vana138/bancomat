using System;

namespace bancomat
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 1000.00m; // Начальный баланс пользователя

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в банкомат!");
                Console.WriteLine("1. Показать баланс");
                Console.WriteLine("2. Снять деньги");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBalance(balance);
                        break;

                    case "2":
                        balance = WithdrawMoney(balance);
                        break;

                    case "3":
                        Console.WriteLine("Спасибо за использование банкомата. До свидания!");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }

        static void ShowBalance(decimal balance)
        {
            Console.WriteLine($"Ваш текущий баланс: {balance:C}");
        }

        static decimal WithdrawMoney(decimal balance)
        {
            Console.Write("Введите сумму для снятия: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount > 0 && amount <= balance)
                {
                    balance -= amount;
                    Console.WriteLine($"Операция успешна! Вы сняли {amount:C}.");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств или неверная сумма.");
                }
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте снова.");
            }

            return balance;
        }
    }
}
