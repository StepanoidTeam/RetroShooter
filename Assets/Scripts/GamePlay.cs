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




    // Use this for initialization
    void Start()
    {
        HiScore = 0;
        AddScore(0);

        player.OnDie += Player_OnDie;


    }

    // Update is called once per frame
    void Update()
    {
        CheckKeys();
    }


    private void Player_OnDie(GameObject sender, Collider other, float durability)
    {
        Destroy(sender);

        StartCoroutine(EndGame());
    }

    private void SetNewHiScore(int newHiScore)
    {
        var prevHiScore = PlayerPrefs.GetInt("HiScore");

        if (newHiScore > prevHiScore)
        {
            PlayerPrefs.SetInt("HiScore", newHiScore);
        }
    }


    private IEnumerator EndGame()
    {
        SetNewHiScore(HiScore);

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
