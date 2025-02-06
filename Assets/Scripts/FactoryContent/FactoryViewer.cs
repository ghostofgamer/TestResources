using System;
using Enums;
using TMPro;
using UnityEngine;

namespace FactoryContent
{
    public class FactoryViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _metalValueText;
        [SerializeField] private TMP_Text _woodValueText;
        [SerializeField] private TMP_Text _stoneValueText;
        [SerializeField]private Factory _factory;

        private void OnEnable()
        {
            _factory.ResourceCreated += Show;
        }

        private void OnDisable()
        {
            _factory.ResourceCreated -= Show;
        }

        private void Start()
        {
            Show();
        }
        
        private void Show()
        {
            _metalValueText.text = _factory.MetalValue.ToString();
            _stoneValueText.text = _factory.StoneValue.ToString();
            _woodValueText.text = _factory.WoodValue.ToString();
            
            // Debug.Log("Show");
        }
    }
}