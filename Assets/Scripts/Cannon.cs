using UnityEngine;

public class Cannon : MonoBehaviour
{
    public bool IsActive = true;
    public float BulletSpeed = 2000;
    public float BulletCooldown = 0.5f;

    public Transform BulletStartPosition;
    public GameObject BulletGO;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            Shooting();
        }
    }


    float cooldown = 0;
    void Shooting()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }
        else
        {
            GameObject bullet = Instantiate(BulletGO, BulletStartPosition.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(BulletStartPosition.forward * BulletSpeed);

            cooldown += BulletCooldown;
        }
    }
}
