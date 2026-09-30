using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lecture4
{
    public enum Art
    {
        Turtle,
        Rabbit,
        Pixel,
        Hammer,
        Violin
    }
    public class AssetManager
    {

        Dictionary<Art, Texture2D> textures;


        public SpriteFont font;

        public AssetManager(ContentManager content)
        {
            Services.AssetManager = this;
            LoadContent(content);
        }
        void LoadContent(ContentManager content)
        {
            textures = new Dictionary<Art, Texture2D>();
            foreach (Art art in Enum.GetValues(typeof(Art)))
            {
                string art_name = Enum.GetName(typeof(Art), art);
                Texture2D texture = content.Load<Texture2D>(art_name);
                textures.Add(art, texture);
            }

            font = content.Load<SpriteFont>("Font");
        }
        public Texture2D GetTexture(Art name)
        {
            return textures[name];
        }
    }
}
