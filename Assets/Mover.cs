using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    public Vector3 Direction;
    public float Speed;

    // Use this for initialization
    Rigidbody rb;
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(Direction * Speed * Time.deltaTime);
    }
}
