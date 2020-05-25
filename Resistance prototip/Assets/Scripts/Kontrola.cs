using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrola : MonoBehaviour
{
    [SerializeField] private Transform[] slike;

    [SerializeField] private GameObject WinText;

    public static bool kraj;

    void Start()
    {
        WinText.SetActive(false);
        kraj = false;
    }

    private void Update()
    {
        if(slike[0].rotation.z == 0 &&
           slike[1].rotation.z == 0 &&
           slike[2].rotation.z == 0 &&
           slike[3].rotation.z == 0 &&
           slike[4].rotation.z == 0 &&
           slike[5].rotation.z == 0)
        {
            kraj = true;
            WinText.SetActive(true);
        }
    }
}
