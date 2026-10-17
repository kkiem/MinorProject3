USE PremierLeagueWeb;
GO

-- 1. Enzo Maresca (Manchester City)
UPDATE Manager 
SET TacticalStyle = 'Positional Control'
WHERE FirstName = 'Enzo' AND LastName = 'Maresca';

-- 2. Mikel Arteta (Arsenal)
UPDATE Manager 
SET TacticalStyle = 'Defensive Control'
WHERE FirstName = 'Mikel' AND LastName = 'Arteta';

-- 3. Xabi Alonso (Chelsea)
UPDATE Manager 
SET TacticalStyle = 'Explosive Verticality'
WHERE FirstName = 'Xabi' AND LastName = 'Alonso';

-- 4. Michael Carrick (Manchester United)
UPDATE Manager 
SET TacticalStyle = 'Deep Build-up'
WHERE FirstName = 'Michael' AND LastName = 'Carrick';

-- 5. Andoni Iraola (Liverpool)
UPDATE Manager 
SET TacticalStyle = 'Counter-Pressing'
WHERE FirstName = 'Andoni' AND LastName = 'Iraola';
GO