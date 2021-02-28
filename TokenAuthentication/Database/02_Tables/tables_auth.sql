DO $$
BEGIN

IF NOT EXISTS (
	SELECT 1 
	FROM information_schema.tables 
	WHERE  table_schema = 'auth' 
	AND table_name = 'user'
) THEN

CREATE TABLE auth.user
(
	user_id SERIAL PRIMARY KEY,
	name VARCHAR(255) NOT NULL,
	password_hash VARCHAR(255) NOT NULL,
	password_salt VARCHAR(255) NOT NULL
);

END IF;

IF NOT EXISTS (
	SELECT 1 
	FROM information_schema.tables 
	WHERE  table_schema = 'auth' 
	AND table_name = 'claim'
) THEN

CREATE TABLE auth.claim
(
	claim_id SERIAL PRIMARY KEY,
	type VARCHAR(255) NOT NULL,
	value VARCHAR(255) NOT NULL
);

END IF;

IF NOT EXISTS (
	SELECT 1 
	FROM information_schema.tables 
	WHERE  table_schema = 'auth' 
	AND table_name = 'user_claim'
) THEN

CREATE TABLE auth.user_claim
(
	user_claim_id SERIAL PRIMARY KEY,
	user_id INTEGER NOT NULL,
	claim_id INTEGER NOT NULL
);

END IF;

END;
$$;