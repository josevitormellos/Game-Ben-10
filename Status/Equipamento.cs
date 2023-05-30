using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Alien", menuName = "Alien MultiVersos/Equipamento", order = 0)]
public class Equipamento : ScriptableObject
{
    public int id;
    public string nome;
    public string descricao;
    public int vida, dano, defesa, critico, velocidade;
    public int nivel;
    public int quantidades;
    public Sprite pele;
}
