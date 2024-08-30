using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// A Collection of extension/utility methods for Unity's Button type
/// </summary>
public static class ButtonExt { 

    /// <summary>
    /// Sets the navigation on the buttons on the vertical axis.
    /// </summary>
    /// <param name="buttons">A list of vertically positioned buttons in order from top to bottom</param>
    public static void SetupVerticalNavigation(this List<Button> buttons) {
        for(int i = 0; i < buttons.Count; i++) {
            Navigation nav = new Navigation();
            nav.mode = Navigation.Mode.Explicit;
            //Up
            if(i != 0) {
                nav.selectOnUp = buttons[i-1];
            }
            //Down
            if(i != buttons.Count - 1) {
                nav.selectOnDown = buttons[i + 1];
            }

            buttons[i].navigation = nav;
        }
    }

    /// <summary>
    /// Sets the navigation on the buttons on the horizontal axis.
    /// </summary>
    /// <param name="buttons">A list of horizontally positioned buttons in order from left to right</param>
    public static void SetupHorizontalNavigation(this List<Button> buttons) {
        for(int i = 0; i < buttons.Count; i++) {
            Navigation nav = new Navigation();
            nav.mode = Navigation.Mode.Explicit;
            //Left
            if(i != 0) {
                nav.selectOnLeft = buttons[i - 1];
            }
            //Right
            if(i != buttons.Count - 1) {
                nav.selectOnRight = buttons[i + 1];
            }

            buttons[i].navigation = nav;
        }
    }

    /// <summary>
    /// Set which Selectable is navigated to when this button receives 'down' input.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="onDownSelectable"></param>
    public static void SetDownNavigation(this Button button, Selectable onDownSelectable) {
        Navigation nav = button.navigation;
        nav.selectOnDown = onDownSelectable;
        button.navigation = nav;
    }

    /// <summary>
    /// Set which Selectable is navigated to when this button receives 'up' input.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="onUpSelectable"></param>
    public static void SetUpNavigation(this Button button, Selectable onUpSelectable) {
        Navigation nav = button.navigation;
        nav.selectOnUp = onUpSelectable;
        button.navigation = nav;
    }

    /// <summary>
    /// Gets the event trigger for the button. If none exists it will add one and return that.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public static EventTrigger GetOrAddEventTrigger(this Button button) {
        EventTrigger trigger = button.GetComponent<EventTrigger>();
        if (trigger) {
            return trigger;
        } else {
            return button.gameObject.AddComponent<EventTrigger>();
        }
    }

    /// <summary>
    /// Adds an action to occur when this button is selected. If the button does not currently have an EventTrigger one will be added.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="action"></param>
    public static void DoOnSelect(this Button button, UnityAction<BaseEventData> action) {
        EventTrigger trigger = button.GetOrAddEventTrigger();
        trigger.DoOnSelect(action);
    }
    /// <summary>
    /// Adds an action to occur when this button is deselected. If the button does not currently have an EventTrigger one will be added.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="action"></param>
    public static void DoOnDeselect(this Button button, UnityAction<BaseEventData> action) {
        EventTrigger trigger = button.GetOrAddEventTrigger();
        trigger.DoOnDeselect(action);
    }
}