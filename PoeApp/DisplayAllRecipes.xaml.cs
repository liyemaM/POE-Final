using System.Windows;

namespace PoeApp
{
    public partial class DisplayAllRecipes : Window
    {
        public DisplayAllRecipes()
        {
            InitializeComponent();
            RecipesListView.ItemsSource = MainWindow.Recipes;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
