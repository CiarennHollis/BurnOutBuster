﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BurnoutBuster.UI
{
    public class HUD : DrawableGameComponent
    {
        // P R O P E R T I E S

        //slot management
        Dictionary<string, object> itemsToDisplay;

        //drawing
        SpriteBatch spriteBatch;
        SpriteFont fontRegular;
        SpriteFont fontBold;
        Color uiColorMain;
        Color uiColorAlt1;
        Color uiColorAlt2;


        // C O N S T R U C T O R S 
        public HUD(Game game) : base(game)
        {
            itemsToDisplay = new Dictionary<string, object>();
        }


        // I N I T
        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            fontBold = this.Game.Content.Load<SpriteFont>("Fonts/ImpactBold");
            fontRegular = this.Game.Content.Load<SpriteFont>("Fonts/Impact");
            uiColorMain = Color.Beige;
            uiColorAlt1 = Color.PaleVioletRed;
            uiColorAlt2 = Color.Red;
        }

        // U P D A T E 
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        // D R A W 
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DisplayItems();
            spriteBatch.End();

            base.Draw(gameTime);
        }

        // U I   M A N A G E M E N T
        public void AddItem(string label, object itemReference)
        {
           itemsToDisplay.Add(label, itemReference);
        }
        public void UpdateHUDSlot(string labelOfSlot, object itemReference)
        {
            itemsToDisplay[labelOfSlot] = itemReference;
        }
        private void DisplayItems()
        {
            Vector2 position = new Vector2(5, 5);
            string slotContents;
            foreach (var item in itemsToDisplay.Keys)
            {
                slotContents = $"{item}: {itemsToDisplay[item]}";
                spriteBatch.DrawString(fontRegular, slotContents, position, uiColorMain);
                position += new Vector2(200, 0);
            }
        }
    }
}
