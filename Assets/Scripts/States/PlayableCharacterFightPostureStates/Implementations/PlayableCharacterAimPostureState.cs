using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterAimPostureState : PlayableCharacterFightPostureState
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
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            NextInput = action;
            switch (action)
            {
                case PlayableCharacterAction.STOP_AIM:
                    NextState = new PlayableCharacterStopPostureState();
                    break;
                case PlayableCharacterAction.FIRE:
                    NextState = new PlayableCharacterAimFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}
