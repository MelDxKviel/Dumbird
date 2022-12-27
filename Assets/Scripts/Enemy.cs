using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.white, hp / 100);
        if (hp <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<Score>().IncreaseScore(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Border") )
            Destroy(gameObject);
    }
}