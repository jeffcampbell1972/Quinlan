--------------------------------------------------------------------------------------------------
-- Determine whether any collectibles have already been imported and only proceed if none have
--------------------------------------------------------------------------------------------------

declare @importCollectibleCount int

select @importCollectibleCount = Count(*) from ImportCollectibles

if @importCollectibleCount = 0 begin

--------------------------------------------------------------------------------------------------
-- BULK INSERT from CSV files 
--------------------------------------------------------------------------------------------------

-- Cards.csv
create table _BulkInsertCards
(
    SubjectType  varchar(max) ,
    LastName	 varchar(max) ,
    FirstName	 varchar(max) ,
    Year	     int ,
    Company	     varchar(max) ,
    CardNumber	 varchar(max) ,
    Description	 varchar(max) ,
    Team	     varchar(max) ,
    Beckett	     decimal(18,2) ,
    Value	     decimal(18,2) ,
    X1	         varchar(max) ,
    InStock	     varchar(max) ,
    Sport	     varchar(max) ,
    X2	         varchar(max) ,
    Grade	     varchar(max) ,
    X3	         varchar(max) ,
    Type         varchar(max) ,
    League       varchar(max) ,
    NotableFlag  bit
)
bulk insert dbo._BulkInsertCards 
from 'C:\Users\jeffc\source\repos\Quinlan\Quinlan.Initialize\InitFiles\Cards.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n')

-- update the type of card based on the Q's description column values

update _BulkInsertCards set SubjectType = 'Player' where SubjectType is null
update _BulkInsertCards set Team = 'New York Giants (MLB)' where Team = 'New York Giants' and Sport = 'BS'

-- People.csv
create table _BulkInsertPeople
(
    Identifier varchar(max) ,
    LastName varchar(max) ,
    FirstName varchar(max) ,
    MiddleName varchar(max) ,
    Suffix varchar(max) ,
    HOFFlag bit ,
    HeismanFlag bit ,
    NotableFlag bit ,
    CollegeIdentifier varchar(max)
)
bulk insert dbo._BulkInsertPeople 
from 'C:\Users\jeffc\source\repos\Quinlan\Quinlan.Initialize\InitFiles\People.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

-- Teams.csv
create table dbo._BulkInsertTeams
(
    Identifier varchar(max) ,
    City varchar(max) ,
    Nickname varchar(max) ,
    SportIdentifier varchar(max) ,
    LeagueIdentifier varchar(max)
)
bulk insert dbo._BulkInsertTeams 
from 'C:\Users\jeffc\source\repos\Quinlan\Quinlan.Initialize\InitFiles\Teams.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

-- Colleges.csv
create table dbo._BulkInsertColleges
(
    Identifier varchar(max) ,
    Name varchar(max) ,
    Nickname varchar(max)
)
bulk insert dbo._BulkInsertColleges 
from 'C:\Users\jeffc\source\repos\Quinlan\Quinlan.Initialize\InitFiles\Colleges.csv' 
with ( FIELDTERMINATOR = ',', ROWTERMINATOR = '\n' )

--------------------------------------------------------------------------------------------------
-- Copy from BULK INSERT tables to IMPORT tables    
--------------------------------------------------------------------------------------------------

insert into ImportCollectibles select * from _BulkInsertCards
insert into ImportPeople select * from _BulkInsertPeople
insert into ImportTeams select * from _BulkInsertTeams
insert into ImportColleges select * from _BulkInsertColleges

--------------------------------------------------------------------------------------------------
-- Drop BULK INSERT tables
--------------------------------------------------------------------------------------------------

drop table _BulkInsertCards
drop table _BulkInsertColleges
drop table _BulkInsertPeople
drop table _BulkInsertTeams

--------------------------------------------------------------------
-- Import into live tables 
--------------------------------------------------------------------

-- Colleges 

insert into Colleges (Identifier, Name, Nickname, ImportCollegeId)
select Identifier, 
    Name, 
    Nickname ,
    Id
from ImportColleges

-- People

insert into People (Identifier)
select distinct LastName + IsNull(FirstName,'') 
from ImportCollectibles 
where LastName is not null
and SubjectType not in ( 'Checklist', 'Team', 'Unknown' )


update People
set FirstName = i.FirstName ,
    LastName = i.LastName ,
    MiddleName = i.MiddleName ,
    Suffix = i.Suffix ,
    HOFFlag = i.HOFFlag ,
    HeismanFlag = i.HeismanFlag ,
    NotableFlag = i.NotableFlag ,
    CollegeId = (select id from Colleges where Identifier = i.CollegeIdentifier) ,
    ImportPersonId = i.Id
from People p
inner join ImportPeople i on p.Identifier = i.Identifier

declare @notreDameId int
select @notreDameId = Id 
from Colleges where Identifier = 'NotreDame'

update People
set CollegeId = @notreDameId
where Identifier in (
    select distinct LastName + IsNull(FirstName,'') 
    from ImportCollectibles 
    where LastName is not null
    and SubjectType is null 
    and X2 = 'ND'
)

-- Teams

insert into Teams (Identifier, City, Nickname, SportId, LeagueId, NotableFlag, ImportTeamId)
select  
    case when t.LeagueIdentifier = 'NCAAF' then Identifier + '-Football'
        when t.LeagueIdentifier = 'NCAAB' then Identifier + '-Basketball'
        else Identifier 
    end as TeamIdentifier ,
    City, 
    case when t.LeagueIdentifier = 'NCAAF' then Nickname + ' Football'
        when t.LeagueIdentifier = 'NCAAB' then Nickname + ' Basketball'
        else Nickname 
    end as Nickname ,
    (select Id from Sports s where s.Name = t.SportIdentifier) ,
    (select Id from Leagues l where l.Identifier = t.LeagueIdentifier) ,
    case t.Identifier
        when 'Boston Bruins' then 1
        when 'Boston Celtics' then 1
        when 'Boston Red Sox' then 1
        when 'Denver Broncos' then 1
        when 'Notre Dame Fightin'' Irish' then 1
        when 'Washington Capitals' then 1
        when 'Washington Nationals' then 1
        when 'Washington Redskins' then 1
        when 'Vermont Catamounts (NCAA)' then 1
        else 0
    end ,
    t.Id
from ImportTeams t

-- Graders and Grades

declare @psaId int
declare @bccgId int
declare @bgsId int
declare @bvgId int
declare @agsId int

insert into Organizations (Identifier, Name) values ('PSA','PSA')
insert into Organizations (Identifier, Name) values ('BCCG','BCCG')
insert into Organizations (Identifier, Name) values ('BGS','BVS')
insert into Organizations (Identifier, Name) values ('BVG','BVG')
insert into Organizations (Identifier, Name) values ('AGS','AGS')

select @psaId = id from Organizations where Identifier = 'PSA'
select @bccgId = id from Organizations where Identifier = 'BCCG'
select @bgsId = id from Organizations where Identifier = 'BGS'
select @bvgId = id from Organizations where Identifier = 'BVG'
select @agsId = id from Organizations where Identifier = 'AGS'

insert into Graders (id) values (@psaId)
insert into Graders (id) values (@bccgId)
insert into Graders (id) values (@bgsId)
insert into Graders (id) values (@bvgId)
insert into Graders (id) values (@agsId)


select distinct Grade 
into #grades
from ImportCollectibles 
where Grade like '%psa%'
or Grade like '%bccg%'
or Grade like '%bgs%'
or Grade like '%bvg%'
or Grade like '%ags%'

insert into Grades (Identifier, Name, GraderId)
select Grade, 
    Grade, 
    case when Grade like '%psa%' then @psaId
        when Grade like '%bccg%' then @bccgId
        when Grade like '%bgs%' then @bgsId
        when Grade like '%bvg%' then @bvgId
        when Grade like '%ags%' then @agsId
    else 0 end
from #grades

-- Companies

insert into Sets (Name)
select distinct Company 
from ImportCollectibles 
where Company is not null 
and Company <> ''

