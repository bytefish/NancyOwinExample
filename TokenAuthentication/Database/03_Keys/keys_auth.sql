DO $$
BEGIN

IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'user_claim_userid_fkey') THEN
	ALTER TABLE auth.user_claim
		ADD CONSTRAINT user_claim_userid_fkey
		FOREIGN KEY (user_id) REFERENCES auth.user(user_id);
END IF;

IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'user_claim_claimid_fkey') THEN
	ALTER TABLE auth.user_claim
		ADD CONSTRAINT user_claim_claimid_fkey
		FOREIGN KEY (claim_id) REFERENCES auth.claim(claim_id);
END IF;

IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'uk_user_name') THEN
	ALTER TABLE auth.user
		ADD CONSTRAINT uk_user_name
		UNIQUE (name);
END IF;

IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'uk_user_claim') THEN
	ALTER TABLE auth.user_claim
		ADD CONSTRAINT uk_user_claim
		UNIQUE (user_id, claim_id);
END IF;

END;
$$;