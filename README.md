# BookingAutomation
Booking.com Automation Tests 

Information
The website http://booking.com have extended their search filters with some new options.
The new options are:
•	Sauna
•	Star rating

Challenge
Write a set of Selenium tests for these new filters options, including framework to support these tests.

NOTE: We will accept a solution written in any programming language, but tests written in C# or using Selenium WebDriver instead of a test library wrapper are preferred.

Deliverables:
•	A solution with a set of passing tests
•	All code source for your solution (github link is fine for this)
•	Any supporting documentation/ReadMe

Sample Data
Some test data that can be used for these tests include:

Location: Limerick
Dates: One night stay (3 months from today’s date)
Number of People: 2 adults
Room: 1 Room

Results expected:
Select Filter	Hotel Name	Is Listed
Sauna	Limerick Strand Hotel	True
Sauna	George Limerick Hotel	False
5 Star	The Savoy Hotel	True
5 Star	George Limerick Hotel	False

Assume that hotels would be expected in the top results (paging does not need to be considered)
Feel free to include extra test scenarios that you would think of for this type of feature.

Tips
In your solution we are looking for:
•	good coding standards/practices
•	clean and easy to read solution

