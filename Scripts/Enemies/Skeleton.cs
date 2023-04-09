using System.Collections;
using UnityEngine;

public class Skeleton : Enemy {
    [SerializeField] private float StopDistance;
    [SerializeField] private float attckSpeed;

    private void Awake() {
        attckTime = Time.time + attckTime;
    }

    private void Update() {
        if (playerPosition != null) {
            if (Vector2.Distance(transform.position, playerPosition.position) > StopDistance) {
                transform.position = Vector2.Lerp(transform.position, Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime), speed * Time.deltaTime);
            } else {
                if (attckTime < Time.time) {
                    attckTime = Time.time + TimeBetweenAttcks;
                    StartCoroutine(Attck());
                }
            }
        }
    }

    IEnumerator Attck() {
        playerPosition.GetComponent<PlayerController>().TakeDamge(1);

        Vector2 originalPos = transform.position;
        Vector2 playerPos = playerPosition.position;

        float persent = 0;

        while (persent <= 1) {
            persent += Time.deltaTime * attckSpeed;
            float formual = (-Mathf.Pow(persent, 2) + persent) * 4;

            transform.position = Vector2.Lerp(originalPos, playerPos, formual);

            yield return null;
        }
    }
}