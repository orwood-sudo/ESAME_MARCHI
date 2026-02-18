using UnityEngine;


public class Enemy1 : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 3f;
    public int maxHp = 3;
    public int moneyValue = 5;
    private int currentHp;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        spriteRenderer.color = Color.red;
        Invoke("ResetColor", 0.1f);

        if (currentHp <= 0)
        {
            Die();
        }
    }
    
    private void ResetColor()
    {
        spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        MoneyManager money = FindAnyObjectByType<MoneyManager>();
        money.IncreaseMoney(moneyValue);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GameOverZone"))
        {
            GameOverManager loose = FindAnyObjectByType<GameOverManager>();
            loose.GameOver(false);
            Time.timeScale = 0; 
        }
    }
}