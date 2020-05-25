using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacija : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!Kontrola.kraj)
            transform.Rotate(0f, 0f, 90f);
    }

}
