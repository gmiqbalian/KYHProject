# KYHProject

# Introduktion till appen:
Det är ett ConsoleApp some har tre olika funktioner att välja mellan. KYHProject är startprojektet och visar huvudmenyn. Det tar andra appar som dependencies.

![image](https://user-images.githubusercontent.com/55350558/213271940-633b6160-7424-4846-96d6-c35217d5a886.png)

1- Shapes: 

Man kan beräkna arean och omkretsen av en form. Shapes menu visar fyra olika former man kan välja mellan. Det finns rektangle, parallelologram, triangle, och romb i menyn. Man anger två, tre, eller fyra värden beronde på vilken form väljes. Appen visar resultat arean och omkretsen och sparar resultet i en databas med datum och tid när det händer. Detta har CRUD (create, read, update, delete) funktionalitet så man kan skappa nytt, läsa, redigera eller radera redan sparat resultat.

![image](https://user-images.githubusercontent.com/55350558/213272060-258a99c9-3bb5-4793-adee-079b866156bb.png)

![image](https://user-images.githubusercontent.com/55350558/213272780-bf0697da-101e-497b-8acb-5d7ae6a10088.png)


2- Calculator: 

Det andra appen är en enkel miniräknare som kan redovisa max två siffror. Menyn visar grundläggande funktionaliteter liksom addition, substraction, multiplication, division, och modulus. Användaren väljer vilken operatör som ska användas och då mattar in två siffror. Appen visar resultat och sparar till samma databas i en separat tabell. Detta också har CRUD (create, read, update, delete) funktionalitet så man kan skappa nytt, läsa, redigera eller radera redan sparat beräkningar.

![image](https://user-images.githubusercontent.com/55350558/213272236-ccee682e-e43c-4e4c-93be-4dea1e52cfd8.png)

![image](https://user-images.githubusercontent.com/55350558/213273177-db12d202-fae6-430d-8986-2d0c88397b8c.png)


3- Game (Sten, Sax, Påse): 

Man kan spela Sten, Sax, Påse i den här delen mot datorn. Man anger sitt val då datorn väljer sitt val och resultat (vint eller förlust) visas i slutet. Appen frågor att forsätta eller ni i slutet. Om man inte vill spela längre visar appen genomsnittet och går tillbaka till spelen menyn. Det har inte CRUD funktion.

![image](https://user-images.githubusercontent.com/55350558/213272420-aad09789-00f1-4caa-8039-12667e6c3284.png)


# Database:
Detta projekt utnyttjar EF Core Code First princip. Databas har tre separata entiteter nämligen ShapeResults, CalculationResults, och GameResults. En record i en viss tabell har unikt id vilket är automatisk ökning. Projekt sparar fyra exempleformer i databasen när man kör det första gången.

# Class libraries:

Detta projekt har fyra class libraries:

1- Input: 
Input library har allmänna funktioner och kod som tar inmatning från anvädaren exemplevis val från menyn eller värde för en form. Det även har metoder för att kontrollera fel inmatning.

2- DBContext library: 
Detta class library har dbcontext klass och andra relevanta klasser som ansluter till sql server.

3- Controller class library:
Detta library har kontroller for shapes, calculator, och game som bär alla logik för dessa appar.

4- Services class library:
Detta klass lagrar strategier för miniräknare och former appar.

# Design pattern:
Shapes app och calculator app använder strategy design pattern. Båda apparna har separata olika strategier som följa gemensam interface. Det finns en klass som väljer vilken strategi som ska användas baserat på parameter.
Jag använde också simple factory design pattern för controllers och menyer.
