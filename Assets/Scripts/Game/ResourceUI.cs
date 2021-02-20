using UnityEngine;
using UnityEngine.UI;

namespace CityBuilder.Game
{
    public class ResourceUI : MonoBehaviour
    {
        [SerializeField]
        private PlayerResource _resource;
        [SerializeField]
        private Text _nameText;
        [SerializeField]
        private Text _currentText;
        [SerializeField]
        private Text _maxText;


        private void Start()
        {
            _nameText.text = string.Concat(_resource.Name, ":");
            _currentText.text = _resource.Current.ToString();
            _maxText.text = _resource.Max.ToString();

            _resource.CurrentValueChanged += OnCurrentValueChanged;
            _resource.MaxValueChanged += OnMaxValueChanged;
        }

        private void OnMaxValueChanged(object sender, int e)
        {
            _maxText.text = e.ToString();
        }

        private void OnCurrentValueChanged(object sender, int e)
        {
            _currentText.text = e.ToString();
        }
    }
}