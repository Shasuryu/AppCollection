using CommunityToolkit.Mvvm.ComponentModel;
using System;
using CommunityToolkit.Mvvm.Input;

namespace App.ViewModels;
public partial class BodyCalculatorViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCubeCommand))]
    private string _cubeSide = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCubeCommand))]
    private string _cubeVolume = "";
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCuboidCommand))]
    private string _cuboidSideA = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCuboidCommand))]
    private string _cuboidSideB = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCuboidCommand))]
    private string _cuboidSideC = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCuboidCommand))]
    private string _cuboidVolume = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePyramidCommand))]
    private string _pyramidSideA = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePyramidCommand))]
    private string _pyramidHeight = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePyramidCommand))]
    private string _pyramidVolume = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePrismaCommand))]
    private string _prismaBase = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePrismaCommand))]
    private string _prismaHeight = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculatePrismaCommand))]
    private string _prismaVolume = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCylinderCommand))]
    private string _cylinderRadius = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCylinderCommand))]
    private string _cylinderHeight = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateCylinderCommand))]
    private string _cylinderVolume = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateConeCommand))]
    private string _coneRadius = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateConeCommand))]
    private string _coneHeight = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateConeCommand))]
    private string _coneVolume = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateSphereCommand))]
    private string _sphereHeight = "";
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(CalculateSphereCommand))]
    private string _sphereVolume = "";

    private bool TryParseValue(string value)
    {
        try
        {
            double.Parse(value);
        }
        catch
        {
            return false;
        }
        return true;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateCube))]
    private void CalculateCube()
    {
        if (TryParseValue(_cubeSide) && _cubeVolume == "")
        {
            CubeVolume = Math.Round(double.Parse(_cubeSide) * double.Parse(_cubeSide) * double.Parse(_cubeSide), 2).ToString();
        }
        if (TryParseValue(_cubeVolume) && _cubeSide == "")
        {
            CubeSide = Math.Round(Math.Pow(double.Parse(_cubeVolume), 0.33333333333333333333), 2).ToString();
        }
    }
    private bool CanCalculateCube()
    {
        if (_cubeSide == "" && _cubeVolume != "" || _cubeSide != "" && _cubeVolume == "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateCuboid))]
    private void CalculateCuboid()
    {
        if (_cuboidSideA != "" && _cuboidSideB != "" && _cuboidSideC != "" && _cuboidVolume == "" &&
            TryParseValue(_cuboidSideA) && TryParseValue(_cuboidSideB) && TryParseValue(_cuboidSideC))
        {
            CuboidVolume = Math.Round(double.Parse(_cuboidSideA) * double.Parse(_cuboidSideB) * double.Parse(_cuboidSideC), 2).ToString();
        }
        if (_cuboidSideA != "" && _cuboidSideB != "" && _cuboidSideC == "" && _cuboidVolume != "" &&
            TryParseValue(_cuboidSideA) && TryParseValue(_cuboidSideB) && TryParseValue(_cuboidVolume))
        {
            CuboidSideC = Math.Round(double.Parse(_cuboidVolume) / double.Parse(_cuboidSideA) / double.Parse(_cuboidSideB), 2).ToString();
        }
        if (_cuboidSideA != "" && _cuboidSideB == "" && _cuboidSideC != "" && _cuboidVolume != "" &&
            TryParseValue(_cuboidSideA) && TryParseValue(_cuboidSideC) && TryParseValue(_cuboidVolume))
        {
            CuboidSideB = Math.Round(double.Parse(_cuboidVolume) / double.Parse(_cuboidSideC) / double.Parse(_cuboidSideA), 2).ToString();
        }
        if (_cuboidSideA == "" && _cuboidSideB != "" && _cuboidSideC != "" && _cuboidVolume != "" &&
            TryParseValue(_cuboidSideB) && TryParseValue(_cuboidSideC) && TryParseValue(_cuboidVolume))
        {
            CuboidSideA = Math.Round(double.Parse(_cuboidVolume) / double.Parse(_cuboidSideB) / double.Parse(_cuboidSideC), 2).ToString();
        }
    }
    private bool CanCalculateCuboid()
    {
        if (_cuboidSideA != "" && _cuboidSideB != "" && _cuboidSideC != "" && _cuboidVolume == "" ||
            _cuboidSideA != "" && _cuboidSideB != "" && _cuboidSideC == "" && _cuboidVolume != "" ||
            _cuboidSideA != "" && _cuboidSideB == "" && _cuboidSideC != "" && _cuboidVolume != "" ||
            _cuboidSideA == "" && _cuboidSideB != "" && _cuboidSideC != "" && _cuboidVolume != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculatePyramid))]
    private void CalculatePyramid()
    {
        if (_pyramidSideA != "" && _pyramidHeight != "" && _pyramidVolume == "" &&
            TryParseValue(_pyramidSideA) && TryParseValue(_pyramidHeight))
        {
            PyramidVolume = Math.Round(0.3333333333 * double.Parse(_pyramidSideA) * double.Parse(_pyramidSideA) * double.Parse(_pyramidHeight), 2).ToString();
        }
        if (_pyramidSideA != "" && _pyramidHeight == "" && _pyramidVolume != "" &&
            TryParseValue(_pyramidSideA) && TryParseValue(_pyramidVolume))
        {
            PyramidHeight = Math.Round(double.Parse(_pyramidVolume) / 0.3333333333 / double.Parse(_pyramidSideA) / double.Parse(_pyramidSideA), 2).ToString();
        }
        if (_pyramidSideA == "" && _pyramidHeight != "" && _pyramidVolume != "" &&
            TryParseValue(_pyramidHeight) && TryParseValue(_pyramidVolume))
        {
            PyramidSideA = Math.Round(Math.Pow(double.Parse(_pyramidVolume) / 0.3333333333 / double.Parse(_pyramidHeight), 0.5), 2).ToString();
        }
    }
    private bool CanCalculatePyramid()
    {
        if (_pyramidSideA != "" && _pyramidHeight != "" && _pyramidVolume == "" ||
            _pyramidSideA != "" && _pyramidHeight == "" && _pyramidVolume != "" ||
            _pyramidSideA == "" && _pyramidHeight != "" && _pyramidVolume != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculatePrisma))]
    private void CalculatePrisma()
    {
        if (_prismaBase != "" && _prismaHeight != "" && _prismaVolume == "" &&
            TryParseValue(_pyramidSideA) && TryParseValue(_prismaHeight))
        {
            PrismaVolume = Math.Round(double.Parse(_prismaBase) * double.Parse(_prismaHeight), 2).ToString();
        }
        if (_prismaBase != "" && _prismaHeight == "" && _prismaVolume != "" &&
            TryParseValue(_prismaBase) && TryParseValue(_prismaVolume))
        {
            PrismaHeight = Math.Round(double.Parse(_prismaVolume) / double.Parse(_prismaBase), 2).ToString();
        }
        if (_prismaBase == "" && _prismaHeight != "" && _prismaVolume != "" &&
            TryParseValue(_prismaHeight) && TryParseValue(_prismaVolume))
        {
            PrismaBase = Math.Round(double.Parse(_prismaVolume) / double.Parse(_prismaHeight), 2).ToString();
        }
    }
    private bool CanCalculatePrisma()
    {
        if (_prismaBase != "" && _prismaHeight != "" && _prismaVolume == "" ||
            _prismaBase != "" && _prismaHeight == "" && _prismaVolume != "" ||
            _prismaBase == "" && _prismaHeight != "" && _prismaVolume != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateCylinder))]
    private void CalculateCylinder()
    {
        if (_cylinderRadius != "" && _cylinderHeight != "" && _cylinderVolume == "" &&
            TryParseValue(_cylinderRadius) && TryParseValue(_cylinderHeight))
        {
            CylinderVolume = Math.Round(Math.PI * double.Parse(_cylinderRadius) * double.Parse(_cylinderRadius) * double.Parse(_cylinderHeight), 2).ToString();
        }
        if (_cylinderRadius != "" && _cylinderHeight == "" && _cylinderVolume != "" &&
            TryParseValue(_cylinderRadius) && TryParseValue(_cylinderVolume))
        {
            CylinderHeight = Math.Round(double.Parse(_cylinderVolume) / (Math.PI * double.Parse(_cylinderRadius) * double.Parse(_cylinderRadius)), 2).ToString();
        }
        if (_cylinderRadius == "" && _cylinderHeight != "" && _cylinderVolume != "" &&
            TryParseValue(_cylinderHeight) && TryParseValue(_cylinderVolume))
        {
            CylinderRadius = Math.Round(Math.Pow(double.Parse(_cylinderVolume) / (Math.PI * double.Parse(_cylinderHeight)), 0.5), 2).ToString();
        }
    }
    private bool CanCalculateCylinder()
    {
        if (_cylinderRadius != "" && _cylinderHeight != "" && _cylinderVolume == "" ||
            _cylinderRadius != "" && _cylinderHeight == "" && _cylinderVolume != "" ||
            _cylinderRadius == "" && _cylinderHeight != "" && _cylinderVolume != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateCone))]
    private void CalculateCone()
    {
        if (_coneRadius != "" && _coneHeight != "" && _coneVolume == "" &&
            TryParseValue(_coneRadius) && TryParseValue(_coneHeight))
        {
            ConeVolume = Math.Round(0.33333333 * (Math.PI * double.Parse(_coneRadius) * double.Parse(_coneRadius) * double.Parse(_coneHeight)), 2).ToString();
        }
        if (_coneRadius != "" && _coneHeight == "" && _coneVolume != "" &&
            TryParseValue(_coneRadius) && TryParseValue(_coneVolume))
        {
            ConeHeight = Math.Round((double.Parse(_coneVolume) * 3) / (double.Parse(_coneRadius) * double.Parse(_coneRadius) * Math.PI), 2).ToString();
        }
        if (_coneRadius == "" && _coneHeight != "" && _coneVolume != "" &&
            TryParseValue(_coneHeight) && TryParseValue(_coneVolume))
        {
            ConeRadius = Math.Round(Math.Pow((double.Parse(_coneVolume) * 3) / (double.Parse(_coneHeight) * Math.PI), 0.5), 2).ToString();
        }
    }
    private bool CanCalculateCone()
    {
        if (_coneRadius != "" && _coneHeight != "" && _coneVolume == "" ||
            _coneRadius != "" && _coneHeight == "" && _coneVolume != "" ||
            _coneRadius == "" && _coneHeight != "" && _coneVolume != "")
        {
            return true;
        }
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanCalculateSphere))]
    private void CalculateSphere()
    {
        if (TryParseValue(_sphereHeight) && _sphereVolume == "")
        {
            SphereVolume = Math.Round(1.333333333 * Math.PI * Math.Pow(double.Parse(_sphereHeight), 3), 2).ToString();
        }
        if (TryParseValue(_sphereVolume) && _sphereHeight == "")
        {
            SphereHeight = Math.Round(Math.Pow((3 * double.Parse(_sphereVolume)) / (4 * Math.PI), 0.333333333), 2).ToString();
        }
    }
    private bool CanCalculateSphere()
    {
        if (_sphereHeight == "" && _sphereVolume != "" || _sphereHeight != "" && _sphereVolume == "")
        {
            return true;
        }
        return false;
    }
}