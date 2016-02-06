using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
   [Serializable]

    public class Snake : Drawer
    {
        // snake belgisi
        public Snake()
        {
            sign = '*';
        }

        public void Move(int dx, int dy)
        {
          
            // snake kozgaltu barisi
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            

            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
            // foodti jegennen kein scorega 1 kosamiz.
            if (Game.snake.body[0].x == Game.food.body[0].x &&
               Game.snake.body[0].y == Game.food.body[0].y)
            {
                Game.ss++;
                if (Game.ss%4==0)
                {
                    Game.level++;
                    Console.Clear();
                    Game.isActive = false;
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Next level!!!");
                    Game.Init();
                    Game.LoadlLevel(Game.level);
                    
                }
                // snake 1 nukte kosamiz
                Game.snake.body.Add(new Point
                {
                    x = Game.food.body[0].x,
                    y = Game.food.body[0].y
                });
                // random jerden food wigaramiz
                if (Game.FoodinWall()!=true)
                {
                    Game.food.body[0].x = new Random().Next(1, 39);
                    Game.food.body[0].y = new Random().Next(1, 14);
                }
                while (Game.FoodinWall() == true)
                {
                    Game.food.body[0].x = new Random().Next(1, 39);
                    Game.food.body[0].y = new Random().Next(1, 14);
                }
            }
            // wallga snake tiip ketken jagdaida oin toktatamiz
            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x &&
       Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game over!");
                    Game.isActive = false;
                }
            }

        }
    }
}