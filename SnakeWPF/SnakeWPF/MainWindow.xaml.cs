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

using System.Windows.Threading;

namespace SnakeWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle obj;
        ImageBrush snakeTailImage = new ImageBrush();
        public List<Rectangle> Snake = new List<Rectangle>();

        private const int _snakeStepSize = 16;

        public int x = 362;
        public int y = 460;

        public int score = 0;
        public bool obstErreicht = false;
    
        DispatcherTimer gameTimer = new DispatcherTimer();
        Fruits _fruits;
        Obstacles _obstacles;
        public MainWindow()
        {
            InitializeComponent();

            myCanvas.Focus();

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(60);
            gameTimer.Start();

            SetupGame();
        }
        private void SetupGame()
        {
            _fruits = new Fruits(this);
            _obstacles = new Obstacles(this);
            _fruits.CreateApple();
            _fruits.CreateCherry();
            _fruits.CreateBanana();

            _obstacles.CreateRedMonster(_fruits);
            _obstacles.CreateYellowMonster(_fruits);
        }
        private void ResetGame(Obstacles obstacles)
        {
            Snake.Clear();
            myCanvas.Children.Clear();
            score = 0;
            obstacles.scoreY = 0;
            obstacles.scoreR = 0;
            myCanvas.Children.Add(_monsterScore);
            myCanvas.Children.Add(MonsterScore);
            myCanvas.Children.Add(_snakeScore);
            myCanvas.Children.Add(SnakeScore);

            _fruits.Reset();
            obstacles.Reset();

            x = 362;
            y = 460;

            SetupGame();
        }
        enum DirectionEnum
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        private DirectionEnum _direction;
        private void GameTimerEvent(object sender, EventArgs e)
        {
            Rectangle obj = CreateSnake();
            NearBorder();
            Snake.Insert(0, obj);
            RemoveAt();

            for (int i = 0; i < Snake.Count; i++)
            {
                if (i > 0)
                {
                    snakeTailImage.ImageSource = new BitmapImage(new Uri(@"../../Image/bodynewww.png", UriKind.Relative));
                    Snake[i].Fill = snakeTailImage;
                }
            }
            Snakekollidiert();
            ShowMonsterScore(_obstacles);
            ShowSnakeScore(_obstacles);

            _fruits.SnakeOnApple();
            _fruits.SnakeOnCherry();
            _fruits.SnakeOnBanana();
            _fruits.FruitOnSnake();
            _fruits.AppleOnAcles(_obstacles);
            _fruits.CherryOnAcles(_obstacles);
            _fruits.BananaOnAcles(_obstacles);

            _obstacles.SnakeOnRedMonster();
            _obstacles.SnakeOnYellowMonster();
            _obstacles.MoveRedMonster(_fruits);
            _obstacles.MoveYellowMonster(_fruits);
            _obstacles.MonsterCrash();
            _obstacles.RedMonsterScore(_fruits);
            _obstacles.YellowMonsterScore(_fruits);
        }
        private Rectangle CreateSnake()
        {
            obj = new Rectangle();
            obj.Width = 15;
            obj.Height = 15;
            ImageBrush snakeHead = new ImageBrush();
            snakeHead.ImageSource = new BitmapImage(new Uri(@"../../Snake/SnakeHeaddown.png", UriKind.Relative));
            obj.Fill = snakeHead;
            myCanvas.Children.Add(obj);

            if (_direction == DirectionEnum.UP)
            {
                Canvas.SetLeft(obj, x);
                Canvas.SetTop(obj, y -= _snakeStepSize);

                snakeHead.ImageSource = new BitmapImage(new Uri(@"../../Snake/SnakeHeadup.png", UriKind.Relative));
            }
            else if (_direction == DirectionEnum.DOWN)
            {
                Canvas.SetLeft(obj, x);
                Canvas.SetTop(obj, y += _snakeStepSize);

                snakeHead.ImageSource = new BitmapImage(new Uri(@"../../Snake/SnakeHeaddown.png", UriKind.Relative));
            }
            else if (_direction == DirectionEnum.LEFT)
            {
                Canvas.SetLeft(obj, x -= _snakeStepSize);
                Canvas.SetTop(obj, y);

                snakeHead.ImageSource = new BitmapImage(new Uri(@"../../Snake/SnakeHeadliks.png", UriKind.Relative));
            }
            else if (_direction == DirectionEnum.RIGHT)
            {
                Canvas.SetLeft(obj, x += _snakeStepSize);
                Canvas.SetTop(obj, y);

                snakeHead.ImageSource = new BitmapImage(new Uri(@"../../Snake/SnakeHeadlrechts.png", UriKind.Relative));
            }
            return obj;
        }
        private void RemoveAt()
        {
            if (Snake.Count > 1 && obstErreicht == false)
            {
                myCanvas.Children.Remove(Snake.ElementAt<Rectangle>(Snake.Count - 1));
                Snake.RemoveAt(Snake.Count - 1);
            }
        }
        private void NearBorder()
        {
            if (Canvas.GetLeft(obj) < 1)
            {
                Canvas.SetLeft(obj, x = 770);
                Canvas.SetTop(obj, y);
            }
            if (Canvas.GetTop(obj) < 50)
            {
                Canvas.SetLeft(obj, x);
                Canvas.SetTop(obj, y = 570);
            }
            if (Canvas.GetLeft(obj) + (obj.Width) > Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(obj, x = 0);
                Canvas.SetTop(obj, y);
            }
            if (Canvas.GetTop(obj) + (obj.Height) > Application.Current.MainWindow.Height)
            {
                Canvas.SetLeft(obj, x);
                Canvas.SetTop(obj, y = 51);
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (_direction == DirectionEnum.RIGHT && Snake.Count > 1)
                {
                    _direction = DirectionEnum.RIGHT;
                }
                else
                {
                    _direction = DirectionEnum.LEFT;
                }
            }
            if (e.Key == Key.Right)
            {
                if (_direction == DirectionEnum.LEFT && Snake.Count > 1)
                {
                    _direction = DirectionEnum.LEFT;
                }
                else
                {
                    _direction = DirectionEnum.RIGHT;
                }
            }
            if (e.Key == Key.Up)
            {
                if (_direction == DirectionEnum.DOWN && Snake.Count > 1)
                {
                    _direction = DirectionEnum.DOWN;
                }
                else
                {
                    _direction = DirectionEnum.UP;
                }
            }
            if (e.Key == Key.Down)
            {
                if (_direction == DirectionEnum.UP && Snake.Count > 1)
                {
                    _direction = DirectionEnum.UP;
                }
                else
                {
                    _direction = DirectionEnum.DOWN;
                }
            }
        }
        public void Snakekollidiert()
        {
            for (int i = 1; i < Snake.Count; i++)
            {
                Rect r1 = new Rect(Canvas.GetLeft(Snake[0]), Canvas.GetTop(Snake[0]), Snake[0].Width, Snake[0].Height);
                Rect r2 = new Rect(Canvas.GetLeft(Snake[i]), Canvas.GetTop(Snake[i]), Snake[i].Width, Snake[i].Height);

                if (r1.IntersectsWith(r2))
                {
                    GameOver();
                    break;
                }
            }
        }
        private void ShowMonsterScore(Obstacles obstacles)
        {
            _monsterScore.Text = $"{obstacles.scoreR + obstacles.scoreY}";
        }
        private void ShowSnakeScore(Obstacles obstacles)
        {
            _snakeScore.Text = $"{score}";
        }
        public void GameOver()
        {
            MessageBoxResult result;
            result = MessageBox.Show($"Game Over!\nYour Score: {score}\nDo you want to reset the game?", "GAME OVER!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                Close();
                return;
            }

            ResetGame(_obstacles);
        }
    }
}
