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

1. Controller
MovieInformationController handles requests coming to access Movies details. We have 2 Get calls. One of them returns list of Movies with Title, Location and Language while the other returns other details of a specific movie based on the selection.
Here for now I have considered Mediatr pattern which handles these requests.
