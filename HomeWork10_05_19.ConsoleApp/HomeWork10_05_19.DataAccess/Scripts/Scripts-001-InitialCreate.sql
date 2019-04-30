create table NewsAuthors
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null
)
go;
create table Themes
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null
)
go;
create table News
(
Id uniqueidentifier primary key not null,
ThemeId uniqueidentifier references Themes(Id) not null,
AuthorId uniqueidentifier references NewsAuthors(Id) not null,
Text nvarchar(256) not null,
PublishedDate datetime not null
)
go;
create table CommentAuthors
(
Id uniqueidentifier primary key not null,
Name nvarchar(50) not null
)
go;
create table Comments
(
Id uniqueidentifier primary key not null,
AuthorId uniqueidentifier references CommentAuthors(Id),
Text nvarchar(256) not null
)
go;
create table NewsComments
(
NewsId uniqueidentifier references News(Id),
CommentId uniqueidentifier references Comments(Id),
primary key (NewsId, CommentId)
)
go;