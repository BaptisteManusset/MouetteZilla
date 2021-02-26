using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    virtual public void Interact()
    {

        Debug.Log("interaction");
    }
    
    virtual public void Interact(int value)
    {

        Debug.Log("interaction");
    }
}
