using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InterestPoint : MonoBehaviour
{
  public float health = 10000;
  [SerializeField] float healthMax = 0;

  bool isDestroy = false;
  public int scoreBonus = 10000;
  public ParticleSystem particle;
  public ParticleSystem particleOra;
  public Image tmp;

  private void Awake()
  {
    healthMax = health;
    SetUi();

  }
  public void Damage(float value)
  {
    if (isDestroy) return;

    health -= value;

    if (health <= 0)
    {
      isDestroy = true;
    }

    SetUi();

    if (isDestroy)
    {
      GameManager.AddScore(scoreBonus);
      SoundManager.PlaySound(SoundLibrary.instance.interestDestroyBonus, 1);
      particle.Play();
      particleOra.Stop();
      GetComponent<MeshRenderer>().enabled = false;
      return;
    }
  }

  void SetUi()
  {
    tmp.fillAmount = health / healthMax;

  }
}
