using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    abstract public class Unit:GameElement
    {
        public Unit(Player player, int health=0)
        {
            Player = player;
            Health = health;
        }

        /// <summary>
        /// Игрок, который управляет юнитом.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Очки жизни юнита.
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        ///Проверить мертв ли юнит.
        /// </summary>
        public bool IsDead => Health == 0;

        /// <summary>
        ///  Количество клеток, на которые юнит может перемещаться.
        /// </summary>
        abstract public int MovingDistance { get; }

        /// <summary>
        /// Может ли юнит передвинуться в указанную клетку.
        /// </summary>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        /// <returns>
        /// <see langvalue="true" />, если юнит может переместиться
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanMove(int x, int y)
        {
            if (Math.Abs(this.X - x) > MovingDistance || Math.Abs(this.Y - y) > MovingDistance)
                return false;

            return true;
        }

        /// <summary>
        /// Передвинуть юнита в указанную клетку.
        /// </summary>
        /// <param name="x">Координата X клетки.</param>
        /// <param name="y">Координата Y клетки.</param>
        public void Move(int x, int y)
        {            
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Максимальная дальность удара юнита.
        /// </summary>
        abstract public int MaxStrikeRange { get; }

        /// <summary>
        /// Урон, наносимый юнитом.
        /// </summary>
        abstract public int Damage { get; }

        /// <summary>
        /// Проверить, может ли один юнит атаковать другого.
        /// </summary>
        /// <param name="targetUnit">Юнит, который является целью.</param>
        /// <returns>
        /// <see langvalue="true" />, если атака возможна
        /// <see langvalue="false" /> - иначе.
        /// </returns>
        public bool CanAttack(Unit targetUnit)
        {
            Player playerTargetUnit = targetUnit.Player;

            if (targetUnit.IsDead)
                return false;

            if (Player == playerTargetUnit)
                return false;

            var dx = X - targetUnit.X;
            var dy = Y - targetUnit.Y;

            return Math.Abs(dx) <= MaxStrikeRange && Math.Abs(dy) <= MaxStrikeRange;
        }

        /// <summary>
        /// Атаковать юнита.
        /// </summary>
        /// <param name="targetUnit">Юнит, который является целью.</param>
        public void Attack(Unit targetUnit)
        {
            var targetUnitHealth = targetUnit.Health;

            int damage = this.Damage;

            var dx = this.X - targetUnit.X;
            var dy = this.Y - targetUnit.Y;

            if (this is Archer || this is Catapult)
            {
                if (Math.Abs(dx) <= 1 && Math.Abs(dy) <= 1)
                {
                    damage /= 2;
                }
            }

            targetUnit.Health = Math.Max(targetUnitHealth - damage, 0);
        }

        public override bool IsSafeForMovement => false;
    }
}
