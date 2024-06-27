using System.Windows;

namespace PoeApp
{
    public partial class AddRecipe2Window : Window
    {
        private readonly string _recipeName;
        private readonly int _numberOfIngredients;
        private readonly int _numberOfSteps;
        private int _currentIngredientIndex = 1;
        private Recipe _recipe;

        public AddRecipe2Window(string recipeName, int numberOfIngredients, int numberOfSteps)
        {
            InitializeComponent();
            _recipeName = recipeName;
            _numberOfIngredients = numberOfIngredients;
            _numberOfSteps = numberOfSteps;
            _recipe = new Recipe { Name = recipeName, Ingredients = new List<Ingredient>(), Steps = new List<string>() };
            UpdateIngredientPrompt();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientQuantityTextBox.Text) ||
                MeasurementUnitComboBox.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(CaloriesTextBox.Text) ||
                FoodGroupComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all ingredient details.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var ingredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = IngredientQuantityTextBox.Text,
                Unit = MeasurementUnitComboBox.Text,
                Calories = int.Parse(CaloriesTextBox.Text),
                FoodGroup = FoodGroupComboBox.Text
            };
            _recipe.Ingredients.Add(ingredient);

            MessageBox.Show($"Ingredient {_currentIngredientIndex} successfully added!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            if (_currentIngredientIndex < _numberOfIngredients)
            {
                _currentIngredientIndex++;
                ClearInputFields();
                UpdateIngredientPrompt();
            }
            else
            {
                MessageBox.Show("All ingredients added successfully!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                AddRecipe3Window addRecipe3Window = new AddRecipe3Window(_recipe, _numberOfSteps);
                addRecipe3Window.Show();
                this.Close();
            }
        }

        private void ClearInputFields()
        {
            IngredientNameTextBox.Clear();
            IngredientQuantityTextBox.Clear();
            MeasurementUnitComboBox.SelectedIndex = -1;
            CaloriesTextBox.Clear();
            FoodGroupComboBox.SelectedIndex = -1;
        }

        private void UpdateIngredientPrompt()
        {
            this.Title = $"Add Recipe - Ingredient {_currentIngredientIndex} of {_numberOfIngredients}";
        }
    }
}
