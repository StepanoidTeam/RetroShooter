using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


    public static int Score;
    public static int Life;


    public Text ScoreText;
    public Text LifeText;

    public Button RestartButton;

    public GameObject Player;


	// Use this for initialization
	void Start () {

        Score = 0;
        Life = 3;
	}
	

    //game!!!

    //test comment from bob

	void Update () {

        //ScoreText.text = "Score: " + Score;
        //LifeText.text = "Life: " + Life;

        //if (Life == 0) {
            
        //    RestartButton.gameObject.SetActive(true);
        //}
	}


    public void RestartGame() {
        Application.LoadLevel(Application.loadedLevel);
    }



    public void StartGame() {
        Application.LoadLevel("game");
    }

    public void EndGame()
    {
        Application.LoadLevel("menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
