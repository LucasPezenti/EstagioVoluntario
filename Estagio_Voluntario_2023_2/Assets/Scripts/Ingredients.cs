using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ingredients : ScriptableObject
{
    public Sprite ingredientSprite;
    public string ingredientName;
    public int IngredientIndex;

    public Ingredients(string ingredientName, int IngredientIndex){
        this.ingredientName = ingredientName;
        this.IngredientIndex = IngredientIndex;
    }
}
