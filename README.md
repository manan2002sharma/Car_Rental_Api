# Car Rental API

All screenshots are there in screenshots folder

## Endpoints

### Car Controller

**1. Get Available Cars**
`/api/Car/GetAvailableCars`
* **HTTP Method:** GET
* **Authorization:** User or Admin
* **Description:** Retrieves a list of available cars.
* **Response:**
  * **200 OK:** Returns a list of available cars.
  * **401 Unauthorized:** Unauthorized access.
  * **500 Internal Server Error:** Server error.
 ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_GetAvailableCars_Admin.png)  
 

**2. Add Car**
`/api/Car/addCar`
* **HTTP Method:** POST
* **Authorization:** Admin
* **Description:** Adds a new car to the system.
* **Request Body:** Car details (e.g., model, year, availability status).
* **Response:**
  * **201 Created:** Car added successfully.
  * **400 Bad Request:** Invalid car data.
  * **401 Unauthorized:** Unauthorized access.
  * **500 Internal Server Error:** Server error.
 ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_addCar_withdataShownBelow.png)  
 
**3. Update Car Availability**
`/api/Car/UpdateCarAvailabilty/{id}`
* **HTTP Method:** PUT
* **Authorization:** Admin
* **Path Parameter:**
  * `{id}` (Guid, required): The ID of the car to update.
* **Description:** Updates the availability status of a car.
* **Response:**
  * **200 OK:** Car availability updated successfully.
  * **400 Bad Request:** Invalid car ID.
  * **401 Unauthorized:** Unauthorized access.
  * **500 Internal Server Error:** Server error.
  
 ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_UpdateCarAvailability_Admin.png)  
 
**4. Get Car by ID**
`/api/Car/{id}`
* **HTTP Method:** GET
* **Authorization:** User or Admin
* **Path Parameter:**
  * `{id}` (Guid, required): The ID of the car to retrieve.
* **Description:** Retrieves a specific car by its ID.
* **Response:**
  * **200 OK:** Returns the car details.
  * **404 Not Found:** Car not found.
  * **401 Unauthorized:** Unauthorized access.
  * **500 Internal Server Error:** Server error.
 ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_getByid_admin.png)   
 

**5. Rent Car**
`/api/Car/RentCar`
* **HTTP Method:** PUT
* **Authorization:** User or Admin
* **Request Body:** Rent car details (e.g., user ID, rental start date, rental end date).
* **Description:** Rents a car.
* **Response:**
  * **200 OK:** Car rented successfully.
  * **400 Bad Request:** Invalid rental details.
  * **401 Unauthorized:** Unauthorized access.
  * **404 Not Found:** Car not found or unavailable.
  * **500 Internal Server Error:** Server error.

 ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_RentCar_Admin_TryingToRentUnavailableCar.png)  
  ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/car_RentCar_Admin_CarRentedAndMaiilSent.png)
   ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/Mail_sent_with_details_to_user_on_renting.png)
 

### User Controller

**1. Login**
`/api/User/Login`
* **HTTP Method:** POST
* **Request Body:** Login credentials (username, password).
* **Description:** Logs in a user.
* **Response:**
  * **200 OK:** Returns an authentication token.
  * **400 Bad Request:** Invalid login credentials.
  * **401 Unauthorized:** Unauthorized access.
  * **500 Internal Server Error:** Server error.

   ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/user_Login_Admin.png)  
 

**2. Register User**
`/api/User/RegisterUser`
* **HTTP Method:** POST
* **Request Body:** User registration details (username, password, email, etc.).
* **Description:** Registers a new user.
* **Response:**
  * **201 Created:** User registered successfully.
  * **400 Bad Request:** Invalid user data.
  * **500 Internal Server Error:** Server error.
   ![ScreenShot](https://raw.github.com/manan2002sharma/Car_Rental_Api/master/Screenshots/user_registerUser_Admin.png) 
 
 
---
## Services

**CarService**

**Methods:**

* **addCar(Car car):** Adds a new car to the database.
* **UpdateCarAvailability(Guid id):** Updates the availability of a car.
* **GetAvailableCars():** Retrieves a list of available cars.
* **GetCarById(Guid id):** Retrieves a specific car by its ID.
* **RentCar(RentCarDetails details):** Rents a car, updates availability, and sends a confirmation email.

---

**UserService**

**Methods:**

* **RegisterUser(User user):** Delegates user registration to the UserRepo.
* **LoginUser(LoginCredentials credentials):** Delegates user authentication to the UserRepo.
---
**EmailService**

**Method:**

* **SendEmailAsync(string email, string subject, string message):** Sends an email asynchronously using SMTP configuration from `IConfiguration`.

---

**JwtService**

**Method:**

* **GenerateToken(string username, string role):** Generates a JWT token with claims for username, role, and a unique identifier. The token is signed with a secret key and expires in one hour.

---

## Repositories

**CarRepo**

**Methods:**

* **AddCar(Car car):** Adds a new car to the database.
* **UpdateCarAvailabilty(Guid id):** Updates the availability of a car.
* **GetCarById(Guid id):** Retrieves a specific car by its ID.
* **GetAvailableCars():** Retrieves a list of available cars.


---

**UserRepo**

**Methods:**

* **RegisterUser(User user):** Registers a new user.
* **LoginUser(LoginCredentials loginCredentials):** Authenticates a user and generates a JWT token based on the user's role.




