using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Strategy.Domain.Models
{
    abstract public class GameElement
    {
        /// <summary>
        /// Координата x объекта на карте.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата y объекта на карте.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Картинка объекта на карте.
        /// </summary>
        abstract public ImageSource GameElementSource { get; }
    }
}
