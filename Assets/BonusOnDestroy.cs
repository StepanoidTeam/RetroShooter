using UnityEngine;

public class BonusOnDestroy : MonoBehaviour
{
    [Range(0, 1)]
    public float BonusHealth = 1f;

    // Use this for initialization
    void Start()
    {
        var bonus = GetComponent<Destroyable>();
        bonus.OnDie += Bonus_OnDie;
    }

    private void Bonus_OnDie(GameObject sender, Collider other, float health)
    {
        var d = other.GetComponent<Destroyable>();

        d.Health = Mathf.Min(d.Health + BonusHealth, 1f);
    }
}
