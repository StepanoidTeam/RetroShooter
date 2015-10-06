using UnityEngine;

[System.Serializable]
public class BooleanVector3
{
    public bool X, Y, Z;
    public Vector3 ToVector3()
    {
        return new Vector3(X ? 0 : 1, Y ? 0 : 1, Z ? 0 : 1);
    }
}


public class LookAtSLerp : MonoBehaviour
{

    public Transform Target;

    public BooleanVector3 FreezeAxis;
    public Vector3 MinRotation;
    public Vector3 MaxRotation;

    [Range(0.1f, 20)]
    public float RotationSpeed = 3;


    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target != null)
        {


            Vector3 direction = Target.position - transform.position;

            direction.Scale(FreezeAxis.ToVector3());

            var qLookRotation = Quaternion.LookRotation(direction);

            var angles = qLookRotation.eulerAngles;

            angles = new Vector3(angles.x, angles.y, angles.z);


            transform.rotation = Quaternion.Slerp(transform.rotation, qLookRotation, Time.deltaTime * RotationSpeed);

        }
    }
}
