using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBattlerMenu : MonoBehaviour
{
    public static ButtonBattlerMenu instance;
    public bool analizou; 

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit(){
        if(!analizou){
            if(Random.Range(1,100) <= SystemDropMenu.instance.taxaFuga){
            int i = Random.Range(0, SystemDropMenu.instance.taxaFuga+1);
            SystemDropMenu.instance.dna -= SystemDropMenu.instance.dna/100 * i;
        }

        SystemDropMenu.instance.Retornar();
        }
        
        
        
    }

    public void Analizar(){
        Alien enemy = Enemy.instance.enemy;
        if(!enemy.verificar){
            int dna = Random.Range(0,6);
        
            enemy.analizar += dna;

            MenuBatalha.instance.AttackEnemy(enemy.skills[Random.Range(0, enemy.skills.Count)]);
            MenuBatalha.instance.StatusLife();
            PlayerStatusMenu.instance.DescriptionsStatus();

            Debug.Log($"{enemy.nome} -> DNA {enemy.analizar.ToString()}%");
            Escanear.instance.escaneando = true;
            analizou = true;
        }
        else{
            Escanear.instance.tInforma.SetActive(true);
            Escanear.instance.informacao.text = "ERRO ERRO... DNA JÁ ESTÁ COMPLETO";
        }
        
    }
}
