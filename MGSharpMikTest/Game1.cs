using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpMik;
using SharpMik.Player;
using SharpMikXNA.Drivers;
using System;
using System.Diagnostics;
using System.Text;

namespace SharpMikMGTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        StringBuilder m_sb = new StringBuilder(256);

        MikMod m_Player;
        Module m_Mod = null;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Initialize mod player
            m_Player = new MikMod();
            try
            {
                m_Player.Init<XNADriver>("");
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }

            //Load Module
	    //m_Mod = m_Player.LoadModule(TitleContainer.OpenStream ("Content\\Stardust.MOD"));

            //Start playing...
            //if (m_Mod!=null)
              //  m_Player.Play(m_Mod);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Debug");

            m_Mod = Content.Load<Module> ("Stardust");
            m_Player.Play (m_Mod);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
			var kbs = Keyboard.GetState ();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kbs.IsKeyDown(Keys.Escape))
                Exit();

			if (kbs.IsKeyDown (Keys.Left))
				m_Player.SetPosition (m_Mod.sngpos - 2);
			if (kbs.IsKeyDown (Keys.Right))
				m_Player.SetPosition (m_Mod.sngpos + 2);

            // TODO: Add your update logic here

            //Garbage
            int G0 = GC.CollectionCount(0);
            int G1 = GC.CollectionCount(1);
            int G2 = GC.CollectionCount(2);

            //Windows Title
            m_sb.Clear();
            m_sb.AppendFormat("GC: {0} Ko G0:{1} G1:{2} G2:{2} ",
                 GC.GetTotalMemory(false) / 1024, G0, G1, G2);

            Window.Title = m_sb.ToString();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            if (m_Mod != null)
            {
                m_sb.Clear();
                m_sb.AppendFormat("Song Name:{0}\nChannels:{1}\nPattern Pos:{2}\nSong Pos: {3}/{4} ", m_Mod.songname, m_Mod.numchn, m_Mod.patpos, m_Mod.sngpos, m_Mod.numpos);

                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, m_sb.ToString(), new Vector2(16, 16), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

      

    }
}
