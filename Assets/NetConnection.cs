using System;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class NetConnection : MonoBehaviour
{
    public Text ShowNetSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(chk_con());
        timer1_Tick();

        CheckSpeed();
    }

    //Oneway to check InternetAvailability
    public static bool chk_con()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.google.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    //Another way to check InternetAvailability
    private void timer1_Tick()
    {
        bool connection = NetworkInterface.GetIsNetworkAvailable();
        if (connection)
        {
            Debug.Log("Available");
        }
        else
        {
            Debug.Log("Not Available");
        }
    }

    void CheckSpeed()
    {
        double[] speeds = new double[5];
        for (int i = 0; i < 5; i++)
        {
            int jQueryFileSize = 261; //Size of File in KB.
            WebClient client = new WebClient();
            DateTime startTime = DateTime.Now;          
            client.DownloadFile("http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js", @Application.dataPath + "/jquery.js");
            DateTime endTime = DateTime.Now;
            speeds[i] = Math.Round((jQueryFileSize / (endTime - startTime).TotalSeconds));
        }
        ShowNetSpeed.text = string.Format("Download Speed: {0}MB/s", speeds.Average()/1000);
    }
}
