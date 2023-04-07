using UnityEngine;

public class projectile : MonoBehaviour {
    public float speed;
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
}
