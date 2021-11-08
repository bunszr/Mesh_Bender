using UnityEngine;

public class Controller : MonoBehaviour
{
    Vector3 oldPosition;
    [SerializeField] float speed = 8;

    public Vector3 Velocity => transform.position - oldPosition;

    private void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        oldPosition = transform.position;
        transform.position += move * Time.deltaTime * speed;
    }
}