using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    public float ShipSpeed = 40;

    public Rigidbody ship;

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
   
    // Update is called once per frame

    float rotation = 0;
    void FixedUpdate()
    {
        MoveControl();
    }


    void MoveControl() {
        float leftRightAxis = Input.GetAxis("Horizontal");
        float topDownAxis = Input.GetAxis("Vertical");

        ship.AddForce(new Vector3(leftRightAxis, 0, topDownAxis) * ShipSpeed);
    }
}
