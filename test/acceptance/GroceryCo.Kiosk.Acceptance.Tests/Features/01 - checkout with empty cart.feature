Feature: Checkout with an empty cart
	In order to understand why I cannot proceed
	As a customer
	I want to be told my cart is empty

Scenario: When checkout with no items and an empty product catalog
	Given I have no prices in the system
		And I have no promotions in the system
		And my cart is empty
	When I checkout
	Then I should be told my cart is empty
