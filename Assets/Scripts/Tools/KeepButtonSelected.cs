using UnityEngine;
using UnityEngine.EventSystems;

public class KeepButtonSelected : MonoBehaviour, IPointerClickHandler
{
    private EventSystem eventSystem;

    void Start()
    {
        eventSystem = EventSystem.current;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Если другой объект выбран, возвращаем фокус на эту кнопку
        if (eventSystem.currentSelectedGameObject != gameObject)
        {
            eventSystem.SetSelectedGameObject(gameObject);
        }
    }
}