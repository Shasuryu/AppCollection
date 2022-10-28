using CommunityToolkit.Mvvm.ComponentModel;
using Ken.FormsBook.ToolkitExt;
using System;
using System.Drawing;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Color = Xamarin.Forms.Color;
using Image = Xamarin.Forms.Image;

namespace App.ViewModels;
internal class PngFadeViewModel : ObservableObject
{
    private int _alpha1;
    private int _red1;
    private int _green1;
    private int _blue1;
    private int _alpha2;
    private int _red2;
    private int _green2;
    private int _blue2;

    private Image _image;

    public int Alpha1
    {
        get => _alpha1;
        set
        {
            _alpha1 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Red1
    {
        get => _red1;
        set
        {
            _red1 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Green1
    {
        get => _green1;
        set
        {
            _green1 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Blue1
    {
        get => _blue1;
        set
        {
            _blue1 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Alpha2
    {
        get => _alpha2;
        set
        {
            _alpha2 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Red2
    {
        get => _red2;
        set
        {
            _red2 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Green2
    {
        get => _green2;
        set
        {
            _green2 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }
    public int Blue2
    {
        get => _blue2;
        set
        {
            _blue2 = value;
            UpdatePicture();
            OnPropertyChanged();
        }
    }

    public Image Image
    {
        get => _image;
        set
        {
            _image = value;
            OnPropertyChanged();
        }
    }

    private void UpdatePicture()
    {
        Image.Source = ImageSource.FromResource("Fade.png");
        Bitmap pic = new Bitmap(1024, 1024);

        pic = Fade(pic, new FadeColor(_alpha1, _red1, _green1, _blue1), new FadeColor(_alpha2, _red2, _green2, _blue2));

        pic.Save("Fade.png");
    }

    private Bitmap Fade(Bitmap pic, FadeColor fadeFrom, FadeColor fadeTo)
    {
        int totalPixel = 0;

        int alphaPixel = 1;
        int redPixel = 1;
        int greenPixel = 1;
        int bluePixel = 1;

        for (int i = 0; i < pic.Width; i++)
        {
            for (int j = 0; j < pic.Height; j++)
            {
                FadeColor pixel = new FadeColor();

                if (fadeFrom.A < fadeTo.A)
                {
                    double result = 1024 / fadeTo.A - fadeFrom.A;
                    alphaPixel = (int)Math.Round(result);
                }
                else
                {
                    alphaPixel = 1024 / fadeFrom.A - fadeTo.A;
                }
                if (alphaPixel % 8 == 0 && fadeFrom.A < fadeTo.A)
                {
                    pixel.A = fadeFrom.A + 1;
                }
                else
                {
                    pixel.A = fadeFrom.A - 1;
                }
                pic.SetPixel(j, i, Color.FromRgba(pixel.R, pixel.G, pixel.B, pixel.A));

                totalPixel++;
            }
        }
        return pic;
    }
}

public struct FadeColor
{
    public int A;
    public int R;
    public int G;
    public int B;

    public FadeColor(int a, int r, int g, int b)
    {
        A = a;
        R = r;
        G = g;
        B = b;
    }
}