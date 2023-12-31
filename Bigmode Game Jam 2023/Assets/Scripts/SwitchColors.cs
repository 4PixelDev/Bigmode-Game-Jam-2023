using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SwitchColors : MonoBehaviour
{
    [SerializeField] private GameObject[] platform_A_Yellow;
    [SerializeField] private GameObject[] platform_B_Blue;

    public bool isOn = true;

    // sound 
    [SerializeField] private AudioSource switchColorsSFX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // change platforms colors
            SwitchColorsSystem();

            // Play SFX 
            switchColorsSFX.Play();
            //play player's move animation
        }

        void SwitchColorsSystem()
        {
            isOn = !isOn;


            foreach (GameObject objYellow in platform_A_Yellow)
            {
                objYellow.SetActive(!isOn);
            }

            foreach (GameObject objBlue in platform_B_Blue)
            {
                objBlue.SetActive(isOn);
            }
        }
    }
}
