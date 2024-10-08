using Assets.Scripts.ScriptableObjects;
using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayableCharacterCameraSystem : MonoBehaviour
{
    [field: SerializeField]
    public CinemachineFreeLook Cinemachine { get; private set; }

    [field: SerializeField]
    public float AimZoomMultiplicator { get; private set; } = 2f;

    [field: SerializeField]
    public float CameraSpeedZoomDivider { get; private set; } = 2f;

    private bool _isZoomRecoilingEffect = false;
    private bool _isRecoilingEffect = false;

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

    public void DoZoomRecoilEffect(Gun gun)
    {
        _isZoomRecoilingEffect = true;
        _isRecoilingEffect = false;
        StartCoroutine(ZoomRecoilEffectCoroutine(gun.FireRate, gun.ZoomRecoil));
    }

    public void DoRecoilEffect(Gun gun)
    {
        _isZoomRecoilingEffect = false;
        _isRecoilingEffect = true;
        StartCoroutine(RecoilEffectCoroutine(gun.FireRate, gun.Recoil));
    }

    public void StopRecoilEffect()
    {
        _isZoomRecoilingEffect = false;
        _isRecoilingEffect = false;
    }

    public IEnumerator ZoomRecoilEffectCoroutine(float rateEffect, float recoilIntensity)
    {
        while (_isZoomRecoilingEffect)
        {
            Cinemachine.m_YAxis.Value = Cinemachine.m_YAxis.Value - (recoilIntensity * 0.1f / 100f);
            yield return new WaitForSeconds(rateEffect);
        }
    }

    public IEnumerator RecoilEffectCoroutine(float rateEffect, float recoilIntensity)
    {
        while (_isRecoilingEffect)
        {
            Cinemachine.m_YAxis.Value = Cinemachine.m_YAxis.Value - (recoilIntensity * 0.1f / 100f);
            yield return new WaitForSeconds(rateEffect);
        }
    }
}
