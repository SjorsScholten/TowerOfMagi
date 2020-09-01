using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts {
    public class GUILoaderComponent : MonoBehaviour {
        public string sceneName = "";

        private void Start() {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName) {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!op.isDone) {
                yield return null;
            }
            
            Debug.Log("loaded gui");
        }
    }
}