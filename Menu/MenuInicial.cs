using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicial : MonoBehaviour
{
    public GameObject panel;
    public int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EntrarGame(){
        Application.LoadLevel("MenuGame");
    }

    public void SairGame(){
        Application.Quit();
    }
    public void PatchDescription(){
        contador++;
        if(contador <= 1){
            panel.SetActive(true);
        }
        else{
            panel.SetActive(false);
            contador = 0;
        }
    }
}
