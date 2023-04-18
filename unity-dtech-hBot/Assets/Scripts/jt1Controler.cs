using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class jt1Controler : MonoBehaviour
{
    public float targetPosition=0.0f;
    public float currentPosition=0.0f;
    public string outStrDirection="0";
    public string outStrDirectionNow="0";

    private string inboundData ="10.0";
    private float lastTime =0.0f;
    private float countTime =0.0f;

    string dataHost = "localhost:8081";

    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(0,0,Time.deltaTime*20);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition=(transform.eulerAngles.y);
        if (transform.eulerAngles.y >= 180)
        {currentPosition=-(360-transform.eulerAngles.y);}
        if (targetPosition<=110 && targetPosition>=-110 )
        {

            if (currentPosition > targetPosition - 0.5)
            {transform.Rotate(0,0,-Time.deltaTime*50);}
        
            if (currentPosition < targetPosition + 0.5)
            {transform.Rotate(0,0,Time.deltaTime*50);}

        }

        outStrDirectionNow = currentPosition.ToString("F2");

        countTime +=Time.deltaTime;
        if (countTime>lastTime+0.5f){
            StartCoroutine(GetData());
            lastTime=countTime;
        }
        
    }



    private IEnumerator GetData()
    {

        int maxAttempts = 10;
        int attempt = 0;

        if (attempt >= maxAttempts) {
            Debug.LogError("Maximum number of attempts reached. Aborting.");
            yield break;
            }

        string urltoGet= "http://" + dataHost + "/api/jt1Control";


        using (UnityWebRequest www = UnityWebRequest.Get(urltoGet))
            {

            yield return www.SendWebRequest();

            if ((www.result==UnityWebRequest.Result.ConnectionError) || (www.result==UnityWebRequest.Result.ProtocolError))
            {
                Debug.LogError(www.error);
                yield return new WaitForSeconds(1); // Wait for a second before retrying
                yield return GetData();
            }
            else
            {
                inboundData = www.downloadHandler.text;
                Debug.Log("Data: " + inboundData);
                targetPosition=float.Parse(inboundData);
                outStrDirection=inboundData;
            }
        }
    }
}