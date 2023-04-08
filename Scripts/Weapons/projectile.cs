using UnityEngine;

public class projectile : MonoBehaviour {
    public float speed;
    public int Damage = 3;
    [SerializeField] private float LifeTime;
    [SerializeField] private GameObject particalEffect;

    private void Start() {
        Invoke("DestroyProjectile", LifeTime);
    }

    private void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void DestroyProjectile() {
        Instantiate(particalEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null) {
            enemy.TakeDamge(Damage);
        }

        DestroyProjectile();
    }
}
