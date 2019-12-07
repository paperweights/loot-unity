using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class CoinDisplay : MonoBehaviour
    {
        [SerializeField] private string _displayFormat = "{0}";
        [SerializeField] private Text _coinText;

        public void UpdateCoins(int newAmount)
        {
            _coinText.text = string.Format(_displayFormat, newAmount);
        }
    }
}