using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(WeatherAPIScriptWind.directionFinal == "NE"){
            animator.SetBool("isNE", true);
        }
        else if(WeatherAPIScriptWind.directionFinal == "E"){
            animator.SetBool("isE", true);
        }
        else if(WeatherAPIScriptWind.directionFinal == "SE"){
            animator.SetBool("isSE", true);
            Debug.Log(":\nRECIEVED DIR AT ANIM: " + WeatherAPIScriptWind.directionFinal);
        }
        else if(WeatherAPIScriptWind.directionFinal == "S"){
            animator.SetBool("isS", true);
        }
        else if(WeatherAPIScriptWind.directionFinal == "SW"){
            animator.SetBool("isSW", true);
        }
        else if(WeatherAPIScriptWind.directionFinal == "W"){
            animator.SetBool("isW", true);
        }
        else if(WeatherAPIScriptWind.directionFinal == "NW"){
            animator.SetBool("isNW", true);
        }
        else{

        }
        
    }
}
