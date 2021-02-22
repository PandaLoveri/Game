using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman:Unit
    {
        public Swordsman(Player player) : base(player, health: 100) { }

        public override int MovingDistance => 5;

        public override int MaxStrikeRange => 1;

        public override int Damage => 50;

        //перегруженный метод получения картинки с присвоением
        //public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Units/Swordsman.png", UriKind.Relative));
        public override ImageSource GameElementSource
        {
            get
            {
                if (this.IsDead)
                    new BitmapImage(new Uri("Resources/Units/Dead.png", UriKind.Relative));
                return new BitmapImage(new Uri("Resources/Units/Swordsman.png", UriKind.Relative));
            }
        }

    }
}