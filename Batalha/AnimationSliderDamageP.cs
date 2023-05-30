using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSliderDamageP : MonoBehaviour
{ 
    public static AnimationSliderDamageP instance;
    public Slider lifeSlider;
    public int vidaDamage;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DamageTime();
    }

    public void DamageTime(){
        if(vidaDamage < lifeSlider.value){
            lifeSlider.value -= 30 * Time.deltaTime;
            
        }
    }
    
}
