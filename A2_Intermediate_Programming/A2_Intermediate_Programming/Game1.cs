///Author: Vibeesshanan Thevamanoharan
///Project Name: A2_Intermediate_Programming
///File Name: Game 1
///Creation Date: November 9th 2017
///Modified Date: November 15th 2017
///Description: Allows user to play the classical 2-Player Snakes and Ladders game
///while also displaying a variety of player information on the side.
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace A2_Intermediate_Programming
{
    /// This is the main type for your game
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Images
        Texture2D background;
        Rectangle backgroundRec;
        Texture2D roll;
        Rectangle rollRec;
        //Player Icons
        Texture2D player1Icon;
        Rectangle player1IconRec;
        Texture2D player2Icon;
        Rectangle player2IconRec;

        //Fonts
        SpriteFont playerInfo;
        SpriteFont newGame;
        Vector2 newGameLoc = new Vector2(820, 600);
        Vector2 playerInfoLoc = new Vector2(820, 300);
        SpriteFont playerRollVal;
        Vector2 playerRollLoc = new Vector2(900, 250);
        Vector2 winGameLoc = new Vector2(800, 10);
        SpriteFont winGame;

        //Mouse Variables;
        MouseState mouse;
        MouseState prevmouse;
        float mouseXLoc = 0.0f;
        float mouseYLoc = 0.0f;
        Vector2 mouseXY = new Vector2(1090, 678);

        //Keyboard Variables
        KeyboardState kb;
        KeyboardState prevkb;

        //Dice Roll
        Random randomDice = new Random();
        int diceNumber;
        Random pTurn = new Random();

        //Stats Variables
        double gamesPlayed;
        double player1Wins;
        double player2Wins;
        double Player1WinPer;
        double Player2WinPer;
        int player1Rolls = 0;
        int player2Rolls = 0;
        double p1AvgRolls = 0;
        double player1AvgRolls = 0;
        double p2AvgRolls = 0;
        double player2AvgRolls = 0;

        //Player Space
        int player1CurrentSpace = 0;
        int player2CurrentSpace = 0;

        //Boardspaces,Ladders, and snakes Arrays
        Vector2[] BoardSpace = new Vector2[105];
        Vector2 [] SpecialSpaces = new Vector2 [10];
        Vector2 [] EndSpaces = new Vector2 [10];

 

        //Player turn
        bool player1Turn = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            //Board Spaces # 1-10
            BoardSpace[0] = new Vector2(30, 665);
            BoardSpace[1] = new Vector2(108, 665);
            BoardSpace[2] = new Vector2(186, 665);
            BoardSpace[3] = new Vector2(264, 665);
            BoardSpace[4] = new Vector2(342, 665);
            BoardSpace[5] = new Vector2(420, 665);
            BoardSpace[6] = new Vector2(498, 665);
            BoardSpace[7] = new Vector2(576, 665);
            BoardSpace[8] = new Vector2(654, 665);
            BoardSpace[9] = new Vector2(732, 665);

            //Board Spaces # 11-20
            BoardSpace[10] = new Vector2(732, 595);
            BoardSpace[11] = new Vector2(654, 595);
            BoardSpace[12] = new Vector2(576, 595);
            BoardSpace[13] = new Vector2(498, 595);
            BoardSpace[14] = new Vector2(420, 595);
            BoardSpace[15] = new Vector2(342, 595);
            BoardSpace[16] = new Vector2(264, 595);
            BoardSpace[17] = new Vector2(186, 595);
            BoardSpace[18] = new Vector2(108, 595);
            BoardSpace[19] = new Vector2(30, 595);

            //Board Spaces # 21-30
            BoardSpace[20] = new Vector2(30, 525);
            BoardSpace[21] = new Vector2(108, 525);
            BoardSpace[22] = new Vector2(186, 525);
            BoardSpace[23] = new Vector2(264, 525);
            BoardSpace[24] = new Vector2(342, 525);
            BoardSpace[25] = new Vector2(420, 525);
            BoardSpace[26] = new Vector2(498, 525);
            BoardSpace[27] = new Vector2(576, 525);
            BoardSpace[28] = new Vector2(654, 525);
            BoardSpace[29] = new Vector2(732, 525);

            //Board Spaces # 31-40
            BoardSpace[30] = new Vector2(732, 455);
            BoardSpace[31] = new Vector2(654, 455);
            BoardSpace[32] = new Vector2(576, 455);
            BoardSpace[33] = new Vector2(498, 455);
            BoardSpace[34] = new Vector2(420, 455);
            BoardSpace[35] = new Vector2(342, 455);
            BoardSpace[36] = new Vector2(264, 455);
            BoardSpace[37] = new Vector2(186, 455);
            BoardSpace[38] = new Vector2(108, 455);
            BoardSpace[39] = new Vector2(30, 455);

            //Board Spaces # 41-50
            BoardSpace[40] = new Vector2(30, 385);
            BoardSpace[41] = new Vector2(108, 385);
            BoardSpace[42] = new Vector2(186, 385);
            BoardSpace[43] = new Vector2(264, 385);
            BoardSpace[44] = new Vector2(342, 385);
            BoardSpace[45] = new Vector2(420, 385);
            BoardSpace[46] = new Vector2(498, 385);
            BoardSpace[47] = new Vector2(576, 385);
            BoardSpace[48] = new Vector2(654, 385);
            BoardSpace[49] = new Vector2(732, 385);

            //Board Spaces # 51-60
            BoardSpace[50] = new Vector2(732, 315);
            BoardSpace[51] = new Vector2(654, 315);
            BoardSpace[52] = new Vector2(576, 315);
            BoardSpace[53] = new Vector2(498, 315);
            BoardSpace[54] = new Vector2(420, 315);
            BoardSpace[55] = new Vector2(342, 315);
            BoardSpace[56] = new Vector2(264, 315);
            BoardSpace[57] = new Vector2(186, 315);
            BoardSpace[58] = new Vector2(108, 315);
            BoardSpace[59] = new Vector2(30, 315);

            //Board Spaces # 61-70
            BoardSpace[60] = new Vector2(30, 245);
            BoardSpace[61] = new Vector2(108, 245);
            BoardSpace[62] = new Vector2(186, 245);
            BoardSpace[63] = new Vector2(264, 245);
            BoardSpace[64] = new Vector2(342, 245);
            BoardSpace[65] = new Vector2(420, 245);
            BoardSpace[66] = new Vector2(498, 245);
            BoardSpace[67] = new Vector2(576, 245);
            BoardSpace[68] = new Vector2(654, 245);
            BoardSpace[69] = new Vector2(732, 245);

            //Board Spaces # 71-80
            BoardSpace[70] = new Vector2(732, 175);
            BoardSpace[71] = new Vector2(654, 175);
            BoardSpace[72] = new Vector2(576, 175);
            BoardSpace[73] = new Vector2(498, 175);
            BoardSpace[74] = new Vector2(420, 175);
            BoardSpace[75] = new Vector2(342, 175);
            BoardSpace[76] = new Vector2(264, 175);
            BoardSpace[77] = new Vector2(186, 175);
            BoardSpace[78] = new Vector2(108, 175);
            BoardSpace[79] = new Vector2(30, 175);

            //Board Spaces # 81-90
            BoardSpace[80] = new Vector2(30, 105);
            BoardSpace[81] = new Vector2(108, 105);
            BoardSpace[82] = new Vector2(186, 105);
            BoardSpace[83] = new Vector2(264, 105);
            BoardSpace[84] = new Vector2(342, 105);
            BoardSpace[85] = new Vector2(420, 105);
            BoardSpace[86] = new Vector2(498, 105);
            BoardSpace[87] = new Vector2(576, 105);
            BoardSpace[88] = new Vector2(654, 105);
            BoardSpace[89] = new Vector2(732, 105);

            //Board Spaces # 91-100
            BoardSpace[90] = new Vector2(732, 35);
            BoardSpace[91] = new Vector2(654, 35);
            BoardSpace[92] = new Vector2(576, 35);
            BoardSpace[93] = new Vector2(498, 35);
            BoardSpace[94] = new Vector2(420, 35);
            BoardSpace[95] = new Vector2(342, 35);
            BoardSpace[96] = new Vector2(264, 35);
            BoardSpace[97] = new Vector2(186, 35);
            BoardSpace[98] = new Vector2(108, 35);
            BoardSpace[99] = new Vector2(30, 35);

            SpecialSpaces[0] = new Vector2(264, 665); // Ladder on space 4
            SpecialSpaces[1] = new Vector2(420, 525); // Ladder on space 26
            SpecialSpaces[2] = new Vector2(576, 455); // Ladder on space 33
            SpecialSpaces[3] = new Vector2(108, 315); // Ladder on space 59
            SpecialSpaces[4] = new Vector2(576, 175); // Ladder on space 73
            SpecialSpaces[5] = new Vector2(732, 525); // Snake on space 30 
            SpecialSpaces[6] = new Vector2(342, 455); // Snake on space 36
            SpecialSpaces[7] = new Vector2(732, 245); // Snake on space 70 
            SpecialSpaces[8] = new Vector2(420, 105); // Snake on space 86
            SpecialSpaces[9] = new Vector2(108, 35); // Snake on space 99

            EndSpaces[0] = new Vector2(108, 455); // Ladder ending on space 39
            EndSpaces[1] = new Vector2(420, 175); // Ladder ending on space 75
            EndSpaces[2] = new Vector2(654, 315); // Ladder ending on space 52
            EndSpaces[3] = new Vector2(186, 245); // Ladder ending on space 63
            EndSpaces[4] = new Vector2(576, 35); // Ladder ending on space 93
            EndSpaces[5] = new Vector2(654, 595); // Snake ending on Space 12
            EndSpaces[6] = new Vector2(576, 665); //  Snake ending on Space 8
            EndSpaces[7] = new Vector2(732, 385); //  Snake ending on Space 50
            EndSpaces[8] = new Vector2(264, 315); //  Snake ending on Space 57
            EndSpaces[9] = new Vector2(108, 385); //  Snake ending on Space 42

            //Extra spaces past boardspace 100
            BoardSpace[100] = new Vector2(-48, 35);
            BoardSpace[101] = new Vector2(-126, 35);
            BoardSpace[102] = new Vector2(-204, 35);
            BoardSpace[103] = new Vector2(-282, 35);
            BoardSpace[104] = new Vector2(-360, 35);
            //Makes Mouse Visible
            this.IsMouseVisible = true;

            //Changes the dimensions of the program
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();

            //Randomizes the player turns
            player1Turn = pTurn.Next(2) == 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Width and Height variables for image resizing
            int width = (this.graphics.GraphicsDevice.Viewport.Width);
            int height = (this.graphics.GraphicsDevice.Viewport.Height);
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Game images Content.Load
            background = Content.Load<Texture2D>(@"Images\Backgrounds\Board");
            roll = Content.Load<Texture2D>(@"Images\Sprites\Dice Roll");
            player1Icon = Content.Load<Texture2D>(@"Images\Sprites\Player1Mouse");
            player2Icon = Content.Load<Texture2D>(@"Images\Sprites\Player2Mouse");

            //Game image rectangles
            rollRec = new Rectangle(900, 125, (int)(width * 0.15), (int)(height * 0.15));
            backgroundRec = new Rectangle(0, 0, (int)(width * 0.65), (int)(height * 1));
            //PlayerIcon Rectangles
            player1IconRec = new Rectangle(1, 650, (int)(width * 0.03), (int)(height * 0.05));
            player2IconRec = new Rectangle(22, 650, (int)(width * 0.03), (int)(height * 0.05));

            //Spritefonts Content.Load
            playerInfo = Content.Load<SpriteFont>(@"Fonts\InfoFont");
            playerRollVal = Content.Load<SpriteFont>(@"Fonts\InfoFont");
            newGame = Content.Load<SpriteFont>(@"Fonts\Newgame");
            winGame = Content.Load<SpriteFont>(@"Fonts\WinGame");

        }
        
        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            //Getstate variables
            mouse = Mouse.GetState();
            kb = Keyboard.GetState();
            mouseXLoc = Mouse.GetState().X;
            mouseYLoc = Mouse.GetState().Y;

            // Allows the game to exit
            if (mouse.RightButton == ButtonState.Pressed || kb.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            //When N key or New game Button is pressed a new game is started
            if (kb.IsKeyDown(Keys.N) && prevkb.IsKeyUp(Keys.N) || mouse.LeftButton == ButtonState.Pressed && prevmouse.LeftButton == ButtonState.Released &&
                (mouseXLoc >= 820 && mouseXLoc <= 1040 && mouseYLoc >= 600 && mouseYLoc <= 640))
            {
                //Sets player 1 icon back to 1st Boardspace
                player1IconRec.X = (Int32)BoardSpace[0].X - 25;
                player1IconRec.Y = (Int32)BoardSpace[0].Y - 25;
                //Sets player 2 icon back to 1st Boardspace
                player2IconRec.X = (Int32)BoardSpace[0].X;
                player2IconRec.Y = (Int32)BoardSpace[0].Y;

                //Resests all the roll stats
                player1Rolls = 0;
                player2Rolls = 0;
                player1AvgRolls = 0;
                player2AvgRolls = 0;
                p1AvgRolls = 0;
                p2AvgRolls = 0;

                //Sets player space back to 1st BorardSpace
                player1CurrentSpace = 0;
                player2CurrentSpace = 0;
            }

            //Roll function using Space and Click
            if (kb.IsKeyDown(Keys.Space) && prevkb.IsKeyUp(Keys.Space) || mouse.LeftButton == ButtonState.Pressed && prevmouse.LeftButton == ButtonState.Released &&
                (mouseXLoc >= 900 && mouseXLoc <= 1050 && mouseYLoc >= 125 && mouseYLoc <= 225))
            {
                //Player 1
                if (player1Turn == true)
                {
                    diceNumber = randomDice.Next(1,7); 
                    player1Rolls = player1Rolls + 1;

                    //Average roll value of player 1
                    p1AvgRolls = Math.Round(p1AvgRolls + diceNumber, 1);
                    player1AvgRolls = Math.Round(p1AvgRolls / player1Rolls, 1);

                    //Allows the player space to move depending on the roll of the dice
                    player1CurrentSpace += diceNumber;
                    player1IconRec.X = (Int32)BoardSpace[player1CurrentSpace].X;

                    player1IconRec.Y = (Int32)BoardSpace[player1CurrentSpace].Y;

                    if ((player1IconRec.X == SpecialSpaces[0].X) && player1IconRec.Y == SpecialSpaces[0].Y)
                    {
                         player1IconRec.X = (Int32)EndSpaces[0].X;
                         player1IconRec.Y = (Int32)EndSpaces[0].Y;
                         player1CurrentSpace = 38;
                     }
                    else if ((player1IconRec.X == SpecialSpaces[1].X) && player1IconRec.Y == SpecialSpaces[1].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[1].X;
                        player1IconRec.Y = (Int32)EndSpaces[1].Y;
                        player1CurrentSpace = 74;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[2].X) && player1IconRec.Y == SpecialSpaces[2].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[2].X;
                        player1IconRec.Y = (Int32)EndSpaces[2].Y;
                        player1CurrentSpace = 51;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[3].X) && player1IconRec.Y == SpecialSpaces[3].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[3].X;
                        player1IconRec.Y = (Int32)EndSpaces[3].Y;
                        player1CurrentSpace = 62;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[4].X) && player1IconRec.Y == SpecialSpaces[4].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[4].X;
                        player1IconRec.Y = (Int32)EndSpaces[4].Y;
                        player1CurrentSpace = 92;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[5].X) && player1IconRec.Y == SpecialSpaces[5].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[5].X;
                        player1IconRec.Y = (Int32)EndSpaces[5].Y;
                        player1CurrentSpace = 11;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[6].X) && player1IconRec.Y == SpecialSpaces[6].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[6].X;
                        player1IconRec.Y = (Int32)EndSpaces[6].Y;
                        player1CurrentSpace = 7;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[7].X) && player1IconRec.Y == SpecialSpaces[7].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[7].X;
                        player1IconRec.Y = (Int32)EndSpaces[7].Y;
                        player1CurrentSpace = 49;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[8].X) && player1IconRec.Y == SpecialSpaces[8].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[8].X;
                        player1IconRec.Y = (Int32)EndSpaces[8].Y;
                        player1CurrentSpace = 56;
                    }
                    else if ((player1IconRec.X == SpecialSpaces[9].X) && player1IconRec.Y == SpecialSpaces[9].Y)
                    {
                        player1IconRec.X = (Int32)EndSpaces[9].X;
                        player1IconRec.Y = (Int32)EndSpaces[9].Y;
                        player1CurrentSpace = 41;
                    }
                    
                    player1Turn = false;
                }

                //Player 2
                else if (player1Turn == false)
                {
                    diceNumber = randomDice.Next(1, 7);
                    player2Rolls = player2Rolls + 1;

                    //Average roll value of player 2
                    p2AvgRolls = Math.Round(p2AvgRolls + diceNumber, 1);
                    player2AvgRolls = Math.Round(p2AvgRolls / player2Rolls, 1);

                    //Allows the player space to move depending on the roll of the dice
                    player2CurrentSpace += diceNumber;
                    player2IconRec.X = (Int32)BoardSpace[player2CurrentSpace].X;
                    player2IconRec.Y = (Int32)BoardSpace[player2CurrentSpace].Y;

                    if ((player2IconRec.X == SpecialSpaces[0].X) && player2IconRec.Y == SpecialSpaces[0].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[0].X;
                        player2IconRec.Y = (Int32)EndSpaces[0].Y;
                        player2CurrentSpace = 38;
                    }
                    if ((player2IconRec.X == SpecialSpaces[1].X) && player2IconRec.Y == SpecialSpaces[1].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[1].X;
                        player2IconRec.Y = (Int32)EndSpaces[1].Y;
                        player2CurrentSpace = 74;
                    }
                    if ((player2IconRec.X == SpecialSpaces[2].X) && player2IconRec.Y == SpecialSpaces[2].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[2].X;
                        player2IconRec.Y = (Int32)EndSpaces[2].Y;
                        player2CurrentSpace = 51;
                    }
                    if ((player2IconRec.X == SpecialSpaces[3].X) && player2IconRec.Y == SpecialSpaces[3].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[3].X;
                        player2IconRec.Y = (Int32)EndSpaces[3].Y;
                        player2CurrentSpace = 62;
                    }
                    if ((player2IconRec.X == SpecialSpaces[4].X) && player2IconRec.Y == SpecialSpaces[4].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[4].X;
                        player2IconRec.Y = (Int32)EndSpaces[4].Y;
                        player2CurrentSpace = 92;
                    }
                    if ((player2IconRec.X == SpecialSpaces[5].X) && player2IconRec.Y == SpecialSpaces[5].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[5].X;
                        player2IconRec.Y = (Int32)EndSpaces[5].Y;
                        player2CurrentSpace = 11;
                    }
                    if ((player2IconRec.X == SpecialSpaces[6].X) && player2IconRec.Y == SpecialSpaces[6].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[6].X;
                        player2IconRec.Y = (Int32)EndSpaces[6].Y;
                        player2CurrentSpace = 7;
                    }
                    if ((player2IconRec.X == SpecialSpaces[7].X) && player2IconRec.Y == SpecialSpaces[7].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[7].X;
                        player2IconRec.Y = (Int32)EndSpaces[7].Y;
                        player2CurrentSpace = 49;
                    }
                    if ((player2IconRec.X == SpecialSpaces[8].X) && player2IconRec.Y == SpecialSpaces[8].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[8].X;
                        player2IconRec.Y = (Int32)EndSpaces[8].Y;
                        player2CurrentSpace = 56;
                    }
                    if ((player2IconRec.X == SpecialSpaces[9].X) && player2IconRec.Y == SpecialSpaces[9].Y)
                    {
                        player2IconRec.X = (Int32)EndSpaces[9].X;
                        player2IconRec.Y = (Int32)EndSpaces[9].Y;
                        player2CurrentSpace = 41;
                    }
                   
                     player1Turn = true;
                }
            }


            base.Update(gameTime);

            //Sets the previous Mouse and Keyboard variables back to the original variables
            prevmouse = mouse;
            prevkb = kb;
        }
        
        protected override void Draw(GameTime gameTime)
        {
            //Color of Background
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            //Background and Dice images
            spriteBatch.Draw(background, backgroundRec, Color.White);
            spriteBatch.Draw(roll, rollRec, Color.White);
            
            //Statistics display
            spriteBatch.DrawString(playerInfo, "Snakes and Ladders Player Information:\n\n" + "Total Number of Games Played: " + gamesPlayed +
                                               "\nPlayer 1 Wins: " + player1Wins +  "\nPlayer 2 Wins: " + player2Wins + "\nPlayer 1 Win %: " + Player1WinPer + "\nPlayer 2 Win %: " + Player2WinPer +
                                               "\nPlayer 1 Rolls:" + player1Rolls + "\nPlayer 2 Rolls: " + player2Rolls +
                                               "\nPlayer 1 Average roll Number: " + player1AvgRolls + "\nPlayer 2 Average roll number: " 
                                               + player2AvgRolls, playerInfoLoc, Color.White);

            //Shows the coordinates of the mouse
            spriteBatch.DrawString(playerInfo, "( " + mouseXLoc + ", " + mouseYLoc + " )" , mouseXY, Color.Red);

            //Displays the user's roll
            spriteBatch.DrawString(playerRollVal, "Your Roll Number is: " + diceNumber, playerRollLoc, Color.White);

            //The two player icons
            spriteBatch.Draw(player1Icon, player1IconRec, Color.White);
            spriteBatch.Draw(player2Icon, player2IconRec, Color.White);

            WinningPlayer();

            //New game button
            spriteBatch.DrawString(newGame, " NEW GAME", newGameLoc, Color.Yellow);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void WinningPlayer()
        {

            if (player1CurrentSpace >= 99)
            {
                player1IconRec.X = (Int32)BoardSpace[0].X - 25;
                player1IconRec.Y = (Int32)BoardSpace[0].Y - 25;

                player2IconRec.X = (Int32)BoardSpace[0].X;
                player2IconRec.Y = (Int32)BoardSpace[0].Y;

                gamesPlayed++;
                player1Wins++;

                Player1WinPer = Math.Round((player1Wins / gamesPlayed) * 100, 2);
                Player2WinPer = Math.Round((player2Wins / gamesPlayed) * 100, 2);

                player1Rolls = 0;
                player2Rolls = 0;
                player1AvgRolls = 0;
                player2AvgRolls = 0;
                p1AvgRolls = 0;
                p2AvgRolls = 0;


                player1CurrentSpace = 0;
                player2CurrentSpace = 0;
            }

            else if (player2CurrentSpace >= 99)
            {
                player1IconRec.X = (Int32)BoardSpace[0].X - 25;
                player1IconRec.Y = (Int32)BoardSpace[0].Y - 25;

                player2IconRec.X = (Int32)BoardSpace[0].X;
                player2IconRec.Y = (Int32)BoardSpace[0].Y;

                gamesPlayed++;
                player2Wins++;

                Player2WinPer = Math.Round((player2Wins / gamesPlayed) * 100, 2);
                Player1WinPer = Math.Round((player1Wins / gamesPlayed) * 100, 2);

                player1Rolls = 0;
                player2Rolls = 0;
                player1AvgRolls = 0;
                p1AvgRolls = 0;
                player2AvgRolls = 0;
                p2AvgRolls = 0;

                player1CurrentSpace = 0;
                player2CurrentSpace = 0;
            }
          
           }
    }
}

