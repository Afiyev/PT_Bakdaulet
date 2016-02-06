using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Models
{
    [Serializable]
    public class Wall : Drawer
    {
        // wall belgisi
        public Wall()
        {
            sign = '#';
        }
    }
}