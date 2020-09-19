using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;



public class WeatherAPIScriptTemp : MonoBehaviour
{
    public string temperatureFinal;
    public static float tempDigit; 
    public GameObject weatherTextObject;
    string url = "http://api.openweathermap.org/data/2.5/weather?lat=41.88&lon=-87.6&APPID=df7f9b099826a16b4c61f302fcd0f0d2&units=imperial";
    // Start is called before the first frame update
    void Start()
    {

    // wait a couple seconds to start and then refresh every 900 seconds

       InvokeRepeating("GetDataFromWeb", 2f, 900f);
   }

   void GetDataFromWeb()
   {

       StartCoroutine(GetRequest(url));
   }
   IEnumerator GetRequest(string uri)
    {
        WWW cRequest = new WWW(url);
        yield return cRequest;
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                var N = JSON.Parse(cRequest.text);
                string temp = N["main"]["temp"].Value; //get the temperature
                float tempTemp; //variable to hold the parsed temperature
                float.TryParse(temp, out tempTemp); //parse the temperature
                tempDigit = tempTemp;
                temperatureFinal = temp;
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived temp: " + temperatureFinal);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        weatherTextObject.GetComponent<TextMeshPro>().text = temperatureFinal+"° F";
    }
}
