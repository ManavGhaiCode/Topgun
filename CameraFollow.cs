using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public float speed;

    [SerializeField] Transform Target;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private void Update() {
        if (Target != null) {
            float TargetX = Mathf.Clamp(Target.position.x, minX, maxX);
            float TargetY = Mathf.Clamp(Target.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2 (TargetX, TargetY), speed);
        }
    }
}
