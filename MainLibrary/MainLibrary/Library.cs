using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary
{
    public class Library
    {
        public static int ReadInt()
        {
            int n;
            do
            {
            } while (!Int32.TryParse(Console.ReadLine(), out n));
            return n;
        }
        public static double ReadDouble()
        {
            double n;
            do
            {
            } while (!Double.TryParse(Console.ReadLine(), out n));
            return n;
        }
        public static int[] CreateMass(int n)
        {
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите " + (i + 1) + " элемент массива: ");
                mas[i] = ReadInt();
            }
            WriteMass(mas);
            return mas;
        }
        public static bool WriteOrRandom(string s)
        {
            Console.Write(s);
            Console.WriteLine("(Y/N)");
            string answer;
            bool YN1 = false;
            int YN = -1;
            do
            {
                answer = Console.ReadLine();
                if (answer.IndexOf("Y") == 0 | answer.IndexOf("y") == 0 | answer.IndexOf("н") == 0 | answer.IndexOf("Н") == 0)
                {
                    YN = 1;
                    YN1 = true;
                }
                if (answer.IndexOf("N") == 0 | answer.IndexOf("n") == 0 | answer.IndexOf("т") == 0 | answer.IndexOf("Т") == 0)
                {
                    YN = 0;
                    YN1 = false;
                }
                if (YN == -1) Console.WriteLine("Повторите ввод");
            } while (YN == -1);
            return YN1;
        }
        public static int BinaruSearch(int[] mas, int key, int left, int right, ref int c)
        {
            int mid = left + (right - left) / 2;
            c++;
            if (c <= mas.Length / 2)
            {

                if (mas[mid] == key)
                {
                    Console.WriteLine("Это число находится под номером {0}", mid + 1);
                    return mid;
                }
                else
                {
                    if (key == mas[left])
                    {
                        Console.WriteLine("Это число находится под номером {0}", left + 1);
                        return mid;
                    }
                    else
                        if (key == mas[right])
                    {
                        Console.WriteLine("Это число находится под номером {0}", right + 1);
                        return mid;
                    }
                    if (mas[mid] > key)
                        return BinaruSearch(mas, key, left, mid, ref c);
                    else
                        return BinaruSearch(mas, key, mid + 1, right, ref c);
                }

            }
            else
            {
                Console.WriteLine("Такого числа нет");
                return mid;
            }
        }

        public static void SimpleSelectSort(int[] mas, ref bool Ok)
        {
            Console.WriteLine("СОРТИРУЮ!!!");
            Ok = true;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min]) min = j;

                }
                int Tmp = mas[i];
                mas[i] = mas[min];
                mas[min] = Tmp;
            }
        }

        public static void SearchNeg(int[] mas)
        {
            bool ok = true;
            int i = 0;
            do
            {
                if (mas[i] < 0)
                {
                    Console.WriteLine("Первое отрицательное число: {0}", mas[i]);
                    ok = false;
                }
                i++;
            } while (ok == true && i < mas.Length);
            if (ok == true) Console.WriteLine("Отрицательных чисел нет");
        }

        public static void SwapMinAndMax(int[] mas)
        {
            Console.WriteLine("Меняю минимальное с максимальным местами");
            int max = mas[0], min = mas[0];
            int imax = 0, imin = 0;
            for (int i = 1; i < mas.Length; i++)
            {
                if (mas[i] < min)
                {
                    imin = i;
                    min = mas[i];
                }
                if (mas[i] > max)
                {
                    imax = i;
                    max = mas[i];
                }
            }
            int Prost = max;
            mas[imax] = mas[imin];
            mas[imin] = Prost;
        }
        public static int[] SimpleAddInMassAtTheBeginning(int[] mas, int number)
        {
            int[] mas2 = new int[mas.Length + 1];
            if (mas.Length != 0)
                for (int i = 1; i < mas.Length - 1; i++) mas2[i] = mas[i - 1];
            mas2[0] = number;
            return mas2;
        }

        public static int[] AddInMass(int[] mas, int k)
        {
            int[] mas2 = new int[mas.Length + k];
            int[] mas3 = mas;
            Random rand = new Random();
            mas = mas2;
            bool YN = WriteOrRandom("Хотите вводить добавляемые элементы сами?");
            for (int i = 0; i < mas3.Length; i++) mas[i] = mas3[i];
            for (int i = mas.Length - k; i < mas.Length; i++)
            {
                bool ok = false;
                do
                {
                    try
                    {
                        if (YN == true)
                        {
                            Console.WriteLine("Введите {0} элемент :", i + 1);
                            mas[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            mas[i] = rand.Next(2000) - 1000;
                        }
                        ok = true;
                    }
                    catch (FormatException)
                    {
                        ok = false;
                    }
                } while (!ok);
            }
            Console.WriteLine();
            return mas;
        }
        public static int[] RandomMass(int n)
        {
            int[] mas = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(2000) - 1000;
                Console.Write("{0} ", mas[i]);
            }
            Console.WriteLine();
            return mas;
        }

        public static void WriteMass(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.Write("{0} ", mas[i]);
            }
            Console.WriteLine();
        }
        public static void WriteMass(double[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] DeletChet(int[] mas)
        {
            if (mas.Length == 0)
            {
                Console.WriteLine("Йо, массив пуст");
                Console.WriteLine();
                return null;
            }
            else
            {
                Console.WriteLine("Происходит удаление всех нечетных элементов");
                int n = Convert.ToInt32(Math.Floor(mas.Length / 2.0));
                int[] mas2 = new int[n];
                int c = 0;
                for (int i = 1; i < mas.Length; i++) if (i % 2 == 1)
                    {
                        mas2[c] = mas[i];
                        c++;
                    }
                mas = mas2;
                WriteMass(mas);
                if (mas.Length == 0)
                {
                    Console.WriteLine("Йо, я удалил массив полностью");
                    Console.WriteLine();
                }
                return mas;
            }
        }
        public static double[] DeletChet(double[] mas)
        {
            if (mas.Length == 0)
            {
                Console.WriteLine("Ой, массив пуст");
                Console.WriteLine();
                return null;
            }
            else
            {
                Console.WriteLine("Происходит удаление");
                int n;
                if (mas.Length % 2 == 1) n = mas.Length / 2 + 1;
                else
                    n = mas.Length / 2;
                double[] mas2 = new double[n];
                int c = 0;
                for (int i = 0; i < mas.Length; i += 2) if (i < mas.Length)
                    {
                        mas2[c] = mas[i];
                        c++;
                    }
                if (mas.Length == 0)
                {
                    Console.WriteLine("Ой,массив полностью удален");
                    Console.WriteLine();
                }
                return mas2;
            }
        }
        public static void DeleteFromMass(int[][] rvanimas)
        {
            Console.WriteLine("Cколько удалять будем?");
            int k;
            do
            {
                k = ReadInt();
                if (k < 0) Console.WriteLine("Как я могу такое сделать?(Никак)");
            } while (k < 0);
            if (k > rvanimas.GetLength(0))
            {
                Console.WriteLine("Да ты хочешь удалить больше чем есть в массиве элементов");
            }
            else
            {
                Console.WriteLine("С какого элемента будем удалять?(включительно)");
                int n1;
                do
                {
                    n1 = ReadInt();
                } while (n1 <= 0);
                Console.WriteLine();
                if (k + n1 <= rvanimas.GetLength(0) + 1)
                {
                    if (rvanimas.GetLength(0) - k == 0)
                    {
                        Console.WriteLine("Массив полностью удален");
                    }
                    else
                    {
                        int[][] rvanimas1 = new int[rvanimas.GetLength(0) - k][];
                        int c = 0;
                        for (int i = 0; i < rvanimas.GetLength(0); i++)
                        {
                            if ((i < n1 - 1 || i >= n1 + k - 1) && c < rvanimas.GetLength(0) - k)
                            {
                                rvanimas1[c] = rvanimas[i];
                                c++;
                            }
                        }
                        foreach (int[] ints in rvanimas1)
                        {
                            foreach (int i in ints)
                            {
                                Console.Write(i + " ");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Выход за границу массива");
                }
            }
        }

        public static int[][] CreatMass()
        {
            int n;
            Console.WriteLine("Введите кол-во строк в массиве. Столбцы будут определены случаенно от 1 до 10 или введены вами");
            do
            {
                n = ReadInt();
            } while (n <= 0);
            int[][] rvanimas = new int[n][];
            bool YN = WriteOrRandom("Вы хотите что-то менять в массиве?");
            Random rand1 = new Random();
            if (YN == true)
            {
                for (int i = 0; i < rvanimas.GetLength(0); i++)
                {
                    YN = WriteOrRandom("Будете вводить кол-во строк " + (i + 1) + " в массиве?");
                    int x = 0;
                    if (YN == true)
                    {
                        x = ReadInt();
                    }
                    else
                    {
                        x = rand1.Next(9) + 1;
                    }
                    rvanimas[i] = new int[x];
                    YN = WriteOrRandom("Будете вводить числа для " + (i + 1) + " массива");
                    if (YN == true)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write("Введите {0} элемент: ", j + 1);
                            rvanimas[i][j] = ReadInt();
                        }
                    }
                    else
                    {
                        for (int j = 0; j < x; j++)
                        {
                            rvanimas[i][j] = rand1.Next(2000) - 1000;
                            Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                WriteMass(rvanimas);
            }
            else
            {
                for (int i = 0; i < rvanimas.GetLength(0); i++)
                {
                    int x = rand1.Next(9) + 1;
                    rvanimas[i] = new int[x];
                    for (int j = 0; j < x; j++)
                    {
                        rvanimas[i][j] = rand1.Next(2000) - 1000;
                        Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            return rvanimas;
        }

        public static void WriteMass(int[][] rvanimas)
        {
            for (int i = 0; i < rvanimas.GetLength(0); i++)
            {
                for (int j = 0; j < rvanimas[i].Length; j++)
                {
                    Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                }
                Console.WriteLine();
            }
        }

        public static void Up(int[,] array1, int[,] array, ref int i, ref int i2, ref int number)
        {
            while (i >= 0)
            {
                number++;
                array1[i, i2 + 1] = array[i, i2];
                i--;
            }
            i++;
            i2++;
        }

        public static void Down(int[,] array1, int[,] array, ref int i, ref int i2, ref int number)
        {
            while (i < array.GetLength(0))
            {
                number++;
                array1[i, i2 + 1] = array[i, i2];
                i++;
            }
            i--;
            i2++;
        }

        public static int[,] CreateMass()
        {
            Console.WriteLine("Введите кол-во строк");
            int n = ReadInt();
            Console.WriteLine("Введите кол-во столбцов");
            int n1 = ReadInt();
            if (n == 0 || n1 == 0)
            {
                Console.WriteLine("Такого не могу");
                return null;
            }
            else
            {
                bool YN = WriteOrRandom("Будете вводить числа в массив?");
                int[,] masDoub = new int[n, n1];
                if (YN == true)
                {
                    int number = 1;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n1; j++)
                        {
                            Console.Write("Введите " + (number++) + " элемент: ");
                            masDoub[i, j] = ReadInt();
                        }
                    }
                }
                else
                {
                    Random rand = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n1; j++)
                        {
                            masDoub[i, j] = rand.Next(2000) - 1000;
                        }
                    }
                }
                WriteMass(masDoub);
                return masDoub;
            }
        }
        public static char[][] CreatMassCh()
        {
            int n;
            string mass = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Console.WriteLine("Введите кол-во строк в массиве. Столбцы будут определены случаенно от 1 до 10 или введены вами");
            n = ReadIntMoreThan(0);
            char[][] rvanimas = new char[n][];
            bool YN = WriteOrRandom("Вы хотите что-то менять в массиве?");
            Random rand1 = new Random(DateTime.Now.Millisecond);
            if (YN == true)
            {
                for (int i = 0; i < rvanimas.GetLength(0); i++)
                {
                    YN = WriteOrRandom("Будете вводить кол-во строк " + (i + 1) + " в массиве?");
                    int x = 0;
                    if (YN == true)
                    {
                        x = ReadIntMoreThan(0);
                    }
                    else
                    {
                        x = rand1.Next(9) + 1;
                    }
                    rvanimas[i] = new char[x];
                    YN = WriteOrRandom("Будете вводить элементы для " + (i + 1) + " массива");
                    if (YN == true)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            Console.Write("Введите {0} элемент: ", j + 1);
                            rvanimas[i][j] = ReadChar();
                        }
                    }
                    else
                    {
                        for (int j = 0; j < x; j++)
                        {
                            int c = rand1.Next(0, 10);
                            if (c > 3)
                                rvanimas[i][j] = Convert.ToChar(mass[(rand1.Next(mass.Length))]);
                            else
                                rvanimas[i][j] = Convert.ToChar(rand1.Next(0, 9));
                            Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Полный массив:");
                WriteMass(rvanimas);
            }
            else
            {
                for (int i = 0; i < rvanimas.GetLength(0); i++)
                {
                    int x = rand1.Next(9) + 1;
                    rvanimas[i] = new char[x];
                    for (int j = 0; j < x; j++)
                    {
                        rvanimas[i][j] = Convert.ToChar(mass[(rand1.Next(mass.Length))]);
                        Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            return rvanimas;
        }
        public static string RandomStringFT(int a, int b)
        {
            string s = "";
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZqwertyuiop[]asdfghjkl;'zxcvbnm,./<>?:}{[]+=_-0987654321!@#$%^&*()№|йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ".ToCharArray();
            Random rand = new Random();
            int RandNum = RandIntFT(a, b);
            for (int i = 0; i < RandNum; i++)
                s += letters[RandIntFT(0, letters.Length)];
            return s;
        }

        public static int RandIntFT(int left, int right)
        {
            Random rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rnd = rndNum.Next(left, right);
            return rnd;
        }
        public static double RandomDouble(int a, int b)
        {
            double info = RandIntFT(a, b);
            Random fixRand = new Random(123);
            info += fixRand.NextDouble();
            return info;
        }
        public static void WriteMass(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(String.Format("{0,5}", array[i, j]));
                Console.WriteLine();
            }
        }
        public static void WriteMass(char[][] rvanimas)
        {
            for (int i = 0; i < rvanimas.GetLength(0); i++)
            {
                for (int j = 0; j < rvanimas[i].Length; j++)
                {
                    Console.Write(String.Format("{0,5}", rvanimas[i][j]));
                }
                Console.WriteLine();
            }
        }
        public static int[] DeleteFromK(int n, int[] mas)
        {
            Console.WriteLine("Cколько удалять будем?");
            int k;
            do
            {
                k = ReadInt();
                if (k < 0) Console.WriteLine("Как я могу такое сделать?(Никак)");
            } while (k < 0);
            if (k > n)
            {
                Console.WriteLine("Да вы хотите удалить больше чем есть в массиве элементов");
            }
            else
            {
                Console.WriteLine("С какого элемента будем удалять?(включительно)");
                int n1;
                do
                {
                    n1 = ReadInt();
                } while (n1 <= 0);
                if (k + n1 <= mas.Length + 1)
                {
                    if (mas.Length - k == 0)
                    {
                        Console.WriteLine("Массив полностью удален");
                    }
                    else
                    {
                        int[] mas2 = new int[mas.Length - k];
                        int c = 0;
                        for (int i = 0; i < mas.Length; i++)
                        {
                            if ((i < n1 - 1 || i >= n1 + k - 1) && c < mas.Length - k)
                            {
                                mas2[c] = mas[i];
                                c++;
                            }
                        }
                        mas = mas2;
                        WriteMass(mas);
                    }
                }
                else
                {
                    Console.WriteLine("Выход за границу массива");
                }
            }

            return mas;
        }
        public static char[][] DeletStroky(char[][] mas, int i)
        {
            char[][] rvanimas1 = new char[mas.GetLength(0) - 1][];
            int c = 0;
            for (int g = 0; g < mas.GetLength(0); g++)
            {
                if ((g < i || g > i) && c < mas.GetLength(0))
                {
                    rvanimas1[c] = mas[g];
                    c++;
                }
            }
            if (rvanimas1.Length == 0)
                Console.WriteLine("Массив стал пуст");
            else
                WriteMass(rvanimas1);
            return rvanimas1;
        }
        public static int ReadIntMoreThan(int k)
        {
            int n;
            bool ok = false;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (n <= k) ok = false;
                if (ok == false) Console.WriteLine("Повторите ввод");
            } while (ok == false);
            return n;
        }
        public static char ReadChar()
        {
            string s;
            char Ch = ' ';
            s = Console.ReadLine();
            try
            {
                Ch = Convert.ToChar(s);
            }
            catch
            {
                Console.WriteLine("Повторите воод");
                ReadChar();
            }
            return Ch;
        }
        public static char[][] CheckOnNumbers(char[][] mas)
        {
            int c1 = 0;
            bool ok = false;
            for (int i = mas.GetLength(0) - 1; i >= 0; i--)
            {
                c1 = 0;
                for (int j = 0; j < mas[i].Length; j++)
                {
                    if (mas[i][j] == '0' || mas[i][j] == '1' || mas[i][j] == '2' || mas[i][j] == '3' || mas[i][j] == '4' || mas[i][j] == '5' || mas[i][j] == '6' || mas[i][j] == '7' || mas[i][j] == '8' || mas[i][j] == '9') c1++;
                }
                if (c1 >= 3)
                {
                    DeletStroky(mas, i);
                    ok = true;
                    return mas;
                }
            }
            if (ok == false) Console.WriteLine("Ни в одной строке нет больше 2 чисел");
            return mas;
        }
        public class TreeNode
        {
            public int Info { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }
        public static TreeNode InputIdealTree(int size, TreeNode p, ref string s)
        {
            TreeNode r = new TreeNode();
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            r.Info = ReadIntMoreThan(0);
            int c = r.Info;
            c = CheckForInput(s, c, size);
            s += Convert.ToString(c) + " ";
            r.Left = InputIdealTree(nl, r.Left, ref s);
            r.Right = InputIdealTree(nr, r.Right, ref s);
            return r;
        }
        public static TreeNode RandomIdealTree(int size, TreeNode p, ref string s)
        {
            TreeNode r = new TreeNode();
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            r.Info = RandIntFT(0, size + 50);
            int c = r.Info;
            c = CheckForRandom(s, c, size);
            s = s + Convert.ToString(c) + " ";
            r.Left = RandomIdealTree(nl, r.Left, ref s);
            r.Right = RandomIdealTree(nr, r.Right, ref s);
            return r;
        }
        public static int CheckForInput(string s, int c, int size)
        {
            if (s.IndexOf(Convert.ToString(c)) > -1)
            {
                Console.WriteLine("Вы ввели число, которое уже есть в дереве.\nПовторите ввод");
                c = ReadInt();
                c = CheckForInput(s, c, size);
                //Console.WriteLine(c);
            }
            return c;
        }
        public static int CheckForRandom(string s, int c, int size)
        {
            if (s.IndexOf(Convert.ToString(c)) > -1)
            {
                c = RandIntFT(0, size + 50);
                c = CheckForRandom(s, c, size + 50);
                //Console.WriteLine(c);
            }
            return c;
        }

        public static void CheckForIntersections(TreeNode root, ref int[,] positions, int y, ref int[] roots)
        {
            RewriteTreeInMass(root, Math.Abs(y), 1, ref positions, 0);
            for (int i = 0; i < positions.GetLength(1) - 1; i++)
                for (int j = i + 1; j < positions.GetLength(1); j++)
                    if (positions[0, i] == positions[0, j] && positions[1, i] == positions[1, j])
                        roots = SimpleAddInMassAtTheBeginning(roots, positions[2, j]);
        }
        public static void RewriteTreeInMass(TreeNode root, int x, int y, ref int[,] positions, int position)
        {
            if (root == null)
                return;
            while (position < positions.GetLength(1) - 1 && positions[1, position] != 0) position++;
            positions[0, position] = x;
            positions[1, position] = y;
            positions[2, position] = root.Info;
            RewriteTreeInMass(root.Left, x - 7, y + 1, ref positions, position);
            RewriteTreeInMass(root.Right, x + 7, y + 1, ref positions, position);
        }
        public static void AddNode(ref TreeNode root, int info)
        {
            var newNode = new TreeNode { Info = info };
            if (root == null)
            {
                root = newNode;
                return;
            }
            var node = root;
            while (true)
            {
                if (node.Info > info)
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        return;
                    }
                    else
                        node = node.Left;
                else
                if (node.Info < info)
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        return;
                    }
                    else
                        node = node.Right;
                else return;
            }
        }
        static void PrintTree(TreeNode root, int x, int y, ref int[,] positions)
        {
            if (root == null)
                return;
            if (root.Left != null)
            {
                Console.SetCursorPosition(x - 7, y);
                Console.Write("┌──────");
            }

            if (root.Right != null)
            {
                Console.SetCursorPosition(x + 1, y);
                Console.Write("──────┐");
            }
            Console.SetCursorPosition(x, y);
            Console.Write(root.Info);
            PrintTree(root.Left, x - 7, y + 1, ref positions);
            PrintTree(root.Right, x + 7, y + 1, ref positions);
        }
        static void PrintTree(TreeNode root, int x, int y, ref int[,] positions, int[] roots, ref bool ok)
        {
            if (root == null)
                return;
            if (root.Left != null)
            {
                Console.SetCursorPosition(x - 7, y);
                Console.Write("┌──────");
            }
            if (root.Right != null)
            {
                Console.SetCursorPosition(x + 1, y);
                if (ok == true)
                    for (int i = 0; i < roots.Length + 1; i++)
                        Console.Write("───────");
                Console.Write("──────┐");
            }
            Console.SetCursorPosition(x, y);
            Console.Write(root.Info);
            if (ok == true)
            {
                PrintTree(root.Right, x + ((roots.Length + 2) * 7), y + 1, ref positions, roots, ref ok);
                ok = false;
            }
            else
                PrintTree(root.Right, x + 7, y + 1, ref positions, roots, ref ok);
            PrintTree(root.Left, x - 7, y + 1, ref positions, roots, ref ok);
        }
        static void CheckForLenght(TreeNode root, int x, ref int y)
        {
            if (root == null)
                return;
            if (y > x) y = x;
            CheckForLenght(root.Left, x - 7, ref y);
            CheckForLenght(root.Right, x + 7, ref y);
        }
        static void CheckForHeight(TreeNode root, int x, ref int y1)
        {
            if (root == null)
                return;
            if (y1 < x) y1 = x;
            CheckForHeight(root.Left, x + 1, ref y1);
            CheckForHeight(root.Right, x + 1, ref y1);
        }
        static public int RandomInt01(int num, int ChanseWithoutPoint)
        {
            int n = 10;
            while (ChanseWithoutPoint / n != 0)
                n *= 10;
            int[] mas = new int[n];
            for(int i = 0; i < ChanseWithoutPoint; i++)
                mas[i] = num;
            int c=1;
            if (num == 1) c = 0;
            for (int i = ChanseWithoutPoint; i < n; i++)
                mas[i] = c;
            return mas[RandIntFT(0, n)];
        }
    }
}
