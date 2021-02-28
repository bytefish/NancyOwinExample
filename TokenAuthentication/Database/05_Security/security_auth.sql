DO $$
BEGIN

REVOKE ALL ON auth.user FROM public;

END;
$$;