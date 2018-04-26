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
using GameEngine.EventArgs;
using GameEngine.Factories;
using GameEngine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Session currentSession = new Session();

        public MainWindow()
        {
            InitializeComponent();
            currentSession.OnMessageRaised += OnGameMessageRaised;
            DataContext = currentSession;

        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            currentSession.MoveUp();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            currentSession.MoveLeft();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            currentSession.MoveRight();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            currentSession.MoveDown();
        }
        
        private void OnGameMessageRaised(object sender, GameMessageEventArgs e)
        {
            GameMessages.Document.Blocks.Add(new Paragraph(new Run(e.Message)));
            GameMessages.ScrollToEnd();
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            currentSession.AttackCurrentMob();
        }

        private void btnTrade_Click(object sender, RoutedEventArgs e)
        {
            TradeScreen tradeScreen = new TradeScreen();
            tradeScreen.Owner = this;
            tradeScreen.DataContext = currentSession;
            tradeScreen.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentSession.StandardPlayer.Experience = currentSession.StandardPlayer.Experience + 10;
            currentSession.StandardPlayer.HealthPoints = currentSession.StandardPlayer.HealthPoints + 2147000;
            currentSession.StandardPlayer.AddItemToInventory(ItemFactory.CreateItem(999));
        }
    }
}
