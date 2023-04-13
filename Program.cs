using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace RanSanMoi
{	
	public class Program : Form
	{	
		static void Main(string[] args)
		{	
			Program snake = new Program();
			while (true)
			{
				snake.WriteBoard();
				snake.Input();
				snake.Logic();
			}
		}

        int Height = 20;
        int Width = 30;

        int[] X = new int[50];
		int[] Y = new int[50];

		int foodX;
		int foodY;

		int parts = 5;

		ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
		char key = 'O';

		Random random = new Random();

		public Program()
		{
			 X[0] = 5;
			Y[0] = 5;
			Console.CursorVisible = false;
			foodX = random.Next(2, (Width - 2));
			foodY = random.Next(2, (Height - 2));
		}

		public void WriteBoard()
        {
            Console.Clear();
            for (int i = 1; i <= (Width + 87); i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
            }
            for (int i = 1; i <= (Width + 87); i++)
            {
                Console.SetCursorPosition(i, (Height + 9));
                Console.Write("■");
            }
            for (int i = 0; i <= (Height + 9); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("■");
            }
            for (int i = 0; i <= (Height + 9); i++)
            {
                Console.SetCursorPosition((Width + 88), i);
                Console.Write("■");
            }
        }

        public void Input()
		{
			if (Console.KeyAvailable)
			{
				keyInfo = Console.ReadKey(true);
				key = keyInfo.KeyChar;
			}
		}

		public void WritePoint(int x, int y)
		{
			Console.SetCursorPosition(x, y);
			Console.Write("O");
		}

		public void Logic()
		{
			if (X[0] == foodX)
			{
				if (Y[0] == foodY)
				{
					parts++;
					foodX = random.Next(2, (Width - 2));
					foodY = random.Next(2, (Height - 2));
				}
			}
			for (int i = parts; i > 1; i--)
			{
				X[i - 1] = X[i - 2];
				Y[i - 1] = Y[i - 2];
			}
			switch (key)
			{
				case 'w':
					Y[0]--;
					break;
				case 's':
					Y[0]++;
					break;
				case 'd':
					X[0]++;
					break;
				case 'a':
					X[0]--;
					break;
			}
			for (int i = 0; i <= (parts - 1); i++)
			{
				WritePoint(X[i], Y[i]);
				WritePoint(foodX, foodY);
			}
			Thread.Sleep(50);
		}		
	}
}
