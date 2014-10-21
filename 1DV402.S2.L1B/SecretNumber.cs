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


        //Ok att gissa?
        public bool CanMakeGuess
        {
            get
            {
               if (Count == MaxNumberOfGuesses)
                {
                    return false;
                }
                if (_guessedNumbers.Contains(_number))
                {
                    return false;
                }

                return true;
            }
        }

        public int Count { get; private set; }

        //Gissningar kvar
        public int GuessesLeft
        {
            get
            {
                return MaxNumberOfGuesses - Count;
            }
        }

        //Initiera ny spelomgång
        public void Initialize()
        {
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 100);

            if (_number < 1 || _number >= 100)
            {
                throw new ArgumentException();
            }

            Count = 0;
            Array.Clear(_guessedNumbers, 0, MaxNumberOfGuesses);
        }

        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }

        //Gissa talet
        public bool MakeGuess(int number)
        {

            bool guessIsRight = false;

                if(Count == MaxNumberOfGuesses)
                {
                    throw new ApplicationException(); 
                }

                if (number < 1 || number > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                
                if (!CanMakeGuess)
                {
                    guessIsRight = false;
                }
                else if (_guessedNumbers.Contains(number))
                {
                    Console.WriteLine("Du har redan gissat på nummer {0}. Gissa igen", number);
                    guessIsRight = false;
                }
                else if (number == _number)
                {
                    _guessedNumbers[Count] = number;
                    Count++;
                    Console.WriteLine(" Du har gissat rätt! {0} är rätt nummer!", _number);
                    guessIsRight = true;
                }
                else if (number < _number)
                {
                    _guessedNumbers[Count] = number;
                    Count++;
                    Console.WriteLine("{0} är ett för lågt nummer Du har {1} gissningar kvar", number, GuessesLeft);
                    guessIsRight = false;
                }
                else if (number > _number)
                {
                    _guessedNumbers[Count] = number;
                    Count++;
                    Console.WriteLine("{0} är ett för högt nummer. Du har {1} gissningar kvar", number, GuessesLeft);
                    guessIsRight = false;
                }
                else
                {
                }

                if (Count == MaxNumberOfGuesses && guessIsRight == false)
                {
                    Console.WriteLine("Rätt nummer är {0} ", _number);
                }
            
            return guessIsRight;
        }

    }
}
