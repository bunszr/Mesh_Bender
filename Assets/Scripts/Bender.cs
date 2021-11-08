using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Bender : MonoBehaviour
{
    [SerializeField] protected BendingModel bendingModel;
    [SerializeField] protected Spring spring;

    protected System.Action onUpdateSpringEvent;

    protected virtual void Start()
    {
        spring.Init(transform);
        onUpdateSpringEvent += spring.UpdateSpring;
    }

    private void FixedUpdate()
    {
        onUpdateSpringEvent?.Invoke();
        SendToShader();
    }

    public void SendToShader()
    {
        bendingModel.SendToShader(transform, spring.maxPosMagnitude);
    }

    Vector3 RotateXZPlane(Vector3 vector) => new Vector3(vector.z, 0, -vector.x);
}
