using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MenuMissao : MonoBehaviour
{
    //Aliens
    public List<TextMeshProUGUI> textBA;
    public List<GameObject> gameBA;

    //Missões
    public List<TextMeshProUGUI> textBM;
    public List<GameObject> gameBM;

    public Alien alien;


    // Start is called before the first frame update
    void Start()
    {
        CarregarAlien();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Sair(){
        Application.LoadLevel("MenuGame");
    }
    public void CarregarAlien(){
        List<Alien> aliens = BibliotecaBD.instance.playerAlien;
        int i;
        for(i = 0; i < aliens.Count; i++){
            gameBA[i].SetActive(true);
            textBA[i].text = aliens[i].nome;

        }
        /*aliens = BibliotecaBD.instance.globalAlien;
        for(int j = 0; j < aliens.Count; j++, i++){
            if(!aliens[j].verificar){
                gameBA[i].SetActive(true);
                textBA[i].text = aliens[j].nome;
            }
        }*/
    }

    public void CarregaMissao(int valor ){
        alien = BibliotecaBD.instance.playerAlien[valor];
        
        int anterior = PlayerPrefs.GetInt("anterior");

        for(int i = 0; i < alien.missions.Count; i++){
                gameBM[i].SetActive(true);
                textBM[i].text = alien.missions[i].nome;
        }
        if( alien.missions.Count < anterior){
            for(int i =  alien.missions.Count; i < anterior; i++){
                gameBM[i].SetActive(false);
            }
        }
        PlayerPrefs.SetInt("anterior", alien.missions.Count);

    }

    public void CarregarStatusMissao(int i){
        StatusMission.instance.StatusDescription(alien, i);
    }
}
