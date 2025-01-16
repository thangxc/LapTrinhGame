using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class ButtonController : Singleton<ButtonController>
{
    public List<Button> targetButton; // Reference to the button
    public Color activeColor = Color.red; // Color to change to
    public Color inactiveColor = Color.white; // Color to change to
    public void BackToMenu()
    {

    }
    public void Retry()
    {

    }
    public void Hint()
    {

    }
    public void Sheep1Selected()
    {
        SheepHandler.Instance.SwitchSheep(0);
    }
    public void Sheep2Selected()
    {
        SheepHandler.Instance.SwitchSheep(1);
    }
    public void Sheep3Selected()
    {
        SheepHandler.Instance.SwitchSheep(2);
    }
    public void ButtonSheepColor(int buttonNumber)
    {
        SetActiveButton(buttonNumber);
    }
    private void Start()
    {

        // Set the initial state (first button active by default)
        SetActiveButton(0);

    }

    public void SetActiveButton(int activeIndex)
    {
        // Loop through all buttons
        for (int i = 0; i < targetButton.Count; i++)
        {
            // Change the color of the button
            Image buttonImage = targetButton[i].GetComponent<Image>();

            if (buttonImage != null)
            {
                buttonImage.color = (i == activeIndex) ? activeColor : inactiveColor;
            }
        }
    }

}
