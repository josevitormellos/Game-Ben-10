using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuLoja : MonoBehaviour
{
    public List<Text> nome;
    public List<Image> item;
    public List<Text> descricao, valor;

    public List<int> idvendas, dna;
    public int contador=0;
    public GameObject panelLoja, panelFechado;

    //Alert
    public GameObject alert;
    public Text nick, dnaValue;
    public bool chave;
    public float time;

    //Dados
    public Alien alien;
    public Item itens;
    public Equipamento equip;

    // Start is called before the first frame update
    void Start()
    {
        CarregarDados();
        CarregarVendas();
    }

    // Update is called once per frame
    void Update()
    {
        if(chave){
            if(time > 10f){
                time = 0;
                chave = false;
                alert.SetActive(chave);
            }
            time += Time.deltaTime * 10;
        }
    }

    public void CarregarVendas(){
        alien = BibliotecaBD.instance.globalAlien[Random.Range(0,BibliotecaBD.instance.globalAlien.Count)];
        itens = BibliotecaBD.instance.globalItem[Random.Range(0,BibliotecaBD.instance.globalItem.Count)];
        equip = BibliotecaBD.instance.globalEquip[Random.Range(0,BibliotecaBD.instance.globalEquip.Count)];
        dna[0] = alien.nivelMaestria * 100 *Random.Range(1, 6);

        Dados(alien.id, alien.pele, alien.descricao, dna[0].ToString(), 0, alien.nome);
       
        dna[1] = 50 * Random.Range(1, 6) * equip.nivel;
        Dados(equip.id, equip.pele, equip.descricao, dna[1].ToString(), 1, equip.nome);

         dna[2] = 10 * Random.Range(1, 6) * itens.nivel;
        Dados(itens.id, itens.pele, itens.descricao, dna[2].ToString(), 2, itens.nome);

        
        
        
    }

    public void Dados(int id, Sprite pele, string description, string custo, int i, string titulo){
        switch(i){
            case 0:
                descricao[0].text = "Serve para carregar seu analise.Completo ganha o alien.";
                nome[0].text = $"DNA {titulo} 10%";
                break;
            default:
                descricao[i].text = description;
                nome[i].text = titulo;
                break;
            
        }
        item[i].sprite = pele;
        idvendas[i] = id;
        valor[i].text = $"DNA {custo}";
    }

    public void Exit(){
        Application.LoadLevel("MenuGame");
    }

    public void Comprar(int i){
        int moeda = PlayerPrefs.GetInt("MoedaDNA");
        if(moeda >= dna[i] ){
            moeda -= dna[i];
            PlayerPrefs.SetInt("MoedaDNA", moeda);
            contador++;
            CarregarDados();
            switch(i){
                case 0:
                    alien.analizar += 10;
                    break;
                case 1:
                    equip.quantidades ++;
                    break;
                default:
                    itens.quantidades++;
                    break;
            }
        }
        else{
            chave = true;
            alert.SetActive(chave);
        }

    }

    public void FecharLoja(){
        if(contador >=5){
            panelLoja.SetActive(false);
            panelFechado.SetActive(true);
        }
    }

    public void CarregarDados(){
        nick.text = "Nickname: "+ PlayerPrefs.GetString("nick");
        dnaValue.text = PlayerPrefs.GetInt("MoedaDNA").ToString();
    }
}
