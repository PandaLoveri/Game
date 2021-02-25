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
            foreach (GameElement gameElement in this.Ground)
            {
                if (!gameElement.IsSafeForMovement && gameElement.X==x && gameElement.Y==y)
                {
                    return false;
                }
            }

            foreach (Unit unit in this.Units)
            {
                if (unit.X == x && unit.Y == y)
                    return false;
            }

            return true;
        }

    }
}