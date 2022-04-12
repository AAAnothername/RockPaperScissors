using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Translation // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string languageInput = "Blank";
            string language = "English";
            Console.WriteLine("Welcome! Please type in your language to proceed.");
            Console.WriteLine("Type 'List' to list all supported languages");
            _LanguageInput:
            Console.WriteLine();
            languageInput = Console.ReadLine();
            if ((languageInput == "List") || (languageInput == "list"))
            {
                Console.WriteLine();
                Console.WriteLine("List of supported languages:");
                Console.WriteLine("EN - English - English");
                Console.WriteLine("NL - Nederlands - Dutch");
                Console.WriteLine("ES - Español - Spanish");
                goto _LanguageInput;
            }
            else if ((string.Equals(languageInput, "nl", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "nederlands", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "dutch", StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine();
                Console.WriteLine("U heeft Nederlands geselecteerd");
				language = "Dutch";
            }
            else if ((string.Equals(languageInput, "en", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "english", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "british", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "american", StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine();
                Console.WriteLine("You have selected English");
				language = "English";
            }
            else if ((string.Equals(languageInput, "es", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "espanol", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "spanish", StringComparison.CurrentCultureIgnoreCase)) || (string.Equals(languageInput, "español", StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine();
                Console.WriteLine("Has seleccionado Español");
				language = "Spanish";
            }
            else
            {
                Console.WriteLine("Invalid input.");
                goto _LanguageInput;
            }



			if (language == "English")
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
			else if (language == "Spanish")
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
						if (PlayerSelection == "Roca")
						{
							AiChoice = "papel";
						}
						else if (PlayerSelection == "Papel")
						{
							AiChoice = "tijeras";
						}
						else if (PlayerSelection == "Tijeras")
						{
							AiChoice = "roca";
						}
						else
						{
							AiChoice = "ERROR";
						}
					}
					else if (x == 2)
					{
						if (PlayerSelection == "Roca")
						{
							AiChoice = "roca";
						}
						else if (PlayerSelection == "Papel")
						{
							AiChoice = "papel";
						}
						else if (PlayerSelection == "Tijeras")
						{
							AiChoice = "tijeras";
						}
						else
						{
							AiChoice = "ERROR";
						}
					}
					else if (x == 3)
					{
						if (PlayerSelection == "Roca")
						{
							AiChoice = "tijeras";
						}
						else if (PlayerSelection == "Papel")
						{
							AiChoice = "roca";
						}
						else if (PlayerSelection == "Tijeras")
						{
							AiChoice = "papel";
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
					Console.WriteLine("-RESULTADOS-");
					Console.WriteLine("Perder: " + iLosses);
					Console.WriteLine("Ganar: " + iWins);
					Console.WriteLine("Empate: " + iDraws);
					Console.WriteLine();
					Console.WriteLine("-SELECCIÓN-");
					Console.WriteLine("Roca: " + iRock);
					Console.WriteLine("Papel: " + iPaper);
					Console.WriteLine("Tijeras: " + iScissor);
					Console.WriteLine();
					Console.WriteLine("-OTRO-");
					Console.WriteLine("Tiempos jugados: " + iPlayed);
					Console.WriteLine();
					if (fromEnd == false)
					{
						Console.WriteLine("Pulse 'Enter' para volver");
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
					if ((PlayerSelection == "Roca"))
					{
						iRock += 1;
						Console.WriteLine("Roca confirmado.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Papel"))
					{
						iPaper += 1;
						Console.WriteLine("Papel confirmado.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Tijeras"))
					{
						iScissor += 1;
						Console.WriteLine("Tijeras confirmado.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Stats"))
					{
						Console.WriteLine("Mostrando estadísticas, por favor espere . . .");
						displaying = true;
						goto _DisplayStats;
					}
					else
					{
						Console.WriteLine("Entrada no válida");
						Thread.Sleep(500);
						goto _InputRequest;
					}
				}

				Active = true;
				Console.WriteLine("¡Bienvenido a Rock Paper Scissors!");
			_InputRequest:
				Console.WriteLine("Escriba 'Roca', 'Papel' o 'Tijeras'.");
				Console.WriteLine("Alternativamente, escriba 'Stats' para sus estadísticas.");


				Console.WriteLine();
				PlayerSelection = Console.ReadLine();
				Selected = true;
				Console.WriteLine();
				Console.WriteLine("Su elección:: " + PlayerSelection);
				Console.WriteLine("Espera...");
				Console.WriteLine();
				Thread.Sleep(3000);
				goto _InputChecker;

			_RPS:
				Console.WriteLine("La IA está eligiendo, por favor espere . . .");
				Thread.Sleep(2310);
				Console.WriteLine();
				Random r = new Random(Guid.NewGuid().GetHashCode());
				x = r.Next(1, 4);
				GameDone = true;
				goto _DetermineAiChoice;
			_ContinueEnd:
				if (x == 1) //lose
				{
					Console.WriteLine("La IA escogió " + AiChoice + ", pierdes.");
					iLosses += 1;
					iPlayed += 1;
				}
				else if (x == 2) //draw
				{
					Console.WriteLine("La IA escogió " + AiChoice + ", es un empate.");
					iDraws += 1;
					iPlayed += 1;
				}
				else if (x == 3) //win
				{
					Console.WriteLine("La IA escogió " + AiChoice + ", tú ganas.");
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
				Console.WriteLine("¿Volver a jugar?");
				Console.WriteLine("Y/N");
				Console.WriteLine("O 'Stats' para estadísticas");
				Console.WriteLine();
				PlayAgain = Console.ReadLine();
				Console.WriteLine();
				if ((PlayAgain == "Y") || (PlayAgain == "y"))
				{
					Console.WriteLine("Empedernido. Cargando otra ronda, por favor espere . . .");
					Thread.Sleep(1500);
					Console.WriteLine();
					goto _BeginAnew;
				}
				else if ((PlayAgain == "N") || (PlayAgain == "n"))
				{
					Console.WriteLine("Empedernido. Apagar, por favor espere . . .");
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
					Console.WriteLine("Entrada no válida");
					goto _PlayAgainQ;
				}
				Console.ReadLine(); //exists to prevent insta-shutdown
			}
			else if (language == "Dutch")
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
						if (PlayerSelection == "Steen")
						{
							AiChoice = "papier";
						}
						else if (PlayerSelection == "Papier")
						{
							AiChoice = "schaar";
						}
						else if (PlayerSelection == "Schaar")
						{
							AiChoice = "steen";
						}
						else
						{
							AiChoice = "ERROR";
						}
					}
					else if (x == 2)
					{
						if (PlayerSelection == "Steen")
						{
							AiChoice = "steen";
						}
						else if (PlayerSelection == "Papier")
						{
							AiChoice = "papier";
						}
						else if (PlayerSelection == "Schaar")
						{
							AiChoice = "schaar";
						}
						else
						{
							AiChoice = "ERROR";
						}
					}
					else if (x == 3)
					{
						if (PlayerSelection == "Steen")
						{
							AiChoice = "schaar";
						}
						else if (PlayerSelection == "Papier")
						{
							AiChoice = "steen";
						}
						else if (PlayerSelection == "Schaar")
						{
							AiChoice = "papier";
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
					Console.WriteLine("-RESULTATEN-");
					Console.WriteLine("Verloren: " + iLosses);
					Console.WriteLine("Gewonnen: " + iWins);
					Console.WriteLine("Gelijkspel: " + iDraws);
					Console.WriteLine();
					Console.WriteLine("-SELECTIE-");
					Console.WriteLine("Steen: " + iRock);
					Console.WriteLine("Papier: " + iPaper);
					Console.WriteLine("Schaar: " + iScissor);
					Console.WriteLine();
					Console.WriteLine("-ANDER-");
					Console.WriteLine("Keer gespeeld: " + iPlayed);
					Console.WriteLine();
					if (fromEnd == false)
					{
						Console.WriteLine("Klik Enter om terug te gaan");
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
					if ((PlayerSelection == "Steen"))
					{
						iRock += 1;
						Console.WriteLine("Steen geconfirmeerd.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Papier"))
					{
						iPaper += 1;
						Console.WriteLine("Papier geconfirmeerd.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Schaar"))
					{
						iScissor += 1;
						Console.WriteLine("Schaar geconfirmeerd.");
						goto _RPS;
					}
					else if ((PlayerSelection == "Stats"))
					{
						Console.WriteLine("Statistieken laden, wacht AUB . . .");
						displaying = true;
						goto _DisplayStats;
					}
					else
					{
						Console.WriteLine("Onvaliede invoer.");
						Thread.Sleep(500);
						goto _InputRequest;
					}
				}

				Active = true;
				Console.WriteLine("Welcome bij Steen Papier Schaar!");
			_InputRequest:
				Console.WriteLine("Typ 'Steen', 'Papier' of 'Schaar'.");
				Console.WriteLine("Of typ uit 'Stats' om je statistieken te bekijken.");


				Console.WriteLine();
				PlayerSelection = Console.ReadLine();
				Selected = true;
				Console.WriteLine();
				Console.WriteLine("Je koos voor: " + PlayerSelection);
				Console.WriteLine("Wacht AUB...");
				Console.WriteLine();
				Thread.Sleep(3000);
				goto _InputChecker;

			_RPS:
				Console.WriteLine("De KI kiest, wacht AUB . . .");
				Thread.Sleep(2310);
				Console.WriteLine();
				Random r = new Random(Guid.NewGuid().GetHashCode());
				x = r.Next(1, 4);
				GameDone = true;
				goto _DetermineAiChoice;
			_ContinueEnd:
				if (x == 1) //lose
				{
					Console.WriteLine("De KI koos voor " + AiChoice + ", jij verliest.");
					iLosses += 1;
					iPlayed += 1;
				}
				else if (x == 2) //draw
				{
					Console.WriteLine("De KI koos voor " + AiChoice + ", het is gelijkspel.");
					iDraws += 1;
					iPlayed += 1;
				}
				else if (x == 3) //win
				{
					Console.WriteLine("De KI koos voor " + AiChoice + ", jij wint.");
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
				Console.WriteLine("Opnieuw spelen?");
				Console.WriteLine("Y/N");
				Console.WriteLine("Of 'Stats' voor statistieken");
				Console.WriteLine();
				PlayAgain = Console.ReadLine();
				Console.WriteLine();
				if ((PlayAgain == "Y") || (PlayAgain == "y"))
				{
					Console.WriteLine("Geconformeerd, een nieuwe ronde laden, wacht AUB . . .");
					Thread.Sleep(1500);
					Console.WriteLine();
					goto _BeginAnew;
				}
				else if ((PlayAgain == "N") || (PlayAgain == "n"))
				{
					Console.WriteLine("Geconformeerd, afsluiten, wacht AUB . . .");
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
					Console.WriteLine("Onvaliede invoer.");
					goto _PlayAgainQ;
				}
				Console.ReadLine(); //exists to prevent insta-shutdown
			}
        }
    }
}
//-
