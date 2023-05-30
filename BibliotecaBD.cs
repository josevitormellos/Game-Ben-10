using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibliotecaBD : MonoBehaviour
{
    public List<Dificuldades> listaAlienDificuldade;
    public List<Alien> globalAlien;
    public static BibliotecaBD instance;
    public List<Alien> playerAlien;
    public List<Item> globalItem;
    public List<Equipamento> globalEquip;
    public int energia;
    public float time;
    public List<float> result;
    
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        instance = this;    
        ListAlienPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        energia = PlayerPrefs.GetInt("Energia");
    }

    // Update is called once per frame
    void Update()
    {
        if( energia < 10){
            time += Time.deltaTime;
            if(time >= 20){
                energia++;
                PlayerPrefs.SetInt("Energia", energia);
                time = 0;
            }
        }
    }

    private void ListAlienPlayer(){
        for(int i = 0; i < globalAlien.Count; i++){
            if(globalAlien[i].verificar){
                playerAlien.Add(globalAlien[i]);
            }
        }
    }

    public List<float> CalcularPoder(Alien alien){
        result.Clear();
        result.Add(alien.vida * PlayerPrefs.GetInt("nivel"));
        result.Add(alien.dano * PlayerPrefs.GetInt("nivel"));
        result.Add(alien.defesa * PlayerPrefs.GetInt("nivel"));
        result.Add(alien.velocidade * PlayerPrefs.GetInt("nivel"));
        result.Add(alien.critico * PlayerPrefs.GetInt("nivel"));

        for(int i = 0; i < alien.missions.Count; i++){
            if(alien.missions[i].confirmar){
                result[1] += alien.missions[i].dano;
                result[0] += alien.missions[i].vida;
                result[3] += alien.missions[i].velocidade;
                result[2] += alien.missions[i].defesa;
                result[4] += alien.missions[i].critico;
              
            } 
        }

        if(alien.equip1 != null){
            result[1] += alien.equip1.dano;
            result[0] += alien.equip1.vida;
            result[3] += alien.equip1.velocidade;
            result[2] += alien.equip1.defesa;
            result[4] += alien.equip1.critico;
                if(alien.equip2 != null){
                    result[1] += alien.equip2.dano;
                    result[0] += alien.equip2.vida;
                    result[3] += alien.equip2.velocidade;
                    result[2] += alien.equip2.defesa;
                    result[4] += alien.equip2.critico;
                }
        }
 
    return result;

    }


}
