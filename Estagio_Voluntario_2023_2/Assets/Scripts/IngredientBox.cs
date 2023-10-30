using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Ingredients ingredient;
    public int ingredientIndex;

    Ingredients GetIngredient(){
        return ingredient;
    }

    public void InstantiateIngredient(Vector3 spawnPoint){
        Ingredients ingredient = GetIngredient();
        ingredientIndex = ingredient.GetIngredientIndex();
        GameObject ingredientGameObject = Instantiate(ingredientPrefab, spawnPoint, Quaternion.identity);
        ingredientGameObject.GetComponent<SpriteRenderer>().sprite = ingredient.ingredientSprite;
    }
}
