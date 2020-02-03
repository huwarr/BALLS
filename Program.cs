using System;
using System.Threading;

namespace Game_Balls
{
    class Program
    { 
        static void BALL(char[,] balls, int[,] ballsColors)
        {
            Console.Write("Enter the initial number of balls: ");
            int n = int.Parse(Console.ReadLine()) - 1;
            try
            {
                if (n < 1 | n > 80) throw new Exception();
            }
            catch (Exception)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You entered invalid number for the amount of balls");
                Environment.Exit(1);
            }
            int i, k, color;
            int count = 0;
            char b = (char)9830;
            Random rand = new Random();
            while (count < n)
            {
                i = rand.Next(9);
                k = rand.Next(9);
                if (balls[i, k] != b)
                {
                    balls[i, k] = b;
                    color = rand.Next(1, 8);
                    sw(color);
                    ballsColors[i, k] = color;
                }
                else continue;
                count++;
            }
        }

        static void sw(int color)
        {
            switch (color)
            {
                case 1: Console.ForegroundColor = ConsoleColor.Black; break;
                case 2: Console.ForegroundColor = ConsoleColor.Red; break;
                case 3: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 4: Console.ForegroundColor = ConsoleColor.White; break;
                case 5: Console.ForegroundColor = ConsoleColor.Green; break;
                case 6: Console.ForegroundColor = ConsoleColor.Blue; break;
                default: Console.ForegroundColor = ConsoleColor.Magenta; break;
            }
        }




        static void field(int[,] b, int again)
        {
            Console.ResetColor();
            Console.Clear();
            int i, k;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  1 2 3 4 5 6 7 8 9");
            char fence = (char)9608;
            Console.Write(" ");
            for (int j = 1; j < 20; j++)
                Console.Write("{0}", fence);


            if (again == 0)
            {
                Random rand = new Random();
                int count = 0;

                while (count < 1)
                {
                    i = rand.Next(9);
                    k = rand.Next(9);
                    if (b[i, k] == 0)
                    {
                        b[i, k] = rand.Next(1, 8);
                        sw(b[i, k]);

                    }
                    else continue;
                    count++;
                }
            }
            


            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (i = 0; i < 9; i++)
            {
                Console.Write("\n{0}{1}", i + 1, fence);
                for (k = 0; k < 9; k++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    if (b[i, k] != 0)
                    {
                        sw(b[i, k]);
                        Console.Write((char)9830);
                    }
                    else Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (k != 8) Console.Write("|");
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(fence);
                if (i != 8)
                {
                    Console.Write("\n {0}", fence);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    for (k = 0; k < 17; k++) Console.Write("-");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(fence);
                }
            }
            Console.Write("\n ");
            for (int j = 1; j < 20; j++)
                Console.Write("{0}", fence);
        }

        static void scoreTable(int score)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(23, 3);
            Console.Write("Score: {0}", score);
            Console.ResetColor();
        }




        static void choose (int[,] b, int i1, int k1)
        {
            sw(b[k1, i1]);
            Console.SetCursorPosition((i1 + 1) * 2, (k1 + 1) * 2);
            if (b[k1, i1] != 0) Console.Write((char)9830);
            else Console.Write(" ");

        }

        static void delete (int[,] b, int i1, int k1)
        {
            Console.SetCursorPosition((i1 + 1) * 2, (k1 + 1) * 2);
            Console.Write(" ");
        }

        static void write (int[,] b, int i1, int k1)
        {
            Console.SetCursorPosition((i1 + 1) * 2, (k1 + 1) * 2);
            Console.Write((char)9830);
        }

        static void arrow(ConsoleKeyInfo k, ref int i1, ref int k1, int[,] b)
        {
            if (k.Key == ConsoleKey.UpArrow & k1-1>=0 && b[k1 - 1, i1]==0) k1--;
            else if (k.Key == ConsoleKey.DownArrow & k1 + 1 <= 8 && b[k1 + 1, i1] == 0) k1++;
            else if (k.Key == ConsoleKey.LeftArrow & i1 - 1 >= 0 && b[k1, i1-1] == 0) i1--;
            else if (k.Key == ConsoleKey.RightArrow & i1 + 1 <= 8 && b[k1, i1+1] == 0) i1++;
        }

