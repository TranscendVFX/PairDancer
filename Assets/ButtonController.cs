using System.Collections;
using System.Collections.Generic;
using PolySpatial.Template;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public SpatialUIToggle targetButton;

    public void OnSelectButton()
    {
        Debug.Log("!!!OnSelectButton");
        targetButton.PressEnd();
    }
}
