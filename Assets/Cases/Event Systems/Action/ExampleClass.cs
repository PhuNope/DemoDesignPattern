using System;
using UnityEngine;

namespace Actions {
    public class ExampleClass {
        public Action<int> Something;

        public ExampleClass() {
            Something += FunctionOne;
            Something += FunctionTwo;

            Something?.Invoke(123);
        }

        private void SimpleFunction() {

        }

        private void FunctionTwo(int num) {
            Debug.Log($"Function two called with value: {num}");
        }

        private void FunctionOne(int num) {
            Debug.Log($"Function one called with value: {num}");
        }
    }
}