using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusMission : MonoBehaviour
{
    public static StatusMission instance;
    public Text nome, tipo, abates, skill, invicto, addSkill, buff;
    public GameObject confirmar, panelstatus;
    public List<Image> stars;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StatusDescription(Alien  alien, int i){
        Mission missao = alien.missions[i];
        nome.text = missao.nome;
        int nivel = missao.nivel * 5;
        panelstatus.SetActive(true);
        tipo.text = $"Nivel : {missao.tipo.ToString()}";
        if(missao.aliens.Count > 0){
            abates.text = $"Abates ({missao.aliens[0].nome}): {missao.alienAbates[0].ToString()} / {missao.alienAbatesConfirmados[0].ToString()}";
        }
        else{
            abates.text = $"Abates (Nulo)";
        }
        if(missao.skills.Count > 0){
            skill.text = $"Skill ({missao.skills[0].nome}): {missao.skillUsadas[0].ToString()} / {missao.skillUsadasConfirmados[0].ToString()}";
        }else{
            skill.text = $"Skill (Nulo)";
        }
        invicto.text = $"Invicto: {nivel.ToString()} / {missao.vitoriaSeguidas.ToString()}";
        if(missao.skill != null){
            addSkill.text = $"Skill Add: {missao.skill.nome}";
        }
        else{
            addSkill.text = $"Skill Add: Nulo";
        }
        
        buff.text = $"VD: {missao.vida.ToString()}+ / DN: {missao.dano.ToString()}+ / DF: {missao.defesa.ToString()}+ / CR: {missao.critico.ToString()}+ / VL: {missao.velocidade.ToString()}+";
        stars[1].color = new Color32 (0,0,0,255);
        stars[2].color = new Color32 (0,0,0,255);
        for(int j = 0; j < missao.tipo; j ++){
            stars[j].color = new Color32 (255,255,255,255);
        }
        if(missao.confirmar){
            confirmar.SetActive(true);
        }
        else{
            confirmar.SetActive(false);
            
        }
    }
}
