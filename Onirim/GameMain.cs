using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Onirim.Command;
using Onirim.Common;
using Onirim.ContentManagers;
using Onirim.States;

namespace Onirim
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private StateManager _stateManager;

        private KeyboardState _previousKeyboardState;
        private MouseState _previousMouseState;

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            _stateManager = new StateManager();
            _stateManager.Initialize(new MainGameState());
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ArtManager.InitializeGraphics(Content, GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            var currentKeyboardState = Keyboard.GetState();
            var currentMouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _stateManager.CurrentState.Update(new InputState
            {
                CurrentKeyboardState = currentKeyboardState,
                CurrentMouseState = currentMouseState,
                PreviousKeyboardState = _previousKeyboardState,
                PreviousMouseState = _previousMouseState
            });

            _previousKeyboardState = currentKeyboardState;
            _previousMouseState = currentMouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _stateManager.CurrentState.Draw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Draw(gameTime);
        }
    }
}
