using Cinemachine;
using UnityEngine;

public class PlayableCharacterCameraSystem : MonoBehaviour
{
    [field: SerializeField]
    public CinemachineFreeLook Cinemachine { get; private set; }

    [field: SerializeField]
    public float AimZoomMultiplicator { get; private set; } = 2f;

    [field: SerializeField]
    public float CameraSpeedZoomDivider { get; private set; } = 2f;

    public void Aim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView / AimZoomMultiplicator;

        Cinemachine.m_XAxis.m_MaxSpeed = Cinemachine.m_XAxis.m_MaxSpeed / CameraSpeedZoomDivider;
        Cinemachine.m_YAxis.m_MaxSpeed = Cinemachine.m_YAxis.m_MaxSpeed / CameraSpeedZoomDivider;
    }

    public void StopAim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView * AimZoomMultiplicator;

        Cinemachine.m_XAxis.m_MaxSpeed = Cinemachine.m_XAxis.m_MaxSpeed * CameraSpeedZoomDivider;
        Cinemachine.m_YAxis.m_MaxSpeed = Cinemachine.m_YAxis.m_MaxSpeed * CameraSpeedZoomDivider;
    }
}
