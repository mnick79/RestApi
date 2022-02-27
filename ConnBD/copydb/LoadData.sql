create database demoshop;
\c demoshop;
create table customer(
id serial PRIMARY key,
first_name varchar(50) NOT NULL,
last_nane varchar(50) NOT NULL,
address varchar(255) NOT NULL,
vip boolean NOT NULL
);

create table product(
number serial PRIMARY key,
name varchar(255) NOT NULL,
price decimal NOT NULL
);

create table cart (
number serial PRIMARY KEY,
totalprice decimal,
customer_id integer REFERENCES customer(id),
description varchar(255)
);

create table details (
id serial PRIMARY KEY,
cart_number integer REFERENCES cart(number),
product_number integer REFERENCES product(number),
count integer NOT NULL);

COPY customer from 'c:\copydb\customer.csv' csv HEADER;
COPY product 	from 'c:\copydb\product.csv' csv HEADER;
COPY cart from 'c:\copydb\cart.csv' csv HEADER;
COPY details from 'c:\copydb\details.csv' csv HEADER;

SELECT count(*) from customer;
SELECT count(*) from product;
SELECT count(*) from cart;
SELECT count(*) from details;