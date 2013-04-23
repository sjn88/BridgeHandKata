BridgeHandKata
==============

A Kata to introduce mocking. The idea is that a program determines the number of points a hand in bridge is worth.

##Brief
###Intro
In bridge a hand may have 13 cards, spread across four suits. The four suits are hearts, spades, clubs and diamonds.
The royal cards and aces are worth points during bidding. An Ace is worth four points, a King is worth three points, a Queen is worth two, and a Jack is worth one. 
Other cards are not worth points (but are used in real bidding to determine the contract).

###Challenge
The task is, using the three rules of TDD, to read a bridge hand and to calculate the points in the hand. 
The program should only accept one format of your choice (although one is provided), and it should be possible to tell points by suit. The extension exercises are mainly for working out what an opening bid would be, using a simplified set of rules.

###Rules of TDD
from http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd

1. You are not allowed to write any production code unless it is to make a failing unit test pass.
2. You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures.
3. You are not allowed to write any more production code than is sufficient to pass the one failing unit test.

##Extra points for...
Using [object calisthenics](ObjCali.txt)
Using [domain modelling](Domain Objects.txt)

##Extra things- we probably won't get on to these:
###Bidding and contracts
In bridge, a bid is a statement that a person could win 6 tricks plus the number of the bid, if the bidded suit is "trump". If a bid is the last one to be made, it becomes the contract, and the person and their partner have to attempt to fulfil their contract.
A bid of 1 club means if clubs were the trump suit (you don't have to know what this means) I would make seven tricks. The number of tricks I can win depends on the length of a suit (how many cards I have in that suit) and the strength of the suit (how many points I have in it.)
No trump means that if there are no trumps, you can make the number of tricks suggested.

### Further challenges
1. Calculate four hands from one string / file- it should be possible to tell which hand is which.
The four players are named after the directions: north, south, east and west.

2. Suggest an opening bid for players with more than twelve points: (These rules are simplified versions of the "Standard American" bidding rules.)

When picking a suit - the suit with the highest number of cards, that has the most points.
If you are in a tie over which suit to suggest, pick the first one you come to in the following list: spade before heart before diamond before club.
If you can, prefer no trumps (NT) over a suit, to play a no trump. You should do this if your hand has the following length distribution:  4-3-3-3, 4-4-3-2 or 5-3-3-2.

You should open 1 if you have 12-18 points, 2 if you have >18 unless you have 25-26 and are playing no trumps, in which case open with 3NT.

For example, in these rules, the following hand is two diamonds: ♠AK??♥J??♦AKJ??♣K