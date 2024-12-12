using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTask();
            FourthTask();
            FifthTask();
            SixthTask();
        }
        private static decimal GetAmountForTransaction()
        {
            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount) && amount > 0)
            { 
                return amount;
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите положительное число:");
                return GetAmountForTransaction(); //рекурсия
            }
        }
        private static int GetUserChoice()
        {
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Пожалуйста, введите число 1 или 2:");
                return GetUserChoice(); //рекурсия
            }
        }
        static void FirstTask()
        {
            Console.WriteLine("Упражнение 8.1");

            /*В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить
            метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка
            на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
            */

            //создание двух счетов
            BankAccount account1 = new BankAccount();
            account1.WriteAccount("12345678", 5981m, AccountType.накопительный);
            BankAccount account2 = new BankAccount();
            account2.WriteAccount("87654321", 1278m, AccountType.текущий);
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());
            Console.WriteLine("Введите сумму для перевода:");
            decimal amountForTransaction = GetAmountForTransaction();
            Console.WriteLine("Выберите с какого счета хотите перевести деньги (введите 1 или 2):");
            Console.WriteLine("1) - накопительный счет (номер: 12345678)");
            Console.WriteLine("2) - текущий счет (номер: 87654321)");
            int fromAccountChoice = GetUserChoice();
            // перевод из выбранного счета на другой
            if (fromAccountChoice == 1)
            {
                account1.Transaction(account2, amountForTransaction);
            }
            else
            {
                account2.Transaction(account1, amountForTransaction);
            }
            Console.WriteLine(account1.GetAccountInfo());
            Console.WriteLine(account2.GetAccountInfo());
        }
        static string ReverseString(string str)
        {
            if (str == null)
                return null;
            char[] charArray = str.ToCharArray(); //преобразовываем строку в массив
            Array.Reverse(charArray); //делаем массив в обратном порядке
            return new string(charArray); 
        }
        static void SecondTask()
        {
            Console.WriteLine("Упражнение 8.2");
           
            /*Реализовать метод, который в качестве входного параметра принимает
            строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.
            Протестировать метод.*/

            string input = "Я учусь в КФУ!";
            string reversed = ReverseString(input);
            Console.WriteLine($"Входная строка: {input}");
            Console.WriteLine($"Переделанная строка: {reversed}");
        }
        static void ThirdTask()
        {
            Console.WriteLine("Упражнение 8.3");

            /*Написать программу, которая спрашивает у пользователя имя файла. Если
            такого файла не существует, то программа выдает пользователю сообщение и заканчивает
            работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными
            буквами.*/
            
            Console.Write("Введите имя файла (в формате:<текст файлы\\имя файла>): ");
            string fileName = Console.ReadLine();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не существует");
                return; 
            }
            string content = File.ReadAllText(fileName);
            string upperContent = content.ToUpper();
            string outputFileName = "текст файлы\\файлкапсом.txt"; 
            File.WriteAllText(outputFileName, upperContent);
            Console.WriteLine($"Содержимое файла записано в {outputFileName}.");
        }
        static bool ImplementsIFormattable(object obj)
        {
            if (obj is IFormattable)
            {
                return true; 
            }
            IFormattable formattable = obj as IFormattable;
            if (formattable != null)
            {
                return true; 
            }
            return false;
        }
        static void FourthTask()
        {
            Console.WriteLine("Упражнение 8.4");

            /*Реализовать метод, который проверяет реализует ли входной параметр
            метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс
            IFormattable обеспечивает функциональные возможности форматирования значения объекта
            в строковое представление.)*/

            int number; 
            try
            {
                Console.Write("Введите целое число: ");
                string userInput1 = Console.ReadLine();
                number = int.Parse(userInput1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный ввод");
                return; 
            }
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();
            DateTime date;
            Console.Write("Введите дату в формате: год-месяц-день: ");
            string userInput2 = Console.ReadLine();
            if (!DateTime.TryParse(userInput2, out date))
            {
                Console.Write("Неверный формат даты. Пожалуйста, введите дату заново в формате: год-месяц-день: ");
                userInput2 = Console.ReadLine();
                if (!DateTime.TryParse(userInput2, out date))
                {
                    Console.WriteLine("Неверный формат даты снова");
                    return; 
                }
            }
            Console.WriteLine($"Целое число реализует IFormattable? {ImplementsIFormattable(number)}");
            Console.WriteLine($"Строка реализует IFormattable? {ImplementsIFormattable(text)}");
            Console.WriteLine($"DateTime реализует IFormattable? {ImplementsIFormattable(date)}");
        }
        public static void SearchEMail(ref string s)
        {
            // разделяем строку по '#' и берем вторую часть
            string[] parts = s.Split('#');
            if (parts.Length > 1)
            {
                s = parts[1].Trim(); //возвращаем почту удаляя лишние пробелы
            }
            else
            {
                s = ""; 
            }
        }
        static void FifthTask()
        {
            Console.WriteLine("Домашнее задание 8.1");

            /*Дан текстовый файл, содержащий ФИО и e-mail
            адрес.Сформировать новый файл, содержащий список адресов электронной почты.
            Предусмотреть метод, выделяющий из строки адрес почты*/

            string inputFile = "текст файлы\\фио.txt"; 
            string outputFile = "текст файлы\\email.txt"; 
            try
            {
                using (StreamReader reader = new StreamReader(inputFile))
                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        SearchEMail(ref line);
                        writer.WriteLine(line); 
                    }
                }
                Console.WriteLine("Список адресов электронной почты успешно записан в файл '{0}'", outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        static void SixthTask()
        {
            Console.WriteLine("Домашнее задание 8.2");

            /*Список песен. В методе Main создать список из четырех песен. В
            цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую
            песню в списке.*/

            List<Song> songs = new List<Song>();
            for (int i = 0; i < 4; i++)
            {
                Song song = new Song();
                song.FillName(); 
                song.FillAuthor();
                if (i > 0) //если это не первая песня присваиваем prev
                {
                    song.SetPrevSong(songs[i - 1]);
                }
                songs.Add(song);
            }
            Console.WriteLine("Информация о песнях:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }
            bool areEqual = songs[0].Equals(songs[1]);
            Console.WriteLine("Первая и вторая песни равны: " + areEqual);
        }
    }
}
