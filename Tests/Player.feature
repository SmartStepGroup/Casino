Feature: Player
	As a man who needed more money
	I want to play in casino

@testTag
Scenario: Player make bet with one chip
	Given Player has 1 chip
	When Make bet with 1 chip
	Then Player's current bet has 1 chip
