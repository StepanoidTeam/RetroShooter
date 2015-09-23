using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{


    public float ShipSpeed = 40;
    public float BulletSpeed = 2000;
    public float BulletCooldown = 0.5f;
    public float TiltRate = 3f;

    public Rigidbody ship;

    public Transform cannonLeftPos;
    public Transform cannonRightPos;

    public GameObject bullet;

    public Text health;
    // Use this for initialization
    void Start()
    {
        var d = GetComponent<Destroyable>();
        d.OnHit += ShipController_OnHit;
        d.OnDie += ShipController_OnDie;

        health.text = "100%";

    }

    private void ShipController_OnHit(GameObject sender, int durability)
    {
        health.text = durability / 20f * 100f + "%";
    }

    private void ShipController_OnDie(GameObject sender, int durability)
    {
        Destroy(gameObject);
        Application.LoadLevel("menu");
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

            GameObject bleft = Instantiate(bullet, cannonLeftPos.position, Quaternion.identity) as GameObject;
            bleft.GetComponent<Rigidbody>().AddForce(cannonLeftPos.forward * BulletSpeed);

            GameObject bright = Instantiate(bullet, cannonRightPos.position, Quaternion.identity) as GameObject;
            bright.GetComponent<Rigidbody>().AddForce(cannonRightPos.forward * BulletSpeed);

            cooldown += BulletCooldown;
        }
    }



    // Update is called once per frame

    float rotation = 0;
    void FixedUpdate()
    {
        float leftRightAxis = Input.GetAxis("Horizontal");
        float topDownAxis = Input.GetAxis("Vertical");

        ship.AddForce(new Vector3(leftRightAxis, 0, topDownAxis)  * ShipSpeed);

        ship.transform.rotation = Quaternion.Euler(0, 0, ship.velocity.x * -TiltRate);

        bool isShooting = Input.GetAxis("Jump") > 0;
        if (isShooting)
        {
            Shooting();
        }

    }
}
