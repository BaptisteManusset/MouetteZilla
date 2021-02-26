using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] GameObject prefab;


    [SerializeField] FloatReference score;
    [SerializeField] int quantity = 1;
    int quantityOffset;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    quantityOffset = quantity;


        InvokeRepeating(nameof(SpawnerController), 5, 10);
    }


    void SpawnerController()
    {
        Spawn(quantity);

        quantity = Mathf.RoundToInt(score.Value / 1000) + quantityOffset;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform item = transform.GetChild(i);
            Gizmos.DrawSphere(item.position, .5f);
        }
    }

    public static void Spawn(int count = 1)
    {
        Debug.Log("Spawn");

        Transform y = Spawner.instance.transform.GetChild(Random.Range(0, Spawner.instance.transform.childCount));

        for (int i = 0; i < count; i++)
        {
            Instantiate(Spawner.instance.prefab, y.position, Quaternion.identity);
        }
    }
}
