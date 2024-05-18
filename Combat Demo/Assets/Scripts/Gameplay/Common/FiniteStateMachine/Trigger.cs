using System;

namespace CoffeeBara.Gameplay.Common.FiniteStateMachine {
    public class Trigger {
        public event Action OnTriggered;

        public void Invoke() {
            OnTriggered?.Invoke();
        }
    }
}