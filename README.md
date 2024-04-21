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



------------------------------------------------- Relationships  -------------------------------------------------------------------------
     
        Yes, your updated models look correct based on the requirements of your makeshift Reddit API project.
        You have properly defined the one-to-many relationships between User and Post, User and Comment,
        and Post and Comment using navigation properties.
        You’ve also correctly defined the many-to-one relationships from Post, Comment, and Vote to User.

        Here’s a brief overview of your models:

        User: A user can create many posts, comments, and votes.
                This is represented by the ICollection<Post> Posts,
                ICollection<Comment> Comments, and ICollection<Vote> Votes properties.

        Post: A post belongs to a user and can have many comments and votes.

                This is represented by the User User property and the ICollection<Comment> Comments and ICollection<Vote> Votes properties.

        Comment: A comment belongs to a user and a post, and can have many votes.
                    This is represented by the User User, Post Post, and ICollection<Vote> Votes properties.

        Vote: A vote belongs to a user and can belong to a post or a comment.
                This is represented by the User User, Post Post, and Comment Comment properties.
    
------------------------------------------------ UML - Class diagram ---------------------------------------------------------------
                            

                User
            ---
            + Id: int
            + Username: string
            + Email: string
            + Password: string
            + Posts: ICollection<Post>
            + Comments: ICollection<Comment>
            + Votes: ICollection<Vote>

            Post
            ---
            + Id: int
            + Title: string
            + Content: string
            + CreatedAt: DateTime
            + UpdatedAt: DateTime
            + UserId: int
            + User: User
            + Comments: ICollection<Comment>
            + Votes: ICollection<Vote>

            Comment
            ---
            + Id: int
            + Content: string
            + CreatedAt: DateTime
            + UpdatedAt: DateTime
            + UserId: int
            + User: User
            + PostId: int
            + Post: Post
            + Votes: ICollection<Vote>

            Vote
            ---
            + Id: int
            + Type: string
            + UserId: int
            + User: User
            + PostId: int?
            + Post: Post
            + CommentId: int?
            + Comment: Comment

            In this diagram:

Each box represents a class (entity). The name of the class is at the top, followed by its properties.
The + symbol before each property indicates that it’s public.
The type of each property is listed after the property name.
The ICollection<T> type indicates a collection navigation property, which is used to represent relationships between entities123.
The ? symbol after a type indicates that the property is nullable123.


----------------------------------------------------------------------------------------------------------------------------

PostsController
---
+ GetPosts(): Task<ActionResult<IEnumerable<Post>>>
+ GetPost(id: int): Task<ActionResult<Post>>
+ PutPost(id: int, post: Post): Task<IActionResult>
+ PostPost(post: Post): Task<ActionResult<Post>>
+ DeletePost(id: int): Task<IActionResult>

CommentsController
---
+ GetComments(): Task<ActionResult<IEnumerable<Comment>>>
+ GetComment(id: int): Task<ActionResult<Comment>>
+ PutComment(id: int, comment: Comment): Task<IActionResult>
+ PostComment(comment: Comment): Task<ActionResult<Comment>>
+ DeleteComment(id: int): Task<IActionResult>

VotesController
---
+ GetVotes(): Task<ActionResult<IEnumerable<Vote>>>
+ GetVote(id: int): Task<ActionResult<Vote>>
+ PutVote(id: int, vote: Vote): Task<IActionResult>
+ PostVote(vote: Vote): Task<ActionResult<Vote>>
+ DeleteVote(id: int): Task<IActionResult>

UsersController
---
+ GetUserPosts(username: string): Task<ActionResult<IEnumerable<Post>>>
+ GetUserVotes(username: string): Task<ActionResult<IEnumerable<Vote>>>
+ GetUserComments(username: string): Task<ActionResult<IEnumerable<Comment>>>
+ GetUser(username: string): Task<ActionResult<User>>
+ PutUser(username: string, user: User): Task<IActionResult>
+ PostUser(user: User): Task<ActionResult<User>>
+ DeleteUser(username: string): Task<IActionResult>

