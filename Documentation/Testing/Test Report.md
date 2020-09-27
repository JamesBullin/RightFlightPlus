AirportAndCityTests.NumberOfResultsIsCorrect

* Failed: When GetAirportAndCityResult() was called, a null value was passed as an argument. This was because the LocationType Enum was written in Pascal case, whereas the the API required the LocationType to be written in capital letters.
* Solution: The Enum was updated to capital letters, and the test passed. 

AirportAndCityTests.GeoCodeIsCorrect

* Failed: It assumed the expectedResult was a decimal, and failed because the data model uses a float.
* I specified that the expected result was a float, and the test passed.

TokenTests.IsAccessKeyInCorrectFormat

* Failed: The expectedValue was wrong because I miscounted the length of the Access Key.
* Solution: Changed the expectedValue.

TokenTests.IsDataCorrect

* Failed: The tests were wrong due to Copy-paste errors
* Solution: I corrected the tests to test the relevant parts of the API data structure.

FlightOfferTests.NumberOfResultsIsCorrect

* Failed: The base URL for the FlightOfferTests API was slightly different from the AirportAndCitiesAPI. Using the latter base URL caused an 400 error.
* Solution: Separate the base URLs in the app.config files, and use a seperate variable for each API.

* Failed: The "non-stop" parameter for the FlightOfferTests API expected a string of either "true" or "false". Instead it received a boolean value.
* Solution: submitted a string of value "true".
* Failed Json converter didn't recognise a duration string format. 
* Solution: The regular expression used to parse the duration was corrected to accept a string where the hours are given as a single digit.