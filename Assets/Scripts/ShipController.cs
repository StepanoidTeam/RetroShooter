using UnityEngine;
using System.Collections;

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


    // Use this for initialization
    void Start()
    {

        var d = GetComponent<Destroyable>();


        d.OnDie += D_OnDie;
    }

    private void D_OnDie(GameObject sender, int durability)
    {
        Debug.Log(durability);
        if (durability <= 0)
        {
            Destroy(gameObject);
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
