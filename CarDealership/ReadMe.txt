HOW TO SET UP THE DATABASE!!!

OPEN and EXICUTE the "CreateCarDb" SQL query file, located in the SQL file.

OPEN _____ solution located in the CarDealership folder. 

RUN the update-database command in the package manager in visual studio. 

OPEN and EXICUTE the "CarDbTablesReplacer" SQL query file, located in the SQL file.



ALSO IMPORTANT:

The "SPROCS" SQL query file, located in the SQL file, creates all sprocs needed for the solution.
AND
The "DbResetSprock" SQL query file, located in the SQL file, can create the sproc for resting the data in the database. DO NOT PUSH TO PRODUCTION









LESS IMPORTANT:


USER STORIES:

As a Customer, I want access a car dealership website, so I can find the car thats right for me. 
	Display the Homepage in the browser.
	Click a special in the 'Jumbotron'and be brought to the specials page with a list of all the specials information from the database..

As a Customer, I want to browse the vehicles on special, so that I can know what car is right for me. 
	Click 'Specials' button in the nav bar and be brought to the Specials page with a list of all the specials information from the database.

As a Customer, I want to browse new vehicles, so that I can know what new car is right for me.
	Click 'New Inventory' button in the nav bar.
	Be brought to the New Inventory page.
	Search by: Make, Model, Year, PriceRange.
	Display cars fitting the discription.
		included info: picture, make, model, year, body style, transmission, color, interior, mileage, vin#, sale price, MSRP, and details button.	
	Click 'Details' button and be redirected to the Inventory/Details/id for the car with that Id.

As a Customer, I want to browse used vehicles, so that I can know what used car is right for me.
	Click 'Used Inventory' button in the nav bar.
	Be brought to the Used Inventory page.
	Search by: Make, Model, Year, PriceRange.
	Display cars fitting the discription.
		included info: picture, make, model, year, body style, transmission, color, interior, mileage, vin#, sale price, MSRP, and details button.
	Click 'Details' button and be redirected to the Inventory/Details/id for the car with that Id.

As a Customer, I want to view details for a vehicle, so that I can know more about the car.
	Click 'Details' button for a car, from a search, and be brought to that vehicles details page.
	Details will display: picture, make, model, year, body style, transmission, color, interior, mileage, vin#, sale price, MSRP, details, and contact button.
	Click 'Contact' button redirscts to the Home/Contact page with the VIN# in the message box of the form.

As a Customer, I want to contact the seller of a vehicle, so that I can ask questions.
	Click 'Contact Us' button in the nav bar.
	Be brought to the contact page, with map and address information.
		form: name, message, email, phone, and a submit button.
	Click 'Submit' button adds form to the Database.





As a Seller, I want to be able to login, so I can lookup cars and log a purchases.
	Form: Enter UserName, Enter Password, 'Submit' button.
	Click 'Submit' and be redirected to the Sales/Index page, or error message.

As a Seller, I want to be able to change my password, so I don't get locked out of my account.
	Form: Enter UserName, Enter NewPassword, Confirm NewPasssword, and 'Submit' button.
	Click 'Submit' to save new password, or get an error message.

As a Seller, I want to browse all vehicles, so that I can mark cars as purchased.
	Click 'Seller' button in the nav bar.
	Be brought to the Sales/Index page.
	Search by: Make, Model, Year, PriceRange.
	Display cars fitting the discription.
		included info: picture, make, model, year, body style, transmission, color, interior, mileage, vin#, sale price, MSRP, and purchase button.
	Click 'Purchase' button to redirects to Sales/Purchase/id page

As a Seller, I want to log a purchase, so that the vehicle removed from inventory searches, and added to the sales report.
	The Sales/Purchase/id page has the details for for a car with specified Id.
	Form: Name, Phone, Email, Street 1, Street 2, City, State, Zip, purchase price, purchase type, and 'Save' button.
	Click 'Save' button:
		Information in the database the vehicle should no longer show up in inventory searches and should only be viewed on the sales report. 
		The purchase date should be saved (today). 
		The sales person should be saved (currently logged in user).




As an Admin, I want to be able to login, so I can edit the inventory, available makes and models, users, and view sale reports.
	Form: Enter UserName, Enter Password, 'Submit' button.
	Click 'Submit' and be redirected to the Admin/Vehicles page, or error message.


As an Admin, I want to be able to change my password, so I don't get locked out of my account.
	Form: Enter UserName, Enter NewPassword, Confirm NewPasssword, and 'Submit' button.
	Click 'Submit' to save new password, or get an error message.

As an Admin, I want to browse all vehicles, Add or Update a car.
	An 'Add' button: redirects to Admin/Addvehicle page.
	Search by: Make, Model, Year, PriceRange.
	Display cars fitting the discription.
		included info: picture, make, model, year, body style, transmission, color, interior, mileage, vin#, sale price, MSRP, and edit button.
	Click 'Edit' button to redirects to Admin/Editvehicle/Id page.

As an Admin, I want to Add cars to the inventory, so that there are cars for customers to buy.
	Form: Make, Model, Type, BodyStyle, Year, Transmission, Color, Interior, Mileage, VIN#, MSRP, SalesPrice, Discription, Picture(upload button), and 'Save' button.
	Click 'Save', redirects to list of cars.

As an Admin, I want to Edit cars in the inventory, so that if it hails I can change stuff.
	Form: Make, Model, Type, BodyStyle, Year, Transmission, Color, Interior, Mileage, VIN#, MSRP, SalesPrice, Discription, Picture(upload button), 'Feature' checkbox, 'Delete' button, and 'Save' button.
	Click 'Save', save changes, redirects to list of cars.
	Click 'Delete', delete car, redirects to list of cars.

As an Admin, I want to view users, so that I know who to add, edit and delete.
	'Add new user' Link to the Admin/AddUser page, at the top.
	Table: Last, First, Email, Role, Edit(button).
	Click 'Edit' redirected to the Admin/EditUser page.

As an Admin, I want to Add users, so when we hire people, they can use the system.
	Form: first, last, email, role, password, confirm password, and 'Save' button.
	Click 'Save' redirects to the user list page.






	







