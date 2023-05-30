using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillStatusMenu : MonoBehaviour
{
    public static SkillStatusMenu instance;
    public List<GameObject> gButton;
    public GameObject panelDescription;
    public List<Text> tButton, buff, debuff;
    public int camada;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSkillBattler(int nextSkill){
        List<Skill> skills = Player.instance.skills;
        int totalSkill = nextSkill * 4;
        Debug.Log(skills.Count);
        NoActivisionButton();

        for(int i = 0; i <4; i++){
            if(i < (skills.Count - totalSkill)){
                gButton[i].SetActive(true);
                tButton[i].text = skills[i + totalSkill].nome;
            }
            else{
                break;
            }
        }

        if(skills.Count > (3 + totalSkill)){
            gButton[5].SetActive(true);
        }
        else{
            gButton[5].SetActive(false);
        }
        
        if(nextSkill > 0){
            gButton[4].SetActive(true);
        }
        else{
            gButton[4].SetActive(false);
        }
        
        
    }

    public void NoActivisionButton(){
        for(int i = 0; i < 4; i ++){
            gButton[i].SetActive(false);
        }
    }

    public void AtualizaCamada(int nextSkill){
        camada += nextSkill;
        StartSkillBattler(camada);
    }

    public void SkillDescription(int i){
        List<Skill> skills = Player.instance.skills;
        panelDescription.SetActive(true);
        i += (camada * 4);
        buff[0].text = "Pd:" + skills[i].dano.ToString();
        buff[1].text = "Dn:" + skills[i].aumentoDano.ToString();
        buff[2].text = "Df:" + skills[i].defesa.ToString();
        buff[3].text = "Cr:" + skills[i].critico.ToString();
        buff[4].text = "Vi:" + skills[i].vida.ToString();
        buff[5].text = "Vl:" + skills[i].velocidade.ToString();
        debuff[0].text = "Df E:" + skills[i].defesaE.ToString();
        debuff[1].text = "Cr E:" + skills[i].criticoE.ToString();
        debuff[2].text = "Vl E:" + skills[i].velocidadeE.ToString();
        debuff[3].text = "Dn E:" + skills[i].danoE.ToString();
        
    }
    public void SkillDescriptionOff(){
        panelDescription.SetActive(false);
    }

    
}
