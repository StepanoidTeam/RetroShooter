using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

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

    LinkedList<GameObject> planes;
    LinkedListNode<GameObject> currentPlane;
    GameObject camera;

    // Use this for initialization
    void Start () {
        camera = GameObject.Find("Main Camera");

        planes = new LinkedList<GameObject>(Planes);
        currentPlane = planes.First;
    }



    public Vector3 v1 = new Vector3();
    public Vector3 v2 = new Vector3();

    void Update () {

        Vector3 planePos = currentPlane.Value.transform.position;



        //Quaternion qeuler = Quaternion.LookRotation(camera.transform.position - planePos, Vector3.forward);
        //qeuler.z= 0.0f;
        //qeuler.y = 0.0f;


        //camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, qeuler, Time.deltaTime * 10);

        //camera.transform.rotation.

        //camera.transform.rotation = Quaternion.ToEulerAngles()

        camera.transform.LookAt(planePos);

    }



    public void ChangePlane(int shift) {
        
        if (shift > 0)
        {
            currentPlane = currentPlane.InfiniteNext();
        }
        else {
            currentPlane = currentPlane.InfinitePrevious();
        }
                
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
