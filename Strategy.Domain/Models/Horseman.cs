using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman:Unit
    {
        /// <inheritdoc />
        public Horseman(Player player) : base(player, health: 200) { }

        public override int MovingDistance => 10;

        public override int MaxStrikeRange => 1;

        public override int Damage => 75;

        //перегруженный метод получения картинки с присвоением
        //public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Units/Horseman.png", UriKind.Relative));
        public override ImageSource GameElementSource
        {
            get
            {
                if (this.IsDead)
                    new BitmapImage(new Uri("Resources/Units/Dead.png", UriKind.Relative));
                return new BitmapImage(new Uri("Resources/Units/Horseman.png", UriKind.Relative));
            }
        }
    }
}