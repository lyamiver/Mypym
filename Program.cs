using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Задача12
{
    class Program
    {
        public static Random ran = new Random();
        public static int sravn, perem, numme;
        public static int[] sortiVosArra, sortiUbArra, sortiVossArra, sortiUbbArra, arra, arraa;

        static void Main(string[] args)
        {
            bool konec = false;
            //Проверка
            do
            {
                numme = ran.Next(9, 17);
                FormirMassivaRandom();
                DeistUbArra();
                DeistVosArra();


                Console.WriteLine("Массивы:");
                Console.WriteLine("Неупорядоченный массив:");
                VivodMassiva(arra);
                Console.WriteLine("Массив по убыванию:");
                VivodMassiva(sortiUbArra);
                Console.WriteLine("Массив по возрастанию:");
                VivodMassiva(sortiVosArra);

                //Вывод быстрого массива
                sravn = perem = 0;
                Console.WriteLine("Массивы через быструю сортировку:");
                Console.WriteLine("Неупорядоченный массив:");
                QuickSort(arraa,0,arra.Length - 1);
                VivodKones();
                VivodMassiva(arra);

                Console.WriteLine("Упорядоченный массив по убыванию:");
                sravn = perem = 0;
                QuickSort(sortiUbbArra, 0, sortiUbArra.Length - 1);
                VivodKones();
                VivodMassiva(sortiUbbArra);


                Console.WriteLine("Упорядоченный массив по возрастанию:");
                sravn = perem = 0;
                QuickSort(sortiVossArra, 0, sortiVosArra.Length - 1);
                VivodKones();
                VivodMassiva(sortiVossArra);

                //Блочная сортировка
                sravn = perem = 0;
                Console.WriteLine("Массивы через блочную сортировку:");
                Console.WriteLine("Неупорядоченный массив:");
                BlockSort(arraa);
                VivodKones();
                VivodMassiva(arra);

                Console.WriteLine("Упорядоченный массив по убыванию:");
                sravn = perem = 0;
                BlockSort(sortiUbbArra);
                VivodKones();
                VivodMassiva(sortiUbbArra);


                Console.WriteLine("Упорядоченный массив по возрастанию:");
                sravn = perem = 0;
                BlockSort(sortiVossArra);
                VivodKones();
                VivodMassiva(sortiVossArra);


                Console.ReadKey();

            } while (!konec);

            
        }
        public static void VivodKones()
        {
            Console.WriteLine("Кол-во перем: {0}  Кол-во сравнений: {1}", perem, sravn);
            Console.ReadKey();
        }

        public static void FormirMassivaRandom()
        {
            arra = new int[numme];
            arraa = new int[numme];
            for(int k=0; k< numme; k++)
            {
                arra[k] = ran.Next(20);
                arraa[k] = arra[k];
            }
        }
    
        public static void DeistUbArra()
        {
            sortiUbArra = new int[numme];
            sortiUbbArra = new int[numme];
            for (int k = 0; k < numme; k++)
            { 
                sortiUbArra[k] = numme - k;
                sortiUbbArra[k] = numme - k;
            }

        }

        public static void DeistVosArra()
        {
            sortiVosArra = new int[numme];
            sortiVossArra = new int[numme];
            for (int k = 0; k < numme; k++)
            {
                sortiVosArra[k] = numme + k;
                sortiVossArra[k] = numme + k;
            }
        }

        public static void VivodMassiva(int[] ar)
        {
            for(int v=0; v<ar.Length; v++)
            {
                Console.WriteLine(ar[v]+ " ");
            }
            Console.ReadKey();

        }

        //Быстрая сортировка
        public static void QuickSort(int[] arra, int perv, int posl)
        {
            int p = arra[(posl - perv) / 2 + perv];
            int temp;
            int pe = perv, po = posl;
            while (pe <= po)
            {
                while (DeistvQ(arra[pe], p, true) && pe <= posl)
                {
                    ++pe;
                }
                while (DeistvQ(arra[po], p, false) && po >= perv)
                {
                    --po;
                }
                if (pe <= po)
                {
                    temp = arra[pe];
                    arra[pe] = arra[po];
                    arra[po] = temp;
                    if (pe != po) perem++;
                    ++pe;
                    --po;
                }
            }
            if (po > perv) QuickSort(arra, perv, po);
            if (pe < posl) QuickSort(arra, pe, posl);
        }

        public static bool DeistvQ(int el, int val, bool less)
        {
            bool resultat = false;
            sravn++;
            if (less) resultat = (el < val);
            else resultat = (el > val);
            return resultat;
        }


        public static void BlockSort(int[] arra) // Блочная сортировка 
        {
            //Поиск элементов с максимальным и минимальным значениями
            // 

            int maxValue = arra[0];
            int minValue = arra[0];

            for (int i = 1; i < arra.Length; i++)
            {
                if (arra[i] > maxValue)
                { maxValue = arra[i]; sravn++; }

                if (arra[i] < minValue)
                { minValue = arra[i]; sravn++; }
            }

            // Создание временного массива "карманов" в количестве, 
            // достаточном для хранения всех возможных элементов, 
            // чьи значения лежат в диапазоне между minValue и maxValue. 
            // Т.е. для каждого элемента массива выделяется "карман" List<int>. 
            // При заполнении данных "карманов" элементы исходного не отсортированного массива 
            // будут размещаться в порядке возрастания собственных значений "слева направо". 
            // 

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты 
            // 

            for (int i = 0; i < arra.Length; i++)
            {
                bucket[arra[i] - minValue].Add(arra[i]);
            }

            // Восстановление элементов в исходный массив 
            // из карманов в порядке возрастания значений 
            // 

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        arra[position] = bucket[i][j];
                        position++;
                        perem++;
                    }
                }
            }
        }


    }
}
