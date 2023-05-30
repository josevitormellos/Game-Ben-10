using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Alien MultiVersos/Item", order = 0)]
public class Item : ScriptableObject {
    public int id;
    public string nome;
    public string descricao;
    public Sprite pele;

    public int vida;
    public int dano;
    public int defesa;
    public int velocidade;
    public float critico;
    public int quantidades;

    public int nivel;
}
  

