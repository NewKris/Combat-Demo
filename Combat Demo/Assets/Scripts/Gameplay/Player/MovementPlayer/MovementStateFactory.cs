using CoffeeBara.Gameplay.Common.FiniteStateMachine;

namespace CoffeeBara.Gameplay.Player.MovementPlayer {
    public static class MovementStateFactory {
        public static State<BlackBoard> IdleState() {
            return State<BlackBoard>.GetBuilder()
                .Build();
        }
    }
}