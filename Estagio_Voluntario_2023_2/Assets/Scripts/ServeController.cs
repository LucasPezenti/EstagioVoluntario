using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ServeController : MonoBehaviour
{
    [SerializeField] Transform order;
    [SerializeField] Transform serveSpot;

    public bool HasOrder(){
        return this.order != null;
    }

    public void setOrder(Transform _order){
        this.order = _order;
    }

}
