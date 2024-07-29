-- 1. Selecting Active Entries with Area Code 012
SELECT * 
FROM ContactDetails
WHERE IsActive = 1 AND AreaCode = '012';

-- 2. Setting Entries with 'x' in Description to Active (except entries with an Order number smaller than or equal to 50)
UPDATE ContactDetails
SET IsActive = 1
WHERE Description LIKE '%x%' AND OrderNumber > 50;

-- 3. Re-Ordering the Table from 1 to N
WITH OrderedContacts AS (
  SELECT 
    ID,
    ROW_NUMBER() OVER (ORDER BY ID) AS NewID
  FROM ContactDetails
)
UPDATE ContactDetails
SET ID = (SELECT NewID FROM OrderedContacts WHERE OrderedContacts.ID = ContactDetails.ID);

-- 4. Combining AreaCode and Telephone into TelephoneNumber
ALTER TABLE ContactDetails
ADD TelephoneNumber VARCHAR(12);

UPDATE ContactDetails
SET TelephoneNumber = AreaCode + Telephone;

ALTER TABLE ContactDetails
DROP COLUMN AreaCode,
DROP COLUMN Telephone;
