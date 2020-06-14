using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        public static Poin sym;
        public static int HowCreate, unber;
        static void Main()
        {
            bool okey  = true;
            int nummer;
            //Проверка
            do
            {
                Console.WriteLine("Введите кол-во элементов в списке: ");
                okey = int.TryParse(Console.ReadLine(), out nummer);
                if (!okey)
                    Console.WriteLine("Ошибка! Требуется ввести натуральное число.");
            } while (!okey);
            


            int select;
            int may = 0;
            string nam;

            while (!okey)
            {
                select = 0;

                Console.WriteLine("Введите 1 для вывода ");
                Console.WriteLine("Введите 2 для поиска элемента по номеру");
                Console.WriteLine("Введите 3 для удаления элемента по номеру");
                Console.WriteLine("Введите 4 для выхода из порграммы");
                while (may == 0)
                {
                    nam = Console.ReadLine();
                    switch (nam)
                    {
                        case "1":
                            Console.WriteLine();
                            PokasSpisok();
                            break;
                        case "2":
                            Console.WriteLine("Введите номер элемента, который вы хотите найти: ");
                            Find();
                            break;
                        case "3":
                            Console.WriteLine("Введите номер элемента, который вы хотите удалить: ");
                            sym = Delete();
                            break;
                        case "4":
                            Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
                            Environment.Exit(0);
                            continue;
                        default:
                            Console.WriteLine("Вы нажали неизвестный символ, повторите попытку");
                            break;
                    }
                }
          
            }
            Console.ReadLine();
        }
        static Poin SdelatSpisok()
        {
            sym = MakePointTwo(1);//создает первый элемент
            for (int i = 1; i < unber; i++)
                sym = AddToTwo(sym, (i + 1));//добавляет  остальные элементы в начало
            return sym;
        }
        static Poin AddToTwo(Poin sym, int numb)//добавление остальных элементов в начало
        {
            Poin x = MakePointTwo(numb);
            Poin poin = new Poin(x.time);

            if (sym == null)
                return poin;
            Poin temp = sym;
            while (temp.pred != null) temp = temp.pred;
            poin.next = sym;
            sym.pred = poin;
            sym = poin;
            return sym;
        }

        static Poin MakePointTwo(int i)
        {
            Console.Clear();
            string x = "";
            if (HowCreate == 1)
            {
                Console.WriteLine(" Допускается ввод букв и знаков препинаний (!.?,;:)");
                Console.WriteLine("Введено " + i + " из " + unber + " элементов: ");
                //x = Number.Symbols();
                return new Poin(x);
            }
            else
                x = Rand.Words();
            Console.WriteLine("\n Добавлено!", ConsoleColor.Cyan);
            return new Poin(x);
        }
        public static void Create()
        {
            Console.WriteLine("Введите количество элементов: ");
           //unber = Number.Check(1, int.MaxValue);
           // HowCreate = System.Text.HowAdd();
            sym = SdelatSpisok();
        }
        static void PokasSpisok()
        {
            Console.WriteLine();
            if (sym == null)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            Poin temp = sym;
            Console.WriteLine("Исходный список:");
            while (temp != null)
            {
                Console.WriteLine(Convert.ToString(temp));
                temp = temp.next;//переход к следующему элементу
            }
        }
        public static Poin Delete()
        {
            if (sym == null)//список пустой
            {
                Console.WriteLine(" Список пуст!");
                return null;
            }
            PokasSpisok();
            Console.WriteLine(" Номер удаляемого элемента: ");
            bool okey;
            int num;
            do
            {
                Console.WriteLine("Введите элемент из списка: ");
                okey = int.TryParse(Console.ReadLine(), out num) && num > 0;
                if (!okey)
                    Console.WriteLine("Ошибка! Требуется ввести натуральное число.");
            } while (!okey);
            if (num == 1) //удаление в начале списка
            {
                sym = sym.next;
                if (sym != null)
                    sym.pred = null;
                return sym;
            }
            Poin p = sym;
            for (int i = 1; i < num && p != null; i++) p = p.next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Ошибка! Размер списка меньше, чем номер.");
                return sym;
            }
            //исключаем элемент из списка
            p.pred.next = p.next;
            if (p.next != null)
                p.next.pred = p.pred;
            Console.WriteLine(" Удалено!");
            return sym;
        }

        public static void Find()
        {
            if (sym == null)
            {
                Console.WriteLine("");
                return;
            }
            bool okey;
            int numm;
            do
            {
                Console.WriteLine("Введите кол-во элементов в списке: ");
                okey = int.TryParse(Console.ReadLine(), out numm);
                if (!okey)
                    Console.WriteLine("Ошибка! Требуется ввести натуральное число.");
            } while (!okey);
            Poin temp = sym;
            for (int i = 0; i < numm && temp != null; i++) temp = temp.next; //перебор элементов до нужного номера
            if (temp == null)
            {
                Console.WriteLine("Элемент не найден.");
                return;
            }
            Console.WriteLine(" Элемент: " + temp);
        }

    }
    class Poin
    {
        public static int count;
        public string time;      //информационное поле
        public Poin next;   //адресное поле
        public Poin pred;  //адресное поле
        private int number;

        public static int Count { get; set; }
        //конструктор без параметров
        public Poin()
        {
            time = "";
            next = null;
            pred = null;
        }
        //конструктор с параметром
        public Poin(string t)
        {
            time = t;
            next = null;
            pred = null;
        }

        public Poin(int number)
        {
            this.number = number;
        }
        //выводит список
        public override string ToString()
        {
            return time + "\n\n";
        }
    }
    class Rand
    {
        static Random rnd = new Random();
        public static string Words()
        {
            string x = ":)";
            int r = rnd.Next(1, 11);
            switch (r)
            {
                case 1:
                    x = "Привет!";
                    return x;
                case 2:
                    x = "Где?";
                    return x;
                case 3:
                    x = "Куда?";
                    return x;
                case 4:
                    x = "Когда?";
                    return x;
                case 5:
                    x = "О";
                    return x;
                case 6:
                    x = "Чайка";
                    return x;
                case 7:
                    x = "Дom";
                    return x;
                case 8:
                    x = "* (.___. ) ";
                    return x;
                case 9:
                    x = "Пока!";
                    return x;
                case 10:
                    x = "Здравствуйте!";
                    return x;
            }
            return x;
        }
    }

}

