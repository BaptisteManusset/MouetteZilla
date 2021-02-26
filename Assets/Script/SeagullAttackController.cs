using DG.Tweening;
using System.Collections;
using UnityEngine;
using Hellmade.Sound;

public class SeagullAttackController : MonoBehaviour
{

    [Header("Object")]
    public GameObject head;
    public Transform center;

    [Header("Power")]
    public FloatReference power;
    [Range(0, 100)] public float powerMax;
    [Range(0, 100)] public float powerIncrease;
    [Range(0, 1)] public float radiusMultiplier = .5f;
    [Range(0, 10)] public float powerMultiplier = 5;
    [Header(" `-> Power Collision")]
    public int force = 100;


    //[Header("Sound")] [SerializeField] AudioClip helicopterDestroy;
    //[SerializeField] AudioClip explotionFat;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (power.Value <= powerMax)
            {
                power.Value += powerIncrease * Time.deltaTime;

            }

            power.Value = Mathf.Min(power.Value, powerMax);

        }

        if (Input.GetMouseButtonUp(0))
        {

            StartCoroutine(nameof(Attack));
        }
    }
    private IEnumerator Attack()
    {
        GetComponentInChildren<Animator>().SetTrigger("head attack");
        float duration = .1f;
        yield return new WaitForSeconds(duration);
        SoundManager.PlaySound(SoundLibrary.instance.explotionFat, (power.Value / powerMax) / 2);
        GameManager.instance.explosionPrefab.GetComponent<Explosion>().Boom(center.transform.position, power.Value * radiusMultiplier, power.Value * powerMultiplier);

        power.Value = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position, power.Value / 50);
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Destructible"))
        {
            Destrucible dest = collision.gameObject.GetComponent<Destrucible>();
            if (dest)
            {
                dest.Interact(force);
                SoundManager.PlaySound(SoundLibrary.instance.collision, 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemy"))
        {
            other.gameObject.GetComponent<Ennemy>()?.Interact();
            SoundManager.PlaySound(SoundLibrary.instance.helicopterExplosion, 1);
        }
        else if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.GetComponent<Bonus>()?.Interact();
        }
    }
}
