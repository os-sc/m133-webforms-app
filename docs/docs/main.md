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

##### Requirements for the application are:
 * users must be able register themselves
 * users must be able to log in to their accouns
 * users must fill in their personal data after the first login
 * users must be able to view and edit their personal data once logged in
 * users must be able to make a rental for a toy
 * users must be able to view all their past rentals


### Planing

#### Page Layout

As a not logged-in user

```
  Main
  |---Login
  |---Register
```

Once logged in, the user is presented with following page layout
<!-- TODO -->
```
  Main
  |---My Account
  |   |---Account Settings
  |       |---Change Personal Data
  |       |---Change Password
  |---My Rentals
      |---New Rental
```


### Test Criteria

<!-- TODO -->


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

#### Data Structure

The data will be saved in the `JSON`-format as a file
on the file system of the server.  

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




