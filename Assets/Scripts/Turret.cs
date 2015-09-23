using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    GameObject player;
    //List<Cannon> Cannons = new List<Cannon>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<LookAtSLerp>().Target = player.transform;

        GetComponent<Destroyable>().OnDie += Turret_OnDie;
    }

    private void Turret_OnDie(GameObject sender, int durability)
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
    }

}
