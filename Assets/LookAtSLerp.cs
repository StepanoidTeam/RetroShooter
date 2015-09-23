using UnityEngine;

public class LookAtSLerp : MonoBehaviour {

    public Transform Target;

    [Range(0.1f, 20)]
    public float RotationSpeed = 3;
       

    // Use this for initialization
    void Start () {
	
	}

	
	// Update is called once per frame
	void FixedUpdate () {
        if (Target != null)
        {
            var qLookRotation = Quaternion.LookRotation(Target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, qLookRotation, Time.deltaTime * RotationSpeed);
        }
    }
}
