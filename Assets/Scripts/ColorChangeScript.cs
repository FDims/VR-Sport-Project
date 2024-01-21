using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeScript : MonoBehaviour
{
    Color hoverEnter = Color.grey;
    Color hoverExit = Color.white;

    public void changeColorHoverEnter (Image imageComponent)
    {
       imageComponent.color = hoverEnter;
    }
    public void changeColorHoverExit (Image imageComponent)
    {
        imageComponent.color = hoverExit;
    }
}
