﻿Feature: ViewWarehouseContents
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Sanity
Scenario: Display warehouse items
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	| PC   | 423.95 | 70       |	
	When I open the application
	Then I expect to see the following data on the screen:
	| Kind | Price | Quantity | Total Cost |
	| Oven | 34.95    | 20      | 699      |
	| TV   | 346.95   | 50      | 17347.5  |
	| PC   | 423.95   | 70      | 29676.5  |

Scenario: Edit item price
	Given warehouse contains the following items:
	| Kind | Price  | Quantity |
	#| Oven | 34.95  | 20       |
	| TV   | 346.95 | 50       |
	When I open the application 
	And I set the Price for "TV" item to 350
	Then Total cost of "TV" item is 17500
