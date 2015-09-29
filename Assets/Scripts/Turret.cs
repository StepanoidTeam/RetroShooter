using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject player;
    GamePlay gamePlay;
    //List<Cannon> Cannons = new List<Cannon>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GetComponent<LookAtSLerp>().Target = player.transform;

        //GetComponent<Destroyable>().OnDie += Turret_OnDie;

        gamePlay = GameObject.FindObjectOfType<GamePlay>();
    }

    private void Turret_OnDie(GameObject sender, int durability)
    {
        //Destroy(gameObject);
        //gameObject.SetActive(false);

        gamePlay.AddScore(10);
    }


    // Update is called once per frame
    void Update()
    {
    }

}
