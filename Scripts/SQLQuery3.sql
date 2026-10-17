USE PremierLeagueWeb;
GO

UPDATE Manager 
SET FirstName = 'Michael', LastName = 'Carrick', TacticalStyle = 'Balanced Control'
WHERE ClubID = (SELECT ClubID FROM Club WHERE ClubName = 'Manchester United');
GO