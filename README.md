BridgeHandKata
==============

A Kata to introduce mocking. The idea is that a bridge hand is on disk in a text file, and you have to calculate the number of points in the hand.

##Brief
###Intro
In bridge a hand may have 13 cards, spread across four suits. The four suits are hearts, spades, clubs and diamonds.
The royal cards and aces are worth points during bidding. An Ace is worth four points, a King is worth three points, a Queen is worth two, and a Jack is worth one. 
Other cards are not worth points.

###Challenge
The task is, using the three rules of TDD, to read a bridge hand stored on disk, and to calculate the points in the hand. 
The program should only accept one format of your choice, and it should be possible to tell points by suit.

###Rules of TDD
from http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd

1. You are not allowed to write any production code unless it is to make a failing unit test pass.
2. You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures.
3. You are not allowed to write any more production code than is sufficient to pass the one failing unit test.

###Extra points for...
Mocking the file system for unit tests, but check your assumptions with integration tests. (Writing integration tests first might help.)
Using linq for parsing the data from the file.

###Further Challenges
0. Correct formating errors in the file.
1. Calculate four hands from one file, it should be possible to tell which hand is which.
2. Suggest an opening bid for players with more than twelve points (you might have to research this).
3. Try object calisthenics all the way through.

