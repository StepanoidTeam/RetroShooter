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


    public float CameraFollowSpeed = 3;

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



    void Update () {

        Vector3 planePos = currentPlane.Value.transform.position;

        //camera.transform.rotation = Quaternion.Euler(rotx,roty,rotz);
        //camera.transform.rotation = Quaternion.LookRotation(planePos - camera.transform.position);

        var cameraLookRot = Quaternion.LookRotation(planePos - camera.transform.position); ;
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, cameraLookRot, Time.deltaTime * CameraFollowSpeed);

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
