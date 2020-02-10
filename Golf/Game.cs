using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Golf.Entitys;
using Golf.Levels.Lvs;

namespace Golf
{
    internal class Game
    {
        private enum Power
        {
            Increment,
            decement
        }

        //Private Props Initialization
        /// <summary>
        /// The distance between the Golfball and Golfhole.
        /// </summary>
        private double Distance { get; set; }

        public int MyPower { get; private set; }

        private const double angleMax = 379;
        private const double angleMin = 0.01;


        //Private Feaild Initialization
        private double angle;
        private double angleOfTheRadious;
        private int    swingsMade;
        private bool   gameWon;
        private bool   validAngle;
        private bool swingedGolfClub;

        GolfBall golfBall = new GolfBall();
        Toturial toturial = new Toturial();
        internal Game()
        {
            golfBall.SetPosition(toturial.GetGolfBallStartPosition());
            Console.CursorVisible = false;
        }

        public void RunGame()
        {
            PrintGameControles();
            while (gameWon == false)
            {
                GameControles();
                if (swingedGolfClub == true)
                {
                    CalculateTheAngleOfTheRadius();
                    CalculateDistance();

                    if (golfBall.getPosition() != toturial.GetGolfHoleStartPosition())
                    {
                        if (golfBall.getPosition() > toturial.GetGolfHoleStartPosition())
                        {

                        }
                        else if (golfBall.getPosition() < toturial.GetGolfHoleStartPosition())
                        {

                        }
                        else
                        {
                            Console.WriteLine("Someting Went wrong with the ditsance");
                            Thread.Sleep(60000);// Paused 60s
                            Console.SetCursorPosition(50, 50);
                            swingedGolfClub = false;
                        }
                    }
                    else
                    {
                        gameWon = true;
                        Console.SetCursorPosition(25, 0);
                        Console.WriteLine("You Win!!!");
                        Thread.Sleep(60000);// Paused 60s
                    }
                }
                
            }
        }
        private void CalculateTheAngleOfTheRadius()
        {
            angleOfTheRadious = (Math.PI / 180 ) * angle;
        }
        private void CalculateDistance()
        {
            double velocity = 45;
            Distance = (Math.Pow(velocity, 2) / toturial.GetGravity() * Math.Sin(2 * angleOfTheRadious));
        }



        private void GameControles()
        {
            Console.SetCursorPosition(70, 3);
            ConsoleKeyInfo cki;
            cki = Console.ReadKey();
            //ArrowUP,   PageUP
            if ((cki.Key.GetHashCode() == 38) && ((cki.Modifiers & ConsoleModifiers.Control) != 0) && ((cki.Modifiers & ConsoleModifiers.Shift)   != 0))
            {
                angle += 0.01;
                MyPower = (int)Power.Increment;
                AngleValidation();
            }
            else if ((cki.Key.GetHashCode() == 38) && ((cki.Modifiers & ConsoleModifiers.Control) != 0))
            {
                angle += 0.1;
                MyPower = (int)Power.Increment;
                AngleValidation();
            }
            else if ((cki.Key.GetHashCode() == 38))
            {
                angle += 1;
                MyPower = (int)Power.Increment;
                AngleValidation();
            }
   
            //ArrowDOWN, PageDOWN
            else if ((cki.Key.GetHashCode() == 40)
                && ((cki.Modifiers & ConsoleModifiers.Control) != 0)
                && ((cki.Modifiers & ConsoleModifiers.Shift) != 0))
            {
                angle -= -0.01;
                MyPower = (int)Power.decement;
                AngleValidation();
            }
            else if ((cki.Key.GetHashCode() == 40) && ((cki.Modifiers & ConsoleModifiers.Control) != 0))
            {
                angle -= 0.1;
                MyPower = (int)Power.decement;
                AngleValidation();
            }
            else if ((cki.Key.GetHashCode() == 40))
            {
                angle -= 1;
                MyPower = (int)Power.decement;
                AngleValidation();
            }

            //Swing
            else if (cki.GetHashCode() == 32)
            {
                swingedGolfClub = true;
            }

            void AngleValidation()
            {
                if (MyPower == (int)Power.Increment)
                {
                    if (angle > angleMax)
                        angle = angleMax - 1;
                    Console.SetCursorPosition(70, 3);
                    Console.WriteLine("           ");
                }
                else if (MyPower == (int)Power.decement)
                {
                    if (angle < angleMin)
                        angle = 0.01;
                    Console.SetCursorPosition(70, 3);
                    Console.WriteLine("           ");
                }
                Console.SetCursorPosition(70, 3);
                Console.WriteLine($"Your swing Angle: {angle}");
                Console.SetCursorPosition(90 , 3);
            }
        }

        private void PrintGameControles()
        {
            Console.WriteLine("Game Controles");
            Console.WriteLine("Press space to throw the ball.");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("UpArrow:                Angle + 1");
            Console.WriteLine("Ctrl + UpArrow:         Angle + 0.1");
            Console.WriteLine("Ctrl + Shift + UpArrow: Angle + 0.01");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("DownArrow:                Angle - 1");
            Console.WriteLine("Ctrl + UpArrow:           Angle - 0.1");
            Console.WriteLine("Ctrl + Shift + DownArrow: Angle - 0.01");
            Console.WriteLine(Environment.NewLine);
        }

        private void ValidateAngleY()
        {
            string _Ipt;
            if (validAngle == false)
            {
                Console.SetCursorPosition(70, 0);
                Console.WriteLine("           ");
                Console.SetCursorPosition(70, 0);
                _Ipt = Console.ReadLine();
                double.TryParse(_Ipt, result: out angle);

                if (angle >= 1.01 || angle <= 387)
                    validAngle = true;
                else
                    validAngle = false;
            }
        }
    }
}
