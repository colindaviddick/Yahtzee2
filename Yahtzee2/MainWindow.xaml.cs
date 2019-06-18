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

namespace Yahtzee2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //bool _dice1 = true;
        //bool _dice2 = true;
        //bool _dice3 = true;
        //bool _dice4 = true;
        //bool _dice5 = true;
        public int dice1 = 0;
        public int dice2 = 0;
        public int dice3 = 0;
        public int dice4 = 0;
        public int dice5 = 0;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        //Need to add some timing differences between rolls to get random numbers

        public void DiceRoll()
        {
            //Need if statement in here, if button is selected don't change the value
            Roll1();
            Roll2();
            Roll3();
            Roll4();
            Roll5();
        }
        public void Roll1()
        {
            int dice1 = r.Next(1, 6);
            Dice1.Content = dice1.ToString();
        }
        public void Roll2()
        {
            int dice2 = r.Next(1, 6);
            Dice2.Content = dice2.ToString();
        }
        public void Roll3()
        {
            int dice3 = r.Next(1, 6);
            Dice3.Content = dice3.ToString();
        }
        public void Roll4()
        {
            int dice4 = r.Next(1, 6);
            Dice4.Content = dice4.ToString();
        }
        public void Roll5()
        {
            int dice5 = r.Next(1, 6);
            Dice5.Content = dice5.ToString();
        }
        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            DiceRoll();
        }
    }
}
