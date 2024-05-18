using ReactionCheckWPF.Models;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ReactionCheckWPF
{
    public partial class TestWindow : Window
    {
        private string FirstName;
        private string LastName;
        private TestInfo TestInfo;

        private Stopwatch timer = new();
        private int clickCount = 0;
        private int currentLevel = 1;
        private List<double> reactionList = new();
        private Dictionary<int, Grid> levelGrid;
        private Dictionary<Grid, List<Button>> levelButtonsList;
        private Random random = new();

        public TestWindow()
        {
            InitializeComponent();
        }
        public TestWindow(string firstName, string lastName, TestInfo testInfo)
        {
            InitializeComponent();
            FirstName = firstName;
            LastName = lastName;
            TestInfo = testInfo;
            levelGrid = new()
            {
                {1, LVL1},
                {2, LVL2},
                {3, LVL3},
                {4, LVL4},
                {5, LVL5}
            };
            levelButtonsList = new()
            {
                {LVL1, [Button1LVL1]},
                {LVL2, [Button1LVL2, Button2LVL2]},
                {LVL3, [Button1LVL3, Button2LVL3, Button3LVL3]},
                {LVL4, [Button1LVL4, Button2LVL4, Button3LVL4, Button4LVL4]},
                {LVL5, [Button1LVL5, Button2LVL5, Button3LVL5, Button4LVL5, Button5LVL5]}
            };
        }

        private async Task LevelUp()
        {
            if (currentLevel == TestInfo.CountLevels)
            {
                MessageBox.Show("GAME OVER");
                StartButton.Visibility = Visibility.Hidden;
                SaveButton.Visibility = Visibility.Visible;
                return;
            }
            levelGrid[currentLevel++].Visibility = Visibility.Hidden;
            levelGrid[currentLevel].Visibility = Visibility.Visible;
            clickCount = 0;
        }
        private async Task ActiveButton()
        {
            await Task.Delay(TestInfo.PressInterval * 1000);
            var buttonsList = levelButtonsList[levelGrid[currentLevel]];
            var rndButton = buttonsList[random.Next(0, buttonsList.Count)];
            rndButton.Background = Brushes.DarkRed;
            rndButton.IsEnabled = true;
            timer.Start();
        }

        private async void ReactionButtonClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            (sender as Button).IsEnabled = false;
            reactionList.Add(timer.Elapsed.TotalSeconds);
            ReactionResult.Text = reactionList.Last().ToString();
            timer.Reset();

            ++clickCount;
            if (clickCount == TestInfo.ClicksBeforeLevelUp)
            {
                await LevelUp();
                CurrentLevel.Text = currentLevel.ToString();
                StartButton.IsEnabled = true;
                return;
            }
            await ActiveButton();
        }
        private async void StartButtonClick(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            await ActiveButton();
        }
        private async void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Customer customer = new(FirstName, LastName, reactionList.Average());
            await File.AppendAllTextAsync("results.json", JsonSerializer.Serialize(customer));
            MessageBox.Show("Saved!");
            Close();
        }
    }
}
