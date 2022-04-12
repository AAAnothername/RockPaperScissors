using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RockPaperScissor
{
	internal class RPS
	{
		public static void Main()
		{
		    //Stats		    	
		    int iPaper = 0;
		    int iRock = 0;
		    int iScissor = 0;
		    int iLosses = 0;
		    int iWins = 0;
		    int iDraws = 0;
		    int iPlayed = 0;
			_BeginAnew:
			bool fromEnd = false;
			bool Active = false;
			bool GameDone = false;
			bool Selected = false;
			bool displaying = false;
			int x = 0;
			var PlayAgain = "blank";
			var AiChoice = "blank";
			var PlayerSelection = "blank";

			//1 = lose, 2= draw, 3 =win
			_DetermineAiChoice:
			if (GameDone == true)
			{
				if (x == 1)
				{
					if (PlayerSelection == "Rock")
					{
						AiChoice = "paper";
					}
					else if (PlayerSelection == "Paper")
					{
						AiChoice = "scissors";
					}
					else if (PlayerSelection == "Scissors")
					{
						AiChoice = "rock";
					}
					else
					{
						AiChoice = "ERROR";
					}
				}
				else if (x == 2)
				{
					if (PlayerSelection == "Rock")
					{
						AiChoice = "rock";
					}
					else if (PlayerSelection == "Paper")
					{
						AiChoice = "paper";
					}
					else if (PlayerSelection == "Scissors")
					{
						AiChoice = "scissors";
					}
					else
					{
						AiChoice = "ERROR";
					}
				}
				else if (x == 3)
				{
					if (PlayerSelection == "Rock")
					{
						AiChoice = "scissors";
					}
					else if (PlayerSelection == "Paper")
					{
						AiChoice = "rock";
					}
					else if (PlayerSelection == "Scissors")
					{
						AiChoice = "paper";
					}
					else
					{
						AiChoice = "ERROR";
					}
				}
				goto _ContinueEnd;
			}
			
			_DisplayStats:
			if ((displaying == true) && (Selected == true))
			{
			    Thread.Sleep(1500);
			    Console.WriteLine("-RESULTS-");
				Console.WriteLine("Losses: " + iLosses);
				Console.WriteLine("Wins: " + iWins);
				Console.WriteLine("Draws: " + iDraws);
				Console.WriteLine();
				Console.WriteLine("-SELECTION-");
				Console.WriteLine("Rock: " + iRock);
				Console.WriteLine("Paper: " + iPaper);
				Console.WriteLine("Scissor: " + iScissor);
				Console.WriteLine();
				Console.WriteLine("-OTHER-");
				Console.WriteLine("Times Played: " + iPlayed);
				Console.WriteLine();
				if (fromEnd == false)
				{
				Console.WriteLine("Press Enter to return");
				Console.ReadLine();
				Console.WriteLine();
				goto _InputRequest;
				}
				else 
				{
				    goto _PlayAgainQ;
				}
			}
			
			_InputChecker:
			if ((Active == true) && (Selected == true))
			{
				if ((PlayerSelection == "Rock"))
				{
				    iRock += 1;
					Console.WriteLine("Rock Confirmed.");
					goto _RPS;
				}
				else if ((PlayerSelection == "Paper"))
				{
				    iPaper += 1;
					Console.WriteLine("Paper Confirmed.");
					goto _RPS;
				}
				else if ((PlayerSelection == "Scissors"))
				{
				    iScissor += 1;
					Console.WriteLine("Scissors Confirmed.");
					goto _RPS;
				}
				else if ((PlayerSelection == "Stats"))
				{
					Console.WriteLine("Displaying Stats, please wait . . .");
					displaying = true;
					goto _DisplayStats;
				}
				else
				{
					Console.WriteLine("Invalid Input.");
					Thread.Sleep(500);
					goto _InputRequest;
				}
			}

			Active = true;
			Console.WriteLine("Welcome to Rock Paper Scissors!");
			 _InputRequest:
			Console.WriteLine("Please type out 'Rock', 'Paper' or 'Scissors'.");
			Console.WriteLine("Alternatively, type out 'Stats' for your statistics.");

			
			Console.WriteLine(); 
			PlayerSelection = Console.ReadLine();
			Selected = true;
			Console.WriteLine();
			Console.WriteLine("You chose: " + PlayerSelection);
			Console.WriteLine("Please wait...");
			Console.WriteLine();
			Thread.Sleep(3000);
			goto _InputChecker;

		_RPS:
			Console.WriteLine("AI is choosing, please wait . . .");
			Thread.Sleep(2310);
			Console.WriteLine();
			Random r = new Random(Guid.NewGuid().GetHashCode());
			x = r.Next(1, 4);
			GameDone = true;
			goto _DetermineAiChoice;
			_ContinueEnd:
			if (x == 1) //lose
			{
				Console.WriteLine("AI picked " + AiChoice + ", you lose.");
				iLosses += 1;
				iPlayed += 1;
			}
			else if (x == 2) //draw
			{
				Console.WriteLine("AI picked " + AiChoice + ", it's a draw.");
				iDraws += 1;
				iPlayed += 1;
			}
			else if (x == 3) //win
			{
				Console.WriteLine("AI picked " + AiChoice + ", you win.");
				iWins += 1;
				iPlayed += 1;
			}
			else
			{
				Console.WriteLine("ERROR");
			}
			Thread.Sleep(2000);
			_PlayAgainQ:
			Console.WriteLine();
			Console.WriteLine("Play again?");
			Console.WriteLine("Y/N");
			Console.WriteLine("Or 'Stats' for statistics");
			Console.WriteLine();
			PlayAgain = Console.ReadLine();
			Console.WriteLine();
			if ((PlayAgain == "Y") || (PlayAgain == "y"))
			{
				Console.WriteLine("Confirmed. Loading another round, please wait . . .");
				Thread.Sleep(1500);
				Console.WriteLine();
				goto _BeginAnew;
			}
			else if ((PlayAgain == "N") || (PlayAgain == "n"))
			{
				Console.WriteLine("Confirmed. Shutting down, please wait . . .");
				Thread.Sleep(1500);
				System.Environment.Exit(0);
			}
			else if (PlayAgain == "Stats")
			{
			    displaying = true;
			    fromEnd = true;
			    goto _DisplayStats;
			}
			else
			{
				Console.WriteLine("Invalid Input.");
				goto _PlayAgainQ;
			}
			Console.ReadLine(); //exists to prevent insta-shutdown
		}
	}
}
