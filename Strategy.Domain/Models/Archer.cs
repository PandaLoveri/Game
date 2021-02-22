using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer:Unit
    {
        /// <inheritdoc />
        public Archer(Player player) : base(player, health: 50) { }

        public override int MovingDistance => 3;

        public override int MaxStrikeRange => 5;

        public override int Damage => 50;

        //перегруженный метод получения картинки с присвоением
        //public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Units/Archer.png", UriKind.Relative));
        public override ImageSource GameElementSource
        {
            get
            {
                if (this.IsDead)
                    new BitmapImage(new Uri("Resources/Units/Dead.png", UriKind.Relative));
                return new BitmapImage(new Uri("Resources/Units/Archer.png", UriKind.Relative));
            }
        }

    }
}