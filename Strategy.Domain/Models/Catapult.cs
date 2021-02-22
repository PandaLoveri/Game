using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    public sealed class Catapult:Unit
    {
        /// <inheritdoc />
        public Catapult(Player player) : base(player, health: 75) { }

        public override int MovingDistance => 1;

        public override int MaxStrikeRange => 10;

        public override int Damage => 100;

        //перегруженный метод получения картинки с присвоением
        //public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Units/Catapult.png", UriKind.Relative));
        public override ImageSource GameElementSource
        {
            get
            {
                if (this.IsDead)
                    new BitmapImage(new Uri("Resources/Units/Dead.png", UriKind.Relative));
                return new BitmapImage(new Uri("Resources/Units/Catapult.png", UriKind.Relative));
            }
        }

    }
}