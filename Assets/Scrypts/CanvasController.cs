using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TechDesignTestProject
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Button _changeScaneButton;
        [SerializeField]
        private TMP_Dropdown _dropdown;
        [SerializeField]
        private Button _exitButton;

        private void Start()
        {
            _changeScaneButton.onClick.AddListener(OnChangeSceneButton);
            _exitButton.onClick.AddListener(ExitGame);
            StartCoroutine(LoadLocale());
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        IEnumerator LoadLocale()
        {
            // Wait for the localization system to initialize, loading Locales, preloading etc.
            yield return LocalizationSettings.InitializationOperation;

            // Generate list of available Locales
            var options = new List<TMP_Dropdown.OptionData>();
            int selected = 0;

            for (int i = 0; i < LocalizationSettings.AvailableLocales.Locales.Count; ++i)
            {
                var locale = LocalizationSettings.AvailableLocales.Locales[i];
                if (LocalizationSettings.SelectedLocale == locale)
                    selected = i;
                options.Add(new TMP_Dropdown.OptionData(locale.name));
            }
            _dropdown.options = options;

            _dropdown.value = selected;
            _dropdown.onValueChanged.AddListener(LocaleSelected);
        }

        static void LocaleSelected(int index)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }

        private void Update()
        {
            float value = _gameManager.TrackerBot();
            if (value < 180) _animator.SetTrigger("FontSize");
            else _animator.ResetTrigger("FontSize");
            _text.text = value.ToString();
       
        }

        public void OnChangeSceneButton()
        {
            SceneManager.LoadScene("second_test_scene");
        }
    }
}