        static void arrow2(ConsoleKeyInfo k, ref int i1, ref int k1, int[,] b)
        {
            if (k.Key == ConsoleKey.UpArrow & k1 - 1 >= 0) k1--;
            else if (k.Key == ConsoleKey.DownArrow & k1 + 1 <= 8) k1++;
            else if (k.Key == ConsoleKey.LeftArrow & i1 - 1 >= 0) i1--;
            else if (k.Key == ConsoleKey.RightArrow & i1 + 1 <= 8) i1++;
        }


        static void emergencyExit(int score)
        {
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("EMERGENCY EXIT");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(2, 3);
            Console.WriteLine("SCORE: {0}", score);
            Environment.Exit(0);
        }
        


        static void move(int[,] b, int score)
        {
            int i1 = 0, k1 = 0, st=0, color;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            choose(b, i1, k1);
            ConsoleKeyInfo k;
            while (st == 0)
            {
                k = Console.ReadKey(true);
                Console.BackgroundColor = ConsoleColor.Gray;
                choose(b, i1, k1);

                if (k.Key == ConsoleKey.Spacebar)
                    emergencyExit(score);

                if (k.Key == ConsoleKey.Enter & b[k1, i1] != 0) break;

                arrow2(k, ref i1, ref k1, b);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                choose(b, i1, k1);

            }

            sw(b[k1, i1]);
            color = b[k1, i1];
            b[k1, i1] = 0;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            write(b, i1, k1);



            while (st == 0)
            {
                k = Console.ReadKey(true);
                Console.BackgroundColor = ConsoleColor.Gray;
                delete(b, i1, k1);
                
                if (k.Key == ConsoleKey.Spacebar)
                    emergencyExit(score);

                if (k.Key == ConsoleKey.Enter) break;


                arrow(k, ref i1, ref k1, b);

                Console.BackgroundColor = ConsoleColor.DarkGray;
                write(b, i1, k1);

            }

            Console.BackgroundColor = ConsoleColor.Gray;
            write(b, i1, k1);
            b[k1, i1] = color;
        }

        static void goriz (int[,] b, ref int count)
        {
            int i = 1, k = 0, i1, color;
            bool was = false;
            for(; k<9; k++)
            {
                for (i = 1; i < 8; i++)
                {
                    if (b[k, i] != 0 & b[k, i] == b[k, i - 1] & b[k, i] == b[k, i + 1]) 
                    {
                        was = true;
                        sw(b[k, i]);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        write(b, i, k);
                        write(b, i-1, k);
                        write(b, i+1, k);
                        count += 3;
                        color = b[k, i];
                        b[k, i] = 0;
                        b[k, i - 1] = 0;
                        b[k, i + 1] = 0;
                        i1 = i-2;
                        while (i1>0)
                        {
                            if (b[k, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k);
                                count++;
                                b[k, i1] = 0;
                                i1--;
                            }
                            else break;
                        }
                        i1 = i + 2;
                        while (i1 < 9)
                        {
                            if (b[k, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k);
                                b[k, i1] = 0;
                                i1++;
                                count++;
                            }
                            else break;
                        }
                    }
                }
            }
            if (was)  Thread.Sleep(1500);
            was = false;
        }

        static void vert(int[,] b, ref int count)
        {
            int i = 0, k = 1, k1, color;
            bool was = false;
            for (; i < 9; i++)
            {
                for (k = 1; k < 8; k++)
                {
                    if (b[k, i] != 0 & b[k, i] == b[k-1, i] & b[k, i] == b[k+1, i])
                    {
                        was = true;
                        sw(b[k, i]);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        write(b, i, k);
                        write(b, i, k-1);
                        write(b, i, k+1);
                        count += 3;
                        color = b[k, i];
                        b[k, i] = 0;
                        b[k-1, i] = 0;
                        b[k+1, i] = 0;
                        k1 = k - 2;
                        while (k1 > 0)
                        {
                            if (b[k1, i] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i, k1);
                                count++;
                                b[k1, i] = 0;
                                k1--;
                            }
                            else break;
                        }
                        k1 = k + 2;
                        while (k1 < 9)
                        {
                            if (b[k1, i] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i, k1);
                                b[k1, i] = 0;
                                k1++;
                                count++;
                            }
                            else break;
                        }
                    }
                }
            }
            if (was) Thread.Sleep(1500);
            was = false;
        }

        static void diag1 (int[,] b, ref int count)
        {
            int i = 1, k = 1, i1, k1, color;
            bool was = false;
            for (; i < 8; i++)
            {
                for (k = 1; k < 8; k++)
                {
                    if (b[k, i] != 0 & b[k, i] == b[k - 1, i-1] & b[k, i] == b[k + 1, i+1])
                    {
                        was = true;
                        sw(b[k, i]);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        write(b, i, k);
                        write(b, i-1, k - 1);
                        write(b, i+1, k + 1);
                        count += 3;
                        color = b[k, i];
                        b[k, i] = 0;
                        b[k - 1, i-1] = 0;
                        b[k + 1, i+1] = 0;
                        k1 = k - 2;
                        i1 = i - 2;
                        while (k1 > 0 & i1>0)
                        {
                            if (b[k1, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k1);
                                count++;
                                b[k1, i1] = 0;
                                i1--;
                                k1--;
                            }
                            else break;
                        }
                        k1 = k + 2;
                        i1 = i + 2;
                        while (k1 < 9 & i1<9)
                        {
                            if (b[k1, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k1);
                                b[k1, i1] = 0;
                                k1++;
                                i++;
                                count++;
                            }
                            else break;
                        }
                    }
                }
            }
            if (was) Thread.Sleep(1500);
            was = false;
        }

        static void diag2(int[,] b, ref int count)
        {
            int i = 1, k = 1, i1, k1, color;
            bool was = false;
            for (; i < 8; i++)
            {
                for (k = 1; k < 8; k++)
                {
                    if (b[k, i] != 0 & b[k, i] == b[k - 1, i + 1] & b[k, i] == b[k + 1, i - 1])
                    {
                        was = true;
                        sw(b[k, i]);
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        write(b, i, k);
                        write(b, i - 1, k + 1);
                        write(b, i + 1, k - 1);
                        count += 3;
                        color = b[k, i];
                        b[k, i] = 0;
                        b[k - 1, i + 1] = 0;
                        b[k + 1, i - 1] = 0;
                        k1 = k + 2;
                        i1 = i - 2;
                        while (k1 < 9 & i1 > 0)
                        {
                            if (b[k1, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k1);
                                count++;
                                b[k1, i1] = 0;
                                i1--;
                                k1++;
                            }
                            else break;
                        }
                        k1 = k - 2;
                        i1 = i + 2;
                        while (k1 > 0 & i1 < 9)
                        {
                            if (b[k1, i1] == color)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                write(b, i1, k1);
                                b[k1, i1] = 0;
                                k1--;
                                i++;
                                count++;
                            }
                            else break;
                        }
                    }
                }
            }
            if (was) Thread.Sleep(1500);
            was = false;
        }






        static void Main(string[] args)
        {
            char[,] balls = new char[9, 9];
            int[,] ballsColors = new int[9, 9];
            bool win = false;
            bool loose = false;
            BALL(balls, ballsColors);
            int st = 0, score = 0, again;
            while (st==0)
            {
                again = 0;
                Console.Clear();
                field(ballsColors, again);
                scoreTable(score);
                goriz(ballsColors, ref score);
                vert(ballsColors, ref score);
                diag1(ballsColors, ref score);
                diag2(ballsColors, ref score);
                foreach (int elem in ballsColors)
                {
                    if (elem != 0) loose = true;
                    else
                    {
                        loose = false;
                        break;
                    }
                }
                if (loose)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(23, 6);
                    Console.Write("YOU LOST, YOUR SCORE IS {0}", score);
                    Console.SetCursorPosition(2, 20);
                    break;
                }
                again++;
                Console.Clear();
                field(ballsColors, again);
                scoreTable(score);
                move(ballsColors, score);
                goriz(ballsColors, ref score);
                vert(ballsColors, ref score);
                diag1(ballsColors, ref score);
                diag2(ballsColors, ref score);

                foreach (int elem in ballsColors)
                {
                    if (elem == 0) win = true;
                    else
                    {
                        win = false;
                        break;
                    }
                }

                

                if (win)
                {
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(23, 6);
                    Console.Write("YOU WON, YOUR SCORE IS {0}", score);
                    Console.SetCursorPosition(2, 20);
                    break;
                }
            }
            Environment.Exit(0);
        }
    }
}