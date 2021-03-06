
# Recepticon Web

Recepticon web is a full-stack adaptation of a Hotel Front Desk Application I built on C# WinForm. It consists of a Receptionist Page where new guests can registered and an Admin Page where users, rooms and guests are managed.

[![Recepticon Landing Page](https://github.com/paulonevrything/recepticon-web/raw/main/landing.png)](https://github.com/paulonevrything/recepticon-web/blob/main/landing.png)

## [](https://github.com/paulonevrything/recepticon-web#task)Task

A solution containing a WebAPI, Docker and a frontend based on a Typescript based Single Page Application Framework

## [](https://github.com/paulonevrything/recepticon-web#table-of-contents)Table of Contents

-   [Features](https://github.com/paulonevrything/recepticon-web#features)
    -   [Authentication](https://github.com/paulonevrything/recepticon-web#authentication)
    -   [Receptionist Users](https://github.com/paulonevrything/recepticon-web#receptionist-users)
    -   [Admin Users](https://github.com/paulonevrything/recepticon-web#admin-users)
-   [Scope of my solution](https://github.com/paulonevrything/recepticon-web#scope-of-my-solution)
    -   [Backend](https://github.com/paulonevrything/recepticon-web#backend)
    -   [User Interface](https://github.com/paulonevrything/recepticon-web#user-interface)
-   [Limitations](https://github.com/paulonevrything/recepticon-web#limitations)
-   [Likely Improvements](https://github.com/paulonevrything/recepticon-web#likely-improvements)
-   [Installation Information](https://github.com/paulonevrything/recepticon-web#installation-information)

## [](https://github.com/paulonevrything/recepticon-web#features)[](https://github.com/paulonevrything/recepticon-web#features)Features

Recepticon Web consists of the following features:

### [](https://github.com/paulonevrything/recepticon-web#authentication)[](https://github.com/paulonevrything/recepticon-web#authentication)Authentication

-   It uses JSON Web Token (JWT) for authentication.
-   Token is generated on user login
-   Token is perpetually verified to check the state of the user if logged in or not.
-   Admin User is pre-seeded into the application with administrative priviledges
-   Admin User can create ne users and set their role to either Receptionist or Admin

### [](https://github.com/paulonevrything/recepticon-web#receptionist-users)[](https://github.com/paulonevrything/recepticon-web#receptionist)Receptionist Users

-   Users can log in
-   Users can Create Hotel Guest

### [](https://github.com/paulonevrything/recepticon-web#admin-users)[](https://github.com/paulonevrything/recepticon-web#admin)Admin Users

-   Admin Users have all priviledges as Normal Users.
-   Admin Users can log in
-   Admin Users can manage (add, update and delete) application Users
-   Admin Users can manage (add, update and delete) rooms and room types
-   Admin Users can manage (add and checkout) hotel guests

## [](https://github.com/paulonevrything/recepticon-web#scope-of-my-solution)[](https://github.com/paulonevrything/recepticon-web#scope)Scope of my solution

#### [](https://github.com/paulonevrything/recepticon-web#backend)[](https://github.com/paulonevrything/recepticon-web#scope-backend)Backend

-   N-Tiered archticature for project structure
-   Entity framework for ORM
-   Unit of Work and Repository Pattern
-   Service interface and implementation class that handles the logic
-   Unit tests on the API controllers
-   Open API documentation using Swagger UI
-   Hangfire Background Task that automatically returns the status of a previously booked room to vacant on the due date
-   MSSQL for the Database.

### [](https://github.com/paulonevrything/recepticon-web#user-interface)[](https://github.com/paulonevrything/recepticon-web#scope-ui)User Interface

-   A single page application built with Angular using  [Angular Material](https://material.angular.io/)  compnents
-   Webpack: Webpack is a module bundler. Its main purpose is to bundle JavaScript files for usage in a browser, yet it is also capable of transforming, bundling, or packaging modules.
-   Modularized project structure.

## [](https://github.com/paulonevrything/recepticon-web#limitations)[](https://github.com/paulonevrything/recepticon-web#limitations)Limitations

The limitations with this current version of Recepticon includes:

-   No pagenation on the get all guest endpoint
-   Guests cannot be manually checked out

## [](https://github.com/paulonevrything/recepticon-web#likely-improvements)[](https://github.com/paulonevrything/recepticon-web#improvements)Likely Improvements

Along with handling of the aforementioned limitations, the following improvements can be made:

-   More test coverage
-   Caching with Redis
-   Better UX
-   More batch processing abilities using background tasks and queues

## [](https://github.com/paulonevrything/recepticon-web#installation-information)[](https://github.com/paulonevrything/recepticon-web#installation)Installation information

Clone the project
```
git clone https://github.com/paulonevrything/recepticon-web
```

From the project root, run the following:
```
docker-compose build
docker-compose up
```
Launch the API on [http://localhost:8000/](http://localhost:8000/)

Launch the UI on [http://localhost:5006/](http://localhost:5006/)