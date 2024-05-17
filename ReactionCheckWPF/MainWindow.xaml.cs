using System.Windows;
using System.Windows.Controls;
using ReactionCheckWPF.Models;

namespace ReactionCheckWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GoButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FirstNameInput.Text)
               || string.IsNullOrEmpty(LastNameInput.Text)
               || CountButtonBox.SelectedItem == null
               || string.IsNullOrEmpty(PressIntervalInput.Text)
               || string.IsNullOrEmpty(ClickBeforeLevelUpInput.Text))
            {
                MessageBox.Show("You haven't filled in all the fields!");
                return;
            }
            if (!int.TryParse(PressIntervalInput.Text, out var pressInterval))
            {
                MessageBox.Show("Invalid press interval input!");
                PressIntervalInput.Clear();
                return;
            }
            if (!int.TryParse(ClickBeforeLevelUpInput.Text, out var clickBeforeLevelUp))
            {
                MessageBox.Show("Invalid clicks before level up input!");
                ClickBeforeLevelUpInput.Clear();
                return;
            }

            int countButtons = int.Parse((CountButtonBox.SelectedItem as ComboBoxItem).Content.ToString());
            TestWindow window = new(FirstNameInput.Text, LastNameInput.Text, new(countButtons, pressInterval, clickBeforeLevelUp));
            window.ShowDialog();
            Close();
        }
    }
}