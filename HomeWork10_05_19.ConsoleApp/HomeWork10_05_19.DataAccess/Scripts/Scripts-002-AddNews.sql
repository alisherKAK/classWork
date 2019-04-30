insert into NewsAuthors values(NEWID(), 'Ilon Mask')
go;
insert into Themes values(NEWID(), 'Science')
go;
insert into News values(NEWID(), (select Id from Themes where Name = 'Science'), (select Id from NewsAuthors where Name = 'Ilon Mask'), 'Black Hole', getdate())
go;