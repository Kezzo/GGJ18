using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
    public IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public IEnumerator LoadScene(float delay, string scene){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }

}
