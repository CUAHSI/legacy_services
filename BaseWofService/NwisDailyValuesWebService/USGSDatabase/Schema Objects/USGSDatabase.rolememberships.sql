EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'readusgs';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'webservice';

