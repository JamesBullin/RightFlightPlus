### APIs Considered:

SkyScanner Long signup process; requires manual review
AirportFinder: No flights
TripAdvisor: Low limit

### API Chosen

Amadeus: Airport & City Search

* Quick sign-up process
* Relatively simple data structure
* 10,000 requests per month for free

Drawbacks:

* Does require a temporary access token that expires in 30 minutes
* Does not show flights, only airports and cities