using System.Windows;

namespace PoeApp
{
    public partial class AddRecipe3Window : Window
    {
        private readonly Recipe _recipe;
        private readonly int _numberOfSteps;
        private int _currentStepIndex = 1;

        public AddRecipe3Window(Recipe recipe, int numberOfSteps)
        {
            InitializeComponent();
            _recipe = recipe;
            _numberOfSteps = numberOfSteps;
            UpdateStepPrompt();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                MessageBox.Show("Please enter the step description.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _recipe.Steps.Add(StepTextBox.Text);

            MessageBox.Show($"Step {_currentStepIndex} successfully added!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            if (_currentStepIndex < _numberOfSteps)
            {
                _currentStepIndex++;
                ClearInputField();
                UpdateStepPrompt();
            }
            else
            {
                MessageBox.Show("All steps added successfully!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recipe.Steps.Count < _numberOfSteps)
            {
                MessageBox.Show("Please enter all recipe steps before proceeding.", "Incomplete Steps", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MainWindow.Recipes.Add(_recipe);

            MessageBox.Show($"Recipe '{_recipe.Name}' created successfully!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ClearInputField()
        {
            StepTextBox.Clear();
        }

        private void UpdateStepPrompt()
        {
            this.Title = $"Add Recipe - Step {_currentStepIndex} of {_numberOfSteps}";
        }
    }
}
