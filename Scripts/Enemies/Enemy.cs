using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public float speed;
    public float attckTime;
    public float TimeBetweenAttcks;

    [HideInInspector] public Transform playerPosition;



    private void Start() {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    } 

    public void TakeDamge(int Damage) {
        health -= Damage;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}