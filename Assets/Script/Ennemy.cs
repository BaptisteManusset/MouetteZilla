using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    protected bool dead = false;
    [SerializeField] protected float damage = 1;

   virtual public void Interact()
    {
        if (dead) return;
        Debug.LogError("Please overide me");
    }

}
