using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterFirePostureState : PlayableCharacterFightPostureState
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
            playableCharacterFightSystem.OnPlayerFireRelease.Raise();
            if (NextInput == PlayableCharacterAction.AIM)
            {
                playableCharacterFightSystem.OnPlayerAimInput.Raise();
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            NextInput = action;
            switch (action)
            {
                case PlayableCharacterAction.STOP_FIRE:
                    NextState = new PlayableCharacterStopPostureState();
                    break;
                case PlayableCharacterAction.AIM:
                    NextState = new PlayableCharacterAimFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}
