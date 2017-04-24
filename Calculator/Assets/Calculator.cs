using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Calculator : MonoBehaviour {

    [SerializeField]
    Text InputField;

    string InputString;
    decimal[] number = new decimal[2];
    string OperatorSymbol;
    int i = 0;
    decimal result;
    bool DisplayResult = false;

    public void ButtonPressed()
    {

        if (DisplayResult == true)
        {
            InputField.text = "";
            DisplayResult = false;
            InputString = "";
        }

        string buttonvalue = EventSystem.current.currentSelectedGameObject.name;
        InputString += buttonvalue;

        int arg;
        if (int.TryParse(buttonvalue,out arg))
        {
            if (i > 1) i = 0;
            number[i] = arg;
            i = i + 1;
        }
        else
        {
            switch (buttonvalue)
            {
                case "+":
                    OperatorSymbol = buttonvalue;
                    break;

                case "-":
                    OperatorSymbol = buttonvalue;
                    break;
                case "*":
                    OperatorSymbol = buttonvalue;
                    break;
                case "/":
                    OperatorSymbol = buttonvalue;
                    break;

                case "C":
                    InputField.text = "";
                    InputString = "";
                    break;

                case "=":
                    switch (OperatorSymbol)
                    {
                        case "+":
                            result = number[0] + number[1];
                            break;
                        case "-":
                            result = number[0] - number[1];
                            break;
                        case "*":
                            result = number[0] * number[1];
                            break;
                        case "/":
                            result = number[0] / number[1];
                            break;
                    }

                    DisplayResult = true;
                    InputString = result.ToString();
                    number = new decimal[2];
                    break;

            }
        }

        InputField.text = InputString;

    }
}
