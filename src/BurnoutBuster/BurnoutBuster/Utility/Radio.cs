﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace BurnoutBuster.Utility
{
    public class Radio : GameComponent
    {
        // P R O P E R T I E S
        Song BackgroundMusic;
        Timer timer;
        float songLength;

        // C O N S T R U C T O R
        public Radio(Game game) : base(game)
        {
            songLength = 216;
        }

        // I N I T
        public override void Initialize()
        {
            songLength *= 1000;
            timer = new Timer();
            timer.StartTimer(0, songLength);

            BackgroundMusic = this.Game.Content.Load<Song>("urban-rainfall-rhythms");
            MediaPlayer.Volume = 0.5f;
            StartMusic();

            base.Initialize();
        }

        // U P D A T E
        public override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.TotalGameTime.TotalMilliseconds;
            UpdateBasedOnTimer(time);

            base.Update(gameTime);
        }

        private void UpdateBasedOnTimer(float time)
        {
            timer.UpdateTimer(time);

            if (timer.State == TimerState.Ended)
            {
                StartMusic();
                timer.StartTimer(time, songLength);
            }
        }

        // M I S C
        public void StopMusic()
        {
            MediaPlayer.Pause();
        }

        public void StartMusic()
        {

            MediaPlayer.Play(BackgroundMusic);
        }
    }
}
