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
            if (NextInput == PlayableCharacterAction.STOP_AIM)
            {
                playableCharacterFightSystem.OnPlayerAimRelease.Raise();
                playableCharacterFightSystem.OnPlayerFireInput.Raise();
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            NextInput = action;
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
