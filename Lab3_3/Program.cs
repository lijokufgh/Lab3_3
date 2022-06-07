using System.Diagnostics;

namespace Lab_3_3
{

    public class Mass
    {
        protected Stopwatch stopWatch = new Stopwatch(); // Переменная для подсчёта времени.
        private static Random Rnd = new Random(); // Переменная для подсчёта рандомного массива.
        private static int[] mas = new int[10]; // Статический массив.
        protected int swap; // Переменная для смены переменных.
        protected static int dlin = mas.Length; // Статическая длина массива.

        public static int[] Zapoln1() // Статический метод для рандомного заполнения статического массива.
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = Rnd.Next(0, 10000);
            }
            return mas;
        }
        private static void Vod(int[] qwe) // Статический метод для вывода массива.
        {
            for (int i = 0; i < qwe.Length; i++)
            {
                Console.Write($"{qwe[i]} ");
            }
            Console.WriteLine("");
        }
        protected void VodMas1(int[] qwe) // Метод для вывода массива и всей его информации.
        {
            Console.Write("Отсортированный массив: ");
            Vod(qwe);
            Console.Write("Скорость выполнения: ");
            Console.Write(stopWatch.Elapsed); // Подсчёт затраченного времени на выполнения сортировки.
            Console.WriteLine("\n");
        }        
    }

    public class Mass1 : Mass // Сортировка пузырьковым методом.
    {
        private void Mas(int[] mas)
        {
            stopWatch.Start();
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length - 1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        swap = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = swap;
                    }
                }
            }
            stopWatch.Stop();
        }
        public Mass1(int[] qwe)
        {
            Mas(qwe);
            Console.Write("Сортировка пузырьковым методом.\n");
            VodMas1(qwe);
        }
    }

    public class Mass2 : Mass // Сортировка выбором.
    {
        int Max = int.MaxValue, ix = 0;
        private void Mas(int[] mas)
        {
            stopWatch.Start();
            for (int j = 0; j < mas.Length; j++)
            {
                for (int i = 0; i < dlin; i++)
                {
                    if (mas[i] < Max)
                    {
                        Max = mas[i];
                        ix = i;
                    }
                }
                swap = mas[dlin - 1];
                mas[dlin - 1] = Max;
                mas[ix] = swap;
                Max = int.MaxValue;
                dlin--;
            }
            stopWatch.Stop();
        }
        public Mass2(int[] qwe)
        {
            Mas(qwe);
            Console.Write("Сортировка выбором.\n");
            VodMas1(qwe);
        }
    }

    public class Mass3 : Mass // Сортировка перемешиванием (шейкерная сортировка).
    {
        private void Mas(int[] mas)
        {
            stopWatch.Start();
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length - 1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        swap = mas[j + 1];
                        mas[j + 1] = mas[j];
                        mas[j] = swap;
                    }
                }

                for (int kon = mas.Length; kon < 1; kon--)
                {
                    if (mas[kon] > mas[kon - 1])
                    {
                        swap = mas[kon - 1];
                        mas[kon - 1] = mas[kon];
                        mas[kon] = swap;
                    }
                }

            }
            stopWatch.Stop();
        }
        public Mass3(int[] qwe)
        {
            Mas(qwe);
            Console.Write("Сортировка перемешиванием (шейкерная сортировка).\n");
            VodMas1(qwe);
        }
    }

    public class Mass4 : Mass // Сортировка расчёской.
    {
        private void Mas(int[] mas)
        {
            double ras = dlin;
            bool rasch = true;
            stopWatch.Start();
            while (ras > 1 || rasch)
            {
                ras /= 1.247330950103979;
                if (ras < 1) ras = 1;
                int i = 0;
                rasch = false;
                while (i + ras < mas.Length)
                {
                    int igap = i + (int)ras;
                    if (mas[i] < mas[igap])
                    {
                        swap = mas[i];
                        mas[i] = mas[igap];
                        mas[igap] = swap;
                        rasch = true;
                    }
                    i++;
                }
            }
            stopWatch.Stop();
        }
        public Mass4(int[] qwe)
        {
            Mas(qwe);
            Console.Write("Сортировка расчёской.\n");
            VodMas1(qwe);
        }
    }

    public class Mass5 : Mass // Сортировка пузырьковым методом.
    {
        private void Mas(int[] mas)
        {
            stopWatch.Start();
            for (int i = 1; i < mas.Length; ++i)
            {
                int x = mas[i];
                int j = i;
                while (j > 0 && mas[j - 1] > x)
                {
                    mas[j] = mas[j - 1];
                    j--;
                }
                mas[j] = x;
            }
            stopWatch.Stop();
        }
        public Mass5(int[] qwe)
        {
            Mas(qwe);
            Console.Write("Сортировка пузырьковым методом.\n");
            VodMas1(qwe);
        }
    }

    public class Program
    {
        static void Main() // Основной метод.
        {
            Mass1 mass1 = new Mass1(Mass.Zapoln1());
            Mass2 mass2 = new Mass2(Mass.Zapoln1());
            Mass3 mass3 = new Mass3(Mass.Zapoln1());
            Mass4 mass4 = new Mass4(Mass.Zapoln1());
            Mass5 mass5 = new Mass5(Mass.Zapoln1());
        }
    }

}