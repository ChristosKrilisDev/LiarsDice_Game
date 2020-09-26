using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieController : MonoBehaviour
{
    //Test value for faster seearch
    [SerializeField] private int dieFaceIndex = 1;

    private void Start()
    {
        RotateToFace(1);
    }

    public void HideDie()
    {
        //Do something weird and cool to vanish the dice in here
    }

    public void RotateToFace(int faceNumber)
    {
        if(faceNumber > 6 || faceNumber < 1)
            Debug.LogError("You piece of sh*t gave number out of range");

        transform.rotation = Quaternion.identity;
        dieFaceIndex = faceNumber;

        switch(faceNumber)
        {

            case 1:
            {
                transform.localRotation = Quaternion.Euler(-90 , 0 , 0);
                break;
            }
            case 2:
            {
                transform.localRotation = Quaternion.Euler(0 , 0 , -90);
                break;
            }

            case 3:
            {
                transform.localRotation = Quaternion.Euler(0 , 0 , 0);
                break;
            }

            case 4:
            {
                transform.localRotation = Quaternion.Euler(-180 , 0 , 0);
                break;
            }

            case 5:
            {
                transform.localRotation = Quaternion.Euler(0 , 0 , 90);
                break;
            }

            case 6:
            {
                transform.localRotation = Quaternion.Euler(90 , 0 , 0);
                break;
            }

        }
    }

}
