using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationGalaxy : MonoBehaviour
{
    public int chave , chaveS;
    public List<Transform> centralizar;
    public List<Image> galaxy;
    public float velocidade = 1f;
    public float time = 255;
    public Image Wallpaper;
    public GameObject worlds;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chave > 0 ){
            centralizar[chave-1].position = Vector3.Lerp(
                centralizar[chave-1].position,
                new Vector3(0,0,0),
                velocidade *Time.deltaTime

            );
            centralizar[chave-1].localScale = Vector3.Lerp(
                centralizar[chave-1].localScale,
                 new Vector3(4,4,0),
                  velocidade *Time.deltaTime);

            if(time > 40){
                time -= 1f;
                galaxy[chave-1].color = new Color32 ((byte)255,(byte)255,(byte)255,(byte)time);
                Wallpaper.color = new Color32 ((byte)time,(byte)time,(byte)time,(byte)255);
               
            }
            else{
                centralizar[chave-1].position = new Vector3(0,0,0);
                chave = 0;
                worlds.SetActive(true);
            }

        }
        if(chave < 0){
            centralizar[chaveS-1].position = Vector3.Lerp(
                centralizar[chaveS-1].position,
                new Vector3(PlayerPrefs.GetFloat("posx"),PlayerPrefs.GetFloat("posy"), 0),
                velocidade *Time.deltaTime

            );
            centralizar[chaveS-1].localScale = Vector3.Lerp(
                centralizar[chaveS-1].localScale,
                 new Vector3(1,1,0),
                  velocidade *Time.deltaTime*3);

            if(time < 254){
                time += 1f;
                galaxy[chaveS-1].color = new Color32 ((byte)255,(byte)255,(byte)255,(byte)time);
                Wallpaper.color = new Color32 ((byte)time,(byte)time,(byte)time,(byte)255);
               
            }
            else{
                centralizar[chaveS-1].position = new Vector3(PlayerPrefs.GetFloat("posx"),PlayerPrefs.GetFloat("posy"),0);
                chave = 0;
            }
        }
    }

    public void CentralizarGalaxia(int i){
        chave = i;
        chaveS = -i;
        PlayerPrefs.SetFloat("posx", centralizar[chave-1].position.x);
        PlayerPrefs.SetFloat("posy", centralizar[chave-1].position.y);

        
    }
    public void DescentralizarGalaxia(){
        chave = chaveS;
        chaveS *= -1;
        worlds.SetActive(false);
        MenuStatusPlanet.instance.statusPanel.SetActive(false);
    }
}
