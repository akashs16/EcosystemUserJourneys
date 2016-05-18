Feature: NewUserRegistrationAndBuyingAnItrem
	In to verify the new user jouney of buying an item

Scenario Outline: New user buying Reebonz item
	Given I am a first time Reebonz user
	And I am using <browser> browser
	When I register on Reebonz
	And I try to buy <number> numbers of items from <merchantType> merchant
	Then I should be successfully be able to by the item or items
	Examples: 
	| browser | number | merchantType |
	| chrome  | 1      | Reebonz      |

	
Scenario Outline: New user buying market place item
	Given I am a first time Reebonz user
	And I am using <browser> browser
	When I register on Reebonz
	And I try to buy <number> numbers of items from <merchantType> merchant
	Then I should be successfully be able to by the item or items
	Examples: 
	| browser | number | merchantType |
	| chrome  | 1      | market place | 

