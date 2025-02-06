using TMPro;
using UnityEngine;

namespace FactoryContent
{
    public class FactoryViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _metalValueText;
        [SerializeField] private TMP_Text _woodValueText;
        [SerializeField] private TMP_Text _stoneValueText;
        [SerializeField]private StorageFactory _factoryStorage;

        private void OnEnable()
        {
            _factoryStorage.ResourceAdded += Show; 
        }

        private void OnDisable()
        {
            _factoryStorage.ResourceAdded += Show;
        }

        private void Start()
        {
            Show();
        }
        
        private void Show()
        {
            _metalValueText.text = _factoryStorage.MetalValue.ToString();
            _stoneValueText.text = _factoryStorage.StoneValue.ToString();
            _woodValueText.text = _factoryStorage.WoodValue.ToString();
        }
    }
}