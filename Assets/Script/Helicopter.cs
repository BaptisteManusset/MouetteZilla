using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Helicopter : Ennemy
{
  Vector3 destination;
  Vector3 direction;
  [SerializeField] float distanceMin = 8;
  [SerializeField] float speed = 10;

  ParticleSystem particle;

  void Awake()
  {
    particle = GetComponentInChildren<ParticleSystem>();
  }


  private void FixedUpdate()
  {
    if (dead) return;

    destination = GameManager.instance.seagull.transform.position;
    destination.y = transform.position.y;


    if (Vector3.Distance(destination, transform.position) > distanceMin)
    {
      direction = destination - transform.position;
      transform.LookAt(destination);
      transform.DOMove(transform.position + Vector3.Normalize(direction) * speed, 2);
    } else
    {
      transform.LookAt(destination);
      particle.transform.LookAt(GameManager.instance.seagull.transform.position);
      GameManager.Damage(damage);
    }
  }

  public override void Interact()
  {

    if (dead) return;
    FXManager.Explosion(transform.position);
    particle.Stop();
    gameObject.SetActive(false);
    transform.position = new Vector3(0, -100, 0);
    GameManager.AddScore(500);

  }

}
