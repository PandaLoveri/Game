using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Проходимая поверхность на земле.
    /// </summary>
    public sealed class Grass:GameElement
    {
        /// <inheritdoc />
        public Grass() : base() { }

        //перегруженный метод получения картинки с присвоением
        public override ImageSource GameElementSource => new BitmapImage(new Uri("Resources/Ground/Grass.png", UriKind.Relative));

    }
}