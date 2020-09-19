using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using UnityEngine.Networking;
public class WeatherAPIScriptWind : MonoBehaviour
{
    public string speedFinal;
    public static string directionFinal;
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
                string speed = N["wind"]["speed"].Value; //get the temperature
                string direction = N["wind"]["deg"].Value;
                float dir; //variable to hold the parsed temperature
                float.TryParse(direction, out dir); //parse the temperature
                direction = convertDir(dir);
                speedFinal = speed;
                directionFinal = direction;
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived temp: " + speedFinal);
            }
        }
    }
    string convertDir(float dir){
        string direction;
        if(dir<30 || dir >330 ){
            direction = "N";
            return direction;
        }
        else if(dir >= 30 && dir<= 60){
            direction = "NE";
            return direction;
        }
        else if(dir >= 61 && dir<= 120){
            direction = "E";
            return direction;
        }
        else if(dir >= 121 && dir<= 160){
            direction = "SE";
            return direction;
        }
        else if(dir >= 161 && dir<= 210){
            direction = "S";
            return direction;
        }
        else if(dir >= 211 && dir<= 240){
            direction = "SW";
            return direction;
        }
        else if(dir >= 241 && dir<= 300){
            direction = "W";
            return direction;
        }
        else if(dir >= 301 && dir<= 330){
            direction = "NW";
            return direction;
        }
        else{
            direction = "N";
            return direction;
        }

    }

    // Update is called once per frame
    void Update()
    {
        weatherTextObject.GetComponent<TextMeshPro>().text = speedFinal+" mph "+directionFinal;
    }
}
