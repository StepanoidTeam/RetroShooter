using UnityEngine;

public class EnableSpawnerOnStay : MonoBehaviour
{

    void Start()
    {


        //Spawner spawner = GetComponent<Spawner>();
        //spawner.enabled = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        col.GetComponent<Spawner>().enabled = true;

    }

    void OnTriggerExit(Collider col)
    {
        Spawner spawner = col.GetComponent<Spawner>();

        if (spawner != null)
        {
            spawner.enabled = false;
        }
    }
}
