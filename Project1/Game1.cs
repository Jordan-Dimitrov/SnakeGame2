using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _transform;
        private Rectangle _apple;
        private Texture2D _tex;
        private Texture2D _tex2;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tex = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            _tex2 = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            uint[] data1 = new uint[] { 0xffffff };
            _tex.SetData(data1);
            uint[] data2 = new uint[] { 0xffffff };
            _tex2.SetData(data2);
            _transform = new Rectangle(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2, 30, 30);
            _apple = new Rectangle(100, 100, 20, 20);
            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            Random rndX = new Random();
            int x = rndX.Next(1, Window.ClientBounds.Width);
            Random rndY = new Random();
            int y = rndX.Next(1, Window.ClientBounds.Height);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _transform.Y -= 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _transform.X += 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _transform.Y += 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _transform.X -= 2;
            }
            if (_transform.Intersects(_apple))
            {
                _apple.X = x;
                _apple.Y = y;
                _transform.Height += 10;
                _transform.Width += 10;
            }
            if (_transform.X<=0||_transform.Y<=0)
            {
                Console.Clear();
            }
            if (_transform.X >= Window.ClientBounds.Width || _transform.Y >= Window.ClientBounds.Height)
            {
                Console.Clear();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.GreenYellow);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_tex, _transform, Color.Red);
            _spriteBatch.Draw(_tex2, _apple, Color.Blue);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
