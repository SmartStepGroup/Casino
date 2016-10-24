Feature: Roll dice
	As a man who needed more money
	I want to play in casino
   And rool dice

@mytag
Scenario: Player win game
	Given Player has some amount of chips
	And has bet with all of his chip and some score
	When Dice roll to same value as Player bet's score
	Then Player win in 6 times more, than previous has

Scenario: Player lose game
	Given Player has some amount of chips
	And has bet with all of his chip and some score
	When Dice roll to not same value as Player bet's score
	Then Player lose his bet and all chips
