# BlueTapeCrew

https://bluetapecrew.com

BlueTapeCrew is a client website I built in ASP.NET while I was freelancing.
I was a junior developer when I built this, I have made small improvements over the last few years.
I am currently converting the site to .NET core; once that conversion is complete, I will continue to improve the codebase.


## Features
  - Front end based on [KeenThemes] Metronic Store HTML Template
  - Paypal integration
  - MailChimp Subsription Integration
  - Mobile Repsonsive
  - Client Accessable Admin
  - Built in Image Handling
  - SSL
  - Emails from SMTP account.
  - Social Logins
  
 *Breaking changes in External services over the past few months -- currently fixing social login feature
 
## Tech
BlueTapeCrew uses a typical .NET stack:
- Dependency Injection
- Homegrown, I did not use an existing schema or site design.
- ASP.NET MVC 5
- SQL Server
- Razor
- AngularJS Admin
- HTML5
- CSS

JS/JQuery Plugins:
- Font Awesome
- Bootstrap
- FancyBox
- Owl Carousel
- UniformJs
- RateIt
- MS JQuery Unobtrusive Validation
- Back-To-Top
- Bootstrap TouchSpin
- JQuery Zoom        
- JQuery Slimscroll

## Roadmap
- Improve Integration / Unit Test Coverage
- Review DI setup and set LifetimeRequestManagers where appropriate.
- Migrate to ASP.NET Core
- Add support for multi-tenancy
- Strip paid template elements from Admin
- Complete de-branding of the source
- Replace stored procedures and views with ORM queries
- Angular Conversion

## Installation

### Environment
**IDE:** Visual Studio 2015
**.NET** Version: 4.5

### Connetion Strings
**There are two connection strings:**
 - UserEntities, which handles MS User Identity
 - BtcEntities

Add connection strings to web.config:
```sh
<connectionStrings>
  <add name="UserEntities"
    connectionString="Server=[SERVER];Database=[DATABASE];User ID=[USER];Password=[PASS];Trusted_Connection=False;Encrypt=True;Connection Timeout=30;" providerName="System.Data.SqlClient" />
  <add name="BtcEntities" 
    connectionString="data source=[SERVER];initial catalog=[DATABASE];persist security info=True;user id=[USER];password=               [PASS];MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### Setup
### Databae Migrations
Add Code-First Migration from Package Manager Console
(You will have to do this once for each connection string.  Follow the prompts in package manager console)
```sh
$ Add-Migration "[DESCRIPTION]"
```
Update Database
```sh
$ Update-Database
```
### Stored Procedures and Views
You will need to create these Views on your SQL Database:
#### CartView View
```sh
create view [dbo].[CartView] AS
SELECT Cart.Id AS Id,CartId, [Count] As Quantity,Styles.ProductId,ProductName,LinkName,Price, StyleId,Colors.ColorText,Products.[Description],
CONCAT('Color: ',ColorText,'; Size: ',SizeText) As StyleText,
([Count] * Price) AS SubTotal,CartImages.ImageData as ImageData
FROM Cart INNER JOIN Styles ON Cart.StyleId = Styles.Id
	INNER JOIN Products ON Styles.ProductId = Products.Id
	INNER JOIN Sizes On Styles.SizeId = Sizes.Id
	INNER JOIN Colors On Styles.ColorId = Colors.Id
	Left JOIN CartImages On CartImages.ProductId = Products.Id
```
#### StyleView View
```sh
create view [dbo].[StyleView] as
select Styles.Id as Id,ProductId,SizeId,SizeOrder,SizeText,ColorId,ColorText,Price,SizeText + ' / ' + ColorText AS StyleText
from Styles inner join Sizes ON SizeId = Sizes.id
			inner join Colors on ColorId = Colors.Id
```
#### GetCart Stored Procedure
```sh
CREATE PROCEDURE [dbo].[uspGetCart] @SessionId char(24)
AS
SELECT * 
FROM CartView
WHERE CartId = @SessionId
```
[KeenThemes]: <http://keenthemes.com/free-bootstrap-templates/fully-responsive-bootstrap-based-ecommerce-frontend-theme>
[Todd Miller]: <https://toddmiller.nyc>
[BlueTapeCrew]: <https://bluetapecrew.com>

