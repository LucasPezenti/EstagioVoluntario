using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreroomController : MonoBehaviour
{   
    private int ingredientCount;
    private int maxIngredients = 5;


    public void PickUpIngredient(){
        if(ingredientCount <= maxIngredients){
            GetComponent<IngredientBox>().InstantiateIngredient(transform.position);
            ingredientCount++;
        }
        else{
            return;
        }
    }

}
