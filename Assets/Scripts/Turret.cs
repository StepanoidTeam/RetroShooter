using UnityEngine;
using System.Collections;
using System;

public class Turret : MonoBehaviour
{

    public GameObject Bullet;
    public float BulletSpeed = 2000;
    public float BulletCooldown = 0.5f;
    public Transform cannonLeftPos;
    public Transform cannonRightPos;
    // 

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<LookAtSLerp>().Target = player.transform;

        GetComponent<Destroyable>().OnDie += Turret_OnDie;
    }

    public float turretDeathCooldown = 10;

    private void Turret_OnDie(GameObject sender, int durability)
    {
        //Destroy(gameObject);

        gameObject.SetActive(false);

        turretDeathCooldown = 10;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Shooting();
        }

        if (turretDeathCooldown <= 0 && !gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        else {
            turretDeathCooldown -= Time.deltaTime;
        }
    }


    float cooldown = 0;
    void Shooting()
    {

        if (cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
            return;
        }
        else
        {

            GameObject bleft = Instantiate(Bullet, cannonLeftPos.position, Quaternion.identity) as GameObject;
            bleft.GetComponent<Rigidbody>().AddForce(cannonLeftPos.forward * BulletSpeed);

            GameObject bright = Instantiate(Bullet, cannonRightPos.position, Quaternion.identity) as GameObject;
            bright.GetComponent<Rigidbody>().AddForce(cannonRightPos.forward * BulletSpeed);

            cooldown += BulletCooldown;
        }
    }
}
