using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Recipes : MonoBehaviour
{
    public static Recipes Instance;

    public int totalSheep;
    public int totalPigs;
    public int totalEggs;
    public int totalChickens;
    // private int totalFlowers;
    
    public TextMeshProUGUI sheepText;
    public TextMeshProUGUI pigsText;
    public TextMeshProUGUI eggsText;

    private List<Recipe> currentRecipes;
    public List<RecipePanel> recipePanels;

    public Sprite sheepSprite;
    public Sprite pigSprite;
    public Sprite eggSprite;
    public Sprite chickenSprite;

    public int completedRecipes;

    private void Awake() {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        currentRecipes = new List<Recipe>();
        AddRandomRecipe(0);
        AddRandomRecipe(1);
        AddRandomRecipe(2);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(currentRecipes.Count);
    }

    private void AddRandomRecipe(int index) {
        int randomNumber = Random.Range(1, 4);
        // breakfast
        if (randomNumber == 1) {
            Recipe recipe = new Recipe("Breakfast", new List<Ingredient>(new[] {Ingredient.Egg, Ingredient.Egg, Ingredient.Pig}));
            if(currentRecipes.Count > index) currentRecipes.RemoveAt(index);
            currentRecipes.Insert(index, recipe);
            recipe.UpdatePanel(recipePanels[index]);
        }
        // lunch
        else if (randomNumber == 2) {
            Recipe recipe = new Recipe("Lunch", new List<Ingredient>(new[] {Ingredient.Chicken, Ingredient.Egg, Ingredient.Egg}));
            if(currentRecipes.Count > index) currentRecipes.RemoveAt(index);
            currentRecipes.Insert(index, recipe);
            recipe.UpdatePanel(recipePanels[index]);
        }
        // dinner
        if (randomNumber == 3) {
            Recipe recipe = new Recipe("Dinner", new List<Ingredient>(new[]
                {Ingredient.Sheep, Ingredient.Sheep, Ingredient.Chicken, Ingredient.Chicken}));
            if(currentRecipes.Count > index) currentRecipes.RemoveAt(index);
            currentRecipes.Insert(index, recipe);
            recipe.UpdatePanel(recipePanels[index]);
        }
        // sweater
        if (randomNumber == 4) {
            Recipe recipe = new Recipe("Sweater", new List<Ingredient>(new[] {Ingredient.Sheep, Ingredient.Sheep}));
            if(currentRecipes.Count > index) currentRecipes.RemoveAt(index);
            currentRecipes.Insert(index, recipe);
            recipe.UpdatePanel(recipePanels[index]);
        }
    }
    
    public void AddSheep() {
        totalSheep++;
        if(sheepText != null) sheepText.text = totalSheep.ToString();
        for (int i = 0; i < currentRecipes.Count; i++) {
            if (currentRecipes[i].RecipeContains(Ingredient.Sheep)) {
                if (currentRecipes[i].AddIngredient(Ingredient.Sheep)) {
                    AddRandomRecipe(i);
                }
                return;
            }
        }
        Debug.Log("none of the current recipes needed sheep");
    }
    public void AddPig() {
        totalPigs++;
        if(pigsText != null) pigsText.text = totalPigs.ToString();
        for (int i = 0; i < currentRecipes.Count; i++) {
            if (currentRecipes[i].RecipeContains(Ingredient.Pig)) {
                if (currentRecipes[i].AddIngredient(Ingredient.Pig)) {
                    AddRandomRecipe(i);
                }
                return;
            }
        }
        Debug.Log("none of the current recipes needed pigs");
    }
    public void AddEgg() {
        totalEggs++;
        if(eggsText != null) eggsText.text = totalEggs.ToString();
        for (int i = 0; i < currentRecipes.Count; i++) {
            if (currentRecipes[i].RecipeContains(Ingredient.Egg)) {
                if (currentRecipes[i].AddIngredient(Ingredient.Egg)) {
                    AddRandomRecipe(i);
                }
                return;
            }
        }
        Debug.Log("none of the current recipes needed eggs");
    }
    public void AddChicken() {
        totalChickens++;
        for (int i = 0; i < currentRecipes.Count; i++) {
            if (currentRecipes[i].RecipeContains(Ingredient.Chicken)) {
                if (currentRecipes[i].AddIngredient(Ingredient.Chicken)) {
                    AddRandomRecipe(i);
                }
                return;
            }
        }
        Debug.Log("none of the current recipes needed chickens");
    }
}

public class Recipe {
    private string recipeName;
    private List<Ingredient> ingredients;
    private RecipePanel panel;

    public Recipe(string recipeName, List<Ingredient> ingredientsInput) {
        this.recipeName = recipeName;
        ingredients = new List<Ingredient>();
        foreach (Ingredient ingredient in ingredientsInput) {
            ingredients.Add(ingredient);
        }
    }

    public bool RecipeContains(Ingredient ingredient) {
        return ingredients.Contains(ingredient);
    }

    // returns true if recipe is done
    public bool AddIngredient(Ingredient ingredient) {
        ingredients.Remove(ingredient);
        
        if (panel.ingredient1 == ingredient)
            panel.ingredient1Count.text = ingredients.FindAll(i => i == panel.ingredient1).Count.ToString();
        if (panel.ingredient2 == ingredient)
            panel.ingredient2Count.text = ingredients.FindAll(i => i == panel.ingredient2).Count.ToString();

        if (ingredients.Count == 0) {
            Recipes.Instance.completedRecipes++;
            return true;
        }
        return false;
    }

    public void UpdatePanel(RecipePanel panel) {
        this.panel = panel;
        List<Ingredient> tempIngredients = new List<Ingredient>(ingredients);

        panel.recipeName.text = recipeName;

        panel.ingredient1 = tempIngredients[0];
        panel.ingredient1Count.text = tempIngredients.FindAll(i => i == panel.ingredient1).Count.ToString();
        if (panel.ingredient1 == Ingredient.Sheep) panel.ingredient1Image.sprite = Recipes.Instance.sheepSprite;
        else if (panel.ingredient1 == Ingredient.Pig) panel.ingredient1Image.sprite = Recipes.Instance.pigSprite;
        else if (panel.ingredient1 == Ingredient.Egg) panel.ingredient1Image.sprite = Recipes.Instance.eggSprite;
        else if (panel.ingredient1 == Ingredient.Chicken) panel.ingredient1Image.sprite = Recipes.Instance.chickenSprite;
        
        tempIngredients.RemoveAll(i => i == panel.ingredient1);
        
        panel.ingredient2 = tempIngredients[0];
        panel.ingredient2Count.text = tempIngredients.Count.ToString();
        if (panel.ingredient2 == Ingredient.Sheep) panel.ingredient2Image.sprite = Recipes.Instance.sheepSprite;
        else if (panel.ingredient2 == Ingredient.Pig) panel.ingredient2Image.sprite = Recipes.Instance.pigSprite;
        else if (panel.ingredient2 == Ingredient.Egg) panel.ingredient2Image.sprite = Recipes.Instance.eggSprite;
        else if (panel.ingredient2 == Ingredient.Chicken) panel.ingredient2Image.sprite = Recipes.Instance.chickenSprite;
    }
}

public enum Ingredient {
    Sheep,
    Pig,
    Egg,
    Chicken
}