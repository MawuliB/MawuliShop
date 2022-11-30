# MawuliShop
# Overview
This is an inventory management system for both the admin and the attendant. This is basically for monitoring sales, keeping track of items and processing purchases

# Functional Requirements

* Admin
- Login into the system (dashboard)
- Add edit and delete products details 
- Increase product quantity
- Add, edit and delete attendant details
- Add category details for the product
- View sales. Per attendant and overall sales 

* Attendant
- Login into the provided he is authorised
- View products
      + Process Sales
- Add product and quantity being purchased
- Edit and delete product details in the checkout section
- Calculate the change to be given to the customer
- Print receipt for the customer 
- Logout


# Assumptions
- Unavailable products can't be brought to the counter.
- Admin won't add the same Attendant or same product or same category twice. 
- It will be used on the shop's PC
- Data will be stored locally and by choice would be transferred to the cloud
- Instead of barcode reader the search function on the sales screen give the gist of how the product can be fetched and read in the checkout list


# How to get it working
- Git Pull or download and unzip the file
- Just incase, visual studio 19 was used.
- Create **Microsoft SQL Server Database File (SqlClient)** with the tables below


![alt text](https://github.com/MawuliB/MawuliShop/blob/master/git.png)
![alt text](https://github.com/MawuliB/MawuliShop/blob/master/1.png)
![alt text](https://github.com/MawuliB/MawuliShop/blob/master/2.png)
![alt text](https://github.com/MawuliB/MawuliShop/blob/master/3.png)
![alt text](https://github.com/MawuliB/MawuliShop/blob/master/4.png)
![alt text](https://github.com/MawuliB/MawuliShop/blob/master/5.png)


- **Run**
