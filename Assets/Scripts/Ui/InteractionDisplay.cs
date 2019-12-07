using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class InteractionDisplay : MonoBehaviour
    {
        [SerializeField] private Text _targetText;

        private void Awake()
        {
            ClearText();
        }

        public void SetText(string newText)
        {
            _targetText.text = newText;
        }

        public void ClearText()
        {
            _targetText.text = "";
        }
    }
}