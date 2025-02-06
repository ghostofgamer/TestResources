using TMPro;
using UnityEngine;

namespace StorageTableContent
{
    public class StorageTableViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private StorageTable _storageTable;

        private void OnEnable()
        {
            _storageTable.ValueChanged += Show;
        }

        private void OnDisable()
        {
            _storageTable.ValueChanged -= Show;
        }

        private void Start()
        {
            Show();
        }

        private void Show()
        {
            _text.text = _storageTable.ValueResource.ToString();
        }
    }
}