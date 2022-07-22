# Project Overview

##  Office Reservation Calculator (ORC)

###  Objectives

> Write a short application (or any managed language you feel comfortable with) on the backend side and a client/tester application that, given a month and a year (YYYY-MM),
 
> What is the revenue for the month? Revenue is calculated according to the monthly price of the reserved offices. If an office is partially reserved for a given month, the revenue should be prorated based on the monthly price. For example 2, 1500, 2014-03-01, 2014-03-15 counts as $750 in revenue for April because the reservation was for half of the month.
 
> What is the total capacity of the unreserved offices for the month? An office is considered reserved if it was reserved even for a single day for the given month.

###  Data

> CSV file with four columns in each line: Capacity, Monthly Price, Start Day, and End Day. The fourth column "End Day" could be empty, meaning the office is indefinitely reserved starting from the Start Day.

###  Output

` 2000-01: expected revenue: $0, expected total capacity of the unreserved offices: 266`

` 2018-01: expected revenue: $75,500, expected total capacity of the unreserved offices: 137`

###  Product Requirements

- Program to run ASP.NET code (C#, JS, HTML, CSS)
- Connection to the internet to access jquery date-picker script (possible to embed in-project if needs to be offline)
- Access to GitHub to download source-code

###  Project Files

Folder Name  | Contents
------------- | -------------
Content  | CSS design (using bootstrap and custom Site.css)
Controllers | HomeController: access to csv file and all calculations (revenue, capacity)
Extras  | CSV file, images, extra fonts
Models  | Office class
Scripts  | bootstrap, jquery and custom JS for index
ViewModels  | ViewModel for possible future updates
Views  | Index and Layout HTMLs


###  Wireframing
**Landing page:**

![Wireframing](https://user-images.githubusercontent.com/22745198/180437459-6d8588fa-5854-4899-8282-3fe2b5fc36ee.jpg)

**Notepad Background**
*showcasing some interests*

![background_image_wider](https://user-images.githubusercontent.com/22745198/180437423-7f383d43-523e-4029-9f1b-7acca03fe634.jpg)

**Logo for ORC:**
*collab with my husband*

![ORC_icon](https://user-images.githubusercontent.com/22745198/180437405-c3f0bf13-a7de-4f51-8758-85b707f31e2b.png)



