// See https://aka.ms/new-console-template for more information
using Ez.Numerics;
using System.Drawing;
using static Ez.Numerics.EzMath;

var bitmap = new Bitmap(1920, 1080);
var max = float.MinValue;
var min = float.MaxValue;
var factor = 1f / 128;
for(var x = 0; x < bitmap.Width; x++)
    for(var y = 0; y < bitmap.Height; y++)
    {
        var i = x * factor;
        var j = y * factor;
        var n1 = Perlin.Noise(i, j);

        var v = Remap(n1, -1, 1, 0, 1);

        //var v1 = Clamp(n1 / n2, -1, 1);
        //var v2 = Clamp(n2 / n3, -1, 1);
        //var v3 = Clamp(n1 / n3, -1, 1);

        //var v = Remap(v1 + v2 + v3, -3, 3, 0, 1);

        //var value = PerlinNoise.Noise(x / 16f, y / 16f);
        //max = MathF.Max(max, value);
        //min = MathF.Min(min, value);
        //var bValue = ToByteColor(value);
        //var c = ((int)(value * ((1 << 24) - 1))) | (0xFF << 24);
        ////bitmap.SetPixel(x, y, Color.FromArgb(bValue, bValue, bValue));
        //bitmap.SetPixel(x, y, Color.FromArgb(c));
        bitmap.SetPixel(x, y, Color.FromArgb(ToByteColor(v), ToByteColor(v), ToByteColor(v)));
    }

Console.WriteLine($"min: {min}, max: {max}");
bitmap.Save("perlinNoise.bmp");

byte ToByteColor(float v)
{
    return (byte)(v * 255f);
}