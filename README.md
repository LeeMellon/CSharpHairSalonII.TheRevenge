# _Hair Salon_

#### _An app for organizing a hair salon. V 0.2 2/23/18_

#### By _Ian Goodrich_

## Description

_Hair Salon is a basic application for organizing and tracking stylists and their clients. It keeps track of clients account information, and which stylists they prefer to see. And it tells you at a glance which clients an individual stylist serves and which station they're currently assigned to._

## Specs

1.
  Create Stylist class and make sure an instance is saved correctly to the database.
  Sample input: Stylist newStylist = Stylist(Kimberly, 5);
  Expected output: id:1, name: Kimberly, station: 5.

2.
  Create Client class and make sure an instance is saved correctly to the database.
  Sample input: Client newClient = Client(Franz, 5301112222, franz@franzia.org, 1);
  Expected output: id:3, name: Franz, number: 5031112222, email: franz@franzia.org, stylist_id: 1);

3.
  View a Stylist and see which Clients belong to them.
  Sample input: Stylist.GetCLientById(1);
  Expected output: Kimberly, Clients: Franz.

4.
  View a list of available specialties.
  Click on View All Specialties on the home page.
  Expected output: "Coloring," "Razor Shave," "Impulsive Bad New Style Choice," "Extensions," "Found Hair Art Sculpture."

5.
  View all specialties of an individual stylist.
  Click on View All Specialties on the stylist page.
  Expected output: Kimberly: "Coloring," "Razor Shave," "Found Hair Art Sculpture."





## Setup/Installation Requirements


* _Clone this GitHub repository_

```
git clone https://github.com/LeeMellon/CSharpHairSalon.git
```

* _Install the .NET Framework_

  .NET Core 1.1 SDK (Software Development Kit)

  .NET runtime.

  See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* _Build your database_
  _From your mySql terminal, run the following commands.
  > CREATE DATABASE hair_salon;
  > USE hair_salon;
  > CREATE TABLE clients (id serial PRIMARY KEY, name_first VARCHAR(255), name_last VARCHAR(255), number INT, email VARCHAR(255));
  > CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), chair INT);
  > CREATE TABLE `ian_goodrich`.`specialties_stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `specialty_id` INT NOT NULL , `stylist_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;
  > CREATE TABLE `ian_goodrich`.`specialties_stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `specialty_id` INT NOT NULL , `stylist_id` INT NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

* _Build your test database_
  _For a useful and quick tutorial on how do create test databases from existing structures follow the instructions given here;
  https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/testing-database-backed-applications

* _Run the program_
  1. In the command line, cd into the project folder.
  2. In the command line, type 'dotnet restore'. Enter to install the required software packages.  It make take a few minutes to complete this process.
  3. In the command line, type 'dotnet build'. Any error messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
  4. In the command line, type 'dotnet run' Enter.

* _View program on web browser at port localhost:5000/_

* _Follow the prompts._

## Known Bugs

_No known bugs.

## Support and contact details


_To suggest changes, submit a pull request in the GitHub repository._

## Technologies Used

* HTML
* Bootstrap
* C#
* .Net Core 1.1

*MIT License*

Copyright (c) 2018 **_Ian Goodrich_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
