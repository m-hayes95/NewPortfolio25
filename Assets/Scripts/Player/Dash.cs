using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Player
{
    public class Dash : MonoBehaviour
    {
        #region variables

        [Header("Dash Settings")]
        [SerializeField, Range(1, 5)] private int dashesAllowed = 3;
        [SerializeField, Range(0.5f, 3f)] private float dashTimer = 1f;
        [SerializeField, Range(0.5f, 5f)] private float dashCooldown = 3f;
        [SerializeField, Range(15f, 35f)] private float dashSpeed = 25f;

        [Header("Dash Effects")]
        [SerializeField] private AudioSource dashAudioSource;
        [SerializeField] private AudioClip dashClip;

        [Header("Dash Events")]
        [SerializeField] private UnityEvent<float, float> OnDash;

        // non-editable variables
        private int currentDashes = 0;
        private bool isDashing = false;

        #endregion

        #region public methods
        public void TryDash()
        {
            if (currentDashes < dashesAllowed && !isDashing)
            {
                StartCoroutine(PerformDash());
            }
        }

        #endregion

        #region private methods
        private IEnumerator PerformDash()
        {
            // Update dash Status
            isDashing = true;
            currentDashes++;

            // Play effects
            // dashAudioSource.PlayOneShot(dashClip);

            // Dash
            OnDash?.Invoke(dashSpeed, dashTimer);

            // Cooldown state
            if (currentDashes >= dashesAllowed)
            {
                yield return new WaitForSeconds(dashCooldown);
                currentDashes = 0;
            }

            // Reverse is dashing variable so we can dash again
            isDashing = false;

            yield return null;
        }
        #endregion
    }
}

