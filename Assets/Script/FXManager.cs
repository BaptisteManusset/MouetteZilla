using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    #region singleton
    static public FXManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
            Debug.LogError("Duplicate GameManager");
        }
    }
    #endregion


    [SerializeField] ParticleSystem explosion;


    public static void Explosion(Vector3 position)
    {
        Instantiate(FXManager.instance.explosion, position, Quaternion.identity, null);
    }
}
