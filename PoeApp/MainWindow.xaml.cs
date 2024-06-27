using System.Collections.Generic;
using System.Windows;

namespace PoeApp
{
    public partial class MainWindow : Window
    {
        public static List<Recipe> Recipes { get; private set; } = new List<Recipe>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecipeWindow addRecipeWindow = new AddRecipeWindow();
            addRecipeWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void DisplayRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayRecipeWindow displayRecipeWindow = new DisplayRecipeWindow(Recipes);
            displayRecipeWindow.Show();
            this.Close();
        }

        private void AllRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayAllRecipes displayAllRecipes = new DisplayAllRecipes();
            displayAllRecipes.Show();
            this.Close();
        }

        private void ScaleRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipe = new ScaleRecipe();
            scaleRecipe.Show();
            this.Close();
        }
    }
}
