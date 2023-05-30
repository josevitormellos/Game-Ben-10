using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCadastro : MonoBehaviour
{
    public GameObject confirma;
    public InputField nome;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("chaveNick") == 1){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nome.text != ""){
            confirma.SetActive(true);
        }
        else{
            confirma.SetActive(false);
        }
        
    }

    public void CadastroRealizar(){
        if(nome.text != ""){
            PlayerPrefs.SetString("nick", nome.text);
            MenuGame.instance.Logar();
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("MoedaDNA", 0);
            PlayerPrefs.SetInt("chaveNick", 1);
            PlayerPrefs.SetInt("selectedAlien", 39);
        }
    }
}
