using UnityEngine;
using System.Collections;

public class SlowMo : MonoBehaviour {


    public float Speed = 1f;
    public float DeltaInterval = 0.02f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = Speed;
        Time.fixedDeltaTime = DeltaInterval * Speed;

    }
}
