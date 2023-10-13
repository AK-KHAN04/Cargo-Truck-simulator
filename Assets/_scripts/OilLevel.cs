using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilLevel : MonoBehaviour
{
    public static OilLevel instance;

    public Transform startPoint, EndPoint;

    private void Awake()
    {
        instance = this;
    }
}
