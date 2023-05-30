using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escanear : MonoBehaviour
{
    public static Escanear instance;
    public Text informacao;
    public GameObject tInforma;
    public Image peleAlien;
    public bool escaneando;
    public float colorz = 255;
    public int contador = 0;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(escaneando == true){
            if(contador%2 == 0){
                colorz -= 100f * Time.deltaTime;
                peleAlien.color = new Color32((byte)255 , (byte)193, (byte)colorz,(byte)255);
                if(colorz <= 0){
                    contador ++;
                }
            }
            else if(contador == 5){
                peleAlien.color = new Color32((byte)255 , (byte)255, (byte)255,(byte)255);
                escaneando = false;
                tInforma.SetActive(true);
                int dna = Enemy.instance.enemy.analizar;
                if(dna == 0){
                    informacao.text = "ERRO ERRO... FALHA AO ESCANEAR";
                }
                else if(dna == 100){
                    informacao.text = $"DNA COMPLETO";
                }
                else{
                     informacao.text = $"Escanemento sucesso DNA -> {Enemy.instance.enemy.analizar}%";
                }
                contador = 0;
            }
            else{
                colorz += 100f * Time.deltaTime;
                peleAlien.color = new Color32((byte)255 , (byte)193, (byte)colorz,(byte)255);
                 if(colorz >= 255){
                    contador ++;
                }
            }
        }
        if(informacao.text != ""){
            if(time < 10f){
                time += 4f * Time.deltaTime;
            }
            else{
                informacao.text = "";
                tInforma.SetActive(false);
                time = 0;
            }
        }
        
    }
}
