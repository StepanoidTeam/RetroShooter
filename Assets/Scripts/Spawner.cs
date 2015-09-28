using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnObject;
    public Vector3 Boundaries;

    public float StartWait;
    public float SpawnWait;
    public float WaveWait;


    public int SpawnCount = 1;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {


    }


    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(StartWait);

        while (true)
        {
            for (int i = 0; i < SpawnCount; i++)
            {
                var spawnPoint = transform.position + new Vector3(Random.Range(-Boundaries.x, Boundaries.x), Random.Range(-Boundaries.y, Boundaries.y), Random.Range(-Boundaries.z, Boundaries.z));

                GameObject go = Instantiate(SpawnObject, spawnPoint, Quaternion.identity) as GameObject;
                go.transform.rotation = transform.rotation;

                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
        }

    }
}
