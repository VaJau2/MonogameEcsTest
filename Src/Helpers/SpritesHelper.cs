// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.Xna.Framework.Graphics;
// using MonoGame.Extended.Sprites;
//
// namespace MonoEcsTest.Helpers;
//
// public class SpritesHelper
// {
//     public enum SpriteVariant
//     {
//         Skeleton
//     }
//     
//     private static SpritesHelper instance;
//
//     public static SpritesHelper GetInstance
//     {
//         get
//         {
//             if (instance == null)
//             {
//                 
//             }
//             return instance;
//         }
//     }
//     
//     private SpritesHelper()
//     {
//         foreach (var sprite in EnumUtil.GetValues<SpriteVariant>())
//         {
//             content.Load<Texture2D>("sprites/skeleton")
//         }
//     }
//
//     
//
//     private Dictionary<SpriteVariant, Texture2D> textures;
//
//     public Sprite Get(SpriteVariant variant)
//     {
//         return textures.TryGetValue(variant, out var texture) ? new Sprite(texture) : null;
//     }
// }