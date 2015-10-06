using UnityEngine;

public class TiltByForce : MonoBehaviour {

    //public Vector3 TiltRate;
    public float TiltRate = -2;

    public Rigidbody RigidbodyToRefer;
    public Transform TransformToRotate;
    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate () {

        //rb.transform.rotation = Quaternion.Euler(Vector3.Scale(rb.velocity, TiltRate) * Time.deltaTime);

        TransformToRotate.rotation = Quaternion.Euler(RigidbodyToRefer.rotation.x, RigidbodyToRefer.rotation.y, RigidbodyToRefer.velocity.x * TiltRate);

    }
}
