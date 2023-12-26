using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoEcsTest.Characters.Destroying;

public class Target
{
    public static readonly Dictionary<float, Color> LIVING_COLORS = new()
    {
        { 0, Color.Green },
        { 1f, Color.Lime },
        { 1.5f, Color.Chartreuse },
        { 2f, Color.LawnGreen },
        { 2.5f, Color.SpringGreen },
        { 3f, Color.Aquamarine },
        { 4f, Color.White }
    };

    public float livingTime;
}