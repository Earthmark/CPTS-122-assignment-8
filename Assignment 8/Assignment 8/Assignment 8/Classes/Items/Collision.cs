using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Assignment_8
{
    //public enum Collision { CarToCar, CarOffRoad }

    public class Collision
    {
        public static Collision CDPerformedWith { get; set; }

        public static bool CarToCar(Car car1, Car car2)
        {
            Rectangle rectangleA = new Rectangle((int)car1.position.X, (int)car1.position.Y, car1.width, car1.height);
            Rectangle rectangleB = new Rectangle((int)car2.position.Y, (int)car2.position.Y, car2.width, car2.width);
            
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            if (top >= bottom || left >= right)
                return false;

            return true;
        }
        public static bool PerPixel(Texture2D Texture1, Texture2D Texture2, Vector2 Pos1, Vector2 Pos2)
        {
            Rectangle Rectangle1 = new Rectangle((int)Pos1.X, (int)Pos1.Y, Texture1.Width, Texture1.Height);
            Rectangle Rectangle2 = new Rectangle((int)Pos2.X, (int)Pos2.Y, Texture2.Width, Texture2.Height);

            if (!CarToCar(Rectangle1.X, Rectangle1.Y, Rectangle1.Width, Rectangle1.Height,
                                  Rectangle2.X, Rectangle2.Y, Rectangle2.Width, Rectangle2.Height))
                return false;

            // Bounding rectangles collide beyond this point so we need to check
            // a per-pixel collision

            Color[] TextureData1 = new Color[Texture1.Width * Texture1.Height];
            Texture1.GetData(TextureData1);

            Color[] TextureData2 = new Color[Texture2.Width * Texture2.Height];
            Texture2.GetData(TextureData2);

            int top = Math.Max(Rectangle1.Top, Rectangle2.Top);
            int bottom = Math.Min(Rectangle1.Bottom, Rectangle2.Bottom);
            int left = Math.Max(Rectangle1.Left, Rectangle2.Left);
            int right = Math.Min(Rectangle1.Right, Rectangle2.Right);

            for (int y = top; y < bottom; y++)
                for (int x = left; x < right; x++)
                {
                    Color colorA = TextureData1[(x - Rectangle1.Left) + (y - Rectangle1.Top) * Rectangle1.Width];
                    Color colorB = TextureData2[(x - Rectangle2.Left) + (y - Rectangle2.Top) * Rectangle2.Width];
                    if (colorA.A != 0 && colorB.A != 0) return true;
                }
            return false;
        }
        public static bool CarIsOnRoad(Vector2 PositionCar, Texture2D TextureCar, Texture2D TextureRoad)
        {
            Rectangle RectangleCar = new Rectangle((int)PositionCar.X, (int)PositionCar.Y, TextureCar.Width, TextureCar.Height);

            Color[] TextureDataRoad = new Color[TextureRoad.Width * TextureRoad.Height];
            TextureRoad.GetData(TextureDataRoad);

            for (int i = RectangleCar.Top; i < RectangleCar.Bottom; i++)
                for (int j = RectangleCar.Left; j < RectangleCar.Right; j++)
                    if (TextureDataRoad[i * TextureRoad.Width + j] != Color.Gray) //Gray for now
                        return false;

            return true;
        }
    }
}
