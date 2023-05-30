using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusEnemyMenu : MonoBehaviour
{
    public static StatusEnemyMenu instance;
    public List<Text> status;
    public Image view;
    public List<Sprite> viewSprite;
    public GameObject panel;
    public int contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        view.sprite = viewSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
         if(contador <= 1){
            MenuView();
        }
    }

    public void ViewMenu(int i){
        contador += i;

        if(contador <= 1){
            MenuView();
        }
        else{
            contador = 0;
            panel.SetActive(false);
            view.sprite = viewSprite[0];

        }
    }
    public void MenuView(){
        panel.SetActive(true);
            status[0].text = "Vd: " + Enemy.instance.vida.ToString();
            status[1].text = "Dn: " + Enemy.instance.dano.ToString();
            status[2].text = "Df: " + Enemy.instance.defesa.ToString();
            status[3].text = "Cr: " + Enemy.instance.critico.ToString();
            status[4].text = "Vl: " + Enemy.instance.velocidade.ToString();
            view.sprite = viewSprite[1];
    }
}
