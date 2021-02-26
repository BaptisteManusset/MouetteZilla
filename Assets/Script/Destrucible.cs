using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(NavMeshObstacle))]
public class Destrucible : Interactable
{


    [SerializeField] Transform child;
    public Rigidbody[] debris;

    private BoxCollider collider;
    private Renderer render;
    private Rigidbody rb;

    [SerializeField] float offset = 4;
    private float radius = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
        collider = GetComponent<BoxCollider>();
        render = GetComponent<Renderer>();
        AutomaticChild();


        if (debris.Length > 0)
        {

            foreach (Rigidbody debri in debris)
            {
                debri.Sleep();
            }
        }

    }



    [ContextMenu("Boom")]
    public override void Interact(int force = 200)
    {
        collider.enabled = false;
        render.enabled = false;
        #region child
        if (child)
        {
            child.GetComponent<Destrucible>()?.Interact(force);
            var render = child.GetComponent<MeshRenderer>();
            if (render) render.material.color = Color.red;
        }
        #endregion

        if (debris.Length > 0)
        {

            foreach (Rigidbody debri in debris)
            {
                #region interaction
                debri.gameObject.SetActive(true);
                debri.isKinematic = false;
                debri.useGravity = true;
                debri.transform.parent = GameManager.instance.scrapCollector.transform;

                debri.AddExplosionForce(force, transform.position, radius);

                #endregion

                GameManager.AddScore(10);


                Destroy(debri.gameObject, Random.Range(5, 15));
            }
        }
        Destroy(gameObject);
    }



    [ContextMenu("AutomaticChild")]
    private void AutomaticChild()
    {
        child = null;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + Vector3.up * offset, .2f);
        if (hitColliders.Length == 0) return;
        foreach (Collider item in hitColliders)
        {
            if (item.gameObject == gameObject) {
                Debug.LogError("Parent cannot by the child (#StopIncest)");
                
                return; }
            child = item.transform;
            //child.Interact();
            child.transform.parent = transform.parent;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position + Vector3.up * offset;

        Gizmos.DrawSphere(pos, 1);
    }

}
