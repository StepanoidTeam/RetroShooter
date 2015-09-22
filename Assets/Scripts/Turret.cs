using UnityEngine;
using System.Collections;
using System;

public class Turret : MonoBehaviour {

    public GameObject Bullet;
    public float BulletSpeed = 2000;
    public float BulletCooldown = 0.5f;
    public Transform cannonLeftPos;
    public Transform cannonRightPos;
    // 

    GameObject player;
    
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

        var d = GetComponent<Destroyable>();


        d.OnDie += D_OnDie;
    }

    private void D_OnDie(GameObject sender, int durability)
    {
        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        if (player != null) { 
            transform.LookAt(player.transform);

            Shooting();
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
