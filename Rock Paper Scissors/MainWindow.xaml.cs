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

namespace Rock_Paper_Scissors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Type _userChoice;
        private Type _computerChoice;
        private Rectangle _userRec;
        private Rectangle _computerRec;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            DrawRectangle();
        }

        #region BUTTON CHOICES
        private void BtnRock_Click(object sender, RoutedEventArgs e)
        {
            _userChoice = Type.ROCK;
            GenerateComputerChoice();
            ShowImages();
            CheckForWinner();
        }

        private void BtnPaper_Click(object sender, RoutedEventArgs e)
        {
            _userChoice = Type.PAPER;
            GenerateComputerChoice();
            ShowImages();
            CheckForWinner();
        }

        private void BtnScissors_Click(object sender, RoutedEventArgs e)
        {
            _userChoice = Type.SCISSORS;
            GenerateComputerChoice();
            ShowImages();
            CheckForWinner();
        }
        #endregion

        private void GenerateComputerChoice()
        {
            Random r = new Random();
            int number = r.Next(1, 4);

            _computerChoice = (Type)number;
        }

        private void CheckForWinner()
        {
            DrawRectangle();

            Brush win = new SolidColorBrush(Colors.Green);
            Brush loss = new SolidColorBrush(Colors.Red);
            Brush draw = new SolidColorBrush(Colors.Gray);

            string returnValue;
            int user = (int)_userChoice;
            int computer = (int)_computerChoice % 3;

            if (user % 3 == computer)
            {
                returnValue = "Draw";
                UpdateRectangle(draw, draw);
            }
            else if (user == computer + 1)
            {
                returnValue = "You Win!";
                UpdateRectangle(win, loss);
            }
            else
            {
                returnValue = "You Lose!";
                UpdateRectangle(loss, win);
            }

            GenerateResult(returnValue,user,computer);
        }

        private void GenerateResult(string outcome, int user, int computer)
        {
            //TxtBlResultaat.Text = "";
            //StringBuilder result = new StringBuilder();
            //result.Append($"User has chosen: {_userChoice}\n");
            //result.Append(user);
            //result.Append(Environment.NewLine + Environment.NewLine);
            //result.Append($"Computer has chosen: {_computerChoice}\n");
            //result.Append(computer);
            //result.Append(Environment.NewLine + Environment.NewLine);
            //result.Append(outcome);

            //TxtBlResultaat.Text = result.ToString();
        }

        private void DrawRectangle()
        {
            _userRec = new Rectangle()
            {
                Width = 250,
                Height = 250,
                StrokeThickness = 7,
                Margin = new Thickness(0, 0, 0, 0),
                Stroke = new SolidColorBrush(Colors.Gray)
            };

            paperCanvas.Children.Add(_userRec);

            _computerRec = new Rectangle()
            {
                Width = 250,
                Height = 250,
                StrokeThickness = 7,
                Margin = new Thickness(270, 0, 0, 0),
                Stroke = new SolidColorBrush(Colors.Gray)
            };

            paperCanvas.Children.Add(_computerRec);
        }

        private void UpdateRectangle(Brush user, Brush computer)
        {
            _userRec.Stroke = user;
            _computerRec.Stroke = computer;
        }

        private void ShowImages()
        {
            paperCanvas.Children.Clear();
            string user = _userChoice.ToString().ToLower();
            string computer = _computerChoice.ToString().ToLower();
            TxtBlResultaat.Text = user;
            
            BitmapImage userImage = new BitmapImage();
            userImage.BeginInit();
            userImage.UriSource = new Uri($"img\\{user}.png", UriKind.RelativeOrAbsolute);
            userImage.EndInit();
            Image userChoice = new Image();
            userChoice.Source = userImage;
            userChoice.Margin = new Thickness(15, 23, 0, 0);
            userChoice.Width = 200;
            userChoice.Height = 200;
            paperCanvas.Children.Add(userChoice);

            BitmapImage computerImage = new BitmapImage();
            computerImage.BeginInit();
            computerImage.UriSource = new Uri($"img\\{computer}.png", UriKind.RelativeOrAbsolute);
            computerImage.EndInit();
            Image computerChoice = new Image();
            computerChoice.Source = computerImage;
            computerChoice.Margin = new Thickness(280, 23, 0, 0);
            computerChoice.Width = 200;
            computerChoice.Height = 200;
            paperCanvas.Children.Add(computerChoice);

        }

    }
}
