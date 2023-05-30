using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlienMenu : MonoBehaviour
{
    public static AlienMenu instance;
    public Text nome;
    public List<Image> equip;
    public List<GameObject> equipView;
    public Image pele;
    public List<Text> status;
    public Image Maestria;
    public List<Sprite> omnetrix;
    public int contador;
    public Alien alien;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CarregarDadosAlien(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarDadosAlien(int i){
        alien = BibliotecaBD.instance.playerAlien[i];
        
        nome.text = alien.nome;
        pele.sprite = alien.pele;

        if(alien.equip1 == null){
            equipView[0].SetActive(false);
            equipView[1].SetActive(false);
        }
        else{
            equipView[0].SetActive(true);
            equip[0].sprite = alien.equip1.pele;
            if(alien.equip2 == null){
                equipView[1].SetActive(false);
            }
            else{
                equipView[1].SetActive(true);
                equip[1].sprite = alien.equip1.pele;
            }   
        }

        //Status
        List<float> result = BibliotecaBD.instance.CalcularPoder(alien);
        status[0].text = $"VD: {(int)result[0]} / {alien.vida}";
        status[1].text = $"DN: {(int)result[1]} / {alien.dano}";
        status[2].text = $"DF: {(int)result[2]} / {alien.defesa}";
        status[3].text = $"VL: {(int)result[3]} / {alien.velocidade}";
        status[4].text = $"CR: {result[4]} / {alien.critico}";

        //Maestria
        Maestria.sprite = omnetrix[alien.nivelMaestria-1];
    }

    public void Next(int i){
        contador += i;

        if(contador < 0){
            contador = BibliotecaBD.instance.playerAlien.Count - 1;
        }
        else if(contador >= BibliotecaBD.instance.playerAlien.Count){
            contador = 0;
        }
        CarregarDadosAlien(contador);
    }


    public void Desequipar(int i){
        if(i == 0){
            if(alien.equip1 != null){
                alien.equip1.quantidades++;
                alien.equip1 = null;
            }
        }
        else if( i == 1){
            if(alien.equip2 != null){
                alien.equip2.quantidades++;
                alien.equip2 = null;
            }
        }
        CarregarDadosAlien(contador);
        SystemMenu.instance.CarregarItemOrEquip(1);
    }
}
