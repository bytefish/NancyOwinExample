DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM information_schema.schemata WHERE schema_name = 'auth') THEN

    CREATE SCHEMA auth;

END IF;

END;
$$;