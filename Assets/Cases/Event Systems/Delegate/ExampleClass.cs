using System;
using UnityEngine;

namespace Delegate {
    public class ExampleClass {
        public delegate void DoSomething(int num);

        public event DoSomething Something;

        public ExampleClass() {
            Something += FunctionOne;
            Something += FunctionTwo;

            Something.Invoke(456);
        }

        private void FunctionTwo(int num) {
            Debug.Log($"Function two called with value: {num}");
        }

        private void FunctionOne(int num) {
            Debug.Log($"Function one called with value: {num}");
        }
    }
}