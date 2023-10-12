using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int direction;
    private int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (i<180)
        {
            this.gameObject.transform.Rotate(0, 0, direction);
            i++;
        }
        else
        {
            direction = -direction;
            i = 0;
        }
    }

}
