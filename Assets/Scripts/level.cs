using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // for debugging

    //cached reference
    SceneLoader sceneloader;

     public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneloader.LoadNextScene();

        }
    }


}
