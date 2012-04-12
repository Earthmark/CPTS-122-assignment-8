using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Assignment_8
{
    public static class Engine
    {
        /// <summary>
        /// Was given to me to solve some graphics issues,
        /// allows textures to be added on the fly along with each class having its own draw function.
        /// Also load content is essentially useless, so you don't have to use it if you don't want to.
        /// </summary>
        static Game game;
        static GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;

        public static Game Game
        {
            get { return game; }
        }
        public static GraphicsDeviceManager Graphics
        {
            get { return graphics; }
        }
        public static SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
        }
        public static void Initialize(Game pGame, GraphicsDeviceManager pGraphics)
        {
            game = pGame;
            graphics = pGraphics;

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
        }
        //public static T FindComponent<T>()
        //{
        //    return game.Components.OfType<T>().First();
        //}
    }
}