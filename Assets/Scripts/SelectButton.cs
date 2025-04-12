using System.Collections;
using System.Collections.Generic;
using PolySpatial.Template;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] private GameObject avatarAnchor;
    [SerializeField] private GameObject anchorObject;
    

    private bool toggleStatus = false;
    private Vector3 startpos;

    private Animator animator;
    private SpatialUIToggle localToggle;

    // Start is called before the first frame update
    void Start()
    {
        localToggle = GetComponentInChildren<SpatialUIToggle>();
        startpos = avatarAnchor.transform.localPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectButton()
    {
        if (anchorObject == null) return;
        Debug.Log("OnSelectButton" + localToggle.Active);

        if(!localToggle.Active)
        //if(toggleStatus)
        {
            // show the all avatars
            for (int i = 0; i < anchorObject.transform.childCount; i++)
            {
                reset(i, true);
            }
            avatarAnchor.transform.localPosition = startpos;
        }
        else
        {
            // show the specified avatar
            for (int i = 0; i < anchorObject.transform.childCount; i++)
            {
                reset(i, false);
            }
            avatarAnchor.transform.localPosition = new Vector3(-0.04f, 0, -1.3f);
            avatarAnchor.SetActive(true);
        }
        //toggleStatus = !toggleStatus;

        void reset(int i,bool setActive)
        {
            Transform child = anchorObject.transform.GetChild(i); //avatar N
            child.gameObject.SetActive(setActive);
            child.GetChild(0).localPosition = Vector3.zero;
            child.GetChild(0).localEulerAngles = Vector3.zero;
            animator = child.GetComponentInChildren<Animator>();
            animator.Play("BackSpotTurn_CrossBodyLead", -1, 0f);
        }
    }
}
