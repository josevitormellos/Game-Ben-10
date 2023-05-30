using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBatalha : MonoBehaviour
{
    public static MenuBatalha instance;
    public Image iP, iE, wallpaper;
    public List<Sprite> battlerWallpaper;
    public List<string> nomeskills;
    public Slider statusP, statusE;
    public Text nome;

    public List<int> idS, usadoS;

    public Text nomeEnemy, wl, danoT;
    public int vidaIP, vel;
    public bool chave1, chave2, chave3;
    public float time1, time2;

   void Awake(){
    instance = this;
   }
    // Start is called before the first frame update
    void Start()
    {
        
        wallpaper.sprite = battlerWallpaper[PlayerPrefs.GetInt("dificuldade")-1];
        nome.text = Player.instance.player.nome;
        CarregaDadosMenu();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chave1){
            if(time1 >= 2f){
                Application.LoadLevel("MenuGame");
            }
            time1 += Time.deltaTime/2;
        }

        if(chave2){
            if(time2 < 255f){
                time2 +=  vel * Time.deltaTime * 3;
                danoT.color = new Color32((byte)255 , (byte)255, (byte)255,(byte)time2);
                if(time2%10 <= 1){
                    if(danoT.fontSize <= 40);
                    danoT.fontSize ++;
                }
                
            }else{
                time2 = 0;
                danoT.color = new Color32((byte)255 , (byte)255, (byte)255,(byte)time2);
                chave2 = false;
                danoT.fontSize = 17;
            }
        }
    }

    public void CarregaDadosMenu(){
        statusP.maxValue = Player.instance.vida;
        statusE.maxValue = Enemy.instance.vida;
        statusE.value = Enemy.instance.vida;
        statusP.value =  Player.instance.vida;
        iP.sprite = Player.instance.player.pele;
        iE.sprite = Enemy.instance.enemy.pele;
        vidaIP = Player.instance.vida;
        nomeEnemy.text = Enemy.instance.enemy.nome;
        StatusLife();
    }

    //Função que fica no botão para confirmar ataque com o "i" que é o id da skill do player
    public void ConfirmarAtaque(int i){
        //Verificar se a animação de dano foi feito
        if(!chave2 && !chave3){
            Skill skillE;
            i += SkillStatusMenu.instance.camada;
            Skill skill = Player.instance.skills[i];
            if(PlayerPrefs.GetInt("dificuldade") <= Enemy.instance.skills.Count){
                skillE = Enemy.instance.skills[Random.Range(0, PlayerPrefs.GetInt("dificuldade"))];
            }
            else{
                skillE = Enemy.instance.skills[Random.Range(0, Enemy.instance.skills.Count)];
            }
            
            if(i >= usadoS.Count){
                usadoS.Add(1);
                idS.Add(skill.id);
                
            }
            else{
                usadoS[i] ++;
            }
        
            //Ataque Player / possivel Vitoria
                AttackPlayer(skill);
            //Ataque Enemy/ possivel Derrota
                AttackEnemy(skillE);

                PlayerStatusMenu.instance.DescriptionsStatus();
                if(StatusEnemyMenu.instance.contador > 0){
                    StatusEnemyMenu.instance.ViewMenu(0);
                }
            //Continua Batalha
                StatusLife();


        
        }
        
        
    }

    public void StatusLife(){
        AnimationSliderDamage.instance.vidaDamage =  Enemy.instance.vida;
        AnimationSliderDamageP.instance.vidaDamage =  Player.instance.vida;
    }


    public void AttackEnemy(Skill skill){
        float acertoCriticoE = Random.Range(0.5f, Enemy.instance.critico/2);
        int taxaDefesaE = Random.Range(Player.instance.defesa/5, Player.instance.defesa);
        int golpe= skill.dano + (int)(Enemy.instance.dano *  acertoCriticoE) - taxaDefesaE;
        if(Player.instance.vida <= golpe){
            Player.instance.player.missions = Player.instance.AtualizarMission(Player.instance.player.missions, 0, idS, usadoS);
            wl.text = "Você Perdeu";
            Enemy.instance.enemy.analizar = Enemy.instance.dna;
            chave1 = true;
            
        }
        else{
             //Efeitos Enemy
           
            
            Player.instance.vida -= golpe;
        }
    }

    public void AttackPlayer(Skill skill){
        float acertoCritico = Random.Range(0.5f, Player.instance.critico);
        int golpe = (int)(skill.dano * acertoCritico)+ (int)(Player.instance.dano *  acertoCritico);
        if(Enemy.instance.vida <= golpe){

            Player.instance.player.missions = Player.instance.AtualizarMission(Player.instance.player.missions, Enemy.instance.enemy.id, idS, usadoS, true);
            PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 3);
            MaestriaPlayer.instance.CalcularXp(2);
            SystemDropMenu.instance.Drops(PlayerPrefs.GetInt("dificuldade"));
            AnimationSliderDamage.instance.vidaDamage =  0;
            Enemy.instance.vida = 0;
            chave3 = true;
            
        }
        else{
            
            //Efeitos Player
            
            Enemy.instance.vida -= golpe;
            Player.instance.defesa += skill.defesa;
            Player.instance.critico += skill.critico;
            Player.instance.velocidade += skill.velocidade;
            Enemy.instance.defesa -= skill.defesaE;
            Enemy.instance.critico -= skill.criticoE;
            Enemy.instance.velocidade -= skill.velocidadeE;

            Player.instance.vida += skill.vida;

            
            danoT.text = golpe.ToString();
            chave2 = true;
           


           
            
        }
    }

    
}
