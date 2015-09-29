using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{

    public Text HiScoreText;
    public Text HealthText;
    public Slider HealthBar;

    public Destroyable player;

    public int HiScore;

    float maxDurability = 0;


    // Use this for initialization
    void Start()
    {
        HiScore = 0;
        AddScore(0);

        maxDurability = player.Durability;

        player.OnDie += Player_OnDie;
    }


    // Update is called once per frame
    void Update()
    {
        CheckKeys();
        UpdateUI();
    }

    void UpdateUI() {
        //HealthText.text = player.Durability / maxDurability * 100f + "%";
        HealthText.text = player.Durability.ToString();
        HealthBar.value = player.Durability / maxDurability;
    }


    private void Player_OnDie(GameObject sender, int durability)
    {
        Destroy(sender);
        PlayerPrefs.SetInt("HiScore", HiScore);

        StartCoroutine(EndGame());
    }


    private IEnumerator EndGame()
    {
        GetComponent<SlowMo>().Speed = 0.1f;
        yield return new WaitForSeconds(0.3f);

        Application.LoadLevel("menu");
    }

    private void CheckKeys()
    {
        var cancel = Input.GetAxis("Cancel");

        if (cancel > 0)
        {
            Application.LoadLevel("menu");
        }


    }

    public void AddScore(int score)
    {

        HiScore += score;

        HiScoreText.text = HiScore.ToString();
    }
}
