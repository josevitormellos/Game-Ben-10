using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaestriaMenu : MonoBehaviour
{
    public static MaestriaMenu instance;
    public Image omnetrix;
    public Slider xp;
    // Start is called before the first frame update
    void Start()
    {   
        instance = this;
        AtualizarDados();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtualizarDados(){
        omnetrix.sprite = MaestriaPlayer.instance.omnetrix[MaestriaPlayer.instance.nivel-1];
        xp.maxValue = MaestriaPlayer.instance.xpProcess;
        xp.value = MaestriaPlayer.instance.xp;
    }
}
