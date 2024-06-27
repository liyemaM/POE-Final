using System.Windows;

namespace PoeApp
{
    public partial class AddRecipeWindow : Window
    {
        public AddRecipeWindow()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeNameTextBox.Text;
            if (int.TryParse(NumberOfIngredientsTextBox.Text, out int numberOfIngredients) &&
                int.TryParse(NumberOfIngredientsTextBox_Copy.Text, out int numberOfSteps) &&
                !string.IsNullOrEmpty(recipeName))
            {
                if (numberOfIngredients > 0 && numberOfSteps > 0)
                {
                    AddRecipe2Window addRecipe2Window = new AddRecipe2Window(recipeName, numberOfIngredients, numberOfSteps);
                    addRecipe2Window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter valid numbers for ingredients and steps.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all details.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
