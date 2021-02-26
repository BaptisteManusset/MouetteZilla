using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
  #region singleton
  static public PoolManager instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    } else
    {
      Destroy(gameObject);
      Debug.LogError("Duplicate PoolManager");
    }
  }
  #endregion


  public Queue<GameObject> list;

  public static void AddToList(GameObject obj)
  {
    PoolManager.instance.list.Enqueue(obj);
  }
  public static void RemoveToList(GameObject obj)
  {
    PoolManager.instance.list.Dequeue();

  }

}
