// MIT license - license_nvjob.txt
// Unity FPS Counter - https://github.com/nvjob/Unity-FPS-Counter
// #NVJOB Nicholas Veselov (independent developer) - https://nvjob.pro, http://nvjob.dx.am
// The script is written according to the calculation of the average value in mathematics.


using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class FPSDisplay : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////

    public Text averageFPSLabel;
    public int frameUpdate = 60;

    //-------

    List<float> fpsBuffer = new List<float>();
    float fps;

    ////////////////////////////////

    void Update()
    {
        //-------      

        if (fpsBuffer.Count < frameUpdate) fpsBuffer.Add(1f / Time.deltaTime);
        else
        {
            for (int f = 0; f < fpsBuffer.Count; f++) fps += fpsBuffer[f];
            fps = fps / fpsBuffer.Count;
            averageFPSLabel.text = Mathf.CeilToInt(fps).ToString();
            fpsBuffer = new List<float>();
            fpsBuffer.Add(1f / Time.deltaTime);
            fps = 0;
        }

        //-------
    }

    ////////////////////////////////////////////////////////////////
}