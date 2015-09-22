using UnityEngine;
using System.Collections;

public class ScrollRepeater : MonoBehaviour {


    public float Speed;
    public Vector3 StartPosition;
    public float Distance;

    public float RealDistanceDebug;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Translate(Vector3.back * Speed * Time.deltaTime);

        RealDistanceDebug = Vector3.Distance(StartPosition, transform.localPosition);

        if (RealDistanceDebug >= Distance) {
            transform.localPosition = StartPosition;
        }
	}
}
