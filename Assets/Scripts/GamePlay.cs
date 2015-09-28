using UnityEngine;

public class GamePlay : MonoBehaviour {

    public UnityEngine.UI.Text HiScoreText;

    public int HiScore;
    
	// Use this for initialization
	void Start () {
        HiScore = 0;
        AddScore(0);
    }
	
	// Update is called once per frame
	void Update () {

        CheckKeys();

	}

    private void CheckKeys()
    {
        var cancel = Input.GetAxis("Cancel");

        if (cancel>0)
        {
            Application.LoadLevel("menu");
        }


    }

    public void AddScore(int score) {

        HiScore += score;

        HiScoreText.text = HiScore.ToString();
    }
}
