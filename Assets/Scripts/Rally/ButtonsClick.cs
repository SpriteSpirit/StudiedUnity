using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickButton()
    {
        Debug.Log("Button");
    }

    // Update is called once per frame
    public void Quit()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
            Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif

        #if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE)
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }
}
