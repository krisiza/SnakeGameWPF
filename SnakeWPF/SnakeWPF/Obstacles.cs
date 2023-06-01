using System;
using System.Collections.Generic;
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
    internal class Obstacles
    {
        Random random = new Random();
        MainWindow _mainWindow;

        public Rectangle redMonster;
        public Rectangle yellowMonster;
        public int scoreR = 0;
        public int scoreY = 0;

        int x = 0;
        int y = 0;
        public int speedR = 5;
        public int speedY = 7;

        public Obstacles(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        public void CreateRedMonster(Fruits fruits)
        {
            redMonster = new Rectangle();
            redMonster.Width = 40;
            redMonster.Height = 40;
            ImageBrush aclesImage = new ImageBrush();
            aclesImage.ImageSource = new BitmapImage(new Uri(@"../../Image/Cute-Monster.png", UriKind.Relative));
            redMonster.Fill = aclesImage;

            _mainWindow.myCanvas.Children.Add(redMonster);

            x = random.Next(520, 720);
            y = random.Next(60, 520);

            Canvas.SetLeft(redMonster, x);
            Canvas.SetTop(redMonster, y);

            Rect r1 = new Rect(Canvas.GetLeft(redMonster), Canvas.GetTop(redMonster), redMonster.Width, redMonster.Height);
            Rect r2 = new Rect(Canvas.GetLeft(fruits.apple), Canvas.GetTop(fruits.apple), fruits.apple.Width, fruits.apple.Height);
            Rect r3 = new Rect(Canvas.GetLeft(fruits.cherry), Canvas.GetTop(fruits.cherry), fruits.cherry.Width, fruits.cherry.Height);
            Rect r4 = new Rect(Canvas.GetLeft(fruits.banana), Canvas.GetTop(fruits.banana), fruits.banana.Width, fruits.banana.Height);

            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4))
            {
                x = random.Next(10, 720);
                y = random.Next(60, 520);

                Canvas.SetLeft(redMonster, x);
                Canvas.SetTop(redMonster, y);
            }
        }
        public void CreateYellowMonster(Fruits fruits)
        {
            yellowMonster = new Rectangle();
            yellowMonster.Width = 40;
            yellowMonster.Height = 40;
            ImageBrush aclesImage = new ImageBrush();
            aclesImage.ImageSource = new BitmapImage(new Uri(@"../../Image/Cute-Monster-PNG-File.png",UriKind.Relative));
            yellowMonster.Fill = aclesImage;

            _mainWindow.myCanvas.Children.Add(yellowMonster);

            x = random.Next(10, 330);
            y = random.Next(60, 520);

            Canvas.SetLeft(yellowMonster, x);
            Canvas.SetTop(yellowMonster, y);

            Rect r1 = new Rect(Canvas.GetLeft(yellowMonster), Canvas.GetTop(yellowMonster), yellowMonster.Width, yellowMonster.Height);
            Rect r2 = new Rect(Canvas.GetLeft(fruits.apple), Canvas.GetTop(fruits.apple), fruits.apple.Width, fruits.apple.Height);
            Rect r3 = new Rect(Canvas.GetLeft(fruits.cherry), Canvas.GetTop(fruits.cherry), fruits.cherry.Width, fruits.cherry.Height);
            Rect r4 = new Rect(Canvas.GetLeft(fruits.banana), Canvas.GetTop(fruits.banana), fruits.banana.Width, fruits.banana.Height);

            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4))
            {
                x = random.Next(10, 520);
                y = random.Next(60, 520);

                Canvas.SetLeft(yellowMonster, x);
                Canvas.SetTop(yellowMonster, y);
            }
        }
        public void SnakeOnRedMonster()
        {
            for (int i = 0; i < _mainWindow.Snake.Count; i++)
            {
                Rect r1 = new Rect(Canvas.GetLeft(redMonster), Canvas.GetTop(redMonster), redMonster.Width, redMonster.Height);
                Rect r2 = new Rect(Canvas.GetLeft(_mainWindow.Snake[i]), Canvas.GetTop(_mainWindow.Snake[i]), _mainWindow.Snake[0].Width, _mainWindow.Snake[i].Height);

                if (r1.IntersectsWith(r2))
                {
                    _mainWindow.GameOver();
                }
            }
        }
        public void SnakeOnYellowMonster()
        {
            for (int i = 0; i < _mainWindow.Snake.Count; i++)
            {
                Rect r1 = new Rect(Canvas.GetLeft(yellowMonster), Canvas.GetTop(yellowMonster), yellowMonster.Width, yellowMonster.Height);
                Rect r2 = new Rect(Canvas.GetLeft(_mainWindow.Snake[i]), Canvas.GetTop(_mainWindow.Snake[i]), _mainWindow.Snake[0].Width, _mainWindow.Snake[i].Height);

                if (r1.IntersectsWith(r2))
                {
                    _mainWindow.GameOver();
                }
            }
        }
        public void MonsterCrash()
        {
            Rect r1 = new Rect(Canvas.GetLeft(yellowMonster), Canvas.GetTop(yellowMonster), yellowMonster.Width, yellowMonster.Height);
            Rect r2 = new Rect(Canvas.GetLeft(redMonster), Canvas.GetTop(redMonster), redMonster.Width, redMonster.Height);

            if (r1.IntersectsWith(r2))
            {
                speedR = -speedR;
                speedY = -speedY;
            }
        }
        public void MoveRedMonster(Fruits fruits)
        {
            Canvas.SetLeft(redMonster, Canvas.GetLeft(redMonster) - speedR);

            if (Canvas.GetLeft(redMonster) < 5 || Canvas.GetLeft(redMonster) + (redMonster.Width * 2) > Application.Current.MainWindow.Width)
            {
                speedR = -speedR;
            }
        }
        public void MoveYellowMonster(Fruits fruits)
        {
            Canvas.SetTop(yellowMonster, Canvas.GetTop(yellowMonster) - speedY);

            if (Canvas.GetTop(yellowMonster) < 50 || Canvas.GetTop(yellowMonster) + (yellowMonster.Height * 2) > Application.Current.MainWindow.Height)
            {
                speedY = -speedY;
            }
        }
        public void RedMonsterScore(Fruits fruits)
        {
            Rect r1 = new Rect(Canvas.GetLeft(redMonster), Canvas.GetTop(redMonster), redMonster.Width, redMonster.Height);
            Rect r2 = new Rect(Canvas.GetLeft(fruits.banana), Canvas.GetTop(fruits.banana), fruits.banana.Width, fruits.banana.Height);
            Rect r3 = new Rect(Canvas.GetLeft(fruits.apple), Canvas.GetTop(fruits.apple), fruits.apple.Width, fruits.apple.Height);
            Rect r4 = new Rect(Canvas.GetLeft(fruits.cherry), Canvas.GetTop(fruits.cherry), fruits.cherry.Width, fruits.cherry.Height);

            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4) || r1.IntersectsWith(r4))
            {
                scoreR++;
            }
        }
        public void YellowMonsterScore(Fruits fruits)
        {
            Rect r1 = new Rect(Canvas.GetLeft(yellowMonster), Canvas.GetTop(yellowMonster), yellowMonster.Width, yellowMonster.Height);
            Rect r2 = new Rect(Canvas.GetLeft(fruits.banana), Canvas.GetTop(fruits.banana), fruits.banana.Width, fruits.banana.Height);
            Rect r3 = new Rect(Canvas.GetLeft(fruits.apple), Canvas.GetTop(fruits.apple), fruits.apple.Width, fruits.apple.Height);
            Rect r4 = new Rect(Canvas.GetLeft(fruits.cherry), Canvas.GetTop(fruits.cherry), fruits.cherry.Width, fruits.cherry.Height);

            if (r1.IntersectsWith(r2) || r1.IntersectsWith(r3) || r1.IntersectsWith(r4))
            {
                scoreY++;
            }
        }
        public void Reset()
        {
            _mainWindow.myCanvas.Children.Remove(redMonster);
            _mainWindow.myCanvas.Children.Remove(yellowMonster);
        }
    }
}
