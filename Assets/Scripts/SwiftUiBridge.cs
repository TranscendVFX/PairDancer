using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using PolySpatial.Template;
using TMPro;
using UnityEngine;

public class SwiftUiBridge : MonoBehaviour
{
    private delegate void CallbackDelegate(string command);

    //[SerializeField] private SpatialUIButton _button;
    [SerializeField] private TMP_Text _text;

    private bool _swiftUIWindowOpen = false;

    private void OnEnable()
    {
        // _button.WasPressed += WasPressed;
        SetNativeInputCallback(CallbackFromNative);
    }

    private void OnDisable()
    {
        SetNativeInputCallback(null);
        CloseSwiftUIInputWindow("HelloWorld");
    }

    private void WasPressed(string buttonText, MeshRenderer meshrenderer)
    {
        Debug.Log("----------> Button was pressed: " + buttonText);

        Toggle();
    }

    public void Toggle()
    {
        Debug.Log("Swift Button Toggled");

        if (_swiftUIWindowOpen)
        {
            CloseSwiftUIInputWindow("InputViewScene");
            _swiftUIWindowOpen = false;
        }
        else
        {
            OpenSwiftUIInputWindow("InputViewScene");
            _swiftUIWindowOpen = true;
        }
    }

    [MonoPInvokeCallback(typeof(CallbackDelegate))]
    private static void CallbackFromNative(string message)
    {
        Debug.Log("Callback from native: " + message);

        SwiftUiBridge self = Object.FindFirstObjectByType<SwiftUiBridge>();

        if (message == "closed")
        {
            self._swiftUIWindowOpen = false;
        }
        else
        {
            self._text.text = message;
        }
    }

#if UNITY_VISIONOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void SetNativeInputCallback(CallbackDelegate callback);

        [DllImport("__Internal")]
        private static extern void OpenSwiftUIInputWindow(string name);

        [DllImport("__Internal")]
        private static extern void CloseSwiftUIInputWindow(string name);
#else
    static void SetNativeInputCallback(CallbackDelegate callback)
    {
    }

    static void OpenSwiftUIInputWindow(string name)
    {
    }

    static void CloseSwiftUIInputWindow(string name)
    {
    }
#endif
}