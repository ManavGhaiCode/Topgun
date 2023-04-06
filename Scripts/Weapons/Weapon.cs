using UnityEngine;

public class Weapon : MonoBehaviour {
    public float bulletSpeed;

    private void Update() {
        Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(Dir.y, Dir.y);        
    }
}