using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatusPlanet : MonoBehaviour
{
    public static MenuStatusPlanet instance;
    public GameObject statusPanel;
    public Text nome, descricao, nivel;
    public int valor;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusDescriptions(int i){
        valor = i;
        statusPanel.SetActive(true);
        if(valor > 0){
            
            
            nome.text = BibliotecaBD.instance.listaAlienDificuldade[i-1].nome;
            descricao.text = BibliotecaBD.instance.listaAlienDificuldade[i-1].descricao;
            nivel.text = $"Nivel Max: {BibliotecaBD.instance.listaAlienDificuldade[i-1].nivelMax.ToString()}";
            PlayerPrefs.SetInt("NivelNaveDrop", 0);
        }
        else{
            nome.text = "Grande Loja";
            descricao.text = "Nave que vive viajando pela galaxia são raros e podem vender produtos exóticos.";
        }
        
    }


}
