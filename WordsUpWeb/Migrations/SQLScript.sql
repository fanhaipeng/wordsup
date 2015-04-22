use WordsUpDB;

select * from WordReviews;

select * from WordEntities;

select * from AspNetUsers;

return;

delete from WordReviews;

delete from WordEntities;

delete from AspNetUsers where UserName like 'TestUser%'
