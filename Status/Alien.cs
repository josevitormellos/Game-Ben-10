using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Alien", menuName = "Alien MultiVersos/Alien", order = 0)]
public class Alien : ScriptableObject {
    
    //Dados Principais do alien
    public int id;
    public string nome;
    public string descricao;
    public int vida;
    public int dano;
    public int velocidade;
    public int defesa;
    public float critico;
    public Sprite pele;
    public List<Skill> skills;
    public List<Mission> missions;

    //VERIFICA DNA PARA PODER UTILIZAR O ALIEN
    public bool verificar;
    public int analizar;

    //Maestria
    public int nivelMaestria;

    //Equipamentos
    public Equipamento equip1, equip2;

}
