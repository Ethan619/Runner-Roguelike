using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// A Collection of extension/utility methods for Unity's EventTrigger type
/// </summary>
public static class EventTriggerExt {

    /// <summary>
    /// Adds a 'Select' action to this EventTrigger
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="action"></param>
    public static void DoOnSelect(this EventTrigger trigger, UnityAction<BaseEventData> action) {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Select;
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }

    /// <summary>
    /// Adds a 'Deselect' action to this EventTrigger
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="action"></param>
    public static void DoOnDeselect(this EventTrigger trigger, UnityAction<BaseEventData> action) {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Deselect;
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }

}