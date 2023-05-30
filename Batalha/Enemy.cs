using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;
    public Dificuldades listAliens;
    public Alien enemy;
    public int dano, vida, velocidade, defesa;
    public float critico;
    public List<Skill> skills;
    public int dna = 0;
    


    void Awake() {
        instance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {   
        
        int nivel = PlayerPrefs.GetInt("dificuldade");
        listAliens = BibliotecaBD.instance.listaAlienDificuldade[nivel-1];
        if(PlayerPrefs.GetInt("NivelNaveDrop") > 0){
             StatusEnemy(Random.Range(nivel-4, 13));
        }
        else{
            StatusEnemy(Random.Range(SystemDropMenu.instance.nivel, SystemDropMenu.instance.nivel + nivel + 1));
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusEnemy(int i){
        enemy = listAliens.aliens[Random.Range(0, listAliens.aliens.Count)];
        dano = enemy.dano + Random.Range(i*2, i*5);
        vida = enemy.vida + Random.Range(i*5, i*20);
        velocidade = enemy.velocidade + Random.Range(i*2, i*5);
        defesa = enemy.defesa + Random.Range(i*2, i*5);
        critico = enemy.critico + Random.Range(0, 1);
        skills = enemy.skills ;
        dna = enemy.analizar ;
        
    }
    
}
