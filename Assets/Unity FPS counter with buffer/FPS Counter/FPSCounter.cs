// MIT license - license_nvjob.txt
// FPS counter with buffer v1.2 - https://github.com/nvjob/Unity-FPS-Counter
// #NVJOB Nicholas Veselov (independent developer) - https://nvjob.pro, http://nvjob.dx.am
// The script is written according to the calculation of the average value in mathematics.


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


public class FPSCounter : MonoBehaviour
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public Text counterText;
    public Transform graph;
    public int frameUpdate = 60;
    public int highestPossibleFPS = 300;
    public float graphUpdate = 1.0f;
    public Color graphColor = new Color(1, 1, 1, 0.5f);

    //---------------------------------

    float ofsetX;
    int curCount, lineCount;
    

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    void Start()
    {
        //---------------------------------

        StartCoroutine(DrawGraph());

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    void Update()
    {
        //---------------------------------

        curCount = StFPS.Counter(frameUpdate, Time.deltaTime);
        counterText.text = "FPS: " + curCount.ToString();

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    IEnumerator DrawGraph()
    {
        //---------------------------------

        while (true)
        {
            yield return new WaitForSeconds(graphUpdate);

            GameObject NewObj = new GameObject();
            NewObj.transform.SetParent(graph);
            Image NewImage = NewObj.AddComponent<Image>();

            NewImage.rectTransform.anchorMin = new Vector2(ofsetX, 0);
            NewImage.rectTransform.anchorMax = new Vector2(ofsetX + 0.01f, 1.0f / highestPossibleFPS * curCount);
            NewImage.rectTransform.offsetMax = NewImage.rectTransform.offsetMin = new Vector2(0, 0);
            NewImage.color = graphColor;

            if (lineCount++ > 49)
            {
                foreach (Transform child in graph) Destroy(child.gameObject);
                ofsetX = lineCount = 0;
            }
            else ofsetX += 0.02f;
        }

        //---------------------------------
    }
    

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


public static class StFPS
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    static List<float> fpsBuffer = new List<float>();
    static float fpsB;
    static int fps;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public static int Counter(int frameUpdate, float deltaTime)
    {
        //---------------------------------

        int fpsBCount = fpsBuffer.Count;

        if (fpsBCount <= frameUpdate) fpsBuffer.Add(1.0f / Time.deltaTime);
        else
        {
            for (int f = 0; f < fpsBCount; f++) fpsB += fpsBuffer[f];
            fpsBuffer = new List<float> { 1.0f / Time.deltaTime };
            fpsB = fpsB / fpsBCount;
            fps = Mathf.RoundToInt(fpsB);
            fpsB = 0;
        }

        return fps;

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}