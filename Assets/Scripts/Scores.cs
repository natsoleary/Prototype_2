using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scores : MonoBehaviour
{
    public TextMeshProUGUI recipesText;

    void Update() {
        recipesText.text = Recipes.Instance.completedRecipes.ToString();
    }
}
