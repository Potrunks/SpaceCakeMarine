using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterStopPostureState : PlayableCharacterFightPostureState
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
            switch (NextInput)
            {
                case PlayableCharacterAction.AIM:
                    playableCharacterFightSystem.OnPlayerAimInput.Raise();
                    break;
                case PlayableCharacterAction.FIRE:
                    playableCharacterFightSystem.OnPlayerFireInput.Raise();
                    break;
                default:
                    break;
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            NextInput = action;
            switch (action)
            {
                case PlayableCharacterAction.AIM:
                    NextState = new PlayableCharacterAimPostureState();
                    break;
                case PlayableCharacterAction.FIRE:
                    NextState = new PlayableCharacterFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}
