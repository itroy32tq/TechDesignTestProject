using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TechDesignTestProject
{
    public class ConvasControllerTwoScene : MonoBehaviour
    {
        [SerializeField]
        private Button _changeScaneButton;

        private void Start()
        {
            _changeScaneButton.onClick.AddListener(OnChangeSceneButton);
        }
        public void OnChangeSceneButton()
        {
            SceneManager.LoadScene("first_test_scene");
        }
    }
}
