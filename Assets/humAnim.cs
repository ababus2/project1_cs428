using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(WeatherAPIScriptHum.humDigit > 20 && WeatherAPIScriptHum.humDigit <=40 ){
            animator.SetBool("is25h", true);
        }
        else if(WeatherAPIScriptHum.humDigit > 40 && WeatherAPIScriptHum.humDigit <=60 ){
            animator.SetBool("is50h", true);
        }
        else if(WeatherAPIScriptHum.humDigit > 60 && WeatherAPIScriptHum.humDigit <=80){
            animator.SetBool("is75h", true);
        }
        else if(WeatherAPIScriptHum.humDigit > 80 && WeatherAPIScriptHum.humDigit <=100){
            animator.SetBool("is100h", true);
        }
        else{

        }
    }
}
