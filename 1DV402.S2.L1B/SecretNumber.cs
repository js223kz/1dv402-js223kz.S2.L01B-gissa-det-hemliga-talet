using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        //gjorda gissningar
        private int[] _guessedNumbers;
       
        //hemliga talet
        private int _number;
       
        //max antalet tillåtna gissningar
        public const int MaxNumberOfGuesses = 7;

        //Egna fält jag deklarerat för att hantera egenskaperna
        private bool _canMakeGuess;
        private int _count;
        private int _guessesLeft;

        //Ok att gissa?
         public bool CanMakeGuess {
             get
             {
                 return _canMakeGuess;  
             }
             private set {//_count eller Count här spelar det roll?
                 if (_count == MaxNumberOfGuesses)
                 {
                     _canMakeGuess = false;
                 }
                 if (_guessesLeft > 0)
                 {
                     _canMakeGuess = true;
                 }
                
               _canMakeGuess = value;
            }
          }

         public int Count
         {
             get
             {
                 return _count;
             }
            private set
             {
                 if (_count > MaxNumberOfGuesses)
                 {
                     throw new ApplicationException();
                 }
                 _count = value; 
             }
         }
        //Varför behövs den här??
         public readonly int GuessesLeft;
        

         public void Initialize()
         {
             Random randomNumber = new Random();
             _number = randomNumber.Next(1, 100);
                 
                if (_number < 1 || _number >= 100)
                 {
                     throw new ArgumentException();
                 }

             Count = 0;
             CanMakeGuess = true;

             _guessedNumbers = new []{0, 0, 0, 0, 0, 0, 0} ;
             
         }

         public SecretNumber()
         {
             _guessedNumbers = new int[MaxNumberOfGuesses];
             GuessesLeft = MaxNumberOfGuesses;
             Initialize();
         }
     
        //Gissa talet
        public bool MakeGuess(int number){
            _canMakeGuess = true;
            int index = 0;
            bool isGuessRight = false;

            for (index = 0; index < MaxNumberOfGuesses; index++)
            {
                _guessedNumbers[index] = number;
            }
            
            /*foreach (var item in _guessedNumbers)
                    {
                        if (_guessedNumbers[item] == number)
                        {
                            Console.WriteLine("Du har redan gissat på {0} ", number);
                        }
                    }*/

                do
                {
                    _count++;
                    _guessesLeft = MaxNumberOfGuesses - _count;
                    

                    if (number < 1 || number > 100)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    if (number == _number)
                    {
                        Console.WriteLine(" Du har gissat rätt! {0} är rätt nummer!", _number);
                        isGuessRight = true;
                    }
                    else if (number < _number)
                    {
                        Console.WriteLine("{0} är ett för lågt nummer Du har {1} gissningar kvar", number, _guessesLeft);
                    }
                    else if (number > _number)
                    {
                        Console.WriteLine("{0} är ett för högt nummer. Du har {1} gissningar kvar", number, _guessesLeft);
                    }
                    else
                    {
                    }

                    if (isGuessRight == false && _count == 6)
                    {
                        Console.WriteLine("Rätt nummer är {0} ", _number);
                        _canMakeGuess = false;

                    }

                   
                    

                } while (_guessesLeft > 0);

                return _canMakeGuess;
            
        }
       
   }
}
