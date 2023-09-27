using UnityEngine;

public class IceBSView : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer skRenderer;

    public void SetBSWeight(float value)
    {
        skRenderer.SetBlendShapeWeight(0, value);
    }
}
