
# Automated test
## Introduction
Automated tests of an e-commerce website using Selenium Webdriver C#.
This project uses Page Object Model (POM) design pattern to represent each web page and component as a class file and Page Factory is used to declare, locate web element using annotations like @FindBy

### Project Structure
```bash
├── SauceDemoTest
│   ├── Component
│   ├── Pages
│   ├── Setup
│   ├── Tests
```
Component - contains reused components of the site. 
Pages - contains classes representing web pages of the site.  
Setup - contains setup configuration related code. Any browser related code can be changed from Browser.cs. Configuration.cs file lets configure values like SiteUrl. TestData.cs contains all test data.   
Tests -  All test cases are written here. Test classes uses components & pages to orchestrate the testing.

## Site
https://www.saucedemo.com/

## Tests Covered
1. Successful Login, Failed Login, Locked user Login and Logout.
2. Products page loading and Add/Remove item to cart.
3. Individual item page loading and Add/Remove item to cart.
4. Navigate to Cart and complete Checkout Process.
5. Order information form validation.

## Pre-requisites
- Visual Studio 2022
- .Net 8.0.
- Selenium Webdriver 4.17.0.
- NUnit 3.

## Installation
1. Git clone this repository
2. Visual Studio is recommended to open this project

## Running the Tests

### Visual Studio
1. Open the solution in Visual Studio.
2. Restore nuget packages.
3. Build the solution (Ctrl+Shift+B).
4. Run tests from the side bar (Ctrl+R,A).
5. Individual test can be run from Test Explorer

### Command line
1. Open terminal (Ctrl+`)
2. Run the command: `dotnet restore`
3. Run the command: `dotnet build`
4. Run the command: `dotnet test`

## Future Work
Test can be run in parallel on dockers. 
Connfigurations can be read from config file.
