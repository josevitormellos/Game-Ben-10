using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationDescription : MonoBehaviour
{
    public int  colorx, colory, colorz;
    public float time;
    public float cronometro;
    public int boolUI;
    public Text nome, descricao;
    public Image imagem;
    public bool chave = false;
    public float resist;
    private float resistenciaTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
    OpacityGameObject();

    
    }
    public void OpacityGameObject(){
        if(resistenciaTime <= 0){      
                    Tempo();
                    nome.color = new Color32((byte)colorx , (byte)colory, (byte)colorz,(byte)time);
                    descricao.color = new Color32((byte)colorx , (byte)colory, (byte)colorz,(byte)time);
                    imagem.color = new Color32((byte)colorx , (byte)colory, (byte)colorz,(byte)time);
                    
        }
        else{
            resistenciaTime -= Time.deltaTime * 10f;
        }
    }

    public void Tempo(){
        if(time >= 1f && chave == false){
                        time -= Time.deltaTime * 40f;
                    }
                    else if ( time > 255f){
                        chave = false;
                        resistenciaTime = resist;
                        time = 255f;
                    }
                    else if(chave == true){
                        time += Time.deltaTime * 40f;
                    }
                    else{
                        chave = true;
                        AltereDescription(BibliotecaBD.instance.globalAlien[Random.Range(0, BibliotecaBD.instance.globalAlien.Count)]);
                    }
    }

    

    public void AltereDescription(Alien alien){
        nome.text = alien.nome;
        descricao.text = alien.descricao;
        imagem.sprite = alien.pele;
        
        
            
    }
    public void AlteraDescriptionButton(){
        time = 0;
        chave = true;
        AltereDescription(BibliotecaBD.instance.globalAlien[Random.Range(0, BibliotecaBD.instance.globalAlien.Count)]);
    }
    
}
