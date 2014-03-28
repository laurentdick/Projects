--
-- PostgreSQL database cluster dump
--

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Roles
--

CREATE ROLE postgres;
ALTER ROLE postgres WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION PASSWORD 'md53fd3ac6867bbfa793fa3c724174b8844';






--
-- Database creation
--

CREATE DATABASE "Papyrus" WITH TEMPLATE = template0 OWNER = postgres;
REVOKE ALL ON DATABASE template1 FROM PUBLIC;
REVOKE ALL ON DATABASE template1 FROM postgres;
GRANT ALL ON DATABASE template1 TO postgres;
GRANT CONNECT ON DATABASE template1 TO PUBLIC;


\connect "Papyrus"

SET default_transaction_read_only = off;

--
-- PostgreSQL database dump
--

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


SET search_path = public, pg_catalog;

--
-- Name: getentcom(smallint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION getentcom(n smallint) RETURNS TABLE("NUMCOM" integer, "DATCOM" date, "OBSCOM" character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
	IF n = -1 THEN
		RETURN QUERY SELECT "T"."numcom", "T"."datcom", "T"."obscom" FROM "entcom" AS "T";
	ELSE
		RETURN QUERY SELECT "T"."numcom", "T"."datcom", "T"."obscom" FROM "entcom" AS "T" WHERE "numfou"=n;
	END IF;
END
$$;


ALTER FUNCTION public.getentcom(n smallint) OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: entcom; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE entcom (
    numcom integer NOT NULL,
    obscom character varying(25),
    datcom date NOT NULL,
    numfou integer NOT NULL
);


ALTER TABLE public.entcom OWNER TO postgres;

--
-- Name: fournis; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE fournis (
    numfou integer NOT NULL,
    nomfou character varying(30) NOT NULL,
    ruefou character varying(40) NOT NULL,
    posfou character varying(5) NOT NULL,
    vilfou character varying(30) NOT NULL,
    confou character varying(15) NOT NULL,
    satisf smallint,
    CONSTRAINT "CK_POSFOU" CHECK ((length((posfou)::text) = 5)),
    CONSTRAINT "CK_SATISF" CHECK (((satisf > 0) AND (satisf <= 10)))
);


ALTER TABLE public.fournis OWNER TO postgres;

--
-- Name: ligcom; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE ligcom (
    numcom integer NOT NULL,
    numlig smallint NOT NULL,
    codart character(4) NOT NULL,
    qtecde smallint NOT NULL,
    priuni money,
    qteliv smallint,
    derliv date
);


ALTER TABLE public.ligcom OWNER TO postgres;

--
-- Name: produit; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE produit (
    codart character(4) NOT NULL,
    libart character varying(30) NOT NULL,
    stkale smallint NOT NULL,
    stkphy smallint NOT NULL,
    qteann smallint NOT NULL,
    unimes character(5)
);


ALTER TABLE public.produit OWNER TO postgres;

--
-- Name: vente; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE vente (
    codart character(4) NOT NULL,
    numfou integer NOT NULL,
    delliv date NOT NULL,
    qte1 smallint NOT NULL,
    prix1 money NOT NULL,
    qte2 smallint,
    prix2 money,
    qte3 smallint,
    prix3 money
);


ALTER TABLE public.vente OWNER TO postgres;

--
-- Data for Name: entcom; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY entcom (numcom, obscom, datcom, numfou) FROM stdin;
70010		2007-02-10	120
70011	Commande urgente	2007-03-01	540
70020		2007-04-25	9180
70025	Commande urgente	2007-04-30	9150
70210	Commande cadencée	2007-05-05	120
70300		2007-06-06	9120
70250	Commande cadencée	2007-10-02	8700
70620		2007-10-02	540
70625		2007-10-09	120
70629		2007-10-12	9180
\.


--
-- Data for Name: fournis; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY fournis (numfou, nomfou, ruefou, posfou, vilfou, confou, satisf) FROM stdin;
120	GROBRIGAN	20 rue du papier	92200	papercity	Georges	8
540	ECLIPSE	53 rue laisse flotter les rubans	78250	Bugbugville	Nestor	7
8700	MEDICIS	120 rue des plantes	75014	Paris	Lison	\N
9120	DISCOBOL	11 rue des sports	85100	La Roche sur Yon	Hercule	8
9150	DEPANPAP	26 avenue des locomotives	59987	Coroncountry	Pollux	5
9180	HURRYTAPE	68 boulevard des octets	04044	Dumpville	Track	\N
10	DICK	18, rue du REDELACH	57580	LESSE	Laurent	3
\.


--
-- Data for Name: ligcom; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY ligcom (numcom, numlig, codart, qtecde, priuni, qteliv, derliv) FROM stdin;
70629	2	B002	200	140,00 €	\N	2007-12-31
70010	1	I100	3000	470,00 €	3000	2007-03-15
70010	2	I105	2000	485,00 €	2000	2007-07-05
70010	3	I108	1000	680,00 €	1000	2007-08-20
70010	4	D035	200	40,00 €	250	2007-02-20
70010	5	P220	6000	3 500,00 €	6000	2007-03-31
70010	6	P240	6000	2 000,00 €	2000	2007-03-31
70011	1	I105	1000	600,00 €	1000	2007-05-16
70020	1	B001	200	140,00 €	\N	2007-12-31
70020	2	B002	200	140,00 €	\N	2007-12-31
70025	1	I100	1000	590,00 €	1000	2007-05-15
70025	2	I105	500	590,00 €	500	2007-05-15
70210	1	I100	1000	470,00 €	1000	2007-07-15
70210	2	P220	10000	3 500,00 €	10000	2007-08-31
70300	1	I110	50	790,00 €	50	2007-10-31
70250	1	P230	15000	4 900,00 €	12000	2007-12-15
70250	2	P220	10000	3 350,00 €	10000	2007-11-10
70620	1	I105	200	600,00 €	200	2007-11-01
70625	1	I100	1000	470,00 €	1000	2007-10-15
70625	2	P220	10000	3 500,00 €	10000	2007-10-31
70629	1	B001	200	140,00 €	\N	2007-12-31
\.


--
-- Data for Name: produit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY produit (codart, libart, stkale, stkphy, qteann, unimes) FROM stdin;
I100	Papier 1 ex continu	100	557	3500	B1000
I105	Papier 2 ex continu	75	5	2300	B1000
I108	Papier 3 ex continu	200	557	3500	B500 
I110	Papier 4 ex continu	10	12	63	B400 
P220	Pré imprimé commande	500	2500	24500	B500 
P230	Pré imprimé facture	500	250	12500	B500 
P240	Pré imprimé bulletin paie	500	3000	6250	B500 
P250	Pré imprimé bon livraison	500	2500	24500	B500 
P270	Pré imprimé bon fabrication	500	2500	24500	B500 
R080	Ruban Epson 850	10	2	120	unité
R132	Ruban imp1200 lignes	25	200	182	unité
B002	Bande magnétique 6250	20	12	410	unité
B001	Bande magnétique 1200	20	87	240	unité
D035	CD R slim 80 mm	40	42	150	B010 
D050	CD R-W 80mm	50	4	0	B010 
\.


--
-- Data for Name: vente; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY vente (codart, numfou, delliv, qte1, prix1, qte2, prix2, qte3, prix3) FROM stdin;
I100	120	1900-04-01	0	700,00 €	50	600,00 €	120	500,00 €
I100	540	1900-03-12	0	710,00 €	60	630,00 €	100	600,00 €
I100	9120	1900-03-02	0	800,00 €	70	600,00 €	90	500,00 €
I100	9150	1900-04-01	0	650,00 €	90	600,00 €	200	590,00 €
I100	9180	1900-01-31	0	720,00 €	50	670,00 €	100	490,00 €
I105	120	1900-04-01	10	705,00 €	50	630,00 €	120	500,00 €
I105	540	1900-03-12	0	810,00 €	60	645,00 €	100	600,00 €
I105	9120	1900-03-02	0	920,00 €	70	800,00 €	90	700,00 €
I105	9150	1900-04-01	0	685,00 €	90	600,00 €	200	590,00 €
I105	8700	1900-01-31	0	720,00 €	50	670,00 €	100	510,00 €
I108	120	1900-04-01	5	795,00 €	30	720,00 €	100	680,00 €
I108	9120	1900-03-02	0	920,00 €	70	820,00 €	100	780,00 €
I110	9180	1900-04-01	0	900,00 €	70	870,00 €	90	835,00 €
I110	9120	1900-03-02	0	950,00 €	70	850,00 €	90	790,00 €
D035	120	1900-01-01	0	40,00 €	\N	\N	\N	\N
D035	8700	1900-01-06	0	40,00 €	100	30,00 €	\N	\N
D035	540	1900-01-01	0	40,00 €	\N	\N	\N	\N
D035	9120	1900-01-06	0	40,00 €	100	30,00 €	5	0,00 €
I108	8700	1900-01-09	0	37,00 €	\N	\N	\N	\N
I105	9180	1900-01-09	0	37,00 €	\N	\N	\N	\N
P220	120	1900-01-16	0	3 700,00 €	100	3 500,00 €	\N	\N
P230	120	1900-01-31	0	5 200,00 €	100	5 000,00 €	\N	\N
P240	120	1900-01-16	0	2 200,00 €	100	2 000,00 €	\N	\N
P250	120	1900-01-31	0	1 500,00 €	100	1 400,00 €	500	1 200,00 €
P250	9120	1900-01-31	0	1 500,00 €	100	1 400,00 €	500	1 200,00 €
P220	8700	1900-01-21	50	3 500,00 €	100	3 350,00 €	\N	\N
P230	8700	1900-03-02	0	5 000,00 €	50	4 900,00 €	\N	\N
R080	9120	1900-01-11	0	120,00 €	100	100,00 €	\N	\N
R132	9120	1900-01-06	0	275,00 €	\N	\N	\N	\N
B001	8700	1900-01-16	0	150,00 €	50	145,00 €	100	140,00 €
B002	8700	1900-01-16	0	210,00 €	50	200,00 €	100	185,00 €
\.


--
-- Name: PK_ENTCOM; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY entcom
    ADD CONSTRAINT "PK_ENTCOM" PRIMARY KEY (numcom);


--
-- Name: PK_FOURNIS; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY fournis
    ADD CONSTRAINT "PK_FOURNIS" PRIMARY KEY (numfou);


--
-- Name: PK_LIGCOM; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY ligcom
    ADD CONSTRAINT "PK_LIGCOM" PRIMARY KEY (numcom, numlig);


--
-- Name: PK_PRODUIT; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY produit
    ADD CONSTRAINT "PK_PRODUIT" PRIMARY KEY (codart);


--
-- Name: PK_VENTE; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY vente
    ADD CONSTRAINT "PK_VENTE" PRIMARY KEY (codart, numfou);


--
-- Name: FK_ENTCOM_FOURNIS; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY entcom
    ADD CONSTRAINT "FK_ENTCOM_FOURNIS" FOREIGN KEY (numfou) REFERENCES fournis(numfou) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: FK_LIGCOM_ENTCOM; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY ligcom
    ADD CONSTRAINT "FK_LIGCOM_ENTCOM" FOREIGN KEY (numcom) REFERENCES entcom(numcom) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: FK_LIGCOM_PRODUIT; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY ligcom
    ADD CONSTRAINT "FK_LIGCOM_PRODUIT" FOREIGN KEY (codart) REFERENCES produit(codart) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: FK_VENTE_FOURNIS; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY vente
    ADD CONSTRAINT "FK_VENTE_FOURNIS" FOREIGN KEY (numfou) REFERENCES fournis(numfou) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: FK_VENTE_PRODUIT; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY vente
    ADD CONSTRAINT "FK_VENTE_PRODUIT" FOREIGN KEY (codart) REFERENCES produit(codart) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

\connect postgres

SET default_transaction_read_only = off;

--
-- PostgreSQL database dump
--

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- Name: postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- Name: adminpack; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION adminpack; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';


--
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

\connect template1

SET default_transaction_read_only = off;

--
-- PostgreSQL database dump
--

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- Name: template1; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE template1 IS 'default template for new databases';


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


--
-- PostgreSQL database dump complete
--

--
-- PostgreSQL database cluster dump complete
--

