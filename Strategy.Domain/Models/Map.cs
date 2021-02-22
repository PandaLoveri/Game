using System.Collections.Generic;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Карта.
    /// </summary>
    public sealed class Map
    {
        /// <inheritdoc />
        public Map(IReadOnlyList<object> ground, IReadOnlyList<object> units)
        {
            Ground = ground;
            Units = units;
        }


        /// <summary>
        /// Поверхность под ногами.
        /// </summary>
        public IReadOnlyList<object> Ground { get; }

        /// <summary>
        /// Список юнитов.
        /// </summary>
        public IReadOnlyList<object> Units { get; }

        /// <summary>
        /// Можно ли юнит передвинуть в указанную клетку.
        /// </summary>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMoveUnit(int x, int y)
        {
            foreach (GameElement g in this.Ground)
            {
                if (g is Water w && w.X == x && w.Y == y)
                {
                    return false;
                }
            }

            foreach (Unit u1 in this.Units)
            {
                if (u1.X == x && u1.Y == y)
                    return false;
            }

            return true;
        }

    }
}