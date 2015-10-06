using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float ShipSpeed = 40;

    public Rigidbody ship;

    // Use this for initialization
    void Start()
    {

    }
   
    void FixedUpdate()
    {
        MoveControl();
    }


    void MoveControl() {
        float leftRightAxis = Input.GetAxis("Horizontal");
        float topDownAxis = Input.GetAxis("Vertical");

        //ship.MovePosition(ship.position + new Vector3(leftRightAxis, 0, topDownAxis) * ShipSpeed * Time.deltaTime);
        ship.AddForce(new Vector3(leftRightAxis, 0, topDownAxis) * ShipSpeed/** Time.deltaTime*/);
    }
}
