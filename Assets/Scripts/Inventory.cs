using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Inventory : MonoBehaviour
{

    public List<Items> items;
    public GameObject affectedTarget;
    public string theTarget;
    public string typeOfAffect;


    public float enemyAttack;

    public float playerAttack;


    private void Start()
    {
        UpdateItemEffect();
    }

    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateItemEffect();
        }
       */
       
    }

    // Start is called before the first frame update
    void UpdateItemEffect()
    {
        foreach (Items e in items)
        {

            
            for (int i = 0; i < e.itemEffects.Length; i++)
            {
                Items.ItemEffect currentItemEffect = e.itemEffects[i];

                #region TYPE
                
                switch (currentItemEffect.type)
                {
                    case Items.ItemEffect.Type.Attack : Debug.Log("Attack");
                        if (theTarget == "Enemy")
                        {
                            if (typeOfAffect == "Bonus")
                            {
                                enemyAttack += currentItemEffect.value;
                            }

                            if (typeOfAffect == "Malus")
                            {
                                enemyAttack -= currentItemEffect.value;
                            }
                        } 
                        
                        if (theTarget == "Player")
                        {
                            if (typeOfAffect == "Bonus")
                            {
                                playerAttack += currentItemEffect.value;
                            }

                            if (typeOfAffect == "Malus")
                            {
                                playerAttack -= currentItemEffect.value;
                            }
                        }
                            
                        break;
            
                    case Items.ItemEffect.Type.Life : Debug.Log("Life");
                        
                        break;
            
                    case Items.ItemEffect.Type.Money : Debug.Log("Money");
                        break;
            
                    case Items.ItemEffect.Type.Move : Debug.Log("Move");
                        break;
            
                }
                

                #endregion
                
                #region TARGET
                
                switch (currentItemEffect.target)
                {
                    case Items.ItemEffect.Target.Ennemy : Debug.Log("Target is Ennemy");
                        affectedTarget = GameObject.FindGameObjectWithTag("Enemy");
                        theTarget = "Enemy";
                        break;
                    
                    case Items.ItemEffect.Target.Player : Debug.Log("Target is Player");
                        affectedTarget = GameObject.FindGameObjectWithTag("Player");
                        theTarget = "Player";
                        break;
                }
                
                #endregion

                #region TYPE OF AFFECT
                
                switch (currentItemEffect.typeOfAffect)
                {
                    case Items.ItemEffect.TypeOfAffect.Bonus : Debug.Log("It's a Bonus !");
                        typeOfAffect = "Bonus";
                        break;
                    
                    case Items.ItemEffect.TypeOfAffect.Malus : Debug.Log("It's a Malus...");
                        typeOfAffect = "Malus";
                        break;
                }
                
                #endregion
            }
            
            
        }

        
    }

    void AddItems(Items items)
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Oui");
        
        if (other.GetComponent<ImAItem>())
        {
            Debug.Log("There's a item, it's " + other.GetComponent<ImAItem>().items.nom);
            Items collisionItem = other.GetComponent<ImAItem>().items;

            if(Input.GetKeyDown(KeyCode.A))
            {
                items.Add(collisionItem);
                UpdateItemEffect();

            }
              
        }
    }

    // Update is called once per frame
  

   
}
