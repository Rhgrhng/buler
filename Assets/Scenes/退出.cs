using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 退出 : MonoBehaviour
{
   public void OnExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
       Application.Quit();
#endif
        //
    }
}
