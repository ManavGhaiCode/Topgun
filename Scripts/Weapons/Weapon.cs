using UnityEngine;

public class Weapon : MonoBehaviour {
    public float bulletSpeed = 12.5f;

    [SerializeField] private GameObject Projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private KeyBindings KeyBinds;

    private float canShootTime;

    private void Start() {
        canShootTime = Time.time;
    }

    private void Update() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButtonDown(KeyBinds.GetMouseKey("fire")) && canShootTime < Time.time) {
            GameObject bullet = Instantiate(Projectile, firePoint.position, firePoint.rotation);
            bullet.GetComponent<projectile>().speed = bulletSpeed;
            canShootTime = Time.time + timeBetweenShots;
        } 
    }
}