using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Ui
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject _activePanel;
        private EventSystem _eventSystem;
        private GameObject _defaultSelectable;

        private void Awake()
        {
            _eventSystem = FindObjectOfType<EventSystem>();
            SwitchPanel(_activePanel);
        }

        public void SwitchPanel(GameObject newPanel)
        {
            _activePanel.SetActive(false);
            _activePanel = newPanel;
            newPanel.SetActive(true);
            SetupNavigation(_activePanel);
        }

        private void SetupNavigation(GameObject panel)
        {
            var selectables = panel.GetComponentsInChildren<Selectable>();
            // Set the default menu.
            _defaultSelectable = selectables[0].gameObject;
            _eventSystem.SetSelectedGameObject(_defaultSelectable);
            // Setup the navigation for each object.
            if (selectables.Length < 2) return;
            for (var i = 0; i < selectables.Length; i++)
            {
                var navigation = selectables[i].navigation;
                navigation.selectOnUp =
                    i == 0 ? selectables[selectables.Length - 1] : selectables[i - 1];
                navigation.selectOnDown = i == selectables.Length - 1 ? selectables[0] : selectables[i + 1];
                selectables[i].navigation = navigation;
            }
        }

        private void Update()
        {
            // Regain lost focus.
            if (!_eventSystem.currentSelectedGameObject)
            {
                _eventSystem.SetSelectedGameObject(_defaultSelectable);
            }
        }
    }
}
