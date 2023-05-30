using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagMenu : MonoBehaviour
{
    public List<Image> itensP;
    public List<Text> quantidade;
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

    public void CarregarItem(){
        contador ++;
        if( contador <= 1){
            panel.SetActive(true);
            for(int i = 0; i < quantidade.Count; i ++){
                itensP[i].sprite = BibliotecaBD.instance.globalItem[i].pele;
                quantidade[i].text = BibliotecaBD.instance.globalItem[i].quantidades + "X";
                if(BibliotecaBD.instance.globalItem[i].quantidades > 0){
                    itensP[i].color = new Color32 ((byte)255,(byte)255,(byte)255,(byte)255);
                }
                else{
                    itensP[i].color = new Color32 ((byte)0,(byte)0,(byte)0,(byte)255);
                }
            }
        }
        else{
            panel.SetActive(false);
            contador = 0;
        }
        
    }

    public void ButtonItemPr(int i){
        Alien enemy = Enemy.instance.enemy;
        int vida = 0;
        if(BibliotecaBD.instance.globalItem[i].quantidades > 0){
            BibliotecaBD.instance.globalItem[i].quantidades --;
            MenuBatalha.instance.AttackEnemy(enemy.skills[Random.Range(0, enemy.skills.Count)]);
            MenuBatalha.instance.StatusLife();
            vida = (MenuBatalha.instance.vidaIP/100) * 50;
            Player.instance.vida += vida;
            if(MenuBatalha.instance.vidaIP < Player.instance.vida){
                Player.instance.vida = MenuBatalha.instance.vidaIP;
            }
            
            
            MenuBatalha.instance.StatusLife();
            PlayerStatusMenu.instance.DescriptionsStatus();
        }  
        panel.SetActive(false);

    }
 
}
