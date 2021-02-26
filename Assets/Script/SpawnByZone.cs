using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByZone : MonoBehaviour
{
 public GameObject prefab;

  bool toggle = true;

  public int delay = 10;
  public float radius = 20;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      toggle = true;

      InvokeRepeating(nameof(Spawn), 1.5f, 3.5f);
    }
  }
  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {

      toggle = true;
      CancelInvoke();
    }
  }

  private void Spawn()
  {
    Vector3 pos = Random.insideUnitCircle * radius;
    pos.y = 8;
    Instantiate(prefab, pos, Quaternion.identity);
  }
}
