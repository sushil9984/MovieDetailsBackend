# MovieDetailsBackend
Backend for fetching Movie Details
- Created Backend project with .Net Core 3.1

Following is the structure of the project.
- Controller
- Extensions
- Models
- Services
- Query.GetMoviesList
- Query.GetMovieInformation
- Constants


1. Controller - MovieInformationController
 Handles requests coming to access Movies details. We have 2 Get calls. One of them returns list of Movies with Title, Location and Language while the other returns other details of a specific movie based on the selection.

2. Extensions - ValidationPipelineBehaviour
This validates all the requests coming to the handlers so that handlers doesnt need to perform validations separately. This way we can handle request errors before reaching the handlers and the code of handlers are cleaners.
Due to time constraints at the moment I am throwing error directly but we should handle this gracefully with proper return type.

3. Models
We can use this for maintaining Models. At the moment I am using this for maintaining DB models. We have 'MovieInformation' class which has all the information of Movie, while 'MoviesList' is list of 'MovieInformation'

4. Services
I am using this for accessing Data. At the moment we have movies json which is acting like Data so I am just reading it and returning back the data to the handlers respectively.

5. Query.GetMoviesList
- Query - GetMoviesListQuery
- Response - MoviesListResponse
- Handler - GetMoviesListHandler
This handles our first request to fetch all movies list to the user which has Title, Location and Language.
Mediatr sends the query in the controller which then triggers 'GetMoviesListHandler' handler to handle the request. The 'GetMoviesListHandler' queries Database which in our case is 'movies.json'. 'IRepository' is injected to call 'GetMoviesDetails' method to get the list of Movies which in turn is returned all the way back to the controller.

6. Query.GetMovieInformation
- Query - GetMovieInformationQuery
- Response - MovieInformationResponse
- Handler - GetMovieInformationHandler
- Validator - GetMovieInformationQueryValidator
This handles our second request to fetch movie details to the user which has other details (such as Plot, Poster, Stills etc.) of a specific movie.
Mediatr sends the query in the controller which then triggers 'GetMovieInformationQueryValidator' which checks whether the movieName is null or blank. If all well request is passed to 'GetMovieInformationHandler' handler to handle the request. The 'GetMovieInformationHandler' queries Database which in our case 'movies.json'. Again 'IRepository' is injected to call 'GetMovieDetailsByTitle' method to get other details of a movie based on the title passed which in turn is returned back to the controller. If incorrect Title is passed we will get NotFound response.

7. Constants
This just maintains constant values to avoid hardcoding.

I have used Dependency Injections and Mediatr Pattern. This way code is cleaner and easily readable and most importantly loosely coupled.

For documentation and testing I have setup Swagger so use 'try it out' option on each request to test them respectively.

Execution - 
- Please make sure you start Backend application before running Frontend.
- Clone the repository locally and run using an IDE such as Visual Studio
- Application should open up Swagger url as - https://localhost:44364/swagger/index.html
- You should be able to see MovieDetails Swagger. Under the MovieInformation you should be able to see 2 Get calls.
- You can test it using swagger directly by clicking on 'Try It Out' and then 'Execute' by passing parameters if required.