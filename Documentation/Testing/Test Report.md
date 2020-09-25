* AirportAndCityTests.NumberOfResultsIsCorrect

Failed: When GetAirportAndCityResult() was called, a null value was passed as an argument. This was because the LocationType Enum was written in Pascal case, whereas the the API required the LocationType to be written in capital letters.

The Enum was updated to , and the test passed. 

* AirportAndCityTests.GeoCodeIsCorrect

Failed: It assumed the expectedResult was a decimal, and failed because the data model uses a float.

I specified that the expected result was a float, and the test passed.

* TokenTests.IsAccessKeyInCorrectFormat

Failed: Miscounted length

* TokenTests.IsDataCorrect

Copy-paste errors