using System;
using System.Collections.Generic;
using System.Windows;

namespace PoeApp
{
    public partial class ScaleRecipe : Window
    {
        private List<Recipe> recipes;
        private Dictionary<Ingredient, string> originalQuantities;

        public ScaleRecipe()
        {
            InitializeComponent();
            LoadRecipes();
            originalQuantities = new Dictionary<Ingredient, string>();
        }

        private void LoadRecipes()
        {
            recipes = MainWindow.Recipes;
            RecipeComboBox.ItemsSource = recipes;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)RecipeComboBox.SelectedItem;
                double scaleFactor = 1.0;

                if (sender == HalfButton)
                    scaleFactor = 0.5;
                else if (sender == DoubleButton)
                    scaleFactor = 2.0;
                else if (sender == TripleButton)
                    scaleFactor = 3.0;

                ScaleIngredients(selectedRecipe, scaleFactor);
            }
        }

        private void ScaleIngredients(Recipe recipe, double scaleFactor)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                if (!originalQuantities.ContainsKey(ingredient))
                {
                    originalQuantities.Add(ingredient, ingredient.Quantity);
                }

                if (double.TryParse(ingredient.Quantity, out double quantity))
                {
                    ingredient.Quantity = (quantity * scaleFactor).ToString();
                }
            }

            RefreshIngredientsList(recipe);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)RecipeComboBox.SelectedItem;
                foreach (var ingredient in selectedRecipe.Ingredients)
                {
                    if (originalQuantities.TryGetValue(ingredient, out string originalQuantity))
                    {
                        ingredient.Quantity = originalQuantity;
                    }
                }

                originalQuantities.Clear();

                RefreshIngredientsList(selectedRecipe);
            }
        }

        private void RefreshIngredientsList(Recipe recipe)
        {
            IngredientsListBox.ItemsSource = null;
            IngredientsListBox.ItemsSource = recipe.Ingredients;
        }

        private void RecipeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem != null)
            {
                Recipe selectedRecipe = (Recipe)RecipeComboBox.SelectedItem;
                RefreshIngredientsList(selectedRecipe);
            }
        }
    }
}
