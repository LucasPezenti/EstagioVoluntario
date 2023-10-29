using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Ingredients ingredient;

    Ingredients GetIngredient(){
        return ingredient;
    }

    public void InstantiateIngredient(Vector3 spawnPoint){
        Ingredients ingredient = GetIngredient();
        GameObject ingredientGameObject = Instantiate(ingredientPrefab, spawnPoint, Quaternion.identity);
        ingredientGameObject.GetComponent<SpriteRenderer>().sprite = ingredient.ingredientSprite;
    }
}
