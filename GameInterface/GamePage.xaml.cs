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
using Strategy.Domain.Models;

namespace GameInterface
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        Player FirstPlayer, SecondPlayer;
        Button[,] Battleground = new Button[16, 20];

        /// <summary>
        /// Инициализация компонентов
        /// </summary>        
        public GamePage(string Player1Name = "", string Player2Name = "")
        {
            InitializeComponent();

            #region Инициализирование игроков

            FirstPlayer = new Player(1, Player1Name, new BitmapImage(new Uri("pack://application:,,,/Resources/Dead.png")));
            SecondPlayer = new Player(2, Player2Name, new BitmapImage(new Uri("pack://application:,,,/Resources/Dead.png")));

            // MessageBox.Show($"{Player1Name} и {Player2Name} "); // проверка передачи данных с 1 окна
            #endregion

            #region Создание поля битвы (кнопок)
            for (sbyte row = 0; row < 16; row++)
            {
                for (sbyte column = 0; column < 20; column++)
                {
                    Button button = new Button();
                    button.SetValue(Grid.ColumnProperty, (int)column);
                    button.SetValue(Grid.RowProperty, (int)row);
                    button.SetValue(Border.BorderThicknessProperty, new Thickness(1));
                    button.Focusable = false;
                    button.Padding = new Thickness(0);
                    button.Tag = new Coordinates(row, column); // привязка координат к кнопке 

                    if (column == 9 || column == 10)
                    {
                        if (row == 7 || row == 8)
                            button.Background = Brushes.Green;
                        else
                            button.Background = Brushes.Blue;
                    }
                    else
                        button.Background = Brushes.Green;

                    // погружаем мир в хаос
                    //var brush = new ImageBrush();
                    //brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/Dead.png"));
                    //button.Background = brush;                             

                    Grid g = new Grid();
                    g.Children.Add(new UIElement());
                    g.Children.Add(new UIElement());
                    button.Content = g;

                    Battleground[row, column] = button;
                    Battlefield.Children.Add(button);
                }
            }
            #endregion


        }

        /// <summary>
        /// Генерирует прямоугольник, который выделяет выбранный квадрат
        /// </summary>
        Rectangle GenerateSelectedSquare(Brush color)
        {
            Rectangle selectedSquare = new Rectangle();
            selectedSquare.Fill = color;
            selectedSquare.Opacity = 0.3;
            selectedSquare.Stretch = Stretch.UniformToFill;
            selectedSquare.HorizontalAlignment = HorizontalAlignment.Stretch;
            selectedSquare.IsHitTestVisible = false;
            return selectedSquare;
        }

        /// <summary>
        /// Событие клика по площади.
        /// </summary>
        private void Battlefield_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ButtonClick((Coordinates)((Button)e.Source).Tag);
        }

        public void ButtonClick(Coordinates coords)
        {
            //((Grid)(Battleground[coords.X, coords.Y].Content)).Children.Add(GenerateSelectedSquare(Brushes.Red)); // проверка отрисовки по нажатию кнопки
            #region Отображение фигур
            Image img = GeneratePieceImage();
            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.RemoveRange(0, 2);
            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.Add(new UIElement());
            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.Add(img);
            #endregion

        }

        /// <summary>
        /// Graphically deselects a square
        /// </summary>
        void DeselectSquare(Coordinates coords)
        {
            UIElement uie = ((Grid)(Battleground[coords.X, coords.Y].Content)).Children[1];

            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.RemoveRange(0, 2);
            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.Add(new UIElement());
            ((Grid)(Battleground[coords.X, coords.Y].Content)).Children.Add(uie);
        }

        /// Generates piece image
        /// </summary>
        /// <param name="pc">Based on square it generates the respective image of the piece</param>
        /// <param name="forWrapPanel">Whether to generate the image for the wrap panel of lost pieces</param>
        /// <returns></returns>
        Image GeneratePieceImage()
        {
            Image image = new Image() { IsHitTestVisible = false };
            image.SetValue(RenderOptions.BitmapScalingModeProperty, BitmapScalingMode.Fant);

            image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Dead.png"));
            return image;
        }

        /// <summary>
        /// Событие клика по кнопке "Назад".
        /// </summary>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomePage page = new HomePage();
            this.NavigationService.Navigate(page);
        }

        /// <summary>
        /// Событие клика по кнопке "Новая игра". 
        /// </summary>
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
