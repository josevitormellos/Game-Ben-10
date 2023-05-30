using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaestriaPlayer : MonoBehaviour
{
    public static MaestriaPlayer instance;
    public int xp, nivel, xpProcess;
    public List<Sprite> omnetrix;
    // Start is called before the first frame update
    void Awake() {
        instance = this;  
        
    }
    void Start()
    {
        xp = PlayerPrefs.GetInt("xp");
        nivel = PlayerPrefs.GetInt("nivel");
        CalcularXp(0);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalcularXp(int i){
        xp+=i;
        xpProcess = nivel * 100;
        if(xpProcess <=  xp){
            nivel++;
            xp -= xpProcess;
            PlayerPrefs.SetInt("nivel", nivel);
            CalcularXp(0);
        }
        PlayerPrefs.SetInt("xp", xp);
        
    }
}
