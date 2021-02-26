//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class CityConverter : MonoBehaviour
//{
//    public List<GameObject> list;
//    public GameObject prefab;
//    public Transform parent;

//    [ContextMenu("Add")]
//    public void Add()
//    {
//        list.Clear();
//        for (int i = 0; i < transform.childCount; i++)
//        {
//            list.Add(transform.GetChild(i).gameObject);
//        }
//    }


//    [ContextMenu("Replace")]
//    public void Replace()
//    {
//        foreach (GameObject item in list)
//        {
//            item.SetActive(false);
//            GameObject obj = PrefabUtility.InstantiatePrefab(prefab as GameObject) as GameObject;
//            Vector3 pos = item.transform.position;
//            pos.y = Mathf.Round(item.transform.position.y);
//            obj.transform.position = pos;
//            obj.transform.rotation = item.transform.rotation;
//            obj.transform.parent = parent;
//        }
//    }

//}
