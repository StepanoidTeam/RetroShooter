using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Events
    public delegate void SpawnEventHandler(GameObject sender);

    public event SpawnEventHandler OnSpawn;
    #endregion

    #region properties
    public GameObject SpawnObject;
    public Vector3 Boundaries;

    public float StartWait;
    public float SpawnWait;
    public float WaveWait;

    public bool IsActive = true;

    public int SpawnCount = 1;
    #endregion

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

        while (IsActive)
        {
            for (int i = 0; i < SpawnCount; i++)
            {
                var spawnPoint = transform.position + new Vector3(Random.Range(-Boundaries.x, Boundaries.x), Random.Range(-Boundaries.y, Boundaries.y), Random.Range(-Boundaries.z, Boundaries.z));

                GameObject go = Instantiate(SpawnObject, spawnPoint, Quaternion.identity) as GameObject;
                go.transform.rotation = transform.rotation;
                if (OnSpawn != null) OnSpawn(go);

                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "ghost-icon.png", false);

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * 2f);
        Gizmos.DrawSphere(transform.position + transform.forward * 0.3f, 0.3f);
    }
}
