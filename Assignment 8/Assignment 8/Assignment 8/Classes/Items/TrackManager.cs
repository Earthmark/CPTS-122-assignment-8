using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Assignment_8
{
    class TrackManager
    {
        //contains all the pieces of track in a list, need to make the track piece class first
        Vector2 TrackPosition;
        Texture2D texture;

        public TrackManager()
        {
            TrackPosition = new Vector2(0, 0);
        }

        public void loadTrack1()
        {
            texture = Engine.Game.Content.Load<Texture2D>("Tracks/RaceTrack1");
        }

        public void drawTrack()
        {
            Rectangle trackRectangle = new Rectangle(0, 0, 600, 600);
            Engine.SpriteBatch.Draw(texture, trackRectangle, Color.White);
        }
    }
}
