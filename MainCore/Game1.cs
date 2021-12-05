using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using easy2code_game.Managers;

namespace easy2code_game.MainCore
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private GameStateManager gsm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Data.ScreenWidth;
            graphics.PreferredBackBufferHeight = Data.ScreenHeight;
            graphics.ApplyChanges();
            gsm = new GameStateManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gsm.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            gsm.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            gsm.Draw(_spriteBatch);
            base.Draw(gameTime);
        }
    }
}
