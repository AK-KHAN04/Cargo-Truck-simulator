using InsaneSystems.RoadNavigator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLevel : MonoBehaviour
{
    public static OilLevel instance;
    Navigator navigator;
    Map map;


    public Transform startPoint, EndPoint;

    //bool isInitialized = false;


    private void Awake()
    {
        instance = this;
        navigator = FindObjectOfType<Navigator>();
        map = FindObjectOfType<Map>();

        Debug.Log("level");
    }

    private void Start()
    {
        //if (OilEnvManager.instance.currentLevel < 6)
        
            navigator.SetTargetPoint(EndPoint.position);
        
        // map.ShowAsNavigator();

    }
    /*
    void Update()
    {
        if (!isInitialized)
        {
            map.ShowAsNavigator();

            isInitialized = true;
        }
    }*/
}
