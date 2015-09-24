using UnityEngine;

[System.Serializable]
public class Boundary
{
    public Vector3 Min;
    public Vector3 Max;
}

public class BoundaryClamp : MonoBehaviour {

    public Boundary Boundaries;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, Boundaries.Min.x, Boundaries.Max.x),
            Mathf.Clamp(rb.position.y, Boundaries.Min.y, Boundaries.Max.y),
            Mathf.Clamp(rb.position.z, Boundaries.Min.z, Boundaries.Max.z)
        );


    }
}
