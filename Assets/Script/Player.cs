using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    [Header("Object")]
    public GameObject head;
    public Transform center;
    Rigidbody controller;

    [Header("Power")]
    public FloatReference power;
    public int force = 200;
    [Range(0, 500)] public float powerMax;
    [Range(0, 10)] public float powerIncrease;


    private void Awake()
    {
        controller = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        controller.MovePosition(new Vector3(0, 0, translation));

        transform.Rotate(0, rotation, 0);

        if (Input.GetMouseButton(0))
        {
            if (power.Value <= powerMax)
            {
                power.Value += powerIncrease;
            } else
            {
                power.Value = powerMax;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(nameof(Attack));
            power.Value = 0;
        }
    }
    private IEnumerator Attack()
    {
        float duration = .1f;

        head.transform.DOLocalRotate(new Vector3(90, 0, 0), duration);

        yield return new WaitForSeconds(duration);
        head.transform.DOLocalRotate(Vector3.zero, .1f);

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position, power.Value / 100);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.CompareTag("Destructible"))
        {
            collision.gameObject.GetComponent<Destrucible>().Interact(force);
        }
    }
}
