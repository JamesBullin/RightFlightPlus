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

