using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class FinishCamera : MonoBehaviour
{
    public Transform targetPosition; // Assign this in the inspector
    public float smoothTime = 2f; // Time it takes to move the camera
    public Camera firstCamera;
    public GameObject endObject;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
        {

            StartCoroutine(MoveCamera(targetPosition.position));
        }
    }

    private IEnumerator MoveCamera(Vector3 target)
    {
        float elapsedTime = 0;

        Vector3 startingPos = firstCamera.transform.position;

        while (elapsedTime < smoothTime)
        {
            firstCamera.transform.position = Vector3.Lerp(startingPos, target, (elapsedTime / smoothTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera ends up at the exact target position
        firstCamera.transform.position = target;

        endObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("menu");
    }
}
