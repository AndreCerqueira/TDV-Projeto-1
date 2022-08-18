using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace rpg
{
    internal class Enemy
    {
        public static List<Enemy> enemies = new List<Enemy>();

        private Vector2 position = new Vector2(0, 0);
        private int speed = 150;
        public SpriteAnimation anim;

        public Enemy(Vector2 newPos, Texture2D spriteSheet)
        {
            position = newPos;
            anim = new SpriteAnimation(spriteSheet, 10, 6);
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void Update(GameTime gameTime)
        {
            anim.Update(gameTime);
        }
    }
}