-- Modify the subject type based on Q's settings

update ImportCollectibles set SubjectType = 'Manager' where Description like '%MG%'
update ImportCollectibles set SubjectType = 'Coach' where Description like '%CO%'

update ImportCollectibles set SubjectType = 'SuperBowl' where Description like '%SB%'

update ImportCollectibles set SubjectType = 'RecordBreaker' where Description like '%RB%'

update ImportCollectibles set SubjectType = 'AllStar' where Description like '%AS%'
update ImportCollectibles set SubjectType = 'AllPro' where Description like '%AP%'
update ImportCollectibles set SubjectType = 'ProBowl' where Description like '%Pro Bowl%'

update ImportCollectibles set SubjectType = 'TeamLeader' where Description like '%TL%'  

update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%AL%'  -- assist leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%BL%'  -- batting leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%SL%'  -- scoring leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%RL%'  -- rebound leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%FG%'  -- field goal leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%HR%'  -- home run leader
update ImportCollectibles set SubjectType = 'LeagueLeader' where Description like '%RBI%'  -- rbi leader => must come after 'RB'

update ImportCollectibles set SubjectType = 'MVP' where Description like '%MVP%'  

update ImportCollectibles set SubjectType = 'Other' where Description like '%FB3%'  

-- Collectibles

insert into Collectibles (
    Identifier ,
    PersonId ,
    Year ,
    CardNumber ,
    Condition ,
    RCFlag ,
    AUFlag ,
    PatchFlag ,
    GradedFlag ,
    NotableFlag ,
    SPFlag ,
    TeamId ,
    SportId ,
    LeagueId ,
    Value ,
    Cost ,
    SetId , 
    GradeId ,
    CollectibleTypeId,
    CardTypeId ,
    CollectibleStatusId,
    ImportCollectibleId )
select 
    convert(varchar(4), Year) + i.Company + case when cardNumber > 0 then convert(varchar(5), CardNumber) else i.LastName + IsNull(i.FirstName,'') end as Identifier ,
    p.Id as PersonId ,
    Year ,
    case when CardNumber > 0 then CardNumber else null end ,
    i.Grade ,
    case when Description LIKE '%RC%' then 1 else 0 end ,
    case when Description LIKE '%AU%' then 1 else 0 end ,
    case when Description LIKE '%Patch%' then 1 else 0 end ,
    case when i.Grade LIKE '%PSA%' then 1 else 0 end ,
    case when i.NotableFlag = 1 then 1 else 0 end,  
    0,
    case when i.Sport = 'BK' then (select Id from Teams t where i.Team = t.Identifier or i.Team + '-Basketball' = t.Identifier )
         when i.Sport = 'FB' then (select Id from Teams t where i.Team = t.Identifier or i.Team + '-Football' = t.Identifier )
         else (select Id from Teams t where i.Team = t.Identifier )
    end  as TeamId ,
    s.Id as SportId ,
    l.Id as LeagueId ,
    Beckett ,
    Value ,
    sets.Id as SetId ,
    g.Id as GradeId ,
    t.Id as CollectibleTypeId ,
    ct.Id as CardTypeId ,
    1 as CollectibleStatusId , -- pending status
    i.Id as ImportCollectiblesId
from ImportCollectibles i
inner join CollectibleTypes t on t.Identifier = i.Type
inner join Sets sets on sets.Name = i.Company
left outer join People p on p.Identifier = i.LastName + IsNull(i.FirstName,'')
left outer join Sports s on s.Identifier = i.Sport
left outer join Leagues l on l.Identifier = i.League
left outer join Grades g on g.Name = i.Grade
left outer join CardTypes ct on ct.Identifier = i.SubjectType
where year is not null
and SubjectType != 'Mascot'
and SubjectType != 'Military'
and SubjectType != 'Unknown'
and SubjectType != 'Quad'


-- PersonSports

insert into PersonSports (PersonId, SportId)
select distinct PersonId, SportId 
from collectibles 
where sportid is not null 
and personid is not null

end -- if @importCollectibleCount = 0


