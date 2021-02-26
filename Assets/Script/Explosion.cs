using Hellmade.Sound;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float radius;
    public float power;

    public List<ParticleSystem> particleSystems;

    private void Awake()
    {
        particleSystems.AddRange(GetComponentsInChildren<ParticleSystem>());
    }


    public void Boom(Vector3 position, float radius, float power)
    {
        transform.position = position;
        this.radius = radius;
        this.power = power;
        Boom();
    }


    [ContextMenu("Boom")]
    public void Boom()
    {
        if (particleSystems.Count > 0)
        {
            foreach (ParticleSystem p in particleSystems)
            {
                p.Play();
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        if (hitColliders.Length == 0) return;

        foreach (Collider item in hitColliders)
        {
            if (item.CompareTag("Destructible"))
            {
                Destrucible dest = item.GetComponent<Destrucible>();
                if (dest)
                {
                    dest.Interact(0);
                    foreach (Rigidbody debris in dest.debris)
                    {
                        debris.AddExplosionForce(power, transform.position, radius);
                    }
                } else
                {
                    Debug.LogError("Missing Destructible", item.gameObject);
                }
            } else if (item.CompareTag("Ennemy"))
            {
                Helicopter enn = item.GetComponent<Helicopter>();
                SoundManager.PlaySound(SoundLibrary.instance.helicopterExplosion, 1);

                if (enn)
                {
                    enn.Interact();
                }

            } else if (item.CompareTag("Interest"))
            {
                InterestPoint interest = item.GetComponent<InterestPoint>();
                interest.Damage(power);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider item in hitColliders)
        {
            if (!item.CompareTag("Destructible")) continue;
            Gizmos.DrawLine(item.transform.position, transform.position);
            Gizmos.DrawSphere(item.transform.position, .2f);
        }
    }
}
