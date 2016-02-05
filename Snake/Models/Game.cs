using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{//fdsgfd
    public class Game
    {
        public static int level = 1;
        public static int ss = 0;
        public static bool isActive;
        public static Snake snake;
        public static Food food;
        public static Wall wall;
        
        

        public static void Init()
        {
            isActive = true;
            snake = new Snake();
            food = new Food();
            wall = new Wall();

            // bastapkida paida bolatin jerler
            snake.body.Add(new Point { x = 1, y = 1 });
            food.body.Add(new Point { x = 1, y = 2 });

            food.color = ConsoleColor.Green;
            wall.color = ConsoleColor.White;
            snake.color = ConsoleColor.Yellow;

            Console.SetWindowSize(40, 15);
            // oin otetin bolikterdi rewetkalarmen korwau
            for (int i = 0; i <= 40; i++)
            {
                wall.body.Add(new Point { x = i, y = 0 });
                wall.body.Add(new Point { x = i, y = 15 });
            }
            for (int i = 0; i <= 15; i++)
            {
                wall.body.Add(new Point { x = 0, y = i });
                wall.body.Add(new Point { x = 40, y = i });
            }
            for (int i = 43; i <= 65; i++)
            {
                wall.body.Add(new Point { x = i, y = 0 });
                wall.body.Add(new Point { x = i, y = 5 });
            }
            for (int i = 0; i <= 5; i++)
            {
                wall.body.Add(new Point { x = 43, y = i });
                wall.body.Add(new Point { x = 65, y = i });
            }

        }

        public static void LoadlLevel(int level)
        {
            // tiisti levelge bailanisti filedardi okimiz
            FileStream fs = new FileStream(string.Format(@"level{0}.txt", level), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);



            string line;
            int row = -1;
            int col = -1;

            // kartadani consolga wigaru
            while ((line = sr.ReadLine()) != null)
            {
                row++;
                col = -1;
                foreach (char c in line)
                {
                    col++;
                    if (c == '#')
                    {
                        wall.body.Add(new Point { x = col, y = row });
                    }
                }
            }
           


            sr.Close();
            fs.Close();
        }

        public static void Save()
        {
            wall.Save();
            snake.Save();
            food.Save();
        }

        public static void Resume()
        {
            wall.Resume();
            snake.Resume();
            food.Resume();
        }

        public static void Draw()
        {
            Console.Clear();
            snake.Draw();
            food.Draw();
            wall.Draw();
        }
    }
}