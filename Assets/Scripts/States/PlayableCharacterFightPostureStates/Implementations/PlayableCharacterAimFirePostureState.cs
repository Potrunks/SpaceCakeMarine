using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterAimFirePostureState : PlayableCharacterFightPostureState
    {
        public override IPlayableCharacterFightPostureState CheckingStateModification(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            return NextState ?? null;
        }

        public override void OnEnter(PlayableCharacterFightSystem playableCharacterFightSystem)
        {

        }

        public override void OnExit(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            if (NextState.GetType() == typeof(PlayableCharacterAimPostureState))
            {
                playableCharacterFightSystem.OnPlayerAimFireRelease.Raise();
            }

            if (NextState.GetType() == typeof(PlayableCharacterFirePostureState))
            {
                playableCharacterFightSystem.OnPlayerFireAimRelease.Raise();
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            switch (action)
            {
                case PlayableCharacterAction.STOP_FIRE:
                    NextState = new PlayableCharacterAimPostureState();
                    break;
                case PlayableCharacterAction.STOP_AIM:
                    NextState = new PlayableCharacterFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}
