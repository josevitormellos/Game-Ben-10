using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemDropMenu : MonoBehaviour
{
    public static SystemDropMenu instance;
    public int nivel = 1;
    public float taxaDna = 0;
    public Text textNivel, textDna, textFuga, textDrop, textGold;
    public List<Item> dropsItem;
    public List<Equipamento> dropsEquip;
    public int  taxaFuga, dna = 0;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        instance =  this;
        CarregarStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregarStatus(){
        
        textNivel.text = $"Nivel: {nivel.ToString()}";
        textDna.text = $"{taxaDna.ToString()}%";
        textFuga.text = $"{taxaFuga.ToString()}%";
        textGold.text = dna.ToString();
    }

    public void Drops(int dificuldade){
        dna += (int)((dificuldade * Random.Range(1, 5)) + (dificuldade * taxaDna));
        nivel ++;
        taxaDna += 1f;
                    if(nivel >= 3 || taxaFuga >= 100){
                        taxaFuga += Random.Range(1, 3);
                        if(taxaFuga >=100){
                            taxaFuga = 100;
                        }
                    }
        CarregarStatus();
        Debug.Log("Passei no Drops " + PlayerPrefs.GetInt("NivelNaveDrop"));
        if(PlayerPrefs.GetInt("NivelNaveDrop") > 0){
            Debug.Log("Entrei Drops");
            DropsNave();
        }
        Enemy.instance.listAliens.nivelMax ++;
        panel.SetActive(true);
        

    }
    public void Prosseguir(){
        int dificuldade = PlayerPrefs.GetInt("dificuldade");
        Enemy.instance.StatusEnemy(Random.Range(nivel, nivel * 2));
        MenuBatalha.instance.statusE.maxValue = Enemy.instance.vida;
        MenuBatalha.instance.statusE.value = Enemy.instance.vida;
        MenuBatalha.instance.iE.sprite = Enemy.instance.enemy.pele;
        MenuBatalha.instance.nomeEnemy.text = Enemy.instance.enemy.nome;
        MenuBatalha.instance.StatusLife();
        MenuBatalha.instance.chave3 = false;
        panel.SetActive(false);
        ButtonBattlerMenu.instance.analizou = false;
    }
    public void Retornar(){
        PlayerPrefs.SetInt("MoedaDNA", PlayerPrefs.GetInt("MoedaDNA") + dna);
        for(int i = 0; i < dropsItem.Count; i++){
            dropsItem[i].quantidades ++;
        }
          for(int j = 0; j < dropsEquip.Count; j++){
            dropsEquip[j].quantidades ++;
        }
        Application.LoadLevel("MenuGame");
        
    }

    public void DropsNave(){
        if(nivel <= 10){
            CalculaDrop();
        }
    }

    private void CalculaDrop(){
        int randomI ;
        int randomE ;


        for(int j = nivel * PlayerPrefs.GetInt("NivelNaveDrop"); j > 0; j--){
           Debug.Log(j);
                if(Random.Range(0, 100) <= 100/j){
                    Debug.Log("Entrou Random");
                    if(Random.Range(0,2) == 0){
                        Debug.Log("Entrou item");
                        randomI = Random.Range(0, BibliotecaBD.instance.globalItem.Count);
                        Debug.Log(randomI);
                        for(int k = randomI; k < BibliotecaBD.instance.globalItem.Count; k++){
                            if(BibliotecaBD.instance.globalItem[k].nivel <= nivel-1){
                                dropsItem.Add(BibliotecaBD.instance.globalItem[k]);
                                break;
                            }
                            
                        }
                        textDrop.text += $"{dropsItem[dropsItem.Count - 1].nome} \n";
                    }

                    else{
                        Debug.Log("Entrou Equipamento");
                        randomE = Random.Range(0, BibliotecaBD.instance.globalEquip.Count);
                         Debug.Log(randomE);
                        for(int k = randomE; k < BibliotecaBD.instance.globalEquip.Count; k++){
                                if(BibliotecaBD.instance.globalEquip[k].nivel <= nivel - 1){
                                    dropsEquip.Add(BibliotecaBD.instance.globalEquip[k]);
                                    break;
                                }
                                
                            }
                            textDrop.text += $"{dropsEquip[dropsEquip.Count - 1].nome} \n";
                    }
            }
            
        }
    }
}
