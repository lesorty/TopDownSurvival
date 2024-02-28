using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{

    private Camera mainCamera;
    private float spawnrate = 2f;


    void Start()
    {
        mainCamera = Camera.main;
    
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0, spawnrate);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    bool isinsidethecamera(float x, float y)
    {
        float leftside = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float rightside = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        float up = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        float down = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        if (x > leftside && x < rightside && y > down && y < up)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Spawn(GameObject obj)
    {
        float x = Random.Range(-8, 8);
        float y = Random.Range(-4, 4);

        // i want to make sure that the object is spawned outside the camera
        while (isinsidethecamera(x, y))
        {
            x = Random.Range(-8, 8);
            y = Random.Range(-4, 4);
        }  

        Instantiate(obj, new Vector3(x, y, 0), Quaternion.identity);
    }

}
