using System;
using UnityEngine;

namespace EventHandle {
    public class ExampleClass {
        public EventHandler Something;

        public ExampleClass() {
            Something(this, EventArgs.Empty);
        }

        private void FunctionTwo(int num) {
            Debug.Log($"Function two called with value: {num}");
        }

        private void FunctionOne(int num) {
            Debug.Log($"Function one called with value: {num}");
        }
    }
}