using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Dificuldades", menuName = "Alien MultiVersos/Dificuldades", order = 0)]
public class Dificuldades : ScriptableObject {
    public string nome;
    public string descricao;
    public List<Alien> aliens;

    public int nivelMax;
}
    
   
