using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System;

public class ApplicationFocusTest : MonoBehaviour
{
    public Text showtime;
    float hour, minutes, seconds;
    float _hour, _minutes, _seconds;
    bool isfocus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnApplicationFocus(bool focus)
    {
        UnityEngine.Debug.Log(focus);
        if(focus)
        {
            isfocus = focus;
            //UnityEngine.Debug.Log(DateTime.Now.Hour - hour);
            //UnityEngine.Debug.Log(DateTime.Now.Minute - minutes);
            //UnityEngine.Debug.Log(DateTime.Now.Second - seconds);

            float m = ((DateTime.Now.Hour - hour)* 60) + ((DateTime.Now.Minute - minutes) * 60) + (DateTime.Now.Second - seconds);
            UnityEngine.Debug.Log(m);
            TimeSpan t = TimeSpan.FromSeconds(m);

            string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
            showtime.text = answer;
        }
        else
        {
            isfocus = focus;
            
            hour = DateTime.Now.Hour;
            minutes = DateTime.Now.Minute;
            seconds = DateTime.Now.Second;
        }
    }

    public void OnCourseOpenButtonClick()
    {
        Process process = new Process();
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        Process.Start(@"D:\NagendraBuilds\Courses\AutoXR\AutoXR.exe");
    }
}
