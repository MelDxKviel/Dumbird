using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public Gradient gradient;
    
    private float maxHp;
    
    private void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        GetComponent<Renderer>().material.color = gradient.Evaluate(Mathf.InverseLerp(0, maxHp, hp));
        if (hp <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<Score>().IncreaseScore(1);
        }
    }

    private void Start()
    {
        maxHp = hp;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border") )
            Destroy(gameObject);
    }
}