using Cinemachine;
using UnityEngine;

public class PlayableCharacterCameraSystem : MonoBehaviour
{
    [field: SerializeField]
    public CinemachineFreeLook Cinemachine { get; private set; }

    [field: SerializeField]
    public float AimZoomMultiplicator { get; private set; } = 2f;

    public void Aim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView / AimZoomMultiplicator;
    }

    public void StopAim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView * AimZoomMultiplicator;
    }
}
