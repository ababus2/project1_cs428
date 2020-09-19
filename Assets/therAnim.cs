using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class therAnim : MonoBehaviour
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
        if(WeatherAPIScriptTemp.tempDigit > 35 && WeatherAPIScriptTemp.tempDigit <=45 ){
            animator.SetBool("is40", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 45 && WeatherAPIScriptTemp.tempDigit <=55 ){
            animator.SetBool("is50", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 55 && WeatherAPIScriptTemp.tempDigit <=65 ){
            animator.SetBool("is60", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 65 && WeatherAPIScriptTemp.tempDigit <=75 ){
            animator.SetBool("is70", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 75 && WeatherAPIScriptTemp.tempDigit <=85 ){
            animator.SetBool("is80", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 85 && WeatherAPIScriptTemp.tempDigit <=95 ){
            animator.SetBool("is90", true);
        }
        else if(WeatherAPIScriptTemp.tempDigit > 95 && WeatherAPIScriptTemp.tempDigit <=105 ){
            animator.SetBool("is100", true);
        }
        else{
            
        }
        
    }
}
