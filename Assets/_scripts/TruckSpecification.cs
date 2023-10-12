using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckSpecification : MonoBehaviour
{
    public string carName;
    public float brake, handle, acceleration, damage;
    public int coins;

    void OnEnable()
    {
        TruckSelectionManager.instance.acceleration.fillAmount = acceleration;
        TruckSelectionManager.instance.damage.fillAmount = damage;
        TruckSelectionManager.instance.brakes.fillAmount = brake;
        TruckSelectionManager.instance.handle.fillAmount = handle;
        TruckSelectionManager.instance.truckName.text = carName;
        TruckSelectionManager.instance.truckPriceText.text = coins.ToString();
    }



}
