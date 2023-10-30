using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour
{
    public GameObject ingredientPrefab;

    public void InstantiateIngredient(Vector3 spawnPoint){
        GameObject ingredientGameObject = Instantiate(ingredientPrefab, spawnPoint, Quaternion.identity);
    }
}
