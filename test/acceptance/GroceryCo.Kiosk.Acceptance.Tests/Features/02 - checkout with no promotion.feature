Feature: Checkout with items with no promotion
	In order to purchase items on my own
	As a customer
	I want to checkout from a kiosk

Scenario: When checking out with a couple items
	Given I have the following products
		| Barcode | Price |
		| apple   | 0.75  |
		| banana  | 1.00  |
	And I have no promotions in the system
	And my cart is
		| Item   |
		| apple  |
		| banana |
		| apple  |
	When I checkout
	Then I should see expected receipt
	| Lines...                  |
	| Receipt:                  |
	| 2 apple @ $0.75 is $1.50  |
	| 1 banana @ $1.00 is $1.00 |
	| Total is $2.50            |
