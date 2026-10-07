using System.Text;
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

namespace Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CController controller;
        CPlayer player;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            controller = new CController(1.0, 0, new Size(Scene.ActualWidth, Scene.ActualHeight));
            player = new CPlayer(1.0);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            controller.update(0.1);
            player.update(0.1);
            Scene.Children.Clear();
            foreach (CCollectable obj in controller.getObjects())
            {
                Scene.Children.Add(obj.getSprite());
            }
            PointsText.Text = $"Очки: {controller.getPoints():F2}";
            CooldownText.Text = $"Перезарядка клика: {player.GetCooldownRemaining():F1} с";
           

        }

        private void Scene_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(Scene);

            if (!player.CanClick)
                return;                                          // перезарядка идёт, клик игнорируется

            controller.mouseClick(mousePosition, player);        // клик по сферам
            player.mouseClick(mousePosition);                    // запуск перезарядки
        }
    }
}