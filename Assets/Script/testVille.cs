using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testVille : MonoBehaviour
{

    public int quantity = 10;
    public int offset = 4;
    public GameObject prefab;
    void Start()
    {
        for (int i = 0; i < quantity; i++)
        {
            for (int y = 0; y < quantity; y++)
            {
                for (int u = 0; u < Random.Range(1, 6); u++)
                {


                    Instantiate(prefab, new Vector3(i * offset, 2 + 2 * u, y * offset), Quaternion.identity) ;
                }
            }
        }
    }


}
