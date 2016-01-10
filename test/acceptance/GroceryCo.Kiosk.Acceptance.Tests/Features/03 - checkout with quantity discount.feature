Feature: Checkout with items with quantity discount
	In order to improve sales
	As the business
	I want to have quantity discounts

Scenario: When checking out with a couple items
	Given I have the following products
		| Barcode | Price |
		| apple   | 0.75  |
		| banana  | 1.00  |
	And I have no additional item promotions in the system
	And I have quantity discounts
	| Barcode | Quantity | Price |
	| apple   | 3        | 2.00  |
	And my cart is
		| Item   |
		| apple  |
		| banana |
		| apple  |
		| apple  |
		| apple  |
		| apple  |
		| apple  |
		| apple  |
	When I checkout
	Then I should see expected receipt
	| Lines...                       |
	| Receipt:                       |
	| 6 apple for 3 @ $2.00 is $4.00 |
	| 1 apple @ $0.75 is $0.75       |
	| 1 banana @ $1.00 is $1.00 |
	| Total is $5.75            |
