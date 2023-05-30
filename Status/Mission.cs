using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Mission", menuName = "Alien MultiVersos/Mission", order = 0)]
public class Mission : ScriptableObject {
    public int id;
    public int tipo;
    public string nome;
    
    public List<Alien> aliens;
    public List<int> alienAbates;
    public List<int> alienAbatesConfirmados;

    public List<Skill> skills;
    public List<int> skillUsadas;
    public List<int> skillUsadasConfirmados;

    public int nivel;
    public int vitoriaSeguidas;
    

    public Skill skill;
    public int vida;
    public int dano;
    public int defesa;
    public float critico;
    public int velocidade;

    public bool confirmar;
    
}
