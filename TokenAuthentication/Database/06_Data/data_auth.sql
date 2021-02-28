DO $$
BEGIN

IF NOT EXISTS (
	SELECT 1 
	FROM auth.claim 
	WHERE type = 'urn:sample:admin') THEN

INSERT INTO auth.claim(type, value) VALUES('urn:sample:admin', 'true');

END IF;

END
$$;