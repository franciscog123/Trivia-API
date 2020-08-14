
insert into [User] ([Username], [Email], [Role],[CreatedDate]) values
('francisco-proton','guerrerof615@protonmail.com', 'admin', GETDATE())

insert into [User] ([Username], [Email], [Role],[CreatedDate]) values
('francisco-g','guerrerof615@gmail.com', 'user', GETDATE())

insert into [GameMode] values
('Normal')

insert into GameMode(GameMode) values
	('Normal')

insert into Category(Category) values
	('Movies')

insert into [Question](CategoryId, Value, Question) values
	(1, 10, 'Which war movie won the Academy Award for Best Picture in 2009?'),
	(1, 10, 'What was the name of the second Indiana Jones movie, released in 1984?'),
	(1, 10, 'Which actor starred in the 1961 movie The Hustler?'),
	(1, 10, 'In which year were the Academy Awards, or "Oscars", first presented?'),
	(1, 10, '"After all, tomorrow is another day!" is the last line from which movie that won the Academy Award for Best Picture in 1939?'),
	(1, 10, 'Which movie features Bruce Willis as John McClane, a New York police officer, taking on a gang of criminals in a Los Angeles skyscraper on Christmas Eve?'),
	(1, 10, 'What is the name of the hobbit played by Elijah Wood in the Lord of the Rings movies?'),
	(1, 10, 'Which actress plays Katniss Everdeen in the Hunger Games movies?'),
	(1, 10, 'Judy Garland starred as Dorothy Gale in which classic movie?'),
	(1, 10, 'What is the name of the kingdom where the 2013 animated movie Frozen is set?')

insert into [Choice](QuestionId, Correct, Choice) values
	(1, 1, 'The Hurt Locker'),
	(1, 0, 'Avatar'),
	(1, 0, 'Zombieland'),
	(1, 0, 'Inglourious Bastards'),
	(2, 1, 'Indiana Jones and the Temple of Doom'),
	(2, 0, 'Raiders of the Lost Ark'),
	(2, 0, 'Indiana Jones and the Last Crusade'),
	(2, 0, 'Indiana Jones and the Kingdom of the Crystal Skull'),
	(3, 1, 'Paul Newman'),
	(3, 0, 'Jack Nicholson'),
	(3, 0, 'Rodney Dangerfield'),
	(3, 0, 'Bill Murray'),
	(4, 1, '1929'),
	(4, 0, '1943'),
	(4, 0, '1920'),
	(4, 0, '1938'),
	(5, 1, 'Gone with the Wind'),
	(5, 0, 'The Wizard of Oz'),
	(5, 0, 'Stagecoach'),
	(5, 0, 'Of Mice and Men'),
	(6, 1, 'Die Hard'),
	(6, 0, 'Hudson Hawk'),
	(6, 0, 'Pulp Fiction'),
	(6, 0, '12 Monkeys'),
	(7, 1, 'Frodo Baggins'),
	(7, 0, 'Samwise Gamgee'),
	(7, 0, 'Peregrin Took'),
	(7, 0, 'Bilbo Baggins'),
	(8, 1, 'Jennifer Lawrence'),
	(8, 0, 'Aubrey Plaza'),
	(8, 0, 'Rachel McAdams'),
	(8, 0, 'Scarlett Johansson'),
	(9, 1, 'The Wizard of Oz'),
	(9, 0, 'Meet Me in St. Louis'),
	(9, 0, 'A Star Is Born'),
	(9, 0, 'Easter Parade'),
	(10, 1, 'Arendelle'),
	(10, 0, 'Westeros'),
	(10, 0, 'Cyrodiil'),
	(10, 0, 'Azeroth')

insert into Category(Category) values
('Food and Drink');

insert into Question(CategoryId,Value,Question) values
(2,10,'A cocktail consisting of gin, lime juice, sugar and carbonated water is otherwise known as a what?'),
(2,10, 'In terms of food, a "flageolet" is what?'),
(2,10,'Usually fashioned into a wheel, "Raclette" is a mild cheese indigenous to which nation?'), 
(2,10,'Ascorbic Acid" is another name from what vitamin?'),
(2,10, 'Artsoppa is a soup from which country?'),
(2,10, 'The name for which Italian food item comes from the Italian word for "slipper"?'),
(2,10, 'Consisting of pieces of spiced meat and vegetables roasted on a skewer, "Souvlaki" is the national dish of which country?'),
(2,10,' In Indian cuisine, what is "Roti"?'),
(2,10,'Marinated in garlic and lemon juice, what kind of meat is found in the Greek dish "Kleftiko"?'),
(2,10,'Named after a city, what popular cocktail was created by Raffles Hotel bartender Ngiam TongBoon in 1915?');

insert into Choice(QuestionId,Correct, Choice) values
(11,0,'Bloody Mary'),
(11,0,'Harvey Wallbanger'),
(11,0,'Moscow Mule'),
(11,1,'Tom Collins'),
(12,0,'Vegetable'),
(12,0,'Nut'),
(12,1,'Bean'),
(12,0,'Fruit'),
(13,0,'Netherlands'),
(13,0,'France'),
(13,0,'Spain'),
(13,1,'Switzerland'),
(14,0,'K'),
(14,0,'A'),
(14,1,'C'),
(14,0,'D'),
(15,0,'Italy'),
(15,0,'Russia'),
(15,0,'France'),
(15,1,'Sweden'),
(16,0,'Ceviche'),
(16,0,'Cannelloni'),
(16,0,'Canape'),
(16,1,'Ciabatta'),
(17,0,'Portugal'),
(17,0,'Germany'),
(17,1,'Greece'),
(17,0,'France'),
(18,0,'Rice'),
(18,0,'Pasta'),
(18,0,'Spiced Meat'),
(18,1,'Bread'),
(19,0,'Chicken'),
(19,1,'Lamb'),
(19,0,'Pork'),
(19,0,'Beef'),
(20,0,'Washington White'),
(20,0,'London Bomber'),
(20,0,'New York Doll'),
(20,1,'Singapore Sling');

insert into Category(Category) values
('Beer Slogans');

insert into Question(CategoryId,Value,Question) values
(3,10,'Let the fin begin.'),
(3,10, 'The Champagne Of Beers'),
(3,10,' Lose the carbs, not the taste'), 
(3,10,'Hooray Beer!'),
(3,10, 'The King Of Beers'),
(3,10, 'It works every time.'),
(3,10, 'Head for the mountains.'),
(3,10,'Miles away from ordinary.'),
(3,10,'The beer that made Milwaukee famous.'),
(3,10,'Life Beckons.');

insert into Choice(QuestionId,Correct, Choice) values
(21,0,'Abbot Ale'),
(21,0,'Rockdale Light'),
(21,1,'Landshark'),
(21,0,'Corona'),
(22,0,'Fruli'),
(22,1,'Miller High Life'),
(22,0,'Guinness'),
(22,0,'Strohs'),
(23,0,'Keystone Light'),
(23,0,'Labatt Maximum Ice'),
(23,1,'Michelob Ultra'),
(23,0,'Budweiser 55'),
(24,0,'Laker Strong'),
(24,1,'Red Stripe'),
(24,0,'Fat Tire'),
(24,0,'Michelob Light'),
(25,0,'Busch'),
(25,1,'Budweiser'),
(25,0,'Molson Canadian'),
(25,0,'Miller Lite'),
(26,0,'Michelob Light'),
(26,0,'Coors Light'),
(26,1,'Colt 45'),
(26,0,'Pabst Blue Ribbon'),
(27,0,'Labatt Blue'),
(27,1,'Busch'),
(27,0,'Northern Logger Golden'),
(27,0,'Molson Ice'),
(28,0,'Red Stripe'),
(28,1,'Corona'),
(28,0,'Kraftig'),
(28,0,'Coors Banquet'),
(29,0,'Sleeman Dark'),
(29,0,'Milwaukees Best Light'),
(29,0,'Hamms Premium'),
(29,1,'Schlitz'),
(30,0,'Heineken'),
(30,0,'Tatra Beer'),
(30,0,'PBR'),
(30,1,'Becks');