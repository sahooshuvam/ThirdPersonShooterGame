using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int startingHealth;
    [SerializeField] int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);
        if(currentHealth<=0)
        {
            DeadMethod();
        }
    }
    public void DeadMethod()
    {
        gameObject.SetActive(false);
    }
}
