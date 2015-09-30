using System;
using UnityEngine;


public class Destroyable : MonoBehaviour
{
    [Range(0, 1)]
    public float Health = 1;
    [Range(0, 1)]
    public float DamagePerHit = 1;
    public string ColliderTag;

    public GameObject DieEffect;

    public delegate void HitEventHandler(GameObject sender, Collider other, float health);

    public event HitEventHandler OnDie;
    public event HitEventHandler OnHit;


    void Hit(Collider other)
    {
        Health = Mathf.Max(Health - DamagePerHit, 0f);

        if (Health <= 0)
        {
            if (OnDie != null)
            {
                OnDie(gameObject, other, Health);

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
            OnHit(gameObject, other, Health);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ColliderTag))
        {
            Hit(other);
        }
    }
}
