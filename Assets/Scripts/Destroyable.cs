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
            Destroy(expl, 5f);
        }

        if (Durability <= 0)
        {
            OnDie(gameObject, Durability);
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Bullet"))
        {
            Explode();

            if (--Durability <= 0)
            {
                Destroy(gameObject);
            }

        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Player"))
        {

            GameController.Life--;
            Destroy(gameObject);
        }

    }
}
