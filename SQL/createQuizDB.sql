Go
Drop table if exists [Choice]

Go
Drop table if exists [QuizQuestion]

Go
Drop table if exists [Question]

Go
Drop table if exists [Category]

Go
Drop table if exists [Quiz]

Go
DROP TABLE IF EXISTS [GameMode]

Go
Drop table if exists [User]


Go
create table [User](
	[UserId] int identity,
	[Username] nvarchar(30) not null,
	[Email] nvarchar(200),
	[Role] nvarchar(20) not null,
	[CreatedDate] datetime not null,
	[TotalScore] int not null,
	constraint PK_AccountId primary key(UserId)
)

Go
create table [Category](
	[CategoryId] int identity,
	[Category] nvarchar(20) not null,
	constraint PK_CategoryId primary key(CategoryId)
)

Go
create table [Quiz](
	[QuizId] int identity,
	[UserId] int not null,
	[Category] nvarchar(20) not null,
	[GameModeId] int not null,
	[Score] int not null,
	[Time] datetime not null,
	constraint PK_QuizId primary key(QuizId)
)

Go
create table [GameMode](
	[GameModeId] int identity,
	[GameMode] nvarchar(100) not null,
	constraint PK_GameModeId primary key(GameModeId)
)

Go
create table [Question](
	[QuestionId] int identity,
	[CategoryId] int not null,
	[Question] nvarchar(300) not null,
	[Value] int not null,
	constraint PK_QuestionId primary key(QuestionId)
)

Go
create table [QuizQuestion](
	[QuizQuestionId] int identity,
	[QuizId] int not null,
	[QuestionId] int not null,
	constraint PK_QuizQuestionId primary key (QuizQuestionId)
)

Go
create table [Choice](
	[ChoiceId] int identity,
	[QuestionId] int not null,
	[Correct] bit not null,
	[Choice] nvarchar(100) not null,
	constraint PK_ChoiceId primary key(ChoiceId)
)

Go
alter table [Quiz] add
	constraint FK_UserId_Quiz_User foreign key (UserId) references [User]([UserId]),
	constraint FK_GameModeId_Quiz_GameMode foreign key (GameModeId) references [GameMode]([GameModeId])
	ON DELETE CASCADE
	ON UPDATE CASCADE;

Go
alter table [QuizQuestion] add
	constraint FK_QuizId_QuizQuestion_Quiz foreign key(QuizId) references [Quiz]([QuizId]),
	constraint FK_QuestionId_QuizQuestion_Question foreign key(QuestionId) references Question(QuestionId)
	ON DELETE CASCADE
	ON UPDATE CASCADE;

Go
alter table [Choice]
	add constraint FK_QuestionId_Choice_Question foreign key(QuestionId) references [Question]([QuestionId])
	ON DELETE CASCADE
	ON UPDATE CASCADE;
	
Go
alter table [Question] 
	add constraint FK_CategoryId_Question_Category foreign key(CategoryId) references [Category]([CategoryId])
	ON DELETE CASCADE
	ON UPDATE CASCADE;  