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
using System.Windows.Shapes;
using GameEngine.Models;
using GameEngine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for TradeScreen.xaml
    /// </summary>
    public partial class TradeScreen : Window
    {
        public Session Session => DataContext as Session;

        public TradeScreen()
        {
            InitializeComponent();
        }
        
        private void OnClick_Sell (object sender, RoutedEventArgs e)
        {
            Item item = ((FrameworkElement)sender).DataContext as Item;

            if(item != null)
            {
                Session.StandardPlayer.GoldPieces += item.ItemValue;
                Session.CurrentTrader.AddItemToTraderInventory(item);
                Session.StandardPlayer.RemoveQuestItemFromInventory(item);
            }
        }
        private void OnClick_Buy(object sender, RoutedEventArgs e)
        {
            Item item = ((FrameworkElement)sender).DataContext as Item;

            if (item != null)
            {
            if(Session.StandardPlayer.GoldPieces >= item.ItemValue)
                {
                    Session.StandardPlayer.GoldPieces -= item.ItemValue;
                    Session.CurrentTrader.RemoveItemFromTraderInventory(item);
                    Session.StandardPlayer.AddItemToInventory(item);
                }
            else
                {
                    MessageBox.Show("You do not have enough gold to buy this item.");
                }
            }
        }
        private void OnClick_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
