# Documentation

## Foreword

The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL
NOT", "SHOULD", "SHOULD NOT", "RECOMMENDED",  "MAY", and
"OPTIONAL" in this document are to be interpreted as described in
RFC 2119.  
*Please note that this is regardless of the key word's case.*  


******
## Analysis

The toy rental company `SpielGut` wants us to implement a web application for managing
the rentals and letting users register themselves and manage their accounts and rentals.  
The web application **will not** handle toy management, as this is already implemented in their
Desktop application.  

### Requirements

#### Functional Requirements
 * users must be able register themselves
 * users must be able to log in to their accouns
 * users must fill in their personal data after the first login
 * users must be able to view and edit their personal data once logged in
 * users must be able to make a rental for a toy
 * users must be able to view all their past rentals

#### Non-Functional Requirements
 * the toys must be saved serverside in a file
 * the same applies to rentals
 * every game must only be available once, therefore it can only be rented once at a time
 * every rental must only consist of one toy
 * a user must be able to have more than one rental at a time

#### Non-Defined Requirements
These are some requirements that the document received does not clearly state
so following are decisions made by myself.  

 * rentals can be extended an unlimited amount of times, as long as they are active  
 * when renting a toy, the rental starts instantly and cannot be   
 <!-- TODO -->

### Planing

#### Page Layout

As a not logged-in user:  

```
  Main
  |---Login
  |---Register
```

Once logged in, the user is presented with following page layout:  

```
  Main
  |---My Account
  |   \--Change Personal Details
  
  |   \--Change Password
  |   \--Logout
  |
  |---My Rentals
      \--New Rental
```

#### Page Design & UX

In order to present the user with a solid UX experience
and a consistent appearing UI, Google's `Material Design Lite`-library will
be used.
The library allows for an easy, quick and seamless integration and
is very lightweight.  

The Application is going to be responsive since that is a necessity
to provide mobile users with a good UX experience.
To ease this process, the design will be based on cards, this means,
that the pages content is presented on card of different sizes,
which in turn makes it easy to append content later without breaking page flow
or layout.  

### Test Criteria

#### Login / Registration

 * As long as the user is not authenticated, the `Login` and `Register` menu entries must be displayed and the menu entries for logged in users (like `My Account`) shall not.  
 * When a user registrates and does not enter valid information (like non-matching passwords) the user shall be notified using a `Toast`\* or simmilar error reporting.  

#### Rentals

 * Once a Toy is in rental it should no longer be available for rental by other users  
 * A Toy can be rented for one or two weeks initially  
 * At any point a toy can be extended an unlimited number of times, as long as the rental is still active  

#### Users & User Data
 * Users need to be able to change their data from the `My Account` menu
 * The same goes for their passwords  
 * After successful saving of the new data or an error during the saving or receiving the user should be notified about it through a `Toast`\*  

\* `Toast`: *A `Toast` is an element commonly used in `Material Design` that pops up, usually from the bottom of the screen, to display a message*  

******
## Concept

### Functionality

When registering as a new customer the user must fill in his
personal data, including, but not limited to, his full name and address.  

After a successfull registration and/or login, the user will be
able to navigate to his personal profile page, where the user has
the ability to chose to view or edit his personal data or reset
his password.
Note that he **will not** be able to view his password
as it is in a hashed state, which is irreversable for
security reasons.  

The user may also chose to navigate to the `My Rentals`-page,
where he has the ability to view his past rentals and view or extend
the currently active ones as well as make a new reservation.  

Every toy is only found once in the library and
can therefore only be rented once at the same time.  

### Realization Concept

#### Time Table

|Date          |Plans
|:-------------|:----
|**06.12.2016**| Start project
|09.12.2016    | Finished analysis parts of documentation and rough estimate of time table
|13.12.2016    | Mostly finished Concepts
|18.12.2016    | Done with implementation and Realization chapters of documentation
|**20.12.2016**| Deadline project (1700)
|08.01.2017    | Finished preparing the presenation
|**10.01.2017**| Presentation

#### Data Structure

All data will be saved in the `XML` format as a file
on the file system of the server.  

There will be a need for three types of data: `Users`, `Rentals`, `Toys`.  
These could be saved in separate `XML` files `users.json`, `rentals.json`
and `toys.json`.

#### User Data
<!-- TODO: User handling/registration -->

The password rules are set to allow any combination of characters
as long as the amount of characters exceeds 15 (and less than 64 to protect the server from `DOS`-attacks), no requirements for
a minimum set of numbers, special characters or the like.
This is because a longer password is more secure than a shorter,
more sophisticated one and enforcing specific characters encourages the
user to just add them to the beginning or the end of their passwords.  

Password and other user data storage

#### Objects

The Application will use an `Object Oriented` approach to
handle data, therefore there will be multiple objects.
The following are the objects that will probably be necessary for
the application's implementation.  
There might be a need to add additional ones later down the
development process.  

```
TOY

Properties:
+ Manufacturer
+ Name
```

```
USER

Properties:
+ Username
+ PermissionSet
```

```
PERMISSIONSET

Properties:
+ Name
+ PermissionList

Functions:
+ Contains(permission): bool
```

```
PERMISSION

Properties:
+ Name
```

```
RENTAL

Properties:
+ User
+ Toy
+ StartDate
+ DueReturnDate
```



******
## Realization

<!-- TODO -->

### Specific Functionality

<!-- TODO -->




