use WareHouse

--create table Sellers(
--	id int primary key identity(1,1) not null,
--	username nvarchar(50) not null,
--	password nvarchar(50) not null,
--	name nvarchar(50) not null,
--	surname nvarchar(50) not null
--)


--create table Customers(
--	customer_id int primary key identity(1,1) not null,
--	name nvarchar(50) not null,
--	surname nvarchar(50) not null,
--	email nvarchar(50) not null,
--	phone nvarchar(50) not null,
--	address nvarchar(100) not null,
--)


--create table Products(
--	product_id int primary key identity(1,1) not null,
--	name nvarchar(50) not null,
--	price nvarchar(50) not null,
--	quantity decimal(10, 1) not null,
--	description nvarchar(100) not null
--)


--create table Orders(
--	order_id int primary key identity(1,1) not null,
--	arrive_time datetime not null,
--	orderAmount decimal(10, 1) not null,
--	customer_id int foreign key references Customers(customer_id) not null,
--	product_id int foreign key references Products(product_id) not null
--)

select * from Sellers
select * from Customers
select * from Products
select * from Orders


insert into Sellers(username, password, name, surname) values('username4', 'password4', 'name4', 'surname4')
insert into Customers(name, surname, email, phone, address) values('cname5', 'csurname5', 'email5.com', '887552323', 'adress5')
insert into Products(name, price, quantity, description) values('pname7','1000','15', 'perfect')
insert into Orders(arrive_time, orderAmount,customer_id, product_id) values('06/07/2020','2', 3, 3)


select quantity from products where name like 'iphoneX'
select name from Customers


delete orders where order_id = 18
delete customers where customer_id = 4
delete Products where product_id = 4

UPDATE Products SET price = '2500' WHERE product_id = 10


-- SELECT WITH JOIN
select c.name + ' ' + c.surname as Fullname, p.name, p.price*o.orderAmount as TotalPrice, p.description, o.orderAmount, o.order_id, o.arrive_time
from Orders o 
join Customers c on o.customer_id = c.customer_id
join Products p on o.product_id = p.product_id
order by order_id desc


select o.order_id, c.name + ' ' + c.surname as Fullname, p.name, o.orderAmount, p.price, p.price*o.orderAmount as TotalPrice, o.arrive_time 
from Orders o
join Customers c on o.customer_id = c.customer_id 
join Products p on o.product_id = p.product_id 
order by order_id desc