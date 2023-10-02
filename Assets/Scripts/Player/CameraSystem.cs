using System.Collections;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] float defaultShakeDuration;
    [SerializeField] float defaultShakeMagnitude;

    #region ShakeCamera

    public void annimationShake() {
        ShakeCamera();
    }

    // Fonction de tremblement de camera à appeler en cas d'attaque ou de besoin
    public void ShakeCamera (float duration = 0, float magnitude = 0) {
        if(duration == 0) {
            duration = defaultShakeDuration;
            magnitude = defaultShakeMagnitude;
        }

        // Appel de la coroutine avec le durée et la force
        StartCoroutine(Shake(duration, magnitude));
    }
    // Duration en seconde (.1f ), magnitude sensible ( .01f )
    private IEnumerator Shake( float duration, float magnitude ) {
        // Positions originelles 
        Vector3 originalPositions = transform.position;
        // Temps écoulé
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Generation de positions aléatoires
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            // Assignation des positions aléatoires
            transform.position = new Vector3(originalPositions.x + x, originalPositions.y + y, originalPositions.z);
            // Ajout du temps écoulé
            elapsed += Time.deltaTime;
            // return null
            yield return null;
        } 
        // remise des positions originales
        transform.position = originalPositions;
    }
    #endregion ShakeCamera 
}
