using UnityEngine;

namespace LuviKunG.Test
{
    /// <summary>
    /// This is test script for testing animation event.
    /// </summary>
    public class TestScripts : MonoBehaviour
    {
        public void AnimationFirstEvent()
        {
            Debug.Log("First event (Called)");
        }

        public void AnimationSecondEvent(string message)
        {
            Debug.Log("Second event: " + message);
        }

        public void AnimationThirdEvent(int index)
        {
            Debug.Log("Third event: " + index.ToString("N0"));
        }

        public void AnimationFouthEvent(float value)
        {
            Debug.Log("Fouth event: " + value.ToString("N2"));
        }

        public void AnimationFifthEvent(Object reference)
        {
            Debug.Log("Fifth event: " + reference.name);
        }
    }
}