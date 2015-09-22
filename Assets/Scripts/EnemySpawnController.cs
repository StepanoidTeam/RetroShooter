using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {


	public GameObject Asteroid;

	public float Timer;
	public float SpawnRange;


	private float _currentTimer;

	// Use this for initialization
	void Start () {
		_currentTimer = Timer;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (_currentTimer > 0) {

			_currentTimer-=Time.deltaTime;
		}else{
			CreateAsteroid();
			_currentTimer = Timer;
		}


	}


	private void CreateAsteroid(){
		var asteroidPos = transform.position + Vector3.right *Random.Range (-SpawnRange, SpawnRange);
		GameObject asteroid = Instantiate (Asteroid, asteroidPos, Quaternion.identity) as GameObject;

	}
}
