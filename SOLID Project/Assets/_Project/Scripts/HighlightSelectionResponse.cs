using UnityEngine;
class HighlightSelectionResponse: MonoBehaviour, ISelectionResponse {
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    public void OnSelect(Transform selection) {
        if(selection != null) {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null) {
                selectionRenderer.material = highlightMaterial;
            }
        }
    }
    public void OnDeselect(Transform selection) {
        if(selection != null) {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null) {
                selectionRenderer.material = defaultMaterial;
            }
        }
    }
}