create Table Users
(
	id int identity(1,1) primary key ,
	UserName Nvarchar(225),
	Password Nvarchar(225),
	EailId Nvarchar(225),	
    Descriptions nvarchar(225),
	CreatedDTm datetime
)
create Table BlogPost
(
 Id int identity(1,1),
 Tittle Nvarchar(225),
 Summery nvarchar(max),
 Created_time Datetime,
 UserId int,
 CreatedDtm datetime,
 UpdatedDtm datetime
)

create Table Comments
(
	 id int identity(1,1) primary key,
	 Content nvarchar(225),
	 Status bit,
	 UserId  int ,
	 PostId int ,
	 CreatedDtm Datetime
)