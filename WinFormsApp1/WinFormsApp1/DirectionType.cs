using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    /// <summary>
    /// Направление перемещения
    /// </summary>
    public enum DirectionType
    {
        /// <summary>
        /// Нет направления
        /// </summary>
        None = 0,

        /// <summary>
        /// Вверх
        /// </summary>
        Up = 1,

        /// <summary>
        /// Вниз
        /// </summary>
        Down = 2,

        /// <summary>
        /// Влево
        /// </summary>
        Left = 3,

        /// <summary>
        /// Вправо
        /// </summary>
        Right = 4
    }
}
