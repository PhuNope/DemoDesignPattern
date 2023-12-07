using System;
using UnityEngine;

namespace Simple_subject_and_observer {
    public class Subject : MonoBehaviour {
        public event Action ThingHappened;

        public void DoThing() {
            ThingHappened?.Invoke();
        }
    }
}