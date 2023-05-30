using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMenu : MonoBehaviour
{
    public static SystemMenu instance;
    public List<GameObject> panelItens;
    public List<Image> itemImg;
    public List<Text> nome, descricao, valor, textB;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        CarregarItemOrEquip(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarItemOrEquip(int i){
        int cont = 0;

        switch(i){
            case 0:
                List<Item> itens = BibliotecaBD.instance.globalItem;
                for(int j = 0; j < itens.Count; j++){
                    if(itens[j].quantidades > 0){
                        panelItens[cont].SetActive(true);
                        itemImg[cont].sprite = itens[j].pele;
                        nome[cont].text = itens[j].nome;
                        descricao[cont].text = itens[j].descricao;
                        valor[cont].text = itens[j].quantidades + "X";
                        textB[cont].text = "Usar";
                        cont++;
                    }
                    

                }
                break;
            case 1:
                List<Equipamento> equips = BibliotecaBD.instance.globalEquip;
                for(int j = 0; j < equips.Count; j++){
                    if(equips[j].quantidades > 0){
                        panelItens[cont].SetActive(true);
                        itemImg[cont].sprite = equips[j].pele;
                        nome[cont].text = equips[j].nome;
                        descricao[cont].text = equips[j].descricao;
                        valor[cont].text = equips[j].quantidades + "X";
                        textB[cont].text = "Equipar";
                        cont++;
                    }
                    
                }
                break;
            default:
                Debug.Log("Erro");
                break;
        }
        for(int k = cont; k < panelItens.Count; k++){
            panelItens[k].SetActive(false);
        }
    }

    public void Equipar(int i){
        if(textB[i].text == "Equipar"){
            Equipamento equip = BibliotecaBD.instance.globalEquip[i];
            Alien alien = AlienMenu.instance.alien;
            if(alien.equip1 == null){
                alien.equip1 =equip;
            }
            else{
                if(alien.equip2 == null){
                    alien.equip2 = equip;
                }
                
            }
            equip.quantidades --;
            CarregarItemOrEquip(1);
            AlienMenu.instance.CarregarDadosAlien(AlienMenu.instance.contador);

        }
        
    }

    
}
