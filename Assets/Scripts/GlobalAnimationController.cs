using System.Collections.Generic;
using UnityEngine;

public class GlobalAnimationController : MonoBehaviour
{
    public static GlobalAnimationController Instance;

    private Dictionary<string, string> animationMap = new Dictionary<string, string>()
    {
        { "A", "BackSpotTurn_CrossBodyLead" },
        { "B", "BasicStep" },
        { "C", "BothHands_WomanRightTurn" },
        { "D", "CrossBodyLead" },
        { "E", "CrossBodyTurn" },
        { "F", "SalsaMan_Cumbia" },
        { "G", "CumbiaRotate" },
        { "H", "InsideTurn" },
        { "I", "ManRightTurn" },
        { "J", "OppositeHandsWomanRightTurn_Throw" },
        { "K", "WomanRightTurn" },
        { "L", "WomanRightTurn_Drop_WomanRightTurn" }
    };

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public string GetAnimationName(string code)
    {
        return animationMap.TryGetValue(code.ToUpper(), out string animName) ? animName : null;
    }
}
