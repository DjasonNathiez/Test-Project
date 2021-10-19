using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(order = 1, fileName = "Data", menuName = "ScriptableObject/Items")]
public class Items : ScriptableObject
{
    public string nom;

    public string description;

    public Sprite image;
    public ItemEffect[] itemEffects;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    [Serializable]
    public struct ItemEffect
    
    {
        
        public float value;
        
        public Type type;
        public enum Type { Attack, Life, Money, Move }
        
        public enum Target { Player, Ennemy}

        public Target target;
        
        public enum TypeOfAffect{ Bonus, Malus}

        public TypeOfAffect typeOfAffect;


    }
    
}
