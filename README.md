# RightFlightPlus
Air Travel Booking App using Flight API

## Project Definition of Done

- [x] Connect a web API to our C# project
- [x] Create and run tests for 80% of the API essential parts of the data structure
- [x] Ensure 100% of the tests pass.

## Class Diagrams:

### Airport And City Search API

![AirportCityCD](Documentation\Class_Diagrams\AirportCityCD.png)

### Flight Offers Search API

### ![FlightOffersCD](Documentation\Class_Diagrams\FlightOffersCD.png)

### Token API

![TokenCD](Documentation\Class_Diagrams\TokenCD.png)

## Sprint 1

### Sprint Goals
* Select API in Postman
  * Obtain API token
* Setup Project Structure
* Conduct Test Analysis
* Design Data Models


### Sprint Review
* We chose and API: Amadeus: Airport and City Search
* We automated the process for getting a 30-minute access token
* We setup the project structure
* We created some preliminary tests for the token API
* We created some preliminary tests for the Airport and City Search API
* We designed the data models and implemented them in C#
* We created stubs in order to test the API
* We conducted a preliminary analysis of the test basis and created test conditions
* We created the code to access the Airport and City Search API.

### Sprint Retrospective

* Possibly spending too much time on documentation, and updating the Kanban board
* We faced some difficulties with merging work from different team members. This may have been due to improper use of branches and pull requests. In addition, changes were made to the project that were not saved when commits were made, leading to some confusion.

On the whole, the first sprint has been very productive.

## Sprint 2

### Sprint Goals
* Create and run tests for the Airport and City Search API
* Create and run tests for the Token Request API
* Research a new API
 * Create a data model for the new API.

### Sprint Review

* Created and passed tests for the Airport and City Search API
* Created and passed tests for the Token Request API
* Researched Flight Offers Search API
 * Created a data model for the new API
 * Wrote code to consume the Flight Offers Search API

### Sprint Retrospective

* We achieved the goals set out at the beginning of the sprint. Division of labour was going well; we are please with the project progress. The tests caught a variety of defects and developer errors which were easy to correct.

## Sprint 3

### Goals

* Tests for Flight offers search API
* Create additional tests for Token Request API
* Create additional tests for Airport and City Search API
* Add more Json Conversions
* Write test summary reports
* Class diagram for solution

### Review

* Create additional tests for Airport and City Search API
* Add more Json Conversions

Did not do:

* Tests for Flight offers search API
* Write test summary reports
* Class diagram for solution

### Retrospective

* Had issues with merge conflicts
* Readme was updated on Github and was not saved correctly; work deleted.
* Difficulties in communication led to incomplete sprint goals.

## Sprint 4

### Goals:

* Prepare for presentation
* Tests for Flight offers search API J
* Create additional tests for Token Request API F
* Class diagram for solution J
* Enable loading of test cases from external data source (Excel)

### Review

* Presentation planned and rehearsed
* Partial testing of Flight Offers API
* Class diagrams for APIs created
* External data source created and connected

### Retrospective

Use UML diagrams for class diagrams instead of Visual Studio class designers. This allows dependencies to be shown.

## Project Review:

* Connected and tested three APIs
* Created classes for the essential parts of the API data structure
* Created tests for approximately 80% of the implemented data structures
* All the tests created pass.

## Project Retrospective:

* Good communication, delegation of tasks, and co-operation.

* Kanban board worked well for the first two sprints, but we used the Readme to organise work. The team felt that time spent updating the Kanban board was not worth it, because the sprints were very short: half a day. In future, a Kanban board would be useful in a project with longer sprints.
* The team gained confidence in solving problems independently.
* We gained experience using Github in a collaborative project, submitting and reviewing pull requests and resolving merge conflicts.
* We became more familiar using APIs and associated software tools, and the ability to test them.

## Future Work:

* Finish Test cases for one of the APIs,
* Test the entire data structure of each API
* Integrate the API consumption project into a pre-existing WPF project that displays information about airports, and allows users to book flights.