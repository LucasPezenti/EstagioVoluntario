using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ingredients : MonoBehaviour
{
    public string ingredientName;
    public int ingredientIndex;

    public Ingredients(string ingredientName, int ingredientIndex){
        this.ingredientName = ingredientName;
        this.ingredientIndex = ingredientIndex;
    }

    public int GetIngredientIndex(){
        return ingredientIndex;
    }
}
