using UnityEngine;

public class Destroyable : MonoBehaviour
{

    public int Durability = 1;
    public string ColliderTag;

    public GameObject HitEffect;
    public GameObject DieEffect;

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


    void Hit()
    {
        if (--Durability <= 0)
        {
            if (OnDie != null)
            {
                OnDie(gameObject, Durability);

                if (DieEffect != null)
                {
                    var die = Instantiate(DieEffect, transform.position, Quaternion.identity);
                    Destroy(die, 3f);
                }
            }

        }
        else
        {
            if (OnHit != null)
            {
                OnHit(gameObject, Durability);

                if (HitEffect != null)
                {
                    var hit = Instantiate(HitEffect, transform.position, Quaternion.identity);
                    Destroy(hit, 3f);
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(ColliderTag))
        {
            Hit();
        }
    }
}
