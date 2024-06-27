using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PoeApp
{
    public partial class DisplayRecipeWindow : Window
    {
        private List<Recipe> allRecipes;

        public DisplayRecipeWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            allRecipes = recipes;
            DisplayRecipes(allRecipes);
        }

        private void DisplayRecipes(List<Recipe> recipes)
        {
            try
            {
                RecipesListView.ItemsSource = recipes.Select(recipe => new { Name = recipe.Name }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while displaying recipes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FoodGroupComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedFoodGroup = selectedItem.Content.ToString();
                if (selectedFoodGroup == "All")
                {
                    DisplayRecipes(allRecipes);
                }
                else
                {
                    var filteredRecipes = allRecipes.Where(recipe => recipe.Ingredients != null &&
                                                                     recipe.Ingredients.Any(ingredient => ingredient.FoodGroup == selectedFoodGroup)).ToList();
                    DisplayRecipes(filteredRecipes);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
