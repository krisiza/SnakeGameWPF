using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SnakeWPF
{
    internal class Fruits
    {
        public Rectangle apple;
        public Rectangle cherry;
        public Rectangle banana;
        private MainWindow _mainWindow;
        int x = 0;
        int y = 0;

        public Fruits(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public void CreateApple()
        {
            Random random = new Random();

            apple = new Rectangle();
            apple.Width = 30;
            apple.Height = 30;
            ImageBrush fruitImage = new ImageBrush();
            fruitImage.ImageSource = new BitmapImage(new Uri(@"../../Image/apple new.png", UriKind.Relative));
            apple.Fill = fruitImage;

            _mainWindow.myCanvas.Children.Add(apple);

            x = random.Next(10, 750);
            y = random.Next(60, 530);

            Canvas.SetLeft(apple, x);
            Canvas.SetTop(apple, y);
        }
        public void AppleOnAcles(Obstacles obstacles)
        {
            Rect r1 = new Rect(Canvas.GetLeft(apple), Canvas.GetTop(apple), apple.Width, apple.Height);
            Rect r2 = new Rect(Canvas.GetLeft(obstacles.redMonster), Canvas.GetTop(obstacles.redMonster), obstacles.redMonster.Width, obstacles.redMonster.Height);
            Rect r3 = new Rect(Canvas.GetLeft(cherry), Canvas.GetTop(cherry), cherry.Width, cherry.Height);
            Rect r4 = new Rect(Canvas.GetLeft(banana), Canvas.GetTop(banana), banana.Width, banana.Height);
            Rect r5 = new Rect(Canvas.GetLeft(obstacles.yellowMonster), Canvas.GetTop(obstacles.yellowMonster), obstacles.yellowMonster.Width, obstacles.yellowMonster.Height);
      
            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4) || r1.IntersectsWith(r5))
            {
                RemoveApple();
                CreateApple();
                obstacles.speedR = -obstacles.speedR;
                obstacles.speedY = -obstacles.speedY;
            }
        }
        public void CreateCherry()
        {
            Random random = new Random();

            cherry = new Rectangle();
            cherry.Width = 30;
            cherry.Height = 30;
            ImageBrush fruitcherryImage = new ImageBrush();
            fruitcherryImage.ImageSource = new BitmapImage(new Uri(@"../../Image/cherrynew.png", UriKind.Relative));
            cherry.Fill = fruitcherryImage;

            _mainWindow.myCanvas.Children.Add(cherry);

            x = random.Next(10, 750);
            y = random.Next(60, 530);

            Canvas.SetLeft(cherry, x);
            Canvas.SetTop(cherry, y);
        }
        public void CherryOnAcles(Obstacles obstacles)
        {
            Rect r1 = new Rect(Canvas.GetLeft(cherry), Canvas.GetTop(cherry), cherry.Width, cherry.Height);
            Rect r2 = new Rect(Canvas.GetLeft(banana), Canvas.GetTop(banana), banana.Width, banana.Height);
            Rect r3 = new Rect(Canvas.GetLeft(apple), Canvas.GetTop(apple), apple.Width, apple.Height);
            Rect r4 = new Rect(Canvas.GetLeft(obstacles.redMonster), Canvas.GetTop(obstacles.redMonster), obstacles.redMonster.Width, obstacles.redMonster.Height);
            Rect r5 = new Rect(Canvas.GetLeft(obstacles.yellowMonster), Canvas.GetTop(obstacles.yellowMonster), obstacles.yellowMonster.Width, obstacles.yellowMonster.Height);

            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4) || r1.IntersectsWith(r5))
            {
                RemoveCherry();
                CreateCherry();
                obstacles.speedR = -obstacles.speedR;
                obstacles.speedY = -obstacles.speedY;
            }
        }
        public void CreateBanana()
        {
            Random random = new Random();

            banana = new Rectangle();
            banana.Width = 30;
            banana.Height = 30;
            ImageBrush fruitbananaImage = new ImageBrush();
            fruitbananaImage.ImageSource = new BitmapImage(new Uri(@"../../Image/BananaNewww.png", UriKind.Relative));
            banana.Fill = fruitbananaImage;

            _mainWindow.myCanvas.Children.Add(banana);

            x = random.Next(10, 750);
            y = random.Next(60, 530);

            Canvas.SetLeft(banana, x);
            Canvas.SetTop(banana, y);
        }
        public void BananaOnAcles(Obstacles obstacles)
        {
            Rect r1 = new Rect(Canvas.GetLeft(banana), Canvas.GetTop(banana), banana.Width, banana.Height);
            Rect r2 = new Rect(Canvas.GetLeft(apple), Canvas.GetTop(apple), apple.Width, apple.Height);
            Rect r5 = new Rect(Canvas.GetLeft(cherry), Canvas.GetTop(cherry), cherry.Width, cherry.Height);
            Rect r3 = new Rect(Canvas.GetLeft(obstacles.redMonster), Canvas.GetTop(obstacles.redMonster), obstacles.redMonster.Width, obstacles.redMonster.Height);
            Rect r4 = new Rect(Canvas.GetLeft(obstacles.yellowMonster), Canvas.GetTop(obstacles.yellowMonster), obstacles.yellowMonster.Width, obstacles.yellowMonster.Height);
            
            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4)|| r1.IntersectsWith(r5))
            {
                RemoveBanana();
                CreateBanana();
                obstacles.speedR = -obstacles.speedR;
                obstacles.speedY = -obstacles.speedY;
            }
        }
        public void FruitOnSnake()
        {
            for (int i = 1; i < _mainWindow.Snake.Count; i++)
            {
                Rect r1 = new Rect(Canvas.GetLeft(apple), Canvas.GetTop(apple), apple.Width, apple.Height);
                Rect r2 = new Rect(Canvas.GetLeft(cherry), Canvas.GetTop(cherry), cherry.Width, cherry.Height);
                Rect r3 = new Rect(Canvas.GetLeft(banana), Canvas.GetTop(banana), banana.Width, banana.Height);
                Rect r4 = new Rect(Canvas.GetLeft(_mainWindow.Snake[i]), Canvas.GetTop(_mainWindow.Snake[i]), _mainWindow.Snake[i].Width, _mainWindow.Snake[i].Height);

                if (r1.IntersectsWith(r4))
                {
                    RemoveApple();
                    CreateApple();
                }
                if (r2.IntersectsWith(r4))
                {
                    RemoveCherry();
                    CreateCherry();
                }
                if (r3.IntersectsWith(r4))
                {
                    RemoveBanana();
                    CreateBanana();
                }
            }
        }
        public void SnakeOnApple()
        {
            Rect r1 = new Rect(Canvas.GetLeft(apple), Canvas.GetTop(apple), apple.Width, apple.Height);
            Rect r2 = new Rect(Canvas.GetLeft(_mainWindow.Snake[0]), Canvas.GetTop(_mainWindow.Snake[0]), _mainWindow.Snake[0].Width, _mainWindow.Snake[0].Height);

            if (r1.IntersectsWith(r2))
            {
                RemoveApple();
                _mainWindow.obstErreicht = true;
                CreateApple();
                _mainWindow.score++;
            }
            else if (!r1.IntersectsWith(r2))
            {
                _mainWindow.obstErreicht = false;
            }
        }
        public void SnakeOnCherry()
        {
            Rect r1 = new Rect(Canvas.GetLeft(cherry), Canvas.GetTop(cherry), cherry.Width, cherry.Height);
            Rect r2 = new Rect(Canvas.GetLeft(_mainWindow.Snake[0]), Canvas.GetTop(_mainWindow.Snake[0]), _mainWindow.Snake[0].Width, _mainWindow.Snake[0].Height);

            if (r1.IntersectsWith(r2))
            {
                RemoveCherry();
                _mainWindow.obstErreicht = true;
                CreateCherry();
                _mainWindow.score++;
            }
        }
        public void SnakeOnBanana()
        {
            Rect r1 = new Rect(Canvas.GetLeft(banana), Canvas.GetTop(banana), banana.Width, banana.Height);
            Rect r2 = new Rect(Canvas.GetLeft(_mainWindow.Snake[0]), Canvas.GetTop(_mainWindow.Snake[0]), _mainWindow.Snake[0].Width, _mainWindow.Snake[0].Height);

            if (r1.IntersectsWith(r2))
            {
                RemoveBanana();
                _mainWindow.obstErreicht = true;
                CreateBanana();
                _mainWindow.score++;
            }
        }
        private void RemoveApple()
        {
            _mainWindow.myCanvas.Children.Remove(apple);
        }
        private void RemoveCherry()
        {
            _mainWindow.myCanvas.Children.Remove(cherry);
        }
        private void RemoveBanana()
        {
            _mainWindow.myCanvas.Children.Remove(banana);
        }
        public void Reset()
        {
            RemoveApple();
            RemoveCherry();
            RemoveBanana();
        }
    }
}
