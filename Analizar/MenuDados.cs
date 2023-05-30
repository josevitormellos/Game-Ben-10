using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuDados : MonoBehaviour
{
    public Image pele;
    public Text nome, porcentagem;
    public GameObject bloqueio;
    public int contador = 0;
    public Slider dna;

    public GameObject selection;
    public Image selectionImage;
    public List<Sprite> selectionSprite;


    //Verificar Maestria

    public GameObject panelAlert;
    public Text alert;
    public bool chave;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        AnalizarAlien(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(chave){
            if(time >= 5){
                panelAlert.SetActive(false);
                time = 0;
                chave = false;
            }
            else{
                time += Time.deltaTime * 3;
            }
        }
    }


    public void AnalizarAlien(int i){
        contador += i;
        Alien alien = BibliotecaBD.instance.globalAlien[contador];
        pele.sprite = alien.pele;
        nome.text = alien.nome;

        if(!alien.verificar){
            bloqueio.SetActive(true);
            selection.SetActive(false);
            if(alien.analizar == 0 ){
                pele.color = new Color32((byte)0 , (byte)0, (byte)0,(byte)255);
            }
            else{
                pele.color = new Color32((byte)255 , (byte)193, (byte)0,(byte)255);
            }
        }
        else{
            bloqueio.SetActive(false);
            pele.color = new Color32((byte)255 , (byte)255, (byte)255,(byte)255);
            selection.SetActive(true);
            if(PlayerPrefs.GetInt("selectedAlien") == contador){
                selectionImage.sprite = selectionSprite[1];
            }
            else{
                selectionImage.sprite = selectionSprite[0];
            }
        }

        CarregarDNA(alien.analizar);
        

    }

    public void CarregarDNA(int dnaValue){
        porcentagem.text = dnaValue.ToString() + "%";
        dna.value = dnaValue;

    }

    public void Sair(){
        Application.LoadLevel("MenuGame");
    }

    public void SelectionAlien(){
        if(BibliotecaBD.instance.globalAlien[contador].nivelMaestria <= PlayerPrefs.GetInt("nivel")){
            PlayerPrefs.SetInt("selectedAlien", contador);
            selectionImage.sprite = selectionSprite[1];
        }
        else{
            panelAlert.SetActive(true);
            alert.text = $"Seu omnetrix nao suporta este alien.\n Erro Erro...... \nMaestria atual : {PlayerPrefs.GetInt("nivel")} \nMaestria do Alien : {BibliotecaBD.instance.globalAlien[contador].nivelMaestria}";
            chave = true;
        }

    }
}
