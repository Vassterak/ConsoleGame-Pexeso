using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_Pexeso
{

    struct Position //struct is almost equal to class, but more memory efficient, it's used for smaller objects
    {
        private readonly int x;
        private readonly int y;

        public int X
        {
            get { return x; }

        }

        public int Y
        {
            get { return y; }
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class GameWorld
    {
        enum CardState
        {
            Hidden, Shown, Deleted
        }

        int revealedCards = 0;
        int numOfMoves = 0;
        int sizeOfField = 4; // square, so 4*4 = 16 cards

        char cardSkin = '#'; //this represents the visual style of card which is hidden(not visible)


        char[,] gameMap; //represents each card
        CardState[,] cardstate; //represents state of each card in gameMap
        Position flippedCard;

        public GameWorld()
        {
            gameMap = new char[sizeOfField, sizeOfField]; //contains values of cards
            cardstate = new CardState[sizeOfField, sizeOfField]; //contains states of the cards
            DealTheCards();
        }

        public GameWorld(int sizeOfField)
        {
            this.sizeOfField = sizeOfField;
            gameMap = new char[sizeOfField, sizeOfField]; //contains values of cards
            cardstate = new CardState[sizeOfField, sizeOfField]; //contains states of the cards
            DealTheCards();
        }

        private void DealTheCards() //cze: rozdat karty
        {
            Random rnd = new Random();
            ArrayList freePosition = new ArrayList();

            char cardValue = 'A'; //value of the first card pair 

            for (int x = 0; x < sizeOfField; x++) //go over all positions in game field
            {
                for (int y = 0; y < sizeOfField; y++)
                {
                    freePosition.Add(new Position(x, y)); //fill up arraylist with positions
                    cardstate[x, y] = CardState.Hidden; //set all cardstates to hidden
                }
            }

            while (freePosition.Count >= 2)
            {
                int number = rnd.Next(freePosition.Count);
                Position firstCard = (Position)freePosition[number];
                freePosition.Remove(firstCard);

                number = rnd.Next(freePosition.Count);
                Position secondCard = (Position)freePosition[number];
                freePosition.Remove(secondCard);

                gameMap[firstCard.X, firstCard.Y] = cardValue;
                gameMap[secondCard.X, secondCard.Y] = cardValue;

                cardValue++; //next is B than C,D,E,F,G....
            }
        }

        public void RenderMap()
        {
            Console.Clear();
            for (int y = 0; y < sizeOfField; y++) //number of rows
            {
                for (int x = 0; x < sizeOfField; x++) //drawn a single row
                {
                    switch (cardstate[x,y])
                    {
                        case CardState.Hidden:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(cardSkin);
                            Console.ResetColor();
                            break;

                        case CardState.Shown:
                            Console.Write(gameMap[x, y]);
                            break;

                        case CardState.Deleted: //deleted is meant for pair of cards that you guessed
                            Console.Write(" "); 
                            break;

                        default:
                            break;
                    }
                }
                Console.WriteLine(); //jumps to next row
            }
        }

        public bool AllShown() //check if all cards are revealed
        {
            return revealedCards == sizeOfField * sizeOfField;
        }

        public bool CardValidityChecker(int x, int y) //check if coordinaties of card are valid and if they are check also if the card is not already guessed or flipped
        {
            return (x >= 0 && x <sizeOfField) && (y >= 0 && y < sizeOfField) && (cardstate[x,y] == CardState.Hidden);
        }

        public void FlipFirstCard(int x, int y)
        {
            flippedCard = new Position(x, y); //for remembering the first flipped card
            cardstate[x, y] = CardState.Shown;
            numOfMoves++;
            RenderMap(); //gameWorld update to see the change


        }

        public void FlipSecondCard(int x, int y)
        {
            cardstate[x, y] = CardState.Shown;
            numOfMoves++;
            RenderMap();
            Console.ReadKey(true);

            if (gameMap[flippedCard.X, flippedCard.Y] == gameMap[x,y]) //flipcard is representing the first one
            {
                cardstate[flippedCard.X, flippedCard.Y] = CardState.Deleted; //when condition is true, then we "delete" both cards.
                cardstate[x, y] = CardState.Deleted;
                revealedCards += 2;
            }
            else
            {
                cardstate[flippedCard.X, flippedCard.Y] = CardState.Hidden;
                cardstate[x, y] = CardState.Hidden;
            }
        }
    }
}
