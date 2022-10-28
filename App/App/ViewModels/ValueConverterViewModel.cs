using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Essentials;

namespace App.ViewModels;

public partial class ValueConverterViewModel : ObservableObject
{
    [ObservableProperty] 
    private int _integerValue;
    [ObservableProperty]
    private string _hexaValue = "";
    [ObservableProperty]
    private string _binaryValue = "";

    [RelayCommand(CanExecute = nameof(CanCalculate))]
    private void Calculate()
    {
        if (_hexaValue == "" && _binaryValue == "")
        {
            HexaValue = HexConverter.ConvertToHex(_integerValue);
            BinaryValue = BinConverter.ConvertToBin(_integerValue);
        }
        if (_hexaValue != "" && _binaryValue == "")
        {
            IntegerValue = IntConverter.ConvertToInt(_hexaValue, "hex");
            BinaryValue = BinConverter.ConvertToBin(_integerValue);
        }
        if (_hexaValue == "" && _binaryValue != "")
        {
            IntegerValue = IntConverter.ConvertToInt(_binaryValue, "bin");
            HexaValue = HexConverter.ConvertToHex(_integerValue);
        }
    }

    private bool CanCalculate()
    {
        return true;
    }
}

public class IntConverter
{
    public static int ConvertToInt(string x, string value)
    {
        string newX = x;
        int integer = 0;
        if (value == "hex")
        {
            if (x.Contains("x"))
            {
                newX = x.Remove(0, 2);
            }
            integer = int.Parse(x, System.Globalization.NumberStyles.HexNumber);
        }
        if (value == "bin")
        {
            if (x.Contains("b"))
            {
                newX = x.Remove(0, 2);
            }
            integer = Convert.ToInt32(newX, 2);
        }
        return integer;
    }
}

public class BinConverter
{
    public static string ConvertToBin(int x)
    {
        int i = x;
        string bin = "";
        int lengthCounter = 0;

        while (i != 0)
        {
            i = x / 2;
            bin = AppendBin(x, bin);
            lengthCounter++;
            x = x / 2;
            if (lengthCounter == 8)
            {
                lengthCounter = 0;
                bin = " " + bin;
            }
        }
        for (int wwww = lengthCounter; wwww < 8; wwww++)
        {
            bin = "0" + bin;
        }
        return "0b" + bin;
    }

    private static string AppendBin(int x, string bin)
    {
        return (x % 2) + bin;
    }
}

public class HexConverter
{
    public static string ConvertToHex(int x)
    {
        int i = x;
        string hex = "";

        while (i != 0)
        {
            i = x / 16;
            hex = AppendHex(x, hex);
            x = x / 16;
        }
        return "0x" + hex;
    }

    private static string AppendHex(int x, string hex)
    {
        x = x % 16;
        switch (x)
        {
            case 0:
                return "0" + hex;
            case 1:
                return "1" + hex;
            case 2:
                return "2" + hex;
            case 3:
                return "3" + hex;
            case 4:
                return "4" + hex;
            case 5:
                return "5" + hex;
            case 6:
                return "6" + hex;
            case 7:
                return "7" + hex;
            case 8:
                return "8" + hex;
            case 9:
                return "9" + hex;
            case 10:
                return "A" + hex;
            case 11:
                return "B" + hex;
            case 12:
                return "C" + hex;
            case 13:
                return "D" + hex;
            case 14:
                return "E" + hex;
            case 15:
                return "F" + hex;
            default:
                return hex;
        }
    }
}