# RedditAPI
------------------------------------------------------- Base Requirements ----------------------------------------------------------

    Reddit is a network of communities where people can dive into their interests,
    hobbies, and passions. Your goal is to build a makeshift Reddit API. This API needs to comply with the following criteria.

    • A user should be able to create posts as well as update and delete those posts.
    • Users should be able to upvote (like) or downvote (dislike) those posts.
    • Users should be able to comment on posts.
    • A User should be able to upvote or downvote comments.
    • A user should be able to query all the posts that they have created.
    • A user should be able to query all the posts that they have upvoted or downvoted.
    • A user should be able to see all the posts created by a specific user by using their username.
    • Viewing any post should show you all the comments for that post as well as how many people upvoted or downvoted the post.


---------------------------------------------- Instructions --------------------------------------------------

1.	Prerequisites:
•	Install .NET 8 SDK on your machine.
•	Install Git on your machine.
•	Install SQL Server or any other database system your application uses.
•	It's recommended to use an IDE like Visual Studio for easier development and debugging

 

2.	Clone the Repository:
•	Open a terminal or command prompt.
•	Navigate to the directory where you want to clone the repository.
•	Run the following command: git clone <your-repository-url>. Replace <your-repository-url> with the URL of your GitHub repository.


3.	Configure the Connection String:
•	In the cloned repository, find the appsettings.json file.
•	Replace the connection string in this file with the connection string for your SQL Server instance. The connection string should be in the following format: Server=<server-name>;Database=<database-name>;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True;.

4.	Navigate to the Project Directory:
•	In the terminal, navigate to the cloned repository's directory.
•	If your .NET project is not in the root of the repository, navigate to the directory containing the .NET project file (.csproj).
 
5.	Restore the Dependencies:
•	Run the following command: dotnet restore <your-project-file>. Replace <your-project-file> with the name of your project file.


## Database Migrations

Entity Framework Core migrations allow you to manage changes to your database schema. You can add a migration and update your database using the following commands:

1. Add a new migration:

        PM> add-migration "MigrationName"
        Build started...
        Build succeeded.
        To undo this action, use Remove-Migration.

Replace `<MigrationName>` with the name of your migration.

2. Update the database:

               update-database
        Build started...
        Build succeeded.
        ...EF sql code ...
        Done.  

These commands should be run in the terminal from the directory containing your .NET project file (.csproj).


6.	Build the Project:
•	Run the following command: dotnet build <your-project-file>. Replace <your-project-file> with the name of your project file.

        ie. dotnet build .\MockRedditAPI.csproj


 1. 
7.	Run the Project:
•	Run the following command: dotnet run --project <your-project-file>. Replace <your-project-file> with the name of your project file.
•	You should see output indicating the application has started and is listening on a certain port (usually http://localhost:5000 or https://localhost:5001).
•	On the first run, Entity Framework will automatically create the database and tables based on your code.

     ie. dotnet run --project  .\MockRedditAPI.csproj
 
8.	Access the API:
•	You can now access the API endpoints by making requests to http://localhost:5000/<your-endpoint> or https://localhost:5001/<your-endpoint>.
Remember to replace <your-repository-url>, <server-name>, <database-name>, <your-project-file>, and <your-endpoint> with the actual values.

 
 
 Dependencies
This project uses the following NuGet packages:
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.4
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.4
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 8.0.4
dotnet add package Microsoft.Data.SqlClient --version 5.2.0
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.4
dotnet add package Microsoft.EntityFrameworkCore.Proxies --version 8.0.4
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.4
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.4

    
    ## App Settings Configuration

The `appsettings.json` file is used to store application settings such as connection strings,
JWT settings, and logging settings. Here's a template you can use:

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=<YourServerName>;Database=<YourDatabaseName>;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "<YourJwtKey>",
    "Issuer": "<YourJwtIssuer>",
    "Audience": "<YourJwtAudience>"
  }
}

Replace <YourServerName>, <YourDatabaseName>, <YourJwtKey>, <YourJwtIssuer>, and <YourJwtAudience> with your actual values.
•	Logging: This section is used to set the logging level. The default level is "Information", which means logs at this level and higher will be logged. "Microsoft" is set to "Warning", which means only logs at this level and higher will be logged for Microsoft's own classes.
•	AllowedHosts: This is used to set the hosts that are allowed to access the application. "*" means any host is allowed.
•	ConnectionStrings: This section is used to store connection strings. The "DefaultConnection" string is used by Entity Framework to connect to the database.
•	Jwt: This section is used to configure the settings for JWT (JSON Web Token) authentication. The "Key" is used to sign the token, the "Issuer" is the one who issues the token, and the "Audience" is the intended recipient of the token.


----------------------------------------------------------------------------------------------------------------------------
Documentation on MockRedditAPI


-------------------------------------------- Relationships  -------------------------------------------------------------------------
     

        User: A user can create many posts, comments, and votes.
                This is represented by the ICollection<Post> Posts,
                ICollection<Comment> Comments, and ICollection<Vote> Votes properties.

        Post: A post belongs to a user and can have many comments and votes.

                This is represented by the User User property and the ICollection<Comment> Comments and ICollection<Vote> Votes properties.

        Comment: A comment belongs to a user and a post, and can have many votes.
                    This is represented by the User User, Post Post, and ICollection<Vote> Votes properties.

        Vote: A vote belongs to a user and can belong to a post or a comment.
                This is represented by the User User, Post Post, and Comment Comment properties.
    
                    User (IdentityUser)
                ----
                + Id: string
                + Posts: ICollection<Post>
                + Comments: ICollection<Comment>
                + Votes: ICollection<Vote>

                Post
                ----
                + Id: Guid
                + Title: string
                + Content: string
                + CreatedAt: DateTime
                + UpdatedAt: DateTime
                + UserId: string
                + User: User
                + Comments: ICollection<Comment>
                + Votes: ICollection<Vote>

                Comment
                -------
                + Id: Guid
                + Content: string
                + CreatedAt: DateTime
                + UpdatedAt: DateTime
                + UserId: string
                + User: User
                + PostId: Guid
                + Post: Post
                + Votes: ICollection<Vote>

                Vote
                ----
                + Id: Guid
                + Type: string
                + UserId: string
                + User: User
                + PostId: Guid
                + Post: Post
                + CommentId: Guid
                + Comment: Comment


----------------------------------------------------------------------------------------------------------------------------

UserController
-----------------
- _userService: IUserService
- _userManager: UserManager<User>
- _configuration: IConfiguration
- _mapper: IMapper
- _voteService: IVoteService
- _postService: IPostService

Methods:
---------
+ UserController(userService: IUserService, userManager: UserManager<User>, configuration: IConfiguration, mapper: IMapper, voteService: IVoteService, postService: IPostService)
+ CreateUser(createUserDto: CreateUserDto): Task<ActionResult<UserDto>>
+ GetUser(id: string): Task<ActionResult<UserDto>>
+ UpdateUser(id: string, updateUserDto: UpdateUserDto): Task<IActionResult>
+ DeleteUser(id: string): Task<IActionResult>
+ GetUsers(): Task<ActionResult<IEnumerable<UserDto>>>
+ Login(model: LoginModel): Task<IActionResult>
+ Register(model: UserRegistrationModel): Task<ActionResult<User>>
+ GenerateToken(user: User): string
+ GetUserVotes(userId: string): Task<ActionResult<IEnumerable<PostDto>>>
+ GetUserId(emailOrUsername: string): Task<ActionResult<string>>

UserController
The UserController class is responsible for handling HTTP requests related to users. It uses dependency injection to get the necessary services and managers for its operations.
•	IUserService _userService: This service is used to perform operations related to users, such as creating, retrieving, updating, and deleting users.
•	UserManager<User> _userManager: This is a built-in service in ASP.NET Core Identity used for user management.
•	IConfiguration _configuration: This is used to access application configuration settings.
•	IMapper _mapper: This is used to map between DTOs (Data Transfer Objects) and entity models.
•	IVoteService _voteService: This service is used to perform operations related to votes.
•	IPostService _postService: This service is used to perform operations related to posts.

The UserController class has several methods that correspond to different HTTP methods:
•	CreateUser(CreateUserDto createUserDto): This method handles POST requests to create a new user.
•	GetUser(string id): This method handles GET requests to retrieve a user by their ID.
•	UpdateUser(string id, UpdateUserDto updateUserDto): This method handles PUT requests to update a user.
•	DeleteUser(string id): This method handles DELETE requests to delete a user.
•	GetUsers(): This method handles GET requests to retrieve all users.
•	Login(LoginModel model): This method handles POST requests for user login.
•	Register(UserRegistrationModel model): This method handles POST requests for user registration.
•	GenerateToken(User user): This is a private method used to generate a JWT (JSON Web Token) for a user.
•	GetUserVotes(string userId): This method handles GET requests to retrieve all votes made by a user.
•	GetUserId(string emailOrUsername): This method handles GET requests to retrieve a user's ID by their email or username.

            ---------------------------------------------------------------------------------
PostsController
-----------------
- _userManager: UserManager<User>
- _postService: IPostService
- _context: RedditDbContext

Methods:
---------
+ PostsController(userManager: UserManager<User>, postService: IPostService, context: RedditDbContext)
+ Create(request: CreatePostRequest): Task<IActionResult>
+ GetPosts(): Task<ActionResult<IEnumerable<PostDto>>>
+ GetPost(id: Guid): Task<ActionResult<PostDto>>
+ UpdatePost(id: Guid, request: UpdatePostRequest): Task<IActionResult>
+ DeletePost(id: Guid): Task<IActionResult>
+ GetPostsByUser(userId: string): Task<ActionResult<IEnumerable<PostDto>>>
+ GetPostsByUserNameOrEmail(usernameOrEmail: string): Task<ActionResult<IEnumerable<PostDto>>>

PostsController
The PostsController class is responsible for handling HTTP requests related to posts. It uses dependency injection to get the necessary services and managers for its operations.
•	UserManager<User> _userManager: This is a built-in service in ASP.NET Core Identity used for user management.
•	IPostService _postService: This service is used to perform operations related to posts.
•	RedditDbContext _context: This is the database context used to interact with the database.

The PostsController class has several methods that correspond to different HTTP methods:
•	Create(CreatePostRequest request): This method handles POST requests to create a new post.
•	GetPosts(): This method handles GET requests to retrieve all posts.
•	GetPost(Guid id): This method handles GET requests to retrieve a post by its ID.
•	UpdatePost(Guid id, UpdatePostRequest request): This method handles PUT requests to update a post.
•	DeletePost(Guid id): This method handles DELETE requests to delete a post.
•	GetPostsByUser(string userId): This method handles GET requests to retrieve all posts made by a user.
•	GetPostsByUserNameOrEmail(string usernameOrEmail): This method handles GET requests to retrieve all posts made by a user, where the user is identified by their username or email.


            ---------------------------------------------------------------------------------

CommentController
-----------------
- _commentService: ICommentService
- _mapper: IMapper

Methods:
---------
+ CommentController(commentService: ICommentService, mapper: IMapper)
+ GetComment(id: Guid): Task<ActionResult<CommentDto>>
+ CreateComment(createCommentDto: CreateCommentDto): Task<ActionResult<CommentDto>>
+ UpdateComment(id: Guid, commentDto: CommentDto): Task<IActionResult>
+ DeleteComment(id: Guid): Task<IActionResult>

 The CommentController class is responsible for handling HTTP requests related to comments. It uses dependency injection to get the necessary services for its operations.
•	ICommentService _commentService: This service is used to perform operations related to comments, such as creating, retrieving, updating, and deleting comments.
•	IMapper _mapper: This is used to map between DTOs (Data Transfer Objects) and entity models.
The CommentController class has several methods that correspond to different HTTP methods:
•	GetComment(Guid id): This method handles GET requests to retrieve a comment by its ID. It uses the _commentService to get the comment and the _mapper to map the comment to a CommentDto. If the comment is not found, it returns a 404 Not Found status. Otherwise, it returns the CommentDto.
•	CreateComment(CreateCommentDto createCommentDto): This method handles POST requests to create a new comment. It maps the CreateCommentDto to a Comment model, creates the comment using the _commentService, maps the created comment back to a CommentDto, and returns the CommentDto with a 201 Created status.
•	UpdateComment(Guid id, CommentDto commentDto): This method handles PUT requests to update a comment. It first checks if the ID in the URL matches the ID in the CommentDto. If not, it returns a 400 Bad Request status. It then maps the CommentDto to a Comment model and updates the comment using the _commentService.
•	DeleteComment(Guid id): This method handles DELETE requests to delete a comment. It deletes the comment using the _commentService and returns a 204 No Content status.

            ---------------------------------------------------------------------------------


VoteController
-----------------
- _voteService: IVoteService
- _mapper: IMapper

Methods:
---------
+ VoteController(voteService: IVoteService, mapper: IMapper)
+ GetVote(id: Guid): Task<ActionResult<VoteDto>>
+ CreateVote(voteDto: VoteDto): Task<ActionResult<VoteDto>>
+ UpdateVote(id: Guid, voteDto: VoteDto): Task<IActionResult>
+ DeleteVote(id: Guid): Task<IActionResult>



The VoteController class is responsible for handling HTTP requests related to votes. It uses dependency injection to get the necessary services for its operations.
•	IVoteService _voteService: This service is used to perform operations related to votes, such as creating, retrieving, updating, and deleting votes.
•	IMapper _mapper: This is used to map between DTOs (Data Transfer Objects) and entity models.

The VoteController class has several methods that correspond to different HTTP methods:
•	GetVote(Guid id): This method handles GET requests to retrieve a vote by its ID. It uses the _voteService to get the vote and the _mapper to map the vote to a VoteDto. If the vote is not found, it returns a 404 Not Found status. Otherwise, it returns the VoteDto.
•	CreateVote(VoteDto voteDto): This method handles POST requests to create a new vote. It maps the VoteDto to a Vote model, creates the vote using the _voteService, maps the created vote back to a VoteDto, and returns the VoteDto with a 201 Created status.
•	UpdateVote(Guid id, VoteDto voteDto): This method handles PUT requests to update a vote. It first checks if the ID in the URL matches the ID in the VoteDto. If not, it returns a 400 Bad Request status. It then maps the VoteDto to a Vote model and updates the vote using the _voteService.
•	DeleteVote(Guid id): This method handles DELETE requests to delete a vote. It deletes the vote using the _voteService and returns a 204 No Content status.

-------------------------------------------------   Services  ---------------------------------------------------------------------------
UserService
-----------------
- _context: RedditDbContext

Methods:
---------
+ UserService(context: RedditDbContext)
+ CreateUser(user: User): Task<User>
+ GetUser(id: string): Task<User>
+ GetUsers(): Task<IEnumerable<User>>
+ UpdateUser(user: User): Task
+ DeleteUser(id: string): Task
+ GetVotesByUser(userId: string): Task<IEnumerable<Vote>>


The UserService class is responsible for handling operations related to users. It uses dependency injection to get the necessary services for its operations.
•	RedditDbContext _context: This is the database context used to interact with the database.

The UserService class has several methods that perform various operations:
•	CreateUser(User user): This method adds a new user to the database and saves the changes.
•	GetUser(string id): This method retrieves a user from the database by their ID.
•	GetUsers(): This method retrieves all users from the database.
•	UpdateUser(User user): This method updates a user in the database and saves the changes. It first finds the user in the database, then updates the fields, and finally saves the changes.
•	DeleteUser(string id): This method deletes a user from the database and saves the changes.
•	GetVotesByUser(string userId): This method retrieves all votes from the database that were made by a specific user.

            ---------------------------------------------------------------------------------

PostService
-----------------
- _context: RedditDbContext

Methods:
---------
+ PostService(context: RedditDbContext)
+ CreatePost(post: Post): Task<Post>
+ DeletePost(id: Guid): Task
+ GetPost(id: Guid): Task<PostDto>
+ GetPosts(): Task<IEnumerable<Post>>
+ GetPostsByUser(userId: string): Task<IEnumerable<Post>>
+ UpdatePost(post: Post): Task
+ GetPostsByUserId(userId: string): Task<IEnumerable<Post>>

The PostService class is responsible for handling operations related to posts. It uses dependency injection to get the necessary services for its operations.
•	RedditDbContext _context: This is the database context used to interact with the database.

The PostService class has several methods that perform various operations:
•	CreatePost(Post post): This method adds a new post to the database and saves the changes.
•	DeletePost(Guid id): This method deletes a post from the database and saves the changes.
•	GetPost(Guid id): This method retrieves a post from the database, along with its associated comments and votes. It then maps the post and its associated data to a PostDto.
•	GetPosts(): This method retrieves all posts from the database.
•	GetPostsByUser(string userId): This method retrieves all posts from the database that were created by a specific user.
•	UpdatePost(Post post): This method updates a post in the database and saves the changes.
•	GetPostsByUserId(string userId): This method retrieves all posts from the database that were created by a specific user.

            ---------------------------------------------------------------------------------

CommentService
-----------------
- _context: RedditDbContext

Methods:
---------
+ CommentService(context: RedditDbContext)
+ GetComment(id: Guid): Task<Comment>
+ CreateComment(comment: Comment): Task<Comment>
+ UpdateComment(comment: Comment): Task<Comment>
+ DeleteComment(id: Guid): Task
+ GetCommentsByPostId(postId: Guid): Task<IEnumerable<Comment>>
+ GetCommentsByUserId(userId: string): Task<IEnumerable<Comment>>

Explanation:
•	The CommentService class has one private field, _context, which is the database context used to interact with the database.
•	The CommentService class has a constructor that takes one parameter, RedditDbContext context, which is used to initialize the _context field.

            ---------------------------------------------------------------------------------

VoteService
-----------------
- _context: RedditDbContext

Methods:
---------
+ VoteService(context: RedditDbContext)
+ GetVote(id: Guid): Task<Vote>
+ CreateVote(vote: Vote): Task<Vote>
+ UpdateVote(vote: Vote): Task
+ DeleteVote(id: Guid): Task
+ GetVotesByUser(userId: string): Task<IEnumerable<Vote>>


The VoteService class is responsible for handling operations related to votes. It uses dependency injection to get the necessary services for its operations.
•	RedditDbContext _context: This is the database context used to interact with the database.
The VoteService class has several methods that perform various operations:
•	GetVote(Guid id): This method retrieves a vote from the database by its ID.
•	CreateVote(Vote vote): This method adds a new vote to the database and saves the changes.
•	UpdateVote(Vote vote): This method updates a vote in the database and saves the changes. It first sets the state of the vote to EntityState.Modified to let Entity Framework know that the vote has been modified, then it saves the changes.
•	DeleteVote(Guid id): This method deletes a vote from the database and saves the changes.
•	GetVotesByUser(string userId): This method retrieves all votes from the database that were made by a specific user.

-------------------------------------------------- DTO Mappings -----------------------------------------------------------------------

Mapping Profile Class

MappingProfile (Profile)
-----------------
Operations:
---------
+ CreateMap<Comment, CommentDto>()
+ CreateMap<CommentDto, Comment>()
+ CreateMap<CreateCommentDto, Comment>()
+ CreateMap<Vote, VoteDto>()
+ CreateMap<VoteDto, Vote>()
+ CreateMap<CreateUserDto, User>()
+ CreateMap<UpdateUserDto, User>()
+ CreateMap<User, UserDto>()


Here's a brief explanation of each mapping:
•	CreateMap<Comment, CommentDto>(): This maps from the Comment model to the CommentDto data transfer object (DTO). It also includes a custom mapping for the VoteCount property, which is set to the count of the Votes collection if it's not null, or 0 if it is.
•	CreateMap<CommentDto, Comment>() and CreateMap<CreateCommentDto, Comment>(): These map from the CommentDto and CreateCommentDto DTOs to the Comment model.
•	CreateMap<Vote, VoteDto>() and CreateMap<VoteDto, Vote>(): These map between the Vote model and the VoteDto DTO.
•	CreateMap<CreateUserDto, User>(), CreateMap<UpdateUserDto, User>(), and CreateMap<User, UserDto>(): These map between the User model and the CreateUserDto, UpdateUserDto, and UserDto DTOs.

----------------------------------------------------------------------------------------------------------------------------
