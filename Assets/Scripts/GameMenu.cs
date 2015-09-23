using UnityEngine;
using System.Collections.Generic;

static class Extensions
{
    public static LinkedListNode<T> InfiniteNext<T>(this LinkedListNode<T> current)
    {
        return current.Next ?? current.List.First;
    }

    public static LinkedListNode<T> InfinitePrevious<T>(this LinkedListNode<T> current)
    {
        return current.Previous ?? current.List.Last;
    }
}


public class GameMenu : MonoBehaviour {


    public List<GameObject> Planes = new List<GameObject>();

    LinkedListNode<GameObject> currentPlane;
    LookAtSLerp lookatSlerp;

    // Use this for initialization
    void Start() {
        lookatSlerp = GameObject.Find("Main Camera").GetComponent<LookAtSLerp>();

        LinkedList<GameObject> planes = new LinkedList<GameObject>(Planes);
        currentPlane = planes.First;
        lookatSlerp.Target = currentPlane.Value.transform;
    }



    void Update() {

    }

    public void ChangePlane(bool nextPrev) {

        currentPlane = (nextPrev) ? currentPlane.InfiniteNext() : currentPlane.InfinitePrevious();
        lookatSlerp.Target = currentPlane.Value.transform;

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
