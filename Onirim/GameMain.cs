using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Onirim.Command;
using Onirim.ContentManagers;
using Onirim.Manager;

namespace Onirim
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StateManager _stateManager;
        private RenderManager _drawManager;
        private InputManager _inputManager;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;//GraphicsDevice.DisplayMode.Width / 2;
            _graphics.PreferredBackBufferHeight = 1000;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            _stateManager = new StateManager();
            _stateManager.ExecuteCommand(new Shuffle());
            _stateManager.ExecuteCommand(new DrawLocations());

            _drawManager = new RenderManager(_spriteBatch, _stateManager);

            _inputManager = new InputManager(_stateManager);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ArtManager.InitializeGraphcis(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();  // get the newest state

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _inputManager.HandleInput(Keyboard.GetState(), Mouse.GetState());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _drawManager.Draw(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Draw(gameTime);
        }
    }
}
