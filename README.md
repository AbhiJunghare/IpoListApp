# IpoList

Overview
The IPO listing is a web application built with ASP.NET Core that provides users with real-time information on initial public offerings (IPOs). The application allows users to view a list of stocks along with their respective listing prices and listing dates, making it an essential tool for investors looking to stay updated on new market opportunities.

Features
Stock Listings: View a comprehensive list of available IPO stocks.
Price Listings: Access current listing prices for each stock.
Listing Dates: Check the dates on which stocks are set to be listed, helping users plan their investments.
User-Friendly Interface: An intuitive and responsive design for an enhanced user experience.
Technologies Used
ASP.NET Core
Dapper
SQL Server 
steps to Clone the Repository 
1)Open your terminal (Command Prompt, PowerShell, or Terminal) and run: git clone https://github.com/AbhiJunghare/IpoListApp.git

Optional: Using Visual Studio
If you prefer using Visual Studio, follow these steps:

Open Visual Studio.
Select "Open a project or solution" and navigate to the cloned repository.
Open the .sln file.
Restore NuGet packages if prompted.
Set the project as the startup project.
Click the "Start" button (or press F5) to run the application.

database Objects
table :
CREATE TABLE [dbo].[Tbl_IPOs_Details] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [StockName] NVARCHAR(100) NOT NULL,
    [ListingPrice] DECIMAL(18, 2) NOT NULL,
    [ListingDate] DATE NOT NULL,
    [CreatedDate] DATETIME NULL,
    [UpdatedDate] DATETIME NULL
);

store Procedure
Create Procedure [dbo].[USP_IPO_CRUD_OP]
(
@FLAG VARCHAR(20) = NULL,
@StockName VARCHAR(50) = null,
@ListingPrice DECIMAL(10, 2) = null,
@ListingDate date = null,
@ID INT = NULL
)
as
BEGIN
IF @FLAG = 'GET'
SELECT * FROM Tbl_IPOs_Details;

if @FLAG = 'ADD'
BEGIN
INSERT INTO Tbl_IPOs_Details (StockName,ListingPrice,ListingDate,CreatedDate)
VALUES(@StockName,@ListingPrice,@ListingDate,GETDATE())
END

IF @FLAG = 'EDIT'
BEGIN
SELECT * FROM Tbl_IPOs_Details WHERE Id = @ID ;
END

IF @FLAG = 'UPDATE'
BEGIN
update Tbl_IPOs_Details set StockName = @StockName,ListingDate = @ListingDate, ListingPrice = @ListingPrice , updateddate = GETDATE() WHERE Id = @ID ;
END


IF @FLAG = 'DELETE'
BEGIN
  DELETE Tbl_IPOs_Details WHERE Id = @ID ;
END
END

