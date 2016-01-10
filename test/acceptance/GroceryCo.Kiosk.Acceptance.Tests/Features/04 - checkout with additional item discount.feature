Feature: Checkout with items with additional item discount
	In order to improve sales
	As the business
	I want to have additional item discounts

Scenario: When checking out with a couple items
	Given I have the following products
		| Barcode | Price |
		| apple   | 0.75  |
		| banana  | 1.00  |
	And I have additional item discounts
	| Barcode | Quantity | NumberDiscounted | DiscountRate |
	| apple   | 1        | 1                | 100          |
	And I have no quantity discounts
	And my cart is
		| Item   |
		| apple  |
		| banana |
		| apple  |
		| apple  |
		| apple  |
		| apple  |
	When I checkout
	Then I should see expected receipt
	| Lines... |
	| Receipt: |
	| 5 apple @ $0.75 is $3.75       |
	| ***Discount on apple: Buy 1 apple get 1 at $0.00, New Price $2.25, Savings $1.50   |
	| 1 banana @ $1.00 is $1.00 |
	| Total is $3.25            |


Scenario: When checking out with a couple items at 50% discount
	Given I have the following products
		| Barcode | Price |
		| apple   | 0.75  |
		| banana  | 1.00  |
	And I have additional item discounts
	| Barcode | Quantity | NumberDiscounted | DiscountRate |
	| apple   | 1        | 1                | 50           |
	And I have no quantity discounts
	And my cart is
		| Item   |
		| apple  |
		| banana |
		| apple  |
		| apple  |
		| apple  |
		| apple  |
	When I checkout
	Then I should see expected receipt
	| Lines... |
	| Receipt: |
	| 5 apple @ $0.75 is $3.75       |
	| ***Discount on apple: Buy 1 apple get 1 at $0.38, New Price $3.00, Savings $0.75   |
	| 1 banana @ $1.00 is $1.00 |
	| Total is $4.00          |
