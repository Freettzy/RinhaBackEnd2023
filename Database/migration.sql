create table pessoa (
	id varchar(36) default gen_random_uuid() primary key not null,
	apelido varchar(32) unique not null,
	nome varchar(100) not null,
	nascimento date not null,
	stack varchar(36)[]
);