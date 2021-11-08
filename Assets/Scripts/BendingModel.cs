using UnityEngine;

[System.Serializable]
public class BendingModel
{
    static readonly int
        bendingCenterID = Shader.PropertyToID("_BendingCenter"),
        bendAxisID = Shader.PropertyToID("_BendAxis"),
        maxBendPosMagnitudeID = Shader.PropertyToID("_MaxBendPosMagnitude"),
        spinToAttenuatedID = Shader.PropertyToID("_SpinToAttenuated");

    public MeshRenderer meshRenderer;
    [SerializeField] Material sharedMaterial;

    public Transform Transform => meshRenderer.transform;

    public Material Material
    {
        get
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                if (sharedMaterial != meshRenderer.sharedMaterial)
                    meshRenderer.sharedMaterial = sharedMaterial;

                return sharedMaterial;
            }
#endif
            return meshRenderer.material;
        }
    }

    public void SendToShader(Transform benderT, float maxBendPosMagnitude)
    {
        Vector3 bendLocalAxis = benderT.localPosition != Vector3.zero ? RotateXZPlane(benderT.localPosition).normalized : Vector3.forward; // must not be (0,0,0)
        Material.SetFloat(maxBendPosMagnitudeID, maxBendPosMagnitude);
        Material.SetVector(bendingCenterID, benderT.localPosition);
        Material.SetFloat(spinToAttenuatedID, benderT.localPosition.magnitude);
        Material.SetVector(bendAxisID, bendLocalAxis);
    }

    Vector3 RotateXZPlane(Vector3 vector) => new Vector3(vector.z, 0, -vector.x);
}





// using UnityEngine;

// [System.Serializable]
// public class BendingModel
// {
//     static readonly int
//         bendingCenterID = Shader.PropertyToID("_BendingCenter"),
//         bendAxisID = Shader.PropertyToID("_BendAxis"),
//         maxBendPosMagnitudeID = Shader.PropertyToID("_MaxBendPosMagnitude"),
//         spinToAttenuatedID = Shader.PropertyToID("_SpinToAttenuated");

//     public MeshRenderer[] meshRenderers;
//     [SerializeField] Material[] sharedMaterials;

//     public Material[] Materials
//     {
//         get
//         {
// #if UNITY_EDITOR
//             if (!Application.isPlaying)
//             {
//                 for (int i = 0; i < meshRenderers.Length; i++)
//                 {
//                     if (sharedMaterials[i] != meshRenderers[i].sharedMaterial)
//                         meshRenderers[i].sharedMaterial = sharedMaterials[i];
//                 }
//                 return sharedMaterials;
//             }
// #endif
//             return meshRenderers.;
//         }
//     }

//     public void SendToShader(Transform benderT, float maxBendPosMagnitude)
//     {
//         Vector3 bendLocalAxis = benderT.localPosition != Vector3.zero ? RotateXZPlane(benderT.localPosition).normalized : Vector3.forward; // (0,0,0 olmamalı!!!)
//         Materials.SetFloat(maxBendPosMagnitudeID, maxBendPosMagnitude);
//         Materials.SetVector(bendingCenterID, benderT.localPosition);
//         Materials.SetFloat(spinToAttenuatedID, benderT.localPosition.magnitude);
//         Materials.SetVector(bendAxisID, bendLocalAxis);
//     }

//     Vector3 RotateXZPlane(Vector3 vector) => new Vector3(vector.z, 0, -vector.x);
// }




