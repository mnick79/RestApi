create database demoshop;
\c demoshop;
create table customer(
number serial PRIMARY key,
first_name varchar(50) NOT NULL,
last_name varchar(50) NOT NULL,
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
description varchar(255),
customer_number integer REFERENCES customer(number)
);

create table details (
number serial PRIMARY KEY,
cart_number integer REFERENCES cart(number) ON DELETE CASCADE,
product_number integer REFERENCES product(number),
count integer NOT NULL);

COPY customer from 'c:\copydb\customer.csv' csv HEADER;
COPY product 	from 'c:\copydb\product.csv' csv HEADER;
COPY cart from 'c:\copydb\cart.csv' csv HEADER;
COPY details from 'c:\copydb\details.csv' csv HEADER;

-- Суммирование данных полного заказа в поле totalprice таблицы cart
update cart as cart1
set totalprice = (select sum(d.count*p.price) 
					from cart join details d on cart.number=d.cart_number 
					join product p on d.product_number=p.number 
					where cart.customer_number=cart1.customer_number);

-- Заполнение описания заказа в поле description таблицы cart
update cart as cart1
set description = (select 
SUBSTRING(
STRING_AGG(p.name || '/count:'|| d.count || '/price'|| p.price, '|') 
FROM 0 FOR 254) 
from customer c 
join  cart on c.number=cart.customer_number 
join details d on cart.number=d.cart_number 
join product p on d.product_number=p.number 
where cart.customer_number=cart1.customer_number);

select SETVAL('customer_number_seq', (select max(number) from customer)); -- поправка SEQUENCE для таблицы customer
select SETVAL('product_number_seq', (select max(number) from product)); -- поправка SEQUENCE для таблицы product
select SETVAL('cart_number_seq', (select max(number) from cart)); -- поправка SEQUENCE для таблицы cart
select SETVAL('details_number_seq', (select max(number) from details)); -- поправка SEQUENCE для таблицы details
