using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    public float ShipSpeed = 40;

    public Rigidbody ship;

    public Text health;
    public Slider healthBar;


    GamePlay gamePlay;

    float MaxDurability = 20f;

    // Use this for initialization
    void Start()
    {
        gamePlay = GameObject.FindObjectOfType<GamePlay>();

        var d = GetComponent<Destroyable>();
        d.OnHit += ShipController_OnHit;
        d.OnDie += ShipController_OnDie;

        health.text = "100%";
        healthBar.value = 1;

    }

    private void ShipController_OnHit(GameObject sender, int durability)
    {
        health.text = durability / MaxDurability * 100f + "%";
        healthBar.value = durability / MaxDurability;
    }

    private void ShipController_OnDie(GameObject sender, int durability)
    {


        PlayerPrefs.SetInt("HiScore", gamePlay.HiScore);


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
