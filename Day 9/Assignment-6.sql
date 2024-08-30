create login new_user with password = 'secure_password';
create User new_user for login new_user;

alter role db_datareader add member new_user;
alter role db_datawriter add member new_user;

GRANT SELECT, INSERT, UPDATE ON ORDERS TO NEW_USER;
REVOKE INSERT, UPDATE ON ORDERS FROM NEW_USER

drop User new_user;
DROP LOGIN NEW_USER




