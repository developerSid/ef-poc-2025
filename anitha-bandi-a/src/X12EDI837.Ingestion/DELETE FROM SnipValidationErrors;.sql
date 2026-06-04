DELETE FROM SnipValidationErrors;
DELETE FROM DiagnosisCodes;
DELETE FROM ServiceLines;
DELETE FROM BillingProviders;
DELETE FROM Subscribers;
DELETE FROM Claims;

SELECT 'Claims' AS TableName, COUNT(*) AS Count FROM Claims
UNION ALL SELECT 'BillingProviders', COUNT(*) FROM BillingProviders
UNION ALL SELECT 'Subscribers', COUNT(*) FROM Subscribers
UNION ALL SELECT 'ServiceLines', COUNT(*) FROM ServiceLines
UNION ALL SELECT 'DiagnosisCodes', COUNT(*) FROM DiagnosisCodes
UNION ALL SELECT 'SnipValidationErrors', COUNT(*) FROM SnipValidationErrors;

