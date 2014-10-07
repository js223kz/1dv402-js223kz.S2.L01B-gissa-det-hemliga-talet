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
             private set {
                 _canMakeGuess = value;
            }
          }  
        
     
        //Gissa talet
        public bool MakeGuess(int number){
            _canMakeGuess = true;

            do
            {
                _count++;
                _guessesLeft = MaxNumberOfGuesses - _count;
                _guessedNumbers[_count] = number;

                if (_guessedNumbers[_count] < 1 || _guessedNumbers[_count] > 100){
                    throw new ArgumentOutOfRangeException();
                }

                if (number == _number){
                    Console.WriteLine(" Du har gissat rätt! {0} är rätt nummer!", _number);
                    _canMakeGuess = false;
                }
                else if (number < _number){
                    Console.WriteLine("{0} är ett för lågt nummer Du har {1} gissningar kvar", number, _guessesLeft);
                }
                else if (number > _number){
                    Console.WriteLine("{0} är ett för högt nummer. Du har {1} gissningar kvar", number, _guessesLeft);
                }
                else
                {
                }

                if (_canMakeGuess == false && _count == 7){

                    Console.WriteLine("Rätt nummer är {0} ", _number);
                }
                
            
            } while (_guessesLeft > 0);
            
            return _canMakeGuess;  
            
        }
       
   }
}
