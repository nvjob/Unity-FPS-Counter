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

    //---------------------------------

    static Transform stTr;
    static GameObject[] stLines;
    static int stNumLines;
    static string[] displayBuffer;
    static WaitForSeconds graphWait;
    

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    

    void Awake()
    {
        //---------------------------------

        stTr = graph;
        stNumLines = 100;
        stLines = new GameObject[stNumLines];

        for (int i = 0; i < stNumLines; i++)
        {
            stLines[i] = new GameObject();
            stLines[i].SetActive(false);
            stLines[i].name = "Line_" + i;
            stLines[i].transform.parent = stTr;
            Image img = stLines[i].AddComponent<Image>();
            img.color = graphColor;
        }

        graphWait = new WaitForSeconds(graphUpdate);
        displayBuffer = new string[highestPossibleFPS + 1];
        for (int i = 0; i <= highestPossibleFPS; i++)
        {
            displayBuffer[i] = "FPS: " + i.ToString();
        }

        StartCoroutine(DrawGraph());

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    void Update()
    {
        //---------------------------------

        curCount = StFPS.Counter(frameUpdate, Time.deltaTime);
        counterText.text = displayBuffer[curCount];

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    IEnumerator DrawGraph()
    {
        //---------------------------------

        while (true)
        {
            yield return graphWait;

            GameObject obj = GiveLine();
            Image img = obj.GetComponent<Image>();
            img.rectTransform.anchorMin = new Vector2(ofsetX, 0);
            img.rectTransform.anchorMax = new Vector2(ofsetX + 0.01f, 1.0f / highestPossibleFPS * curCount);
            img.rectTransform.offsetMax = img.rectTransform.offsetMin = new Vector2(0, 0);
            obj.SetActive(true);

            if (lineCount++ > 49)
            {
                foreach (Transform child in graph) child.gameObject.SetActive(false);
                ofsetX = lineCount = 0;
            }
            else ofsetX += 0.02f;
        }

        //---------------------------------
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    static GameObject GiveLine()
    {
        //---------------------------------

        for (int i = 0; i < stNumLines; i++) if (!stLines[i].activeSelf) return stLines[i];
        return null;

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