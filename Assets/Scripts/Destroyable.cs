using System;
using UnityEngine;


public class Destroyable : MonoBehaviour
{

    public int Durability = 1;
    public string ColliderTag;

    public GameObject DieEffect;

    public delegate void HitEventHandler(GameObject sender, int durability);

    public event HitEventHandler OnDie;
    public event HitEventHandler OnHit;


    void Hit()
    {
        Durability--;

        if (Durability <= 0)
        {
            if (OnDie != null)
            {
                OnDie(gameObject, Durability);
                
            }
            if (DieEffect != null)
            {
                var die = Instantiate(DieEffect, transform.position, Quaternion.identity);
                Destroy(die, 3f);
            }
            Destroy(gameObject);
        }
        else if (OnHit != null) //Dur > 0
        {
            OnHit(gameObject, Durability);
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
