using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using ReactionCheckWPF.Models;

namespace ReactionCheckWPF
{
    public partial class TestWindow : Window
    {
        private string _firstName;
        private string _lastName;
        private TestInfo _testInfo;

        private Stopwatch _timer = new();
        private int _clickCount = 0;
        private int _currentLevel = 1;
        private List<TimeSpan> _reactionList = new();
        private Dictionary<int, Grid> levelGrid;

        public TestWindow()
        {
            InitializeComponent();
        }
        public TestWindow(string firstName, string lastName, TestInfo testInfo)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            _testInfo = testInfo;
            levelGrid = new()
            {
                {1, LVL1},
                {2, LVL2},
                {3, LVL3},
                {4, LVL4}
            };
        }

        private void LevelUp()
        {
            levelGrid[_currentLevel++].Visibility = Visibility.Hidden;
            levelGrid[_currentLevel].Visibility = Visibility.Visible;
        }

        private async void ReactionButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            (sender as Button).IsEnabled = false;
            _reactionList.Add(_timer.Elapsed);
            ReactionResult.Text = _timer.Elapsed.ToString();
            _timer.Reset();

            ++_clickCount;
            if (_clickCount == _testInfo.ClicksBeforeLevelUp)
            {
                LevelUp();
                CurrentLevel.Text = _currentLevel.ToString();
            }
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            await Task.Delay(new Random().Next(1, 4) * 1000);
            Button1LVL1.IsEnabled = true;
            _timer.Start();
        }
    }
}
