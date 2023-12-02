using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SwitchColors : MonoBehaviour
{
    [SerializeField] private GameObject platform_A_Yellow;
    [SerializeField] private GameObject platform_B_Blue;

    public bool isOn = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // change platforms colors
            platform_A_Yellow.SetActive(isOn);
            platform_B_Blue.SetActive(!isOn);
            isOn = !isOn;

            //play player's move animation
            // Play SFX 
        }
    }
}
