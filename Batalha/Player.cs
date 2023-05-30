using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Alien player;
    public int dano, vida, velocidade, defesa;
    public float critico;
    public List<Skill> skills;

    
    void Awake() {
        instance = this;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
        CarregaAlienDados();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CarregaAlienDados(){
        
        player = BibliotecaBD.instance.globalAlien[PlayerPrefs.GetInt("selectedAlien")];
        List <float> result = BibliotecaBD.instance.CalcularPoder(player);
        dano = (int)result[1];
        vida = (int)result[0];
        velocidade = (int)result[3];
        defesa = (int)result[2];
        critico = result[4];
        skills.AddRange(player.skills);
        MissionsVerific(player.missions);
        SkillStatusMenu.instance.StartSkillBattler(0);
    }
    private void MissionsVerific(List<Mission> missions){
        for(int i = 0; i < missions.Count; i++){
            if(missions[i].confirmar){
                if(missions[i].skill != null){
                    skills.Add(missions[i].skill);

                }
              
            } 
        }
    }



    public List<Mission> AtualizarMission(List<Mission> missions, int id, List<int> idS , List<int> usados, bool vitoria = false){
        for(int i = 0; i < missions.Count; i++){
            if(!missions[i].confirmar){
                
                if(missions[i].aliens.Count > 0){
                    for(int j = 0; j <missions[i].aliens.Count; j++){
                        if(missions[i].aliens[j].id == id){
                            missions[i].alienAbatesConfirmados[j] ++;
                        }
                        if(missions[i].alienAbates[j] <= missions[i].alienAbatesConfirmados[j] ){
                            missions[i].confirmar = true;
                            break;
                        }
                    }
                }
                else if( missions[i].skills.Count > 0){
                    for(int j = 0; j < missions[i].skills.Count; j++){
                        for(int k = 0; k < idS.Count; k++){
                            if(missions[i].skills[j].id == idS[k]){
                                missions[i].skillUsadasConfirmados[j] += usados[k];
                                }
                            if(missions[i].skillUsadas[j] <= missions[i].skillUsadasConfirmados[j] ){
                                missions[i].confirmar = true;
                                break;
                            }
                        }
                    }
                            
                }    

            }
             else {
                
                if(vitoria){
                    missions[i].vitoriaSeguidas++;
                    if(missions[i].nivel * 5 == missions[i].vitoriaSeguidas){
                        missions[i].dano += 10;
                        missions[i].nivel ++;
                        
                    }
                    
                
                }  
                else{
                    missions[i].vitoriaSeguidas = 0;
                }
            }

        
        }
        
        return missions;   
    }
}
