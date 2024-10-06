using Assets.Scripts.GameEvents.ScriptableObjects;
using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayableCharacterFightSystem : MonoBehaviour
{
    [field: SerializeField]
    public GameEvent OnPlayerAimInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerAimRelease { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireRelease { get; private set; }

    private IPlayableCharacterFightPostureState _currentFightPostureState = new PlayableCharacterStopPostureState();
    private IPlayableCharacterFightPostureState _nextFightPostureState;

    public void Aim(CallbackContext context)
    {
        if (context.performed)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.AIM);
        }

        if (context.canceled)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.STOP_AIM);
        }

        ChangeFightPostureState();
    }

    public void Fire(CallbackContext context)
    {
        if (context.performed)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.FIRE);
        }

        if (context.canceled)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.STOP_FIRE);
        }

        ChangeFightPostureState();
    }

    private void ChangeFightPostureState()
    {
        _nextFightPostureState = _currentFightPostureState.CheckingStateModification(this);
        if (_nextFightPostureState != null)
        {
            _currentFightPostureState.OnExit(this);
            _currentFightPostureState = _nextFightPostureState;
            _currentFightPostureState.OnEnter(this);
        }
    }
}
