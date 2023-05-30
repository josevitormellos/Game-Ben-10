using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusMenu : MonoBehaviour
{
    public static PlayerStatusMenu instance;
    public List<Text> descriptions;
    public GameObject panelDescription;
    private bool visible = false; 
    public Text nome;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        descriptions[5].text = Player.instance.player.nome;
        nome.text = Player.instance.player.nome;
    }

    // Update is called once per frame
    void Update()
    {
        DescriptionsStatus();   
    }

    public void OnDescriptions(){
        if(!visible){
            panelDescription.SetActive(true);
            DescriptionsStatus();
            visible = true;
            
        }
        else{
            panelDescription.SetActive(false);
            visible = false;
        }
    }

    public void DescriptionsStatus(){
         if(!visible){
                descriptions[0].text = "Vi:"+ MenuBatalha.instance.vidaIP.ToString() + "/" + Player.instance.vida.ToString();
                descriptions[1].text = "Dn:"+ Player.instance.dano.ToString();
                descriptions[2].text = "Df:"+ Player.instance.defesa.ToString();
                descriptions[3].text = "Cr:"+ Player.instance.critico.ToString();
                descriptions[4].text = "Vl:"+ Player.instance.velocidade.ToString();

         }
    }
}
