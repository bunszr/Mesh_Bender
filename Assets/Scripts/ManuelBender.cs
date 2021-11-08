using UnityEngine;

public class ManuelBender : Bender
{
    Camera cam;
    Vector2 enterMousePos;
    const float smoother = 0.09f;

    [SerializeField] float stretchSmoother = 2;
    [SerializeField] Vector3 dirRotationOffset;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onUpdateSpringEvent -= spring.UpdateSpring;
            enterMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 screenDirVector = ((Vector2)Input.mousePosition - enterMousePos) * smoother;
            Vector3 worldDirVector = new Vector3(screenDirVector.x, 0, screenDirVector.y);
            Vector3 camSpaceDir = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * worldDirVector;
            Vector3 localSpaceDir = Quaternion.Euler(dirRotationOffset) * bendingModel.Transform.InverseTransformDirection(camSpaceDir);
            Vector3 targetLocalPos = Vector3.ClampMagnitude(localSpaceDir, spring.maxPosMagnitude / bendingModel.Transform.localScale.x);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPos, stretchSmoother * Time.deltaTime);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            onUpdateSpringEvent += spring.UpdateSpring;
        }
    }
}