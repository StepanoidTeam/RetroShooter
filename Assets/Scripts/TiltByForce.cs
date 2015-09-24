using UnityEngine;

public class TiltByForce : MonoBehaviour {

    //public Vector3 TiltRate;
    public float TiltRate = -2;

    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate () {

        //rb.transform.rotation = Quaternion.Euler(Vector3.Scale(rb.velocity, TiltRate) * Time.deltaTime);

        rb.transform.rotation = Quaternion.Euler(0, 0, rb.velocity.x * TiltRate);

    }
}
