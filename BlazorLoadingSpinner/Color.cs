namespace BlazorLoadingSpinner;

/// <summary>
/// Represent CSS colour in C#
/// </summary>
public readonly struct Color
{
    /// <summary>
    /// Red channel of the color
    /// </summary>
    public byte R { get; }

    /// <summary>
    /// Green channel of the color
    /// </summary>
    public byte G { get; }

    /// <summary>
    /// Blue channel of the color
    /// </summary>
    public byte B { get; }

    /// <summary>
    /// Alpha channel of the color
    /// </summary>
    public double A { get; }

    /// <summary>
    /// Create color object from RGBA value
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <param name="a"></param>
    public Color(byte r, byte g, byte b, double a = 1.0)
    {
        R = r;
        G = g;
        B = b;
        A = Math.Clamp(a, 0.0, 1.0);
    }

    /// <summary>
    /// Create color object from CSS hex string
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Invalid hex expression</exception>
    public static Color FromHex(string hex)
    {
        hex = hex.TrimStart('#');

        if (hex.Length == 3) // #RGB
        {
            hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}";
        }
        else if (hex.Length == 4) // #RGBA
        {
            hex = $"{hex[0]}{hex[0]}{hex[1]}{hex[1]}{hex[2]}{hex[2]}{hex[3]}{hex[3]}";
        }

        if (hex.Length == 6) // #RRGGBB
        {
            return new Color(
                Convert.ToByte(hex[..2], 16),
                Convert.ToByte(hex[2..4], 16),
                Convert.ToByte(hex[4..6], 16)
            );
        }
        else if (hex.Length == 8) // #RRGGBBAA
        {
            return new Color(
                Convert.ToByte(hex[..2], 16),
                Convert.ToByte(hex[2..4], 16),
                Convert.ToByte(hex[4..6], 16),
                Convert.ToByte(hex[6..8], 16) / 255.0
            );
        }
        else
        {
            throw new ArgumentException("Invalid hex color format", nameof(hex));
        }
    }

    /// <summary>
    /// Create color object equivalent to rgba(255, 0, 0, 1)
    /// </summary>
    public static readonly Color Red = new(255, 0, 0);

    /// <summary>
    /// Create color object equivalent to rgba(0, 255, 0, 1)
    /// </summary>
    public static readonly Color Green = new(0, 255, 0);

    /// <summary>
    /// Create color object equivalent to rgba(0, 0, 255, 1)
    /// </summary>
    public static readonly Color Blue = new(0, 0, 255);

    /// <summary>
    /// Create color object equivalent to rgba(255, 255, 255, 1)
    /// </summary>
    public static readonly Color White = new(255, 255, 255);

    /// <summary>
    /// Create color object equivalent to rgba(0, 0, 0, 0)
    /// </summary>
    public static readonly Color Transparent = new(0, 0, 0, 0);

    /// <summary>
    /// Generate CSS color string in rgba format
    /// </summary>
    /// <returns></returns>
    public override readonly string ToString() => $"rgba({R}, {G}, {B}, {A})";
}
