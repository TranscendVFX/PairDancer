using System.Collections;
using System.Collections.Generic;
using PolySpatial.Template;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private GameObject avatar;
    [SerializeField] private GameObject anchorObject;

    private bool toggleStatus = false;

    private SpatialUIToggle localToggle;
    // Start is called before the first frame update
    void Start()
    {
        localToggle = GetComponentInChildren<SpatialUIToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectButton()
    {
        if (anchorObject == null) return;
        Debug.Log("OnSelectButton" + toggleStatus);

        //if(localToggle.isActiveAndEnabled)
        if(toggleStatus)
        {
            for (int i = 0; i < anchorObject.transform.childCount; i++)
            {
                Transform child = anchorObject.transform.GetChild(i);
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < anchorObject.transform.childCount; i++)
            {
                Transform child = anchorObject.transform.GetChild(i);
                child.gameObject.SetActive(false);
            }
            avatar.SetActive(true);
        }

        toggleStatus = !toggleStatus;

    }
}
