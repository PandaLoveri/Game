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
        /// <param name="o">Координаты объекта, которые необходимо получить.</param>
        /// <returns>Координата x, координата y.</returns>       
        public Coordinates GetObjectCoordinates(GameElement o)
        {
            return new Coordinates(o.X, o.Y);
        }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMoveUnit(Unit u, int x, int y)
        {
            if (!u.CanMove(x, y))
                return false;

            return _map.CanMoveUnit(x, y);
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="u">Юнит.</param>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void MoveUnit(Unit u, int x, int y)
        {
            if (!CanMoveUnit(u, x, y))
                return;

            u.Move(x, y);
        }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttackUnit(Unit au, Unit tu)
        {
            return au.CanAttack(tu);
        }

        /// <summary>
        /// Атаковать указанного юнита.
        /// </summary>
        /// <param name="au">Юнит, который собирается совершить атаку.</param>
        /// <param name="tu">Юнит, который является целью.</param>
        public void AttackUnit(Unit au, Unit tu)
        {
            if (!CanAttackUnit(au, tu))
                return;

            au.Attack(tu);
        }

        /// <summary>
        /// Получить изображение объекта.
        /// </summary>
        public ImageSource GetObjectSource(GameElement o)
        {
            return o.GameElementSource;
        }
        
    }
}