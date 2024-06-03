using System;
using UnityEngine;

namespace CoffeeBara.Gameplay.Util {
    public class RequireInterface : PropertyAttribute {
        public Type type;
        
        public RequireInterface(Type type) {
            this.type = type;
        }
    }
}