using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    public static MenuGame instance;
    public Text nick;
    public Text goldDNA;
    public List<Image> energiaP;

    void Awake(){
        instance =this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Logar();
    }

    // Update is called once per frame
    void Update()
    {
        CarregarEnergia();
    }

    public void Batalhar(){
        if(BibliotecaBD.instance.energia > 0){
            BibliotecaBD.instance.energia --;
            PlayerPrefs.SetInt("Energia", BibliotecaBD.instance.energia);
            if(MenuStatusPlanet.instance.valor > 0){
                 PlayerPrefs.SetInt("dificuldade", MenuStatusPlanet.instance.valor);
                Application.LoadLevel("Batalha");
            }
            else{
                Application.LoadLevel("Loja");
            }
        }
        
       
        
    }

    public void Logar(){
        nick.text = "Encanador: " + PlayerPrefs.GetString("nick");
        goldDNA.text = PlayerPrefs.GetInt("MoedaDNA").ToString();

    }
    public void Analizar(){
        Application.LoadLevel("AnalizerAlienMenu");
    }

    public void Missao(){
        Application.LoadLevel("Mission");
    }
     public void Mochila(){
        Application.LoadLevel("Mochila");
    }

    public void CarregarEnergia(){
        int i;
        for(i = 0; i < BibliotecaBD.instance.energia; i++){
            energiaP[i].color = new Color32((byte)82, (byte)133, (byte)238, 255);
        }
        if(i < energiaP.Count){
            for(; i < energiaP.Count; i++){
                energiaP[i].color = new Color32((byte)147, (byte)147, (byte)147,255);
            }
        }
    }
    
}
