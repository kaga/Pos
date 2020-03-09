## Technical Exercise

### Problem

Consider a grocery market where items have prices per unit but also volume prices. For example, Apples may be $1.25 each, or 3 for $3.

Implement a class library for a point-of-sale scanning system that accepts an arbitrary ordering of products, similar to what would happen at an actual checkout line, then returns the correct total price for an entire shopping cart based on per-unit or volume prices as applicable.

Here are the products listed by code and the prices to use. There is no sales tax.

| Product Code | Unit Price | Bulk Price
| --- | --- | --- |
| A | $1.25 | 3 for $3.00 |
| B | $4.25 | |
| C | $1.00 | $5 for a six-pack |
| D | $0.75 | |

### Test Case

Test cases required for this technical exercise is located at [PointOfSaleTerminalTest+TechnicalExercise.cs](VoyagerPosTest/PointOfSaleTerminalTest+TechnicalExercise.cs).