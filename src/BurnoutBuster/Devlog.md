# Devlog
  
## 7 May 2024 | 12:39
### Check In
 * Picked a different font for the instructions page to make it more readable.
 * Adjusted the layout of the title screen
  
### Goals
 * Documentation [DONE]

  
## 6 May 2024 | 16:08
### Check In
 * So, in all honesty, I am kind of at the point of just wanting to be done with this project (really with the semester as a whole which includes this project), and so my bandwith for bug fixing this project is very low.
	* A lot of the things I wanted do this sprint were more so aesthetic things. A lot of those things aren't necessary. I got the big aesthetic thing in, which was the animations, but even that isn't completely implemented the way I wanted it to be
 * I couldn't figure out how to get rid of the old sword once the player has picked up the new one
	* I think it keeps getting attached because it keeps colliding with the player and so it persists because of that. 
	* It could also because the instance of that first sword still exists in the components list the Game has and manages, but I couldn't (didn't have the bandwith) to figured out how to implement that first weapon the player starts with without assigning it to that list.
		* I could try creating the instance of that first weapon (a SimpleSword) and put that weapon into the components list before assigning it to the MGWeapon variable, but I don't really want to test that out right now.
	* This isn't the biggest issue, the old sword doesn't hinder the behavior of the new sword so it's fine if this issue doesn't get fixed. Fixing it is more so an aesthetics thing than anything else.
 * I am too tired to finish implementing the health pick up right now. 
	* The way I implemented how the new weapon (the GoldSword) spawns in doesn't really allow for other use cases. I need to restructured that system and make it more flexible since because of this, the ItemManager isn't really as built out as it could (and should be if I wanted to add more items and features to this project)
 * There's an issue with the animation on the sword slash not playing whenever the player attacks and only when the player hits an enemy. 
	* I know why this is (the PlayAnimations() method gets called from the Weapon's PerformAttack() method, and that method only gets called if the player an enemy is in the player's hitbox and the player attacks it)
	* I tried to fix it a dirty way (having the CommandCreature class call the animation method for the weapon, which would break separation of concern, since the player still performs actions even if it hasn't hit anything); It didn't fix the issue
	* I also don't really have the bandwith to bug fix this further
  
### Next Steps
 * Documentation

## 6 May 2024 | 13:51
### Check In
 * Going to start working on this for today.
  
### Goals
 * Health pick up -> finish implementing [NOT GOING TO FINISH -> am tired and burnt out and so I'm going to not do this in favor of other things.]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Bug fixing

  
## 4 May 2024 | 15:00
### Check In
 * Implemented new equation to the EnemyManager
 * Adjusted animations
 * Implemented health pick up
	* Just need to decide and implement how and when the item manager will spawn in healh pickups
 * Found and implemented game music
  
### Next Steps
 * Health pick up -> finish implementing [MOSTLY DONE -> need to decide and implement how and when the item manager will spawn in healh pickups]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * New screens?
 * Bug fixing
 * Documentation

## 4 May 2024 | 13:37
### Check In
 * Going to start working on this for today.
  
### Goals
 * Paste the new equation into the EnemyManager [DONE]
 * Adjust animation so the cooler animation is what get played [DONE]
 * Health pick up -> finish implementing [MOSTLY DONE -> need to decide and implement how and when the item manager will spawn in healh pickups]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio -> game music [DONE]

  
## 2 May 2024 | 13:19
### Check In
 * Originally, the rate at which the amount of enemies it takes to clear a wave increases at an ok amount for the first few waves but once you've reached wave #5, there are a lot of enemies and getting throught the waves really isn't fun anymore. The math the EnemyManager does to handle this increase is simple, it just multiplies the the previous amount of enemies it takes to clear a wave by two every time. This ramps really fast.
 * I liked the idea of the amount of enemies needed to complete a wave being increase exponentially to some degree since it would increasingly get harder while the pattern of the increase wouldn't be as easy for the player to see at first glance. However, I don't want the game to get too hard too quick.
 * So, I opened a (online) graphing calculator and started playing around with some functions
 	* I knew I wanted the first wave to have about 5-6 enemies and have that increase to there being about 100 enemies in wave #10.
	* I did get the function that would produce the original values the game was using -> [(1, 5), (2,10), (3, 20), (4, 40), (5, 80), etc.], it was a rather complicated function, but it's basic structure was something along the lines of f(x) = 5 + x^(x-1). I had played around some variations of that equation, but it still increased too much too soon.
	* So, I tried playing around with using a cubic function. When that was still to abrupt of an increase, I tried a quadratic function.
	* I liked the values the quadratic function gave me so that will be what gets plugged into the EnemyManager instead of what's currently in place. Instead of just multiply the previous wave's amount of enemies by 2 to get the amount for the on coming wave, it was use the equation I settle on and calculate the amount via plugging in the current wave number (which the enemy manager already keeps track of) for x
 * The equation I settled on: 5 + x^2
	* C# implementation: NumberOfEnemiesPerWave = 5 + (WaveCounter * WaveCounter);
  
### Next Steps
 * Paste the new equation into the EnemyManager
 * Adjust animation so the cooler animation is what get played
 * Health pick up -> finish implementing [IN PROGRESS]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio -> game music

  
## 1 May 2024 | 11:20
### Check In
 * I can't figured out why the MonogameWeapon will play its "BasicAttack" and not its "HeavyAttack" since the logic for playing both is the same 
	* I stepped through for both to make sure the isPaused var is false and that it's assigned to the places it needs to be -> and everything is
	* Even when I swap out the BasicAttack animation for the HeavyAttack one, it still won't. So I don't know. I had wanted to have different animations so it could be clear that the attacks were different but there's other things that need to be work on and I've spent all morning trying to figure this out
 * I guess one thing I could try is to not pause the weapon animations and just let the celAnimationManager keep animating them but just set the current animation to null so that I don't have to worry about the paused business :P Idk, just a thought.
	* The issue with implementing this is that there'd have to be a way for the sprite adapter to know the thing has finished playing so that it can set the current animation to null
  
### Next Steps
 * Balance gameplay and progression [DONE]
 * Adjust animation so the cooler animation is what get played
 * Health pick up -> finish implementing [IN PROGRESS]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio
  
## 1 May 2024 | 10:37
### Check In
 * Tried to fix the issue with the MonogameWeapon.Animations dictionary getting set to null at some point during the run time. 
	* I stepped through the initialization code to ensure that the dictionary is indeed being initialized, and it was. But by the time the weapon needs to play it's animation, the dictionary is null
	* I made a method that gets called before the weapon calls its PlayAnimation() that checks to see if the dictionary is null and if it is, it creates a new one and sets up the animations again.
		* I know this is kind of an expesinve thing to do, but it's kind of the last resort for this since I can't find why and where the original dictionary that gets created later becomes null.
	* I then hit the issue of it only playing the slash animation the first time, but then not the second time. I created a RestartAnimation() method in the CelAnimationManager and SpriteAnimationAdapter to "reset" the animation without pausing it and that fixed that issue
	* I then hit the issue of it not playing it's secondary animation (since there are animations for the basic attack and for the heavy attack)
		* I'm not entirely sure as to why :P
  
### Goals
 * Fix HeavyAttack animation not playing [TRIED]
  
  
## 30 April 2024 | 21:31
### Check In
 * Fixed the issue with animations not player with help from Jeff
 * Looked at the sword rendering thing in class with Jeff, we didn't fix it but I think I have an idea of how to fix it.
	* The SimpleSword should be instantiated and added to componenet separately from the MGWeapon obj then assigned to the MGWeapon obj
 * Hit an issue with the Animations Dictionary on the weapons being null by the time the player attacks
	* I think that the dirty delete in the MonogameCreature is wiping that list 
  
### Next Steps
 * Fix error with weapons animation dictionary [FIXED -> added a check to make sure this dictionary isn't null]
 * Health pick up -> finish implementing [IN PROGRESS]
 * HUD color change based on creature state [SKIPPING FOR NOW -> not the most necessary]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio
  
## 30 April 2024 | 17:35
### Check In
 * Going to look at the animation stuff -> the oneshot animations don't play/display the way I want them to
  
### Goals
 * Fix animations not playing -> ask Jeff in class today if no fix [FIXED -> with Jeff's help]
 * Previous sword showing up under old sword when the player picks up a new one.
  
  
## 28 April 2024 | 12:49
### Check In
 * Imported the last of the animations.
 * Implemented them mostly. I hit a bit of an issue with not having the right animations play on the objects who have and use different animations.
 * Implementing changing the UI color based on the player's state (normal, overwhelmed, shutdown) for just the player's HitPoints display was more of a chore than I thought it would be an I don't really want to figure that out right now. I could just change the color of the entire HUD dynamically, that would be easier to implement. Idk atm, I'll decide what I'll do with this later.
 * I am tired and don't really wanna finish implementing the health pick up rn so I'm not going to :P
  
### Next Steps
 * Fix issue with things not playing different animations
 * Health pick up -> finish implementing [IN PROGRESS]
 * HUD color change based on creature state [SKIPPING FOR NOW -> not the most necessary]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio
  
## 28 April 2024 | 12:49
### Check In
 * Going to start working on this for today.
  
### Goals
 * Import basic attack animations for the swords [DONE]
 * Fix bug with enemy animations -> animation is cropped wrong, the larger ones have the same croppins the tiny ones [DONE -> all the animations had the same key in the SpriteAnimationAdapter/CelAnimationManager's dictionary of spriteAnimations and that was cropping the larger animations]
 * Health pick up -> finish implementing
 * HUD color change based on creature state [SKIPPING FOR NOW -> not the most necessary]
  
  
## 26 April 2024 | 10:58
### Check In
 * Added some comments to the enemy manager here and there.
 * Wanted to look at the values the enemy manager is using to manage the amount of enemies it is spawning per wave
	* The project is in a good enough spot that I can some more formal methods of balancing the difficulty of the game since there really isn't much more functionality that will be added, just bug fixing
	* I want to kind of graph out those values for the enemy spawning since right now the amount of enemies per waves increase really fast which makes getting through like the 3rd or 4th wave is more of a feat than I'd like it to be.
	* Plugged in the animation files.
  
### Next Steps
 * Import basic attack animations for the swords [DONE]
 * Fix bug with enemy animations -> animation is cropped wrong, the larger ones have the same croppins the tiny ones [DONE]
 * Health pick up -> finish implementing [LATER]
 * HUD color change based on creature state [LATER]
 * Fixing the thing with the old sword still showing up underneath the new sword when it's picked up
 * Structure for implementing audio
  
  
## 22 April 2024 | 11:37
### Check In
 * So, I added some extra functionality to Jeff's animation 'engine'. Before it could only play animations on a loop and I wanted to be able to play an animation once
 * So, I added a bool field to both the spriteAnimation and the celAnimations (since I saw that the spriteAnimationAdapter creates celAnimations from SpriteAnimations) that notes whether or not the animaiton is looped. 
 * By default, animations are looped, but I overloaded the constructors to allow for noting if the animation isn't looped. Doing that also let me keep the original functionality intact. The only other change was updating the celAnimationManager's methods to account for the extra property
 * Added the code bits to the classes that need animations for playing animations.
 * I was thinking that I could just create different animations for the weapon for each type of action rather than doing so for the player. Would cut down on the animations I have to make and it might be easier to implement since there kind of is no way to tell whether or not an animation has ended. Thus playing an different animation once one has ended isn't currently possible. I could probably implement playing an new animation once once has ended via state and giving the animations a state, but it's not the most necessary thing at the moment and so I won't :P
 * The damage flashes kind of broke when I implemented animations so I went into the DrawableAnimatableSprite class to fix it, was just a matter of switching the color call to Colors.White to this.DrawColor.
  
### Goals
 * Create animations [DONE]
 * Github Issues tasks
  
## 22 April 2024 | 10:14
### Check In
 * I am waiting for unity to open so I figured I'd implement the animation bits to the rest of the animated things in this in this project
  
### Goals
 * Animation code bits for animated things [DONE]
  
  
## 20 April 2024 | 16:23
### Check In
 * Figured out how to implement the drawable animatable sprite
  
### On DrawableAnimatableSprite Implementation
 * I implemented this through the MonogameCreature -> made it inherit from DrawableAnimatableSprite and had it play a test animation
 * I made an interface with the methods and properties I used (or will use) to implement animations. This will make it easier to implement this even if the notion of a DrawableAnimatableSprite also being IAnimateable is kind of weird and redundent-seeming.
  
### Next Steps
 * Create animations
 * Implement Animations
 * Github Issues tasks
  
## 21 April 2024 | 19:18
### Check In
 * I am going to try to implement animations, am doing so on a separate branch so as to not mess up the other progress
  
### Goals
 * Animations for a character
  
  
## 20 April 2024 | 16:23
### Check In
 * Did the small tasks I intended to do
 * Read through the DrawableAnimatableSprite some
  
### On DrawableAnimatableSprite
 * It seems like this class builds off of the drawable sprite and gives it funcitionality for animating itself
	* The animator (so to say) or as Jeff called it "spriteAnimationAdapter" seems to be an object that has a list of animations and that uses a "celAnimationManager" for flipping through the frames of the animation
	* the DrawableAnimatable sprite has a spriteAnimationAdapter and references it to see what texture it should be displaying
 * What I'll probably do is try to implement this on a dummy class type so that I don't mess up the logic and structure of the classes I've written for this project.
  
### Next Steps
 * Create animations
 * Implement Animations
  
## 20 April 2024 | 15:30
### Check In
 * I am going to look into implementing animations into the game
  
### Goals
 * Look at and read Jeff's animatable sprite script 
 * Check enemy manager spawning [DONE]
 * Check collision manager debug tool [DONE]
 * Check for typos [DONE]
 * Set up structure for health pickup [DONE -> will fill it out later]
  
  
## 16 April 2024 | 14:47
### Check In
 * Fixed some things here and there
 * Adds new enemy textures
 * Adds new screen textures
 * For some reason the screens don't draw their visual to the screen. Idk why rn, I even tried stepping through the method. It will be fixed next sprint as there is no time to rn.
 * Adds release build to the folder.
  
### Next Steps
 * Bugging fixing 
 * Parsing critique and feedback
 * Generating new git issues for the final sprint
 * Weapon/attack animation
 * Music
  
  
## 15 April 2024 | 12:15
### Check In
 * Successfully implemented pickup-able sword/weapon.
  
### Next Steps
 * Enemy sprites [DONE]
 * Weapon/attack animation?
 * Music?
  
## 15 April 2024 | 12:15
### Check In
 * Taking a break for lunch
  
### Next Steps
 * Make pick up for new sword [DONE -> the old sword doesn't go away tho] [CLOSED ISSUES #27 ]
 * Enemy sprites
 * Weapon/attack animation
 * Music?
  
## 15 April 2024 | 10:11
### Check In
 * Got the weapon to move with the player
 * Currently looking at how I want to have a weapon that can be picked up
  
### On Items in the Game Space
 * So, I wanted to have a weapon that appears later after the player has fought through x amount of wave and was trying to decide how I want to implement that
 * I'll need an item manager for managing the items on screen. I was thinking about implementing observer pattern for that so that the reference to the enemy manager for spawning the item does have to be hard coded
 * My thought is that if  I implement observer pattern for the item manager, I might as well also implement it for moving the weapon with the player.
  
## 15 April 2024 | 10:11
### Check In
 * Going to start working on this again. I need to finish this today so I can do documentation tomorrow :P
 * Grace is in the lab today so I can ask her about carrying items 
  
### Goals
 * Sword texture on the creature (animation doesn't have to be implemented) [DONE -> kind of breaks SoC a bit since the sword needs a reference to the player]
 * Make pick up for new sword
 * Enemy sprites
 * Weapon/attack animation
 * Music?
  

## 14 April 2024 | 23:11
### Check In
 * So, I tried to implement the weapons having textures that can be drawn to the screen
 * I encapsulated the weapons like how the enemies and creature/player objects are encaslated so that the can interact in monogame
 * The weapons matches the way the enemies are structured. Everything funtionality-wise works the same way as it did before. 
 * The issue I hit though is that I'm struggling to get the weapon to move with the player. The weapon draws to screen, but it won't follow the player
 * I tried having the player pass the weapon it's location for the weapon to use to set it's own position with, but the variable I use to pass the player's location with always ended up being 0 by the time the weapon's update runs.
 * I don't know what else to try to get this to work. I know Grace will be in the lab tomorrow so I can ask her about this then since I think she did a similar thing in her game for this class (having the player carry an item)
 * I also added the structure I intend to use to make a weapon that the player can pick up.
  
### Next Steps
 * Sword texture on the creature (animation doesn't have to be implemented)
 * Make pick up for new sword
 * Enemy sprites
 * Screens visuals
 * Weapon/attack animation

## 14 April 2024 | 19:31
### Check In
 * Going to start working on this again. I want to try to get the majority of things for this project done so I don't have to worry about this too much tomorrow and can work on another project I'm heading.
  
### Goals
 * Game restart and screens [DONE]
 * Dash need tweeking, feels slow -> might make player movement not a lerp function [DONE -> just adjusted the lerp rather than replacing it]
 * Sword texture on the creature (animation doesn't have to be implemented)
 * Enemy spawn locations -> they sometimes spawn off screen [DONE -> fixed it so they aren't all coming from one corner]
 * Need to makes sure the restart game behavior goes as expected. [DONE]
 * Make pick up for new sword
 * Enemy sprites
 * Weapon/attack animation
  

## 13 April 2024 | 18:41
### Check In
 * Implemented game screens and state
	* System mostly works, I just need to populate the game screens
 * Need to stop for today :P
  
### Things that I noticed need tweaking or that should also be done for the MVP
 * Dash need tweeking, feels slow -> might make player movement not a lerp function
 * Sword texture on the creature (animation doesn't have to be implemented)
 * Enemy spawn locations -> they sometimes spawn off screen
 * Need to makes sure the restart game behavior goes as expected.
 * Make pick up for new sword
  
### Next Steps
 * Game restart and screens [WORKING ON -> need to populate screens]
 * Enemy sprites
 * Weapon/attack animation
  
## 13 April 2024 | 17:23
### Check In
 * Implemented the enemy waves system in the enemy manager
 * Added wave info to the HUD
  
### On Game Screens
 * So, for implementing this, I will definitely implement using games states (ie, title, playing, lose, win) and then update and draw the appropriate thing based off that game state 
 * I will probably make a class that's a "game screen" for the non-gameplay screen that hold their respective info and draw it.
	* I'm not going to have this class inherit from the Sprite class though since it doesn't need all the things a sprite has
  
### Next Steps
 * Game restart and screens [WORKING ON]
 * Enemy sprites
 * Weapon/attack animation
  
## 13 April 2024 | 16:08
### Check In
 * Going to start working on this again.
  
### On Levels/EnemyWaves/Game Progression
 * So, I had originally want this game to have different rooms that the player would fight through. But this is out of scope for me now.
 * Instead, I'm going to shift to just having waves of enemies that progressively become more.
	* The enemy manager already has functionality for progressively spawning in new enemies. It wouldn't hard to add some extra functionality to it for managing waves of enemies more explicity (like with a counter keeping track of which wave the player is one and the number of enemies left in the current wave)
 * Then the game will have the HUD display the enemy kill count and wave counter
  
### Goals
 * Levels/wave managment [DONE] [ISSUE #28 CLOSED]
 * Game restart and screens
 * Enemy sprites
 * Weapon/attack animation
  
## 13 April 2024 | 13:34
### Check In
 * Just finished refactoring the logic for the way the enemy manager spawns enemies so that there's a delay between spawns.
 * Need to take a break for now.
  
### Next Steps
 * Levels/wave managment [WORKING ON]
 * Game restart and screens
 * Enemy sprites
 * Weapon/attack animation
  
## 13 April 2024 | 12:24
### Check In
 * Making a note about the enemy types 
  
### On Enemy types
 *  So, all the enemies in the game are children of the MonogameEnemy class.
 * Currently, the variations are handled by the parent class. 
 * I am aware that in having this this way, it gives a more responsibility to the MonogameEnemy class than it should probably have
	* But, doing it this way lets me reuse a movement mode for multiple types of enemies (for multipe children) without having to copy and paste the same code
  
## 13 April 2024 | 11:20
### Check In
 * Making a note about the player state 
  
### On Player/Creature State
 * So, there are 3 states for the player: Normal, Overwhelmed, and Shutdown. 
	* __Normal:__ the normal player state
	* __Shutdown:__ the dead state 
	* __Overwhelmed:__ I wanted to implement a feature to go along with this state where if the player lost more than half of their current HP in one hit, they would be handicapped movement and attacking wise
    	* So, to achieve this, I've added a previousHitpoint field to the MonogameCreature so that it could compare previous and current hit points and react if more than half has been lost 
  
## 13 April 2024 | 11:00
### Check In
 * Sitting down to work on this today. I want to try to get the majority of the work for this milestone done today, at least the programming bits
  
### Goals
 * Player state [DONE] [ISSUE #17 CLOSED]
 * Levels/wave managment [WORKING ON]
 * Enemy types [DONE] [ISSUE #26 CLOSED]
 * Game restart and screens
 * Enemy sprites
 * Weapon/attack animation
  
  
## 11 April 2024 | 13:37
### Check In
 * Implemented debugging feature for the collision system
 * Doing so did uncover a bug that that system has -> collision boxes on the enemies don't get updated or removed when the enemy respawns so that that hitbox ends up getting left behind in the scene and still cause the player damage.
  
### Next Steps
 * Collision/enemy respawn bug [DONE] -> the collision box wasn't being disabled even though the enemy was getting disabled.
 * Enemy sprites
 * Weapon/attack animation
 * Player state
 * Levels/wave managment
 * Enemy types 
  
## 11 April 2024 | 13:37
### Check In
 * Made and imported some new textures for the characters that are bigger
 * Made textures for some weapons
 * Made a background texture
 * I wanted to write a debug feature for the collision system that would allow for the collision boxes (and hit boxes if applicable) to be visible.	
	* It would allow me to better debug the collision system.
	* It would also make it easier to showcase that feature of the project.
	* I'm going to have this debug feature mimic the way the console gets toggled on and off
  
### Next Steps
 * Collision debug feature [DONE]
 * Enemy sprites
 * Weapon/attack animation
  
  
## 6 April 2024 | 10:09
### Check In
 * Implemented a player hit box so the player can attack the enemy without taking damage 
	* Uses an interface to do so that inherits from ICollidable. 
	* The Collision manager also has some extra functionality. 
	* Learned the hard way that doing a try/catch thing several times an update slows the game down like 300%
 * I don't know right now if I want to fix the dash since it's effectively a teleport thing right now with the way it works :P It's not something that needs to be fixed right now so I am going to be with this for now.
 * Close Isues: #20, #21, #22, #24
  
### Next Steps
 * Enemy sprites
 * Weapon sprites [DONE]
 * Weapon/attack animation
  
## 6 April 2024 | 10:09
### Check In
 * Got the damage flash to work. It uses two timers: one for the total duration of the flashing and one for the duration of each individual flash. There's a flashing state that notes which color should be shown or if the flashing effect is off. There's also a boolean being used to send relay the trigger to start the flashing from the Hit() function to the Update() function since the way I've implemented this feature is dependent on the update loop
 * Also organized the MonogameEnemy and MonogameCreature scripts -> added some comments and regions to make sections more clear 
  
### Next Steps
 * Collision bits 
  
## 6 April 2024 | 13:35
### On Damage Flashing Again
 * So, I am going to implement state for the flashing but it'd be it's own state that is separate. Just using the bool IsFlashing didn't allow for noting whether or not the color is being displayed or not.
  
## 6 April 2024 | 12:48
### Check In
 * Going to actually start working now.
  
### On Damage Flashing
 * So, for having the enemies flash their sprite texture when they are hit, I had origianlly thought to use state for that. That's what Jeff did when he implemented that during class as an example.
 * There is a stunned state on the enemies that I thought to use for this purpose. However, I did have an intended use for this state and there currently isn't something similar on the player. Plus, the "flashing" state wouldn't be exclusive to the player's other states.
 * So, because I don't want the flashing state to be exclusive, I am just going to use a boolean for it, especially since there's only 2 states for that: "flashing" and "not flashing";
  
## 6 April 2024 | 10:09
### Check In
 * Writing this before I actually start working on this (which won't be for a few hours) so I can just start working when I do get to start working on this
 * Starting progress for the MVP milestone. As the previous entry illustrates, I've already sat down and noted out all the things I need to do for the next milestone so I can move forward with a direction
 * Today/this weekend, I want to tackle the bugs and unfinished functionality in the project so that next week I can focus on building out the game loop more (with progression and implementing aesthetics)
  
### Goals
 * Damage flash for characters [DONE]
 * Have enemy collide with other enemies [DONE] -> issue with this fix is that it glitches out when enemies are spawned ontop of each other
 * Adjust the player's collision box to match it's sprite [DONE] -> the keepCreatureOnScreen method just needed to be adjusted since the issue really was that the player could move off screen slightly
 * Make dash an actual dash rather than just teleporting around [TBD/LATER]
 * Give the player a hit box that is different from (and bigger than) it's hitbox [DONE]
  
   
## 3 April 2024 | 14:02
### Vertical Slice Reflection
I wasn't able to finish all that I wanted to for the vertical slice milestone. I didn't expect to have to handle collision. Part of that came from the fact that the project I used a kind of a jumping off point for this one really didn't implement a proper collision system and I had forgotten that fact. So, a considerable amount of time went into reading throught the scripts and files of the MonoGame.Extended.Collision system so that I could implement my own version of it. There are a couple features I also pulled from Unity's collision system for this (such as having an object attached to the collision information that system returns). The input buffer and chord analyzer also took more time than I thought it would. Thus I really didn't really have time to adequately build out and bug fix the other features I had wanted to have for this milestone like the level manager. I also didn't really have time for asset creation.
  
The Vertical Slice Documentation (artifactReleases/2VS/Documentation) details what exactly got done for this milestone as well as what didn't get done. 
  
### Planning for MVP
The Minimum Viable Product is the next milestone and it is due two weeks from yesterday. In the initial proposal I put together for this project, I noted three things that I wanted to implement for this milestone:
 * Building out levels
 * Implement score and currency
 * Implement animations 
  
Right now, the basic game loop exists in the game (albiet a very rudimentary one, but a game loop nonetheless that can be built on). The structure for the majority of the objects exists. I had wanted to include pick ups in the project, but I don't think I have time to implement that. Maybe later (since the end of the semester doesn't have to mean that I stop working on this project altogether). The main game interactions are there and can be built upon to further flesh out the gameplay. I had originally intended to have the player move between different rooms/levels in the game, but to make my life easier (:P) I am just going to have waves of enemies and have the game be a survive-as-long-as-you-can type of thing rather than something with destinct rooms. This won't be a hard pivot for the level system since as it doesn't work at all in it's current state and that would save me time with asset creation since I would've have to create a bunch of environment art (I'd just need one). 
  
It seems like there are three main overarchering things that need to be done for the MVP milestone:
 1. __Bug fixing -> fixing bugs and getting the non-functioning bits to function properly__
  * Enemy flashing on hit
  * Enemy colliding with each other -> would prevent them from piling on top of each other 
  * Collision box/bounds position on the player being off from the texture 
  * The dash behaves more like a teleport rather than an actual dash
  * Having the player's hit box not be the same as their collision box
  
 2. __Progression -> having some sense of progression so that the gameplay feels more like gameplay rather than fiddling around with what is essentially a digital toy__
  * More difficult enemies -> more difficult enemies -> stronger, different movement 
  * More effective weapons -> player gets better weapons the longer they survive, the better weapons they get
  * Waves of enemies -> more and more enemies spawn during each subsequent wave -> will pivot the functionality of the level class and manager for to be for this
 
 3. __Asset Creation -> creating and implementing art and animations for game so that game looks and feels nice (if not at least decent)__
  * Enemy sprites -> for different enemy types
  * Weapon sprites and animation -> attack anim
  * Environment art
  * Player animation and visual hit feedback
  * Misc pick ups -> health buff
  
There's two weeks before the milestone deadline, so this task break down is for those two weeks
#### Week 1 
Bug Fixing
 *  Enemy flashing on hit
 * Enemy colliding with each other -> would prevent them from piling on top of each other 
 * Collision box/bounds position on the player being off from the texture 
 * The dash behaves more like a teleport rather than an actual dash
 * Having the player's hit box not be the same as their collision box
  
Asset Creation
 * Weapon sprites
 * Enemy sprites 
  
#### Week 2 
Progression
 * More difficult enemies -> more difficult enemies -> stronger, different movement 
 * More effective weapons -> player gets better weapons the longer they survive, the better weapons they get
 * Waves of enemies -> more and more enemies spawn during each subsequent wave -> will pivot the functionality of the level class and manager for to be for this
  
Asset Creation
 * Environment Art
 * Health pickup
 
### Next Steps
 * Create issues in github for the tasks for this milestone
 * Get started with bugfixing
  
  
## 2 April 2024 | 16:35
### Check In
 * Finished the things
 * Did player death a dirty way as in when the play dies the game immediately quits itself
 * Need to do the documentation
  
### Goals
 * Documentation for VS submission

## 2 April 2024 | 14:55
### Check In
 * Going to get some of the level functionality built out :P
 * Want to try and get the basic game loop working :P
 * Need to do the documentation
  
### Goals
 * finish implementing level manager [FINISH LATER - DOESN"T WORK]
 * kill able enemies and respawning enemies [DONE]
 * player death [DONE]
 * Documentation for VS submission

## 2 April 2024 | 12:50
### Check In
 * Built out level class
 * Started building out level manager
 * Made some quick place holder art
  
### Next Steps
 * finish implementing level manager
 * kill able enemies and respawning enemies
 * player death
 * Documentation for VS submission
  
## 2 April 2024 | 11:40
### Check In
 * Going to get some of the level functionality built out :P
 * Want to try and get the basic game loop working :P
 * Need to do the documentation
  
### Goals
 * Placeholder level art [DONE]
 * level class [DONE]
 * level manager
 * kill able enemies and respawning enemies
 * player death
 * Documentation for VS submission
  
    
## 1 April 2024 | 17:25
### Check In
 * Got the HUD working to display the player's hit points 
 * The level.cs and LevelManager.cs exist in the project, I didn't ahve time this even to build these out today like I thought I would
  
### Next Steps
 * Will see if I can build out the level stuff tomorrow
 * Will do the documentation and sprint reflection (and gather the submission materials) tomorrow.
  
## 1 April 2024 | 13:07
### Check In
 * Got the player's attacks and the enemy's attack back working. I need to implement the HUD so I can see the player's health update :P
	* Player death (and state) won't be hard to implement, for this milestone I think I'll just have it do something simple like quit the application (While I know that is annoying, I don't really have time right now to handle that more gracefully). I also need to decide how that mechanic will work (really more so for the state).
	* Started working on HUD. I wanted there to be slots for it so it'd be easy to have things write to it and have the HUD class handle the formatting of it itself
  
### Next Steps
 * Finish HUD stuff [DONE]
 * Level class and manager [EXISTS BUT ISN"T BUILT OUT]
 * Vertical slice documentation

## 1 April 2024 | 9:10
### Check In
 * Post spring break. Back in the lab. 
 * Today, I need to finish up the stuff for the vertical slice since that's due tomorrow.
  
### Goals
 * Enemy attacks dealing damage to the player [DONE]
 * Player attacks dealing damage to the enemy [DONE]
 * Enemy death (and state) [DONE]
 * Player death (and state) [LATER]
 * Level class and manager [EXISTS]
 * HUD for player health [DONE]
 * Simple level art if possible [LATER]
  
  
## 30 March 2024 | 15:41
### Check In
 * Implemented the input buffer for input combos [omfg, %-(  (;U;) , brain is mush] 
  
### THE CHORD ANALYZER
 * So, there's five main pieces to this buffer/analyzer system
	1. enum ActionCommands = serves as a reference to the commands being passed into and out of the chord analyzer without actually having to pass a command object through the system; this makes it easier to compare the current chord in the buffer with the collection of possible chords
	2. ChordMap.cs = collection of all the possible chords -> it defines what the possible chords are and what the command associated with those chords are 
	3. Note.cs = defines a note (a command and a timer) 
	4. Chord.cs = defines a chord (a set of 1-3 notes)
	5. ChordAnalyzer.cs = this takes the input/notes passed to it and adds them to the buffer; it then checks that buffer to see if there are valid chords, in then passes out a "reference" to a command so that the command processor can execute it if there is a valid chord in the buffer; If one of the notes in the buffer times out, it will clear the buffer.
 * The big mental hurdle with this was figuring out how I wanted to pass commands (or at least references to commands) through the analyzer since the combos are based on commands. I decided to use an enum (the ActionCommands enum) to relay the reference to the commands and than have the command processor create the command based off the enum value.
 * What does it do? 
    1. input gets passed in as a string along with the current time and a note is created and added to the buffer
	2. The analyzer updates the notes in the buffer and then checks the buffer. If any of the notes has times out, the buffer is cleared.
	3. If there is a valid chord in the buffer, the analyzer returns a command for the command processor to execute
   
### Next Steps
 * The levels/rooms system -> in needs to at least exist
 * Enemy attack -> basic attack
 * Enemy death -> reset and disable while it waits to be used again -> have the enemy manager just spawn another one it when one is killed :P
 * UI -> HUD for player health
 * Player damage and state based off that damage
  
## 30 March 2024 | 13:12
### Check In
 * The collision pretty much works the way I want it to work. 
 * The Bounds rectangle ends up being a bit too big so the collision isn't the most precise, but that can be a TD for a later milestone. I need to move on with building out the other features I intend to have at least mostly done for the Vertical Slice milestone
 * The enemy manager is implemented. Meaning, the enemy the game currently has on screen is being managed by the enemy manage rather than the game.
  
### Next Steps
 * The input buffer/analyzer
  
## 30 March 2024 | 12:42
### Check In
 * So, I wrote my own collision manager, it's heavily based off of MonoGame Extended's CollisionComponent though. Mine collision manager is just a little more targeted for my project (notably: it doesn't handle circle collision) and doesn't use a node based collection.
 * I decided to not use the node based collection and instead have the manager only check collisions on the active objects in the game. I am using what's basically an object pool for managing the enemies and I don't want the game to calculate collision on inactive enemies in that pool.
 * I also have my ICollidable inherit from ITaggable so that my collision objects have a tag on them by default.
  
### Next Steps 
 * Finish implementing the enemy manager [DONE]
  
## 30 March 2014 | 10:32
### Check In
 * Had to stop and move locations since I got kicked out of the first coffee shop I went too :| (they don't let people sit at a table for longer than an hour and I didn't know that until someone informed me)
 * I couldn't really find anything about having issues with the Monogame Extended collision system so I will be write a custom one based off of it :P
  
### On MonoGame.Extended.Collision
 * So, there's two main objects that constitutes this collision system
	1. ICollisionActor -> An interface that has a Bounds property and an OnCollision(CollisionEventArgs collisionInfo) method. The bounds is what gets used to calculate a collision and the method is for the behavior that thing does when it collides. That method seems to functionally be the same as Unity's OnCollisionEnter(Collision other), which is what I was looking for.
    2. CollisionComponent -> A class that holds collection of all the things that have collision calculated for them and has methods for performing those calculations. It's collection of collision objects looks to be a node tree: each collision object gets a quadtree saved with them in the dictionary and then there's a larger quadtree that all those smaller trees stem from. I read on the forums that MonoGame uses this node system for performance reasons so that the game only calculates the collision on objects that are in a specific area rather than calculating collision on all the objects that are housed in the collection. 
 * There is another piece, the CollisionEventArgs class, but it is used to relay the object attached to the collision and the vector of the collision (the penetration vector)
 * Those first two things are what I would need my own versions of, the third thing is less important since I could in theory just have the my version of OnCollisoin(...) return the collision object itself. But I think I will indeed have my own verion of this piece since having the collision vector would be handy for keeping characters from overlapping on each other
  
### On the input buffer/analyzer
 * So, to implement this, I was thinking of having a Stack<ICommand> with a capacity of three. As new commands get called, the command at the top gets popped off to make room for the next one 
 * To implement the timers for each command, tho, I may need a custom datatype to hold the command and the timer -> whenever a command is performed, a new "note" type is created and added to the stack (which would make the stack a Stack<"Note"> or something of the like) 
 * The command processor would then constantly check that buffer stack to see if the "notes" in it make a "chord". It would also update the timers on the commands/notes currently in the buffer stack
  
### Goals 
 * Still pretty much the same as the previous entry :P
  
## 30 March 2024 | 9:16
### Check In 
 * Need to make some headway on this project today
 * I was still unable to get the collision thing from Monogame Extended to work :P I'm not really sure what the issue is. 
 * So, I just might write my own collision component :P
  
### Goals
 * Finish enemy manager [DONE]
 * Collision [DONE]
 * analyzer and buffer :P [DONE]
  
## 29 March 2024 | 13:25
### Check In
 * Started buidling out the enemy manager -> I made it a drawable game componenet so that it could call draw on the enemies. It will be the thing initializing, updating, and drawing the enemies. It will also have a pool of enemies to pull and "spawn" enemies from*
 * I need to test this out to see if to see if it works
  
### Next Steps
 * Finish building out the enemy manager
 * Implement levels and rooms
 * Implement HUD
 * Implement buffer and analyzer for input combos
 * Look into Monogame Extended collision and maybe ask Jeff for help with it :P
  
## 29 March 2024 | 12:41
### Check In
 * So, I had implemented the collision system from the Monogame Extended library, but I can't get the system to work for some reason. I'm unsure what I'm doing wrong with it
 * So, since I've spent the last hour trying to get that system to respond to me, I'm going to work on something else for now :P
  
### Goals
 * Enemy manager
  
## 29 March 2024 | 11:31
### Check In
 * Sitting down to work on this project
  
### Goals
 * Get the enemy class built out
 * Build out the enemy manager 
 * Decide how levels/rooms will work in this game
 * Implement a HUD
 * Implement an analzer for the input combos
  
  
## 20 March 2024 | 14:02
### Check In
 * So, I hit this question of how do I handle collision for this game. I wanted to have a system that was relatively similar to how Unity implements it's collisions so that I could have a method similar to Unity's OnCollisionEnter().
 * I don't really have the time to sit down and write a custom physics/collision system for this project, while that probably would be neat to do (and I may do so at some point in the future just to do it). Because I don't have that time, I looked around at other ways to bring in a collision system into this project.
 * I eventually found the MonoGame.Extended.Collision library and was able to install it into the project. 
 * To go along with the collision system, I also wrote a simple tag manager so that I could give tags to things and have check to if things are tagged rather than checking their type. Instead of using strings for tags though, I am using an enum.
 * These two things together in theory should let me implement this collision sysem in a way that's relatively similar to doing so in Unity. I just wrapped the ICollisionActor from MonoGame Extended and my ITaggable into it's own interface ITaggedCollidable so it would look a little cleaner and be simpler to implement.
 * I kind of forgot to check in with this doc before implementing the things listed above since I didn't intend to do work on this project when I sat down. I kind of just ended up working on it a bit since I got bored :P


## 18 March 2024 | 16:29
### Check In
 * Didn't get as much done today as I wanted to :P
 * Really only get some simple enemmy movement in
  
### Next Steps
 * Continue implementing the enemy bits
 * Implement the enemy manager
  
## 18 March 2024 | 11:53
### Check In
 * I've gone in and made new issues for the tasks for this sprint
 * Today I'm hoping to build out the functionality of the enemies
  
### Goals
 * Enemy movement
 * Enemy collision 
 * Enemy attack
 * Enemy state
 * Start Enemy manager
  
  
## 11 March 2024 | 16:47
### Check In
 * I added in a janky little collision thing so that the combat system can be demoed in a more substantial manner. Collision for the enemies probably should be handled through an enemy manager but that was outside the scope of the POC milestone for me.
 * Added instructions to the screen so demoing the POC would be easier
 * Cleaned up unused using statements

  
### Next Steps 
 * Ask Jeff about the animatable sprite 
 * Enemy movement
 * Enemy manager: spawning enemies, collision for the enemies
 * I'm sure there's other things that I can't think of right now and I'm sure there'll be things that come up in class tomorrow. I can also look at my proposal doc since I noted down things there. Those tasks will be housed in GitHub Issues though.
  
  
## 11 March 2024 | 14:16
### Check In
 * So, the combat system and combat combos is successfully implemented!! [ISSUE #5 CLOSED]
 * The original design I drew up for them also had "cool down" timers on them. I'm not exactly sure how I want to implement this gameplay-wise. I have those there because I don't want players to be able to spam the heavy attack button and just deal out heavy attacks. But there could be a better way of implementing this limitation with. I want to look at how other games (like Hades) handle this in their gameplay. Because of this this particular aspect will be something for the next milestone (the vertical slice).
 * The working combat-combo-system I think meets the POC requirement. I would like to make it possible for the play to hit the enemy that is currently in the scene. But I haven't decided how I want the enemy behavior to be structured. I have written the enemy manager yet.
 * Added sprite for the enemy [ISSUE #6 CLOSED]
  
### Next Steps
 * Think about how implement the enemies taking damage and the manager.
 * Write documentation for the POC
  
## 11 March 2024 | 12:02
### Check In
 * Started implementing using listening states in the command processor.
 * I found that the timed input bits I had in the TimeInputManager I probably won't use (the PressedKey var) since I realized that those were only really being used for seeing if a key was double pressed. I might still use that for the Dash Attack since that combo was meant to be: Dash + attack + attack. But I think, to make my life a little easier, I might just have the dash attack be: Dash + Attack.	
 * Started implementing the combos. I abstracted out how the processor will respond based on the listening state to their own methods and have those methods return commands so things fit nicely back into the way the command processor functions.
 * Taking a break for lunch :P
  
### Next Steps
 * Continue implementing the combat combos
 * Start with continuing to build out the methods in the command processor for the listening modes [DONE]
  
## 11 March 2024 | 10:37
### Check In
 * Slept on it. Will continue where I left off yesterday
  
### Goals
 * Implement the timed input bits in the command processor [DONE]
 * Implement listening states for the combat combos [DONE]
 * Implement combat combos [DONE]
 * Make place holder sprite for the enemy [DONE]
  
  
## 10 March 2024 | 16:20
### Check In
 * Created the command class for all the actions and set things up for those actions to be implemented in game
 * [ISSUE #4 CLOSED]
 * I've looked at this too long today and need to take a break. Will continue working on this tomorrow.
  
### Implementing the timed input stuff
 * So, the EmojiJoy project I originally wrote the TimedInputHandler class for handled movement combos by having different states and listening for different thing based off of those states. It's states would change based on the times that were attached to the PressedKey that would be instantiated whenever arrow key input was detected.
 * In EmojiJoy, the EmojiController handled those listing states but for this project, the CommandProcessor will do that. Instead of what input it's listening for being hard coded, it gets read in from a KeyMap and there is a switch the CommandProcessor uses to handle that. 
 * I'm thinking that I could have methods for the action buttons and those methods will create and execute the new command rather than that switch itself so that I can implement the listening states and have the processor create and execute the commands based on what particular action it's listening for. 
 * Having the creation of the action commands be separated out into different methods (rather than in the switch) would in theory also let me use the timers on the pressedKey vars that would be created and stop those timers if the game sees that a player wouldn't be using a combo and can thus adjust its state accordingly.
  
### Next Steps 
 * Implement the timed input bits in the command processor
 * Implement listening states for the combat combos
 * Implement combat combos
  
  
## 10 March 2024 | 15:55
### Check In
 * Implemented the weapon bits. I also used the strategy pattern for this for the same reason as the enemies.
 * [ISSUE #7 CLOSED]
  
### Next Steps
 * Implement the combat/action commmands
  
## 10 March 2024 | 15:19
### Check In
 * Implemented the enemy bits. I used the strategy pattern for it so that it would be easier to have several different variations of enemies.
 * But for now, there is only one type of enemy since the focus for this milestone is getting the combat system up and running.
  
### Next Steps
 * Built out the weapons system a bit so that the combat system can be tested. My intention is to have the player's attack be dependent on the weapon they have.
  
## 10 March 2024 | 14:21
### Check In
 * Going to implement the combat system bits: Setting the commands for those actions and getting them to work with the player and command processor system
 * I also want to try to finish up the rest of the tasks noted in Github Issues for the POC milestone
  
### Goals
 * Implement combat commands
 * Implement simple weapon system that can be built on [DONE]
 * Implement simple enemy to be built out further later [DONE]
  

## 2 March 2024 | 16:05
### Check In
 * Basic player movement is implemented. 
	* I tried to have the MonogameCreature inherit from the DrawableAnimatableSprite, but I'm not entirely sure how this class works so I wanna ask Jeff about it. It would be nice to have that so I can implement animations. But the animations aren't imperative at this time so I just used the DrawableSprite.
 * I did end up having the movement and combat system both be ran through the command processor. I had thought about having them just be separate since I was going to us Jeff's PlayerController. I didn't know hard it would be to implement the command pattern for the movement and actions together, but once I had implemented the movement, the actions/attacks/combat move commands were basically the same set up. Plus, it does make sense the two would be together since they both are dependent on input.
 * Set up the structure for the combat, the command types need to be made and the command methods on the CommandCreature need to be built out.

### Next Steps
 * Ask Jeff about the DrawableAnimatableSprite
 * Implement the combat actions
 * Think about and implement the combat combos
  

## 2 March 2024 | 13:31
### Check In
 * Going to start implementing the player bits: player class, movement, and set up the structure for the combat
  
### Goals
 * Write the player script [DONE]
 * Implement player movement [DONE]
 * Implement initial structure for combat (doesn't have to work yet) [DONE]

  
## 27 February 2024 | 17:56
### Check In
 * Finished implementing the command pattern bits. Some of it will probably have to be refactored once I add in the player bits.
 * I am currently very much leaning towards having the movement stuff not be ran though the command system, just the actions (attack, heavy attack, etc.) this might make things weird with implementing the dash mechanic but we will see.
  
### Next Steps
 * Implement the player bits 
  
## 27 February 2024 | 16:25
### Check In
 * Going to finish up some stuff from yesterday, mainly implementing the command pattern stuff.
  
## Goals
 * Implement the command pattern stuff based on jeff's examples.
  

## 26 February 2024 | 17:13
### Check In
 * I didn't finish everything I wanted to today, but I did make some good progress.
 * Created this file. [ISSUE #8 CLOSED]
 * Brought in the old script from the Emoji Joy project. [ISSUE #2 CLOSED]
 * I saw that Jeff's InputHandler uses an enum to store the gamepad buttons, but it's only local to it's particular class. I made an enum to compliment that that is accessible to the wider project. I made sure the values of my new enum matched that of Jeff's so I can cast variables between them without an issue. [ISSUE #3 CLOSED]
 * I made classes for the pressed key and pressed button, I was unsure of what class those two would inherit from since they are essentially the same, just one is for a key press and the other is for a button press. [ISSUE #3 CLOSED]
 * I also expanded my TimedInputHandler.cs so it can also handle a gamepad since I would like this project to support play with a gamepad. [ISSUE #3 CLOSED]
 * I noticed that Jeff's MonogameLibrary has a PlayerController.cs script. I might just use that for the player's movement and not have that movement input ran through the command processor (that processor would then just handle input for the ingame actions/attacks) since it already handles movement with a game pad. I haven't decided yet and I want to look at that class more before I decide. 
 * I added the initial scripts for implementing the command pattern but haven't built them out yet. [ISSUE #5]
 * Brought in the place holder sprite for the player.
  
### Where I Left Off
 * I had just added the scripts and folders for implementing the command pattern to the project
  
### Next Steps
 * Continue implementing the command pattern
 * Start building out the player class
  
## 26 February 2024 | 13:36
### Check In
 * The project files have been created and currently run the way they should (displaying plain old corn flower blue).
 * Had some issues with Windows not allowing the project to build the dotnet-tools.json files, but that has been fixed.
  
### Goals
 * Bring in old scripts from the Emoji joy project [DONE]
 * Implement the timed input system from the Emoji Joy project [DONE]
 * Build out the player class
 * Build out structure for command pattern [STARTED]
