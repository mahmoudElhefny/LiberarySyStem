use Library;
go

insert into Categories values('Fiction'),('History'),('Litrary'),('Political'),('Self development')
,('Novels'),('Childrens'),('Sciences & Astrophysics')
 
 go
insert into Publishers values('Hindawi Publishing Corporation',01254284562,1970)
insert into Publishers values('Dar El-Farouk for Publishing and Distribution',01154284562,2002)
insert into Publishers values('Al-Dar Al-Masriah Al-Lubnaniah',01054284562,1997)
insert into Publishers values('EduGate Publishing and Distribution',01554284562,1981)
insert into Publishers values('Kalemat Arabia',01001884316,1980)

go
insert into Authors values('Robert Louis Stevenson',1850)
insert into Authors values('Jules Verne',1828)
insert into Authors values('Charles Dickens',1812)
insert into Authors values('Karen Armstrong',1930)

insert into Authors values('Chris Abbott',1930)

insert into Authors values('William Shakespeare',1564)

insert into Authors values('Albert Einstein',1879)

insert into Authors values('Anna Sewell',1820)

insert into Authors values('Edward de Bono',1933)

insert into Authors values('Dale Carnegie',1564)

insert into Authors values('George Orwell',1903)

insert into Authors values('Roald Dahl',1916)

insert into Authors values('Pegasus',1916)

insert into Authors values('J.K. Rowling',1965)

go
insert into Books values(20245,'Treasure Island','5.0.8',2001,20,200,1,
'1.jpg','this is Treasure Island, and if you do not think all of this, the pirates will hunt you down',3,1,1)

insert into Books values(20285,'Strange Case Of Dr Jekyll And Mr Hyde','4.0.8',2005,15,155,1,
'2.jpg','Strange Case of Dr Jekyll and Mr Hyde is a Gothic novella by Scottish author Robert Louis Stevenson,
first published in 1886',4,1,1)

insert into Books values(20215,'Around The World In Eighty Days','4.0.8',1999,12,165,1,
'3.jpg',
'Around the World in Eighty Days is a classic adventure novel by the French writer Jules Verne, published in 1873',4,1,2)

insert into Books values(14245,'Leagues Under The Sea 20,000','4.0.8',1881,15,176,1,
'4.jpg','Jules Vernes Twenty Thousand Leagues Under the Sea is considered a science fiction classic',3,1,2)

insert into Books values(265445,'Hard Times','4.0.8',1854,16,320,1,
'5.jpg','For These Times is the tenth novel by Charles Dickens, first published in 1854.',3,1,3)

insert into Books values(2022245,'A Tale Of Two Cities','3.0.8',2005,15,159,1,
'6,jpg','A  Tale of Two Cities (1859) is a historical novel by Charles Dickens,
set in London and Paris before and during the French Revolution. ',3,6,3)

insert into Books values(212345,'Great Expectations (Vintage Classics Dickens Series)','4.0.0',2009,15,170,1,
'7.jpg','Pips desire to improve himself is matched only by his longing for the icy-hearted Estella, but secrets from the past impede his progress and he has many hard lessons to learn.
',3,6,3)

insert into Books values(321245,'David Copperfield (Vintage Classics Dickens Series','1.0.8',2003,10,912,1,
'8.jpg','Pips desire to improve himself is matched only by his longing for the icy-hearted Estella,
but secrets from the past impede his progress and he has many hard lessons to lear',2,6,3)


insert into Books values(2321455,'Speeches That Shaped Our World : The people and ideas that','5.0.8',2010,20,200,1,
'9.jpg',
'The speeches in this book are arranged thematically, linked by concepts such as might is right',3,2,5)


insert into Books values(20245,'Julius Ceasar','5.0.8',1999,7,200,1,
'10.jpg','the senators of Rome, including his loving friend Brutus, 
contrive a plan to murder him. Julius Caesar is stabbed to death at the Senate',3,3,6)

insert into Books values(2350245,'As You Like It','5.0.8',2018,8,152,1,
'11.jpg',
'William Shakespeare s As You Like It presents the various types of love in all its splendor.',4,3,6)

insert into Books values(3256245,'Macbeth','2.0.8',2015,20,160,1,
'12.jpg',
'What will he do to get away from the consequences of his crime ?
A drama of dark desire, violence and fear, Shakespeare�s Macbeth reveals how evil can rule over a man�s goodness',3,3,6)

insert into Books values(254785,'Hamlet','5.0.8',2015,10,200,1,
'13.jpg','The Prince of Denmark, re-enacts the murder to find the truth. 
Will he be able to unmask and avenge the brutal and cold-blooded murder of his father ?',4,6,6)

insert into Books values(20789,'The Three Musketeers','5.0.8',2018,18,188,1,
'14.jpg','the theory of gravitation, and the universe.
A Nobel laureate, Einstein�s research and theories changed the world. First published in 1916, Relativity:
The Special and the General Theory is regarded as the most significant work in modern physics. ',3,3,7)

insert into Books values(32165478,'Black Beauty','4.0.8',2017,20,208,1,
'15.jpg','Anna Sewell�s Black Beauty was a galloping success',2,3,8)

insert into Books values(554782,'The Six Value Medals','3.0.8',2008,13,176,1,
'16.jpg','. De Bono demonstrates that values come into all areas of thinking, behaviour and decision-making and outlines a framework to focus employees attention on a variety of values including human values, 
organisational values, cultural values and perceptual values. By introducing a scoring system to rate different values as strong, sound, 
weak or remote de Bono helps readers to prioritise and make executive decisions that count',1,5,9)

insert into Books values(555445,'Lateral Thinking','5.0.8',2014,20,160,1,
'17.jpg','De Bono argues that conventional vertical thinking often inhibits our ability to solve problems and come up with new ideas. ',3,5,9)

insert into Books values(321455,'How to Have a Beautiful Mind','2.0.8',2004,14,240,1,
'18.jpg','the clear, practical instructions in this guide demonstrate how applying lateral and parallel thinking skills to conversation can improve the mind',2,5,9)

insert into Books values(20245,'How to Have Creative Ideas : 62 exercises to develop the mind','3.0.8',2008,11,192,1,
'19.jpg','Creativity is essential not only for artists, writers, musicians, etc., but also for business people, students, and many others. Cultivating your creative powers takes time and effort, but can also be lots of fun. Keep an open and an inquisitive mind, and you’ll be on your way to becoming a creative genius!',3,5,9)

insert into Books values(214578,'How To Stop Worrying And Start Living','3.0.8',2004,10,304,1,
'20.jpg','. It is a very intelligently knit book that would keep the reader involved in 
self-applying thoughts while reading the book and an urge to come back to explore more as they take a halt.the target of the book is to
help readers understand what suits their respective lives best to help them reframe it in a constructive manner',3,5,10)

insert into Books values(21547885,'How to Enjoy Your Life and Job','4.0.8',2004,8,208,1,
'21.jpg','Dale Carnegie isolates and explores the feelings of harmony, excitement and purpose that will enable us to transcend boredom,',3,5,10)

insert into Books values(2024664,'How to Win Friends and Influence People','1.0.8',2005,14,304,1,
'22.jpg','This book is all about building relationships. With good relationships; personal and business success are easy',3,5,10)

insert into Books values(21245,'1984','4.0.8',2016,20,200,1,
'23.jpg',' The brilliance of the novel is Orwells prescience of modern life�the ubiquity of television,
 the distortion of the language�and his ability to construct such a thorough version of hell.
 Required reading for students since it was published, it ',3,6,11)

insert into Books values(50245,'Animal Farm','5.0.8',2015,10,200,1,
'24.jpg','This landmark illustrated edition of Orwells novel was first published alongside it,
 and features the original line drawings by the films animators, Joy Batchelor and John Halas',4,6,11)

insert into Books values(20545,'Georges Marvellous Medicine','5.0.8',2020,10,128,1,
'25.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(2024985,'The Twits :The Plays','3.0.8',2018,20,128,1,
'26.jpg','Entertaining and useful childrens stories',3,7,12)


insert into Books values(2024995,'The BFG: Plays for Children','5.0.8',2017,20,128,1,
'27.jpg','Entertaining and useful childrens stories',3,7,12)


insert into Books values(20246585,'The Giraffe and the Pelly and Me','5.0.8',2014,11,32,1,
'28.jpg','Entertaining and useful childrens stories',3,7,12)


insert into Books values(254789,'Going solo','5.0.8',2014,11,40,1,
'29.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(4578963,'Great Automatic Grammatizator & Other','5.0.8',2014,51,40,1,
'30.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(245638,'Rhyme Stew','5.0.8',2015,61,40,1,
'31.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(888745,'Revolting Rhymes','5.0.8',2014,10,40,1,
'32.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(20286478,'The Giraffe and the Pelly and Me','5.0.8',2014,14,40,1,
'33.jpg','Entertaining and useful childrens stories',3,7,12)

insert into Books values(20286654,'Space - 500 Facts','4.0.8',2014,14,40,1,
'34.jpg','this book is ideal for curious readers and a must-read for
anyone who is interested in knowing and understanding the Space and the Universe',3,8,13)

insert into Books values(20286123,'500 Facts - Human Body','3.0.8',2016,14,40,1,
'35.jpg','the human body in a quick-facts format and an attractive, 
attention-grabbing layout. Full of relevant pictures and diagrams to help understand the most important 
aspects of the human body and its function',3,8,13)

insert into Books values(20286321,'DINOSAURS - 500 FACTS','1.0.8',2015,14,40,1,
'36.jpg','Dinosaurs are a diverse group of reptiles of the clade Dinosauria.',3,8,13)

insert into Books values(7676332,'Nineteen Eighty-Four','1.0.8',2015,20,250,1,
'37.jpg','The Penguin English Library - collectable general readers editions of the best fiction in English,
from the eighteenth century to the end of the Second World Wa',3,1,11)

insert into Books values(202866547,'Animal Farm','1.0.8',2016,12,260,1,
'38.jpg','oday it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell�s
masterpiece have a meaning and message still ferociously fres',3,6,11)

insert into Books values(202863214,'Animal Farm','1.0.8',2015,11,140,1,
'39.jpg','Soon the other animals discover that they are not all as equal as they thought, 
and find themselves hopelessly ensnared as one form of tyranny is replaced with anothe',3,6,11)

insert into Books values(202866547,'Othello','1.0.8',2015,9,240,1,
'40.jpg','What happens when he comes to know that she is innocent? One of the four great Shakespearean tragedies,
Othello represents the dark side of man. ',3,6,6)

insert into Books values(202866844,'Anna Karenina','1.0.8',2015,12,290,1,
'41.jpg','Anna is doomed. Caught between the rigorous societal norms, laws, and the Orthodox Church, she is consumed by guilt and isolation. 
What becomes of Anna as she is left tormente',3,6,8)

insert into Books values(20286682,'War And Peace','1.0.8',2015,10,1232,1,
'42.jpg','An explosive tale of epic proportions, War and Peace, one of the best known Russian historical novels',3,6,8)

insert into Books values(20286687,'Oliver Twist (Vintage Classics Dickens Series)','4.0.8',2015,12,340,1,
'43.jpg','In Oliver Twist, Dickens graphically conjures up the capitals underworld, full of prostitutes, thieves and lost and homeless children, and gives a voice to the 
disadvantaged and abused.',3,6,3)

insert into Books values(20286615,'A Christmas Carol','3.0.8',2015,15,285,1,
'44.jpg','hs about his choices. A Christmas Carol is Dickens most influential book and a funny, 
clever and hugely enjoyable story',3,1,3)

insert into Books values(20286985,'The Origin of Species : (Patterns of Life)','2.0.8',2015,14,528,1,
'45.jpg','the evolution of species by a process of natural selection.
This theory, published as On the Origin of Species in 1859,',3,8,3)

insert into Books values(20284485,'Harry Potter and the Chamber of Secrets','1.0.8',2015,14,384,1,
'46.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. 
The novels chronicle the lives of a young wizard, Harry Potter, and his friends ',3,6,14)

insert into Books values(20286685,'Harry Potter and the Prisoner of Azkaban','1.0.8',2015,6,480,1,
'47.jpg','s a series of seven fantasy novels written by British author J. K. Rowling.
The novels chronicle the lives of a young wizard, Harry Potter, and his friends ',3,6,14)

insert into Books values(20286685,'Harry Potter and the Goblet of Fire','1.0.8',2015,11,640,1,
'48.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends ',3,6,14)

insert into Books values(20286685,'Harry Potter and the Order of the Phoenix','1.0.8',2014,10,816,1,
'49.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives of a young wizard,
Harry Potter, and his friends ',3,6,14)

insert into Books values(20286685,'Harry Potter and the Half-Blood Prince','1.0.8',2014,2,560,1,
'50.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends',3,6,14)

insert into Books values(20286685,'Harry Potter and the Deathly Hallows','1.0.8',2015,3,640,1,
'51.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends',3,6,14)

insert into Books values(20286685,'Harry Potter and the Half-Blood Prince (hardcover)','1.0.8',2005,5,608,1,
'52.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends',3,6,14)

insert into Books values(20286685,'Harry Potter and the Deathly Hallows (hardcover)','1.0.8',2015,9,608,1,
'53.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends',3,6,14)

insert into Books values(20286685,'Harry Potter and the Philosophers Stone','1.0.8',2015,11,352,1,
'54.jpg','s a series of seven fantasy novels written by British author J. K. Rowling. The novels chronicle the lives
of a young wizard, Harry Potter, and his friends',3,6,14)

--select * from AspNetUsers

--select * from Categories;

--select * from Publishers;

--select * from Authors;

--select * from Books;


