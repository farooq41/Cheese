# Cheese

## **.NET CORE/Angular App to manage cheese business.**

## **Overview**
**App Features**
1.	User can add a cheese
2.	User can edit a cheese
3.  User can delete a cheese
4.  User can view all cheese

**Application structure & Tech Stack**
1.	CheeseWeb - It is an Angular 5 .NET Core 2.1 app
2.	EF Core is used as ORM
3.	SQL DB on Azure
4.	CheeseModel – It is a project for all the entities of the app
5.	CheeseService – It is a project for the business logic of the app
6.	CheeseData – It is a project that has EF context

**Running the app:**
There are two ways to test this one.
1)	Locally cloning the app and setup.
2)	Accessing the deployed site on Azure app service [here](https://cheesaria.azurewebsites.net)

**Local Setup:**
This project was generated with Angular CLI version 6.0.0.

**Prerequisites:**
1)	.NET Core 2.2
2)	Node JS 
3)	VS 2017 or higher
4)   git clone https://github.com/farooq41/Cheese.git

**Running Angular:**
Go to this location CheeseWeb/CheeseWeb/ClientApp and run
1)	Npm install
2)	Ng serve

**Locally running the app:**
1)	Open Solution file in VS Right click and Restore Nuget Packages & Build the soultion
2)	Set CheeseWeb Project app as start up and run the solution.
 
**Esimations:**
1.	As a user (of the application) I can see all cheese. – 3h
2.	As a user I can create/edit cheese. – 2h
3.	As a user I can delete cheese. - 1h
4.  UI - 2h
6.	Azure(app services, SQL db creation & deployments)  - 2h

**Known Limitations:**
1.	Cheese claculator
2.	Unit tests
3.	Docker - Requrie some learning 


