using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameInterface
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Эвент нажатия кнопки "Старт".
        /// </summary>
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new GamePage(Player1NameTextBox.Text, Player2NameTextBox.Text, GetItem(Player1ComboBox.SelectedIndex), GetItem(Player2ComboBox.SelectedIndex)) );
        }

        /// <summary>
        /// Изменение картинки для 1 игрока.
        /// </summary>
        private void ComboBox1_Selected(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show($"{Player1ComboBox.SelectedIndex}");           
            Player1Image.Source = new BitmapImage(new Uri($"Resources/Units/{GetItem(Player1ComboBox.SelectedIndex)}.png", UriKind.Relative));
        }

        /// <summary>
        /// Изменение картинки для 2 игрока.
        /// </summary>
        private void ComboBox2_Selected(object sender, RoutedEventArgs e)
        {
            Player2Image.Source = new BitmapImage(new Uri($"Resources/Units/{GetItem(Player2ComboBox.SelectedIndex)}.png", UriKind.Relative));
        }

        /// <summary>
        /// Получение модели по ивыделенному индексу 
        /// </summary>
        private string GetItem(int playerchoise)
        {
            switch (playerchoise)
            {
                case 0: return "Archer";
                case 1: return "Swordsman";
                case 2: return "Catapult";
                case 3: return "Horseman";

                default: return "Dead";
            }
        }
    }
}
