using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TechDesignTestProject
{
    public class ConvasControllerTwoScene : MonoBehaviour
    {
        [SerializeField]
        private Button _changeScaneButton;
        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private TMP_Dropdown _dropdown;

        private void Start()
        {
            _changeScaneButton.onClick.AddListener(OnChangeSceneButton);
            _exitButton.onClick.AddListener(ExitGame);
            StartCoroutine(LoadLocale());
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

        public void OnChangeSceneButton()
        {
            SceneManager.LoadScene("first_test_scene");
        }
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
