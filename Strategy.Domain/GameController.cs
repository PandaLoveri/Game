using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Strategy.Domain.Models;

namespace Strategy.Domain
{
    /// <summary>
    /// Контроллер хода игры.
    /// </summary>
    public class GameController
    {
        private readonly Map _map;
               
        /// <inheritdoc />
        public GameController(Map map)
        {
            _map = map;
        }

        /// <summary>
        /// Получить координаты объекта.
        /// </summary>
        /// <param name="gameElement">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>       
        public Coordinates GetObjectCoordinates(GameElement gameElement)
        {
            return new Coordinates(gameElement.X, gameElement.Y);
        }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="unit">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMoveUnit(Unit unit, int x, int y)
        {
            if (!unit.CanMove(x, y))
                return false;

            return _map.CanMoveUnit(x, y);
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="unit">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(Unit unit, int x, int y)
        {
            if (!CanMoveUnit(unit, x, y))
                return;

            unit.Move(x, y);
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="attackUnit">Юнит, который собирается совершить атаку.</param>
        /// <param name="targetUnit">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(Unit attackUnit, Unit targetUnit)
        {
            return attackUnit.CanAttack(targetUnit);
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="attackUnit">Юнит, который собирается совершить атаку.</param>
        /// <param name="targetUnit">Юнит, который является целью.</param>
        public void AttackUnit(Unit attackUnit, Unit targetUnit)
        {
            if (!CanAttackUnit(attackUnit, targetUnit))
                return;

            attackUnit.Attack(targetUnit);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(GameElement gameElement)
        {
            return gameElement.GameElementSource;
        }
        
    }
}