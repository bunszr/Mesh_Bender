using UnityEngine;

[System.Serializable]
public class Spring
{
    Vector3 velocity;
    Transform transform;

    [Range(.5f, 3)] public float damping = 1f;
    [Range(0, .5f)] public float k = .22f;
    public float maxPosMagnitude = 3;

    public void Init(Transform transform)
    {
        this.transform = transform;
    }

    public void UpdateSpring()
    {
        float distance = transform.localPosition.magnitude;
        velocity += -transform.localPosition * distance * k;
        velocity *= 1f - damping * Time.deltaTime;
        transform.localPosition += velocity * Time.deltaTime;
    }
}