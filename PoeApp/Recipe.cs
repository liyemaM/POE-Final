namespace PoeApp
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
