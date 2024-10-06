using UnityEngine;

public class AimCursorSystem : MonoBehaviour
{
    [field: SerializeField]
    public Transform AimTarget { get; private set; }

    [field: SerializeField]
    public float AimSmooth { get; private set; } = 20f;

    [field: SerializeField]
    public Camera Camera { get; private set; }

    [field: SerializeField]
    public float MaxTargetDistance { get; private set; }

    private void Update()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray rayFromScreenCenter = Camera.ScreenPointToRay(screenCenter);
        Vector3 targetPoint = rayFromScreenCenter.origin + rayFromScreenCenter.direction * MaxTargetDistance;
        AimTarget.position = Vector3.Lerp(AimTarget.position, targetPoint, AimSmooth * Time.deltaTime);
    }
}
