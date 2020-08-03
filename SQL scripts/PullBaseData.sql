use [ReservationSystem]
go

insert into ReservationSystemCinema values
('CinemaName1','CinemaDescription1'),
('CinemaName2','CinemaDescription2')

insert into ReservationSystemHall values
('HallName1','HallDescription1',10,1),
('HallName2','HallDescription2',12,1),
('HallName3','HallDescription3',10,2),
('HallName4','HallDescription4',12,2)

insert into ReservationSystemFilm values
('MovieName1','Genre1',100,'MovieDescription1','Country1','Producer1',2001),
('MovieName2','Genre2',101,'MovieDescription2','Country2','Producer2',2002),
('MovieName3','Genre3',123,'MovieDescription3','Country3','Producer3',2003),
('MovieName4','Genre4',110,'MovieDescription4','Country4','Producer4',2004),
('MovieName5','Genre5',170,'MovieDescription5','Country5','Producer5',2005),
('MovieName6','Genre6',182,'MovieDescription6','Country6','Producer6',2006),
('MovieName7','Genre7',190,'MovieDescription7','Country7','Producer7',2007)

insert into ReservationSystemPlaces values
(1,1,1),
(1,2,1),
(1,3,1),
(1,4,1),
(1,5,1),

(2,1,1),
(2,2,1),
(2,3,1),
(2,4,1),
(2,5,1),

(1,1,2),
(1,2,2),
(1,3,2),
(1,4,2),
(1,5,2),
(1,6,2),

(2,1,2),
(2,2,2),
(2,3,2),
(2,4,2),
(2,5,2),
(2,6,2),

(1,1,3),
(1,2,3),
(1,3,3),
(1,4,3),
(1,5,3),

(2,1,3),
(2,2,3),
(2,3,3),
(2,4,3),
(2,5,3),

(1,1,4),
(1,2,4),
(1,3,4),
(1,4,4),
(1,5,4),
(1,6,4),

(2,1,4),
(2,2,4),
(2,3,4),
(2,4,4),
(2,5,4),
(2,6,4)

insert ReservationSystemUser values
('userName1','login1','pass1',0),
('userName2','login2','pass2',0),
('userName3','login3','pass3',0),
('userName4','login4','pass4',0)