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
	| 7 apple @ $0.75 is $5.25       |
	|***Discount on apple: Buy 3 apple for $2.00, New Price $4.75, Savings $0.50|
	| 1 banana @ $1.00 is $1.00 |
	| Total is $5.75            |
