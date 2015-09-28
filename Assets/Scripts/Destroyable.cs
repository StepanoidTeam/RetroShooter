using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour
{

    public int Durability = 1;
    public GameObject explosion;

    public delegate void HitEventHandler(GameObject sender, int durability);
    public event HitEventHandler OnDie;
    public event HitEventHandler OnHit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    void Explode()
    {
        if (explosion != null)
        {
            var expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expl, 3f);
        }


        if (--Durability <= 0)
        {
            if (OnDie != null)
            {
                OnDie(gameObject, Durability);
            }

        }
        else
        {
            if (OnHit != null)
            {
                OnHit(gameObject, Durability);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Bullet") || col.gameObject.CompareTag("Player"))
        {
            Explode();
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

    }
}
