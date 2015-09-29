using UnityEngine;

public class Aligner : MonoBehaviour
{
    public Transform Target;
    public bool X, Y, Z;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            X ? Target.position.x : transform.position.x,
            Y ? Target.position.y : transform.position.y,
            Z ? Target.position.z : transform.position.z);
    }
}
