using UnityEngine;
using UnityEngine.EventSystems;

public class ModelButton : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private CharacterSelection characterSelection;
    [SerializeField] private GameObject characterPrefab; // Assign boyPrefab/girlPrefab in Inspector
    private CharacterPreviewRotator rotator;

    void Start()
    {
        // Auto-get references if not set in Inspector
        if (rotator == null) rotator = GetComponent<CharacterPreviewRotator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        characterSelection.SelectCharacter(characterPrefab);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Speed up rotation
        if (rotator != null) rotator.OnHoverEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset rotation spee
        if (rotator != null) rotator.OnHoverExit();
    }
}
