﻿using Snake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Init();
            Game.LoadlLevel(Game.level);
            
            while (Game.isActive)
            {
                Game.Draw();
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Game.snake.Move(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        Game.snake.Move(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        Game.snake.Move(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        Game.snake.Move(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        Game.isActive = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
            }

            Console.ReadKey();



        }
    }
}