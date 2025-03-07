﻿using Microsoft.Xna.Framework;
using MonoGameLibrary.Sprite;

namespace BurnoutBuster.Character
{
    public class BasicEnemy : MonogameEnemy
    {
        // C O N S T R U C T O R 
        public BasicEnemy(Game game, MonogameCreature creature) : base(game, creature)
        {
            this.EnemyType = EnemyType.Melee;
            this.movementMode = EnemyMovementMode.FollowPlayer;


            this.HitPoints = 10;
            this.Damage = 1;
        }

        // I N I T
        public override void SetUpAnimations()
        {
            Animations.Add("BasicEnemyAnim",
                new SpriteAnimation("BasicEnemyAnim", "CharacterSprites/BasicEnemyAnim", 6, 4, 1));

            base.SetUpAnimations();
        }

        // U P D A T E
        public override void Update(GameTime gameTime)
        {
            this.Move(gameTime);

            base.Update(gameTime);
        }

        // M E T H O D S
        public override void Move(GameTime gameTime)
        {
            base.Move(gameTime);
        }

        public override void Hit(int damageAmount)
        {
            this.moveVector = Vector2.Zero;
            base.Hit(damageAmount);
        }
    }
}
