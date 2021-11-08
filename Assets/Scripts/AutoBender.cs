using UnityEngine;

public class AutoBender : Bender
{
    Controller controller;
    [SerializeField] float speed = 15;

    [SerializeField] Vector3 dirRotationOffset;

    private void Awake()
    {
        controller = transform.parent.GetComponent<Controller>();
    }

    void Update()
    {
        transform.position += Quaternion.Euler(dirRotationOffset) * -controller.Velocity * Time.deltaTime * speed;
    }
}
