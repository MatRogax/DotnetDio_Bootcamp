--1 Questao

select
	"Nome",
	"Ano"
from
	"Filmes"

--2  Questao


select
	*
from
	"Filmes"
order by
	"Ano" asc

--3  Questao

select
	"Nome",
	"Ano",
	"Duracao"
from
	"Filmes"
where
	"Nome" like '%De Volta%'

--4  Questao
	
select
	"Nome",
	"Ano",
	"Duracao"
from
	"Filmes"
where
	"Ano" = '1997'

--5  Questao

select
	*
from
	"Filmes"
where
	"Ano" > '2000'

--6  Questao

select
	*
from
	"Filmes"
where
	"Duracao" > '100'
	and "Duracao" < '150'
order by
	"Duracao" asc

--7  Questao

select
	"Ano",
	COUNT(*) as quantidade_filmes,
	MAX("Duracao") as maior_duracao
from
	"Filmes"
group by
	"Ano"
order by
	quantidade_filmes desc;

--8 Questao

select
	*
from
	"Atores"
where
	"Genero" = 'M'
	
--9  Questao
	
select
	*
from
	"Atores"
where
	"Genero" = 'F'
order by
	"PrimeiroNome" asc
	
--10 Questao
	
	select
	*
from
	"Generos"
	
	select
	*
from
	"FilmesGenero"
	
--11 Questao	
select
	"Filmes"."Nome",
	"Generos"."Genero"
from
	"Filmes"
inner join "FilmesGenero" on
	"Filmes"."Id" = "FilmesGenero"."IdFilme"
inner join "Generos" on
	"Generos"."Id" = "FilmesGenero"."IdGenero"
	and
	"Generos"."Genero" = 'Mistério';

--12  Questao

select * from "ElencoFilme"

select * from "Atores"

select
	"Filmes"."Nome",
	"Atores"."PrimeiroNome",
	"Atores"."UltimoNome",
	"ElencoFilme"."Papel"
from
	"Filmes"
inner join "ElencoFilme"
on
	"Filmes"."Id" = "ElencoFilme"."IdFilme"
inner join "Atores"
on
	"Atores"."Id" = "ElencoFilme"."IdAtor"




