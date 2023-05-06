using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public void PlayVibrationContainer(string vibrationLevel)
    {
        switch (vibrationLevel)
        {
            case "Level1":
                Vibration.Vibrate(50);
                break;

            case "Level2":
                Vibration.Vibrate(100);
                break;

            case "Level3":
                Vibration.Vibrate(150);
                break;
        }
    }
}
