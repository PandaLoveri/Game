using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Непроходимая наземная поверхность.
    /// </summary>
    public sealed class Water:GameElement
    {
        /// <inheritdoc />
        public Water() : base() { }

        //перегруженный метод получения картинки с присвоением
        public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Ground/Water.png", UriKind.Relative));

    }
}