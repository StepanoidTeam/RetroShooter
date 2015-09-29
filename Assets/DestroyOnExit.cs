using UnityEngine;

public class DestroyOnExit : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerExit (Collider col) {

        var des = col.GetComponent<Destroyable>();
        if (des)
        {
            Destroy(col.gameObject);
        }
	}
}
