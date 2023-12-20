using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoEcsTest.Characters.Destroying;

public class Target
{
    public static readonly Dictionary<float, Color> LIVING_COLORS = new()
    {
        { 0, Color.Green },
        { 1f, Color.Lime },
        { 2f, Color.Chartreuse },
        { 3f, Color.LawnGreen },
        { 4f, Color.SpringGreen },
        { 5f, Color.Aquamarine },
        { 6f, Color.White }
    };

    public float livingTime;
}