using UnityEngine;

namespace Simple_subject_and_observer {
    public class Observer : MonoBehaviour {
        [SerializeField] private Subject subjectToObserver;

        private void OnThingHappened() {
            Debug.Log("Observer reponds");
        }

        private void Awake() {
            if (subjectToObserver != null) {
                subjectToObserver.ThingHappened += OnThingHappened;
            }
        }

        private void OnDestroy() {
            if (subjectToObserver != null) {
                subjectToObserver.ThingHappened -= OnThingHappened;
            }
        }
    }
}