using System;

namespace CoffeeBara.Gameplay.Common.HierarchicalStateMachine {
    public class Trigger {
        public event Action OnTriggered;

        public void Invoke() {
            OnTriggered?.Invoke();
        }
    }
}