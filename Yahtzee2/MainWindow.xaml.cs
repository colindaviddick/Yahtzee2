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

/// <summary>
/// Todo: I need to finish the logic for the opponent's game. I have it SEMI implemented. 
/// 
/// Possible reaction to losing viible????
/// I found this formula below, cases for a range of outcomes, should be able to find the odds for each hand and I'll add them in 
/// using this formula. 
// switch (mystring.length)
//{
//    case int n when(n >= 0 && n <= 25) :
//    //do this
//    break;

//    case int n when(n >= 26 && n <= 50 ) :
//    //do this
//    break;
//}
/// </summary>

namespace Yahtzee2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool _dice1 = true;
        public bool _dice2 = true;
        public bool _dice3 = true;
        public bool _dice4 = true;
        public bool _dice5 = true;
        public int dice1 = 0;
        public int dice2 = 0;
        public int dice3 = 0;
        public int dice4 = 0;
        public int dice5 = 0;
        public int rolls = 2;
        public int rounds = 0; // Goes up to 13.
        public int maxRounds = 12;
        public int[] randomiseOPOrder = new int[13] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        
        static Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();

            //ShuffleOpponentOrder();

            //ChooseOPScore();
        }
        public void DiceToBeRolled(bool _dice1, bool _dice2, bool _dice3, bool _dice4, bool _dice5)
        {
            if (_dice1)
            {
                Roll1();
            }
            if (_dice2)
            {
                Roll2();
            }
            if (_dice3)
            {
                Roll3();
            }
            if (_dice4)
            {
                Roll4();
            }
            if (_dice5)
            {
                Roll5();
            }



            if (!CheckIfRollsLeft())
            {
                RollDiceButton.IsEnabled = false;
            }
        }
        public void GameOverCheck()
        {
            if (rounds == maxRounds)
            {
                /// Need to do more with this
                MessageBox.Show("Game Over!");
            }
            else
            {
                rounds++;
            }
        }
        public void EndTurn()
        {
            _dice1 = true;
            Dice1.Background = Brushes.Beige;
            _dice2 = true;
            Dice2.Background = Brushes.Beige;
            _dice3 = true;
            Dice3.Background = Brushes.Beige;
            _dice4 = true;
            Dice4.Background = Brushes.Beige;
            _dice5 = true;
            Dice5.Background = Brushes.Beige;
        }
        public void Roll1()
        {
            int dice1 = r.Next(1, 7);
            Dice1.Content = dice1.ToString();
        }
        public void Roll2()
        {
            int dice2 = r.Next(1, 7);
            Dice2.Content = dice2.ToString();
        }
        public void Roll3()
        {
            int dice3 = r.Next(1, 7);
            Dice3.Content = dice3.ToString();
        }
        public void Roll4()
        {
            int dice4 = r.Next(1, 7);
            Dice4.Content = dice4.ToString();
        }
        public void Roll5()
        {
            int dice5 = r.Next(1, 7);
            Dice5.Content = dice5.ToString();
        }
        public void BonusCheck()
        {
            if (Ones.IsEnabled == false && Twos.IsEnabled == false && Threes.IsEnabled == false && Fours.IsEnabled == false && Fives.IsEnabled == false && Sixes.IsEnabled == false)
            {

                int sum = (Int32.Parse(OnesTotal.Text) +
                Int32.Parse(TwosTotal.Text) +
                Int32.Parse(ThreesTotal.Text) +
                Int32.Parse(FoursTotal.Text) +
                Int32.Parse(FivesTotal.Text) +
                Int32.Parse(SixesTotal.Text));

                if (sum >= 63)
                {
                    OneToSixBonus.Text = "35";
                }
                else
                {
                    OneToSixBonus.Text = "0";
                }
            }
        }
        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            DiceToBeRolled(_dice1, _dice2, _dice3, _dice4, _dice5);
            rolls--;
        }
        private void RollReset()
        {
            rolls = 2;
        }
        private void RollButtonEnabled()
        {
            RollDiceButton.IsEnabled = true;
        }
        private bool CheckIfRollsLeft()
        {
            if (rolls == 0)
            {
                Turns.Text = "Mark off your score.";
                return false;
            }
            else if (rolls == 1)
            {
                Turns.Text = "Last roll";
                return true;
            }
            else if (rolls == 2)
            {
                Turns.Text = "Roll again";
                return true;
            }
            else return true;
        }
        private void TallyScore()
        {
            TotalScore.Text = ((Int32.Parse(OnesTotal.Text) + Int32.Parse(TwosTotal.Text) +
            Int32.Parse(ThreesTotal.Text) + Int32.Parse(FoursTotal.Text) +
            Int32.Parse(FivesTotal.Text) + Int32.Parse(SixesTotal.Text) +
            Int32.Parse(ThreeOfAKindTotal.Text) + Int32.Parse(FourOfAKindTotal.Text) +
            Int32.Parse(FullHouseTotal.Text) + Int32.Parse(SmallStraightTotal.Text) +
            Int32.Parse(LargeStraightTotal.Text) + Int32.Parse(ChanceTotal.Text) +
            Int32.Parse(YahtzeeTotal.Text)).ToString());
        }
        private void RoundReset()
        {
            TallyScore();
            RollReset();
            EndTurn();
            RollButtonEnabled();
            GameOverCheck();
            ResetDice();
            Turns.Text = "Roll your dice!";
        }
        private void Ones_Click(object sender, RoutedEventArgs e)
        {
            int oneSum = 0;
            int value = 1;
            if (Dice1.Content.ToString() == value.ToString())
            {
                oneSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                oneSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                oneSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                oneSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                oneSum += value;
            }

            Ones.IsEnabled = false;
            OnesTotal.Text = oneSum.ToString();
            BonusCheck();
            RoundReset();
            
        }
        private void Twos_Click(object sender, RoutedEventArgs e)
        {
            int twoSum = 0;
            int value = 2;
            if (Dice1.Content.ToString() == value.ToString())
            {
                twoSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                twoSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                twoSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                twoSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                twoSum += value;
            }
            Twos.IsEnabled = false;
            TwosTotal.Text = twoSum.ToString();
            BonusCheck();
            RoundReset();
        }
        private void Threes_Click(object sender, RoutedEventArgs e)
        {
            int threeSum = 0;
            int value = 3;
            if (Dice1.Content.ToString() == value.ToString())
            {
                threeSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                threeSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                threeSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                threeSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                threeSum += value;
            }
            Threes.IsEnabled = false;
            ThreesTotal.Text = threeSum.ToString();
            BonusCheck();
            RoundReset();
        }
        private void Fours_Click(object sender, RoutedEventArgs e)
        {
            int fourSum = 0;
            int value = 4;
            if (Dice1.Content.ToString() == value.ToString())
            {
                fourSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                fourSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                fourSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                fourSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                fourSum += value;
            }
            FoursTotal.Text = fourSum.ToString();
            Fours.IsEnabled = false;
            BonusCheck();
            RoundReset();
        }
        private void Fives_Click(object sender, RoutedEventArgs e)
        {
            int fiveSum = 0;
            int value = 5;
            if (Dice1.Content.ToString() == value.ToString())
            {
                fiveSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                fiveSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                fiveSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                fiveSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                fiveSum += value;
            }
            FivesTotal.Text = fiveSum.ToString();
            Fives.IsEnabled = false;
            BonusCheck();
            RoundReset();
        }
        private void Sixes_Click(object sender, RoutedEventArgs e)
        {
            int sixSum = 0;
            int value = 6;
            if (Dice1.Content.ToString() == value.ToString())
            {
                sixSum += value;
            }
            if (Dice2.Content.ToString() == value.ToString())
            {
                sixSum += value;
            }
            if (Dice3.Content.ToString() == value.ToString())
            {
                sixSum += value;
            }
            if (Dice4.Content.ToString() == value.ToString())
            {
                sixSum += value;
            }
            if (Dice5.Content.ToString() == value.ToString())
            {
                sixSum += value;
            }
            SixesTotal.Text = sixSum.ToString();
            Sixes.IsEnabled = false;
            BonusCheck();
            RoundReset();
        }
        private void ThreeOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int[] threeOfAKindArray = new int[5];
            threeOfAKindArray[0] = Int32.Parse(Dice1.Content.ToString());
            threeOfAKindArray[1] = Int32.Parse(Dice2.Content.ToString());
            threeOfAKindArray[2] = Int32.Parse(Dice3.Content.ToString());
            threeOfAKindArray[3] = Int32.Parse(Dice4.Content.ToString());
            threeOfAKindArray[4] = Int32.Parse(Dice5.Content.ToString());

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;

            foreach (int roll in threeOfAKindArray)
            {
                if (roll == 1)
                {
                    num1++;
                }
                else if (roll == 2)
                {
                    num2++;
                }
                else if (roll == 3)
                {
                    num3++;
                }
                else if (roll == 4)
                {
                    num4++;
                }
                else if (roll == 5)
                {
                    num5++;
                }
                else if (roll == 6)
                {
                    num6++;
                }
            }

            if (num1 >= 3 || num2 >= 3 || num3 >= 3 || num4 >= 3 || num5 >= 3 || num6 >= 3)
            {
                int threeOfAKindTotal = 0;
                foreach (int roll in threeOfAKindArray)
                {
                    threeOfAKindTotal += roll;
                }
                ThreeOfAKindTotal.Text = threeOfAKindTotal.ToString();
            }
            else
            {
                ThreeOfAKindTotal.Text = "0";
            }


            ThreeOfAKind.IsEnabled = false;
            RoundReset();
        }
        private void FourOfAKind_Click(object sender, RoutedEventArgs e)
        {
            int[] fourOfAKindArray = new int[5];
            fourOfAKindArray[0] = Int32.Parse(Dice1.Content.ToString());
            fourOfAKindArray[1] = Int32.Parse(Dice2.Content.ToString());
            fourOfAKindArray[2] = Int32.Parse(Dice3.Content.ToString());
            fourOfAKindArray[3] = Int32.Parse(Dice4.Content.ToString());
            fourOfAKindArray[4] = Int32.Parse(Dice5.Content.ToString());

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;

            foreach (int roll in fourOfAKindArray)
            {
                if (roll == 1)
                {
                    num1++;
                }
                else if (roll == 2)
                {
                    num2++;
                }
                else if (roll == 3)
                {
                    num3++;
                }
                else if (roll == 4)
                {
                    num4++;
                }
                else if (roll == 5)
                {
                    num5++;
                }
                else if (roll == 6)
                {
                    num6++;
                }
            }

            if (num1 >= 4 || num2 >= 4 || num3 >= 4 || num4 >= 4 || num5 >= 4 || num6 >= 4)
            {
                int fourOfAKindTotal = 0;
                foreach (int roll in fourOfAKindArray)
                {
                    fourOfAKindTotal += roll;
                }
                FourOfAKindTotal.Text = fourOfAKindTotal.ToString();
            }
            else
            {
                FourOfAKindTotal.Text = "0";
            }

            FourOfAKind.IsEnabled = false;
            RoundReset();
        }
        private void FullHouse_Click(object sender, RoutedEventArgs e)
        {
            int[] fullHouseArray = new int[5];
            fullHouseArray[0] = Int32.Parse(Dice1.Content.ToString());
            fullHouseArray[1] = Int32.Parse(Dice2.Content.ToString());
            fullHouseArray[2] = Int32.Parse(Dice3.Content.ToString());
            fullHouseArray[3] = Int32.Parse(Dice4.Content.ToString());
            fullHouseArray[4] = Int32.Parse(Dice5.Content.ToString());

            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            int num6 = 0;

            foreach (int roll in fullHouseArray)
            {
                if (roll == 1)
                {
                    num1++;
                }
                else if (roll == 2)
                {
                    num2++;
                }
                else if (roll == 3)
                {
                    num3++;
                }
                else if (roll == 4)
                {
                    num4++;
                }
                else if (roll == 5)
                {
                    num5++;
                }
                else if (roll == 6)
                {
                    num6++;
                }
            }

            if((num1 == 3 || num2 == 3 || num3 == 3 || num4 == 3 || num5 == 3 || num6 == 3) &&
                (num1 == 2 || num2 == 2 || num3 == 2 || num4 == 2 || num5 == 2 || num6 == 2))
            {
                FullHouseTotal.Text = "25";
            }
            else
            {
                FullHouseTotal.Text = "0";
            }

            FullHouse.IsEnabled = false;
            RoundReset();
        }
        private void SmallStraight_Click(object sender, RoutedEventArgs e)
        {
            int[] smallStraightArray = new int[5];
            smallStraightArray[0] = Int32.Parse(Dice1.Content.ToString());
            smallStraightArray[1] = Int32.Parse(Dice2.Content.ToString());
            smallStraightArray[2] = Int32.Parse(Dice3.Content.ToString());
            smallStraightArray[3] = Int32.Parse(Dice4.Content.ToString());
            smallStraightArray[4] = Int32.Parse(Dice5.Content.ToString());

            if (((smallStraightArray.Contains(1)) && (smallStraightArray.Contains(2)) && (smallStraightArray.Contains(3)) && (smallStraightArray.Contains(4))) ||
                  ((smallStraightArray.Contains(2)) && (smallStraightArray.Contains(3)) && (smallStraightArray.Contains(4)) && (smallStraightArray.Contains(5))) ||
                  ((smallStraightArray.Contains(3)) && (smallStraightArray.Contains(4)) && (smallStraightArray.Contains(5)) && (smallStraightArray.Contains(6))) )
            {
                MessageBox.Show("YASSS");
                SmallStraightTotal.Text = "30";
            }
            else
            {
                MessageBox.Show("BOOO");
                SmallStraightTotal.Text = "0";
            }
            SmallStraight.IsEnabled = false;
            RoundReset();
        }
        private void LargeStraight_Click(object sender, RoutedEventArgs e)
        {
            int[] largeStraightArray = new int[5];
            largeStraightArray[0] = Int32.Parse(Dice1.Content.ToString());
            largeStraightArray[1] = Int32.Parse(Dice2.Content.ToString());
            largeStraightArray[2] = Int32.Parse(Dice3.Content.ToString());
            largeStraightArray[3] = Int32.Parse(Dice4.Content.ToString());
            largeStraightArray[4] = Int32.Parse(Dice5.Content.ToString());

            if (((largeStraightArray.Contains(1)) && (largeStraightArray.Contains(2)) && (largeStraightArray.Contains(3)) && (largeStraightArray.Contains(4)) && (largeStraightArray.Contains(5))) ||
                  ((largeStraightArray.Contains(2)) && (largeStraightArray.Contains(3)) && (largeStraightArray.Contains(4)) && (largeStraightArray.Contains(5)) && (largeStraightArray.Contains(6))))
            {
                LargeStraightTotal.Text = "40";
            }
            else
            {
                LargeStraightTotal.Text = "0";
            }
            SmallStraight.IsEnabled = false;
            RoundReset();

            LargeStraight.IsEnabled = false;
            RoundReset();
        } 
        private void Chance_Click(object sender, RoutedEventArgs e)
        {
            int chanceSum = 0;

            chanceSum += (Int32.Parse(Dice1.Content.ToString()));
            chanceSum += (Int32.Parse(Dice2.Content.ToString()));
            chanceSum += (Int32.Parse(Dice3.Content.ToString()));
            chanceSum += (Int32.Parse(Dice4.Content.ToString()));
            chanceSum += (Int32.Parse(Dice5.Content.ToString()));
            ChanceTotal.Text = chanceSum.ToString();
            Chance.IsEnabled = false;
            RoundReset();
        }
        private void Yahtzee_Click(object sender, RoutedEventArgs e)
        {
            Yahtzee.IsEnabled = false;

            if (((Int32.Parse(Dice1.Content.ToString())) ==
                (Int32.Parse(Dice2.Content.ToString()))) &&
                ((Int32.Parse(Dice2.Content.ToString())) ==
                (Int32.Parse(Dice3.Content.ToString()))) &&
                ((Int32.Parse(Dice3.Content.ToString())) ==
                (Int32.Parse(Dice1.Content.ToString()))) &&
                ((Int32.Parse(Dice4.Content.ToString())) ==
                (Int32.Parse(Dice5.Content.ToString()))))
            {
                YahtzeeTotal.Text = "50";
            }
            else
            {
                YahtzeeTotal.Text = "0";
            }
            RoundReset();
        }
        private void Dice1_Click(object sender, RoutedEventArgs e)
        {
            if (rolls == 2)
            {

            }
            else
            {
                if (_dice1 == true)
                {
                    Dice1.Background = Brushes.CornflowerBlue;
                    _dice1 = false;
                }
                else
                {
                    Dice1.Background = Brushes.Beige;
                    _dice1 = true;
                }

            }
        }
        private void Dice2_Click(object sender, RoutedEventArgs e)
        {
            if (rolls == 2)
            {

            }
            else
            {
                if (_dice2 == true)
                {
                    Dice2.Background = Brushes.CornflowerBlue;
                    _dice2 = false;
                }
                else
                {
                    Dice2.Background = Brushes.Beige;
                    _dice2 = true;
                }

            }
        }
        private void Dice3_Click(object sender, RoutedEventArgs e)
        {
            if (rolls == 2)
            {

            }
            else
            {
                if (_dice3 == true)
                {
                    Dice3.Background = Brushes.CornflowerBlue;
                    _dice3 = false;
                }
                else
                {
                    Dice3.Background = Brushes.Beige;
                    _dice3 = true;
                }

            }
        }
        private void Dice4_Click(object sender, RoutedEventArgs e)
        {
            if (rolls == 2)
            {

            }
            else
            {
                if (_dice4 == true)
                {
                    Dice4.Background = Brushes.CornflowerBlue;
                    _dice4 = false;
                }
                else
                {
                    Dice4.Background = Brushes.Beige;
                    _dice4 = true;
                }

            }
        }
        private void Dice5_Click(object sender, RoutedEventArgs e)
        {
            if (rolls == 2)
            {

            }
            else
            {
                if (_dice5 == true)
                {
                    Dice5.Background = Brushes.CornflowerBlue;
                    _dice5 = false;
                }
                else
                {
                    Dice5.Background = Brushes.Beige;
                    _dice5 = true;
                }

            }
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            //RoundReset();
            //GameReset();
        }
        private void Options_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }
        private void GameReset()
        {
            ResetScoreButtons();
            ResetDice();
        }
        private void ResetDice()
        {
            dice1 = 0;
            Dice1.Content = "";
            dice2 = 0;
            Dice2.Content = "";
            dice3 = 0;
            Dice3.Content = "";
            dice4 = 0;
            Dice4.Content = "";
            dice5 = 0;
            Dice5.Content = "";
        }
        private void ResetScoreButtons()
        {
            Ones.IsEnabled = true;
            Twos.IsEnabled = true;
            Threes.IsEnabled = true;
            Fours.IsEnabled = true;
            Fives.IsEnabled = true;
            Sixes.IsEnabled = true;
            ThreeOfAKind.IsEnabled = true;
            FourOfAKind.IsEnabled = true;
            FullHouse.IsEnabled = true;
            SmallStraight.IsEnabled = true;
            LargeStraight.IsEnabled = true;
            Chance.IsEnabled = true;
            Yahtzee.IsEnabled = true;
        }
        //private void ChooseOPScore()
        //{
        //    Random r = new Random();
        //    int rInt = r.Next(0,15);

        //    if(randomiseOPOrder[rolls] == 1)
        //    {

        //        switch (rInt)
        //        {
        //            case 0:
        //                OPOnesTotal.Text = "0";
        //                break;
        //            case 1:
        //                OPOnesTotal.Text = "0";
        //                break;
        //            case 2:
        //                OPOnesTotal.Text = "1";
        //                break;
        //            case 3:
        //                OPOnesTotal.Text = "1";
        //                break;
        //            case 4:
        //                OPOnesTotal.Text = "1";
        //                break;
        //            case 5:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 6:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 7:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 8:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 9:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 10:
        //                OPOnesTotal.Text = "3";
        //                break;
        //            case 11:
        //                OPOnesTotal.Text = "3";
        //                break;
        //            case 12:
        //                OPOnesTotal.Text = "3";
        //                break;
        //            case 13:
        //                OPOnesTotal.Text = "3";
        //                break;
        //            case 14:
        //                OPOnesTotal.Text = "4";
        //                break;
        //            case 15:
        //                OPOnesTotal.Text = "4";
        //                break;
        //            default:
        //                OPOnesTotal.Text = "5";
        //                break;
        //        }
        //    }
        //    if (randomiseOPOrder[rolls] == 2)
        //    {
        //        switch (rInt)
        //        {
        //            case 0:
        //                OPTwosTotal.Text = "0";
        //                break;
        //            case 1:
        //                OPTwosTotal.Text = "0";
        //                break;
        //            case 2:
        //                OPTwosTotal.Text = "2";
        //                break;
        //            case 3:
        //                OPTwosTotal.Text = "2";
        //                break;
        //            case 4:
        //                OPTwosTotal.Text = "4";
        //                break;
        //            case 5:
        //                OPTwosTotal.Text = "4";
        //                break;
        //            case 6:
        //                OPTwosTotal.Text = "4";
        //                break;
        //            case 7:
        //                OPTwosTotal.Text = "4";
        //                break;
        //            case 8:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 9:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 10:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 11:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 12:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 13:
        //                OPTwosTotal.Text = "6";
        //                break;
        //            case 14:
        //                OPTwosTotal.Text = "8";
        //                break;
        //            case 15:
        //                OPTwosTotal.Text = "10";
        //                break;
        //            default:
        //                OPTwosTotal.Text = "0";
        //                break;
        //        }
        //    }
        //    if (randomiseOPOrder[rolls] == 3)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 4)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 5)
        //    {
        //        switch (rInt)
        //        {
        //            case 0:
        //                OPSixesTotal.Text = "0";
        //                break;
        //            case 1:
        //                OPSixesTotal.Text = "6";
        //                break;
        //            case 2:
        //                OPSixesTotal.Text = "6";
        //                break;
        //            case 3:
        //                OPSixesTotal.Text = "6";
        //                break;
        //            case 4:
        //                OPSixesTotal.Text = "6";
        //                break;
        //            case 5:
        //                OPSixesTotal.Text = "10";
        //                break;
        //            case 6:
        //                OPSixesTotal.Text = "10";
        //                break;
        //            case 7:
        //                OPSixesTotal.Text = "10";
        //                break;
        //            case 8:
        //                OPSixesTotal.Text = "15";
        //                break;
        //            case 9:
        //                OPSixesTotal.Text = "15";
        //                break;
        //            case 10:
        //                OPSixesTotal.Text = "15";
        //                break;
        //            case 11:
        //                OPSixesTotal.Text = "15";
        //                break;
        //            case 12:
        //                OPSixesTotal.Text = "20";
        //                break;
        //            case 13:
        //                OPSixesTotal.Text = "20";
        //                break;
        //            case 14:
        //                OPSixesTotal.Text = "20";
        //                break;
        //            case 15:
        //                OPSixesTotal.Text = "25";
        //                break;
        //            default:
        //                OPSixesTotal.Text = "0";
        //                break;
        //        }
        //    }
        //    if (randomiseOPOrder[rolls] == 6)
        //    {
        //        switch (rInt)
        //        {
        //            case 0:
        //                OPOnesTotal.Text = "0";
        //                break;
        //            case 1:
        //                OPOnesTotal.Text = "0";
        //                break;
        //            case 2:
        //                OPOnesTotal.Text = "2";
        //                break;
        //            case 3:
        //                OPOnesTotal.Text = "6";
        //                break;
        //            case 4:
        //                OPOnesTotal.Text = "6";
        //                break;              
        //            case 5:                 
        //                OPOnesTotal.Text = "6";
        //                break;              
        //            case 6:                 
        //                OPOnesTotal.Text = "6";
        //                break;
        //            case 7:
        //                OPOnesTotal.Text = "12";
        //                break;
        //            case 8:
        //                OPOnesTotal.Text = "12";
        //                break;
        //            case 9:
        //                OPOnesTotal.Text = "12";
        //                break;
        //            case 10:
        //                OPOnesTotal.Text = "24";
        //                break;
        //            case 11:
        //                OPOnesTotal.Text = "24";
        //                break;
        //            case 12:
        //                OPOnesTotal.Text = "24";
        //                break;
        //            case 13:
        //                OPOnesTotal.Text = "36";
        //                break;
        //            case 14:
        //                OPOnesTotal.Text = "36";
        //                break;
        //            case 15:
        //                OPOnesTotal.Text = "48";
        //                break;
        //            default:
        //                OPOnesTotal.Text = "0";
        //                break;
        //        }
        //    }
        //    if (randomiseOPOrder[rolls] == 7)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 8)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 9)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 10)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 11)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 12)
        //    {

        //    }
        //    if (randomiseOPOrder[rolls] == 13)
        //    {
        //        switch (rInt)
        //        {

        //            case 0:
        //                OPYahtzeeTotal.Text = "50";
        //                break;
        //            default:
        //                OPYahtzeeTotal.Text = "0";
        //                break;
        //        }
        //    }
        //}


        //void ShuffleOpponentOrder()
        //{
        //    {
        //        randomiseOPOrder = ShuffleArray(randomiseOPOrder);
        //    }
        //    int[] ShuffleArray(int[] opPlayOrder)
        //    {
        //        Random r = new Random();
        //        for (int i = opPlayOrder.Length; i > 0; i--)
        //        {
        //            int j = r.Next(i);
        //            int k = opPlayOrder[j];
        //            opPlayOrder[j] = opPlayOrder[i - 1];
        //            opPlayOrder[i - 1] = k;
        //        }

        //        return opPlayOrder;
        //    }
        //}
    }
}
