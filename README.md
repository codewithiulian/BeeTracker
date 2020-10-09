# BeeTracker
A simple .NET WebForms bee tracker application.

## Contents
### The Bee class (Bee.cs)
It has got the required properties and methods. Instead of creating multiple Bee classes for each type, I have created only one, to avoid code duplication. Then a property of custom type BeeType (BeeType.cs) has been added to the Bee class, to distinguish the different types of bees. Another way code duplication could have been avoided was through inheritance, creating a parent interface, from which the different types of bees would inherit. However, this way I created an enum, therefore, contributing towards the expendability of the app (new types of bees having to be added only within the enum).
Properties:
ID, Health, Type, IsDead, HealthResistance. Note: I have added an ID property to assign it to each data row button in particular. This way the argument passed into the asp callback by the button click would always contain the unique button. This could have been solved (probably more performant) by just assigning the button with the array index of the IEnumerable. HealthResistance is a property to store the minimum health before the type of bee is dead. This is specified in the assignment document, and defined in Bee.cs : GetHealthResistance : 59.

All the methods and logic inside the Bee class are commented as well as time allowed, therefore, please refer to the in-code documentation.

### The Default page (Default.aspx & Default.aspx.cs)
My first assumption was made when thinking about how to display the bees. I decided to display the bees as data rows in a grid. The reason being that HESA is a data statistics collection and curation agency. If the nature was games design, I would have displayed them in a playful manner, added a start and a reset button.

Composed of the front-end and back-end. The front-end consists of a simple asp.net GridView with a number of necessary columns: Type, health and Is Dead. It also contains a button that damages the bee on the selected row. The data is bound in the code behind (Default.aspx.cs)

The code behind Default.aspx.cs contains 4 functions: Page_Load, which defines the bees as a list and assigns them to the Session variable (I have used session variable to simulate a PUT request to a database service.). BindBeesGrid which is responsible for binding the earlier defined bees list to the asp.net GridView. GetBees which defines a default fresh list of bees: for each type of bee, it generates 10 bees with the default property values specified in the assignment document. Lastly, LnkDamage_Click which gets and parses the id passed in by the button click event (this is assigned in the Default.aspx : 11). Then filters the latest snapshot of bees from the session, then it generates a random integer (between 0 and 80) then applies the damage and resets the session bees list. Lastly it re-binds the grid. Here a asp:UpdatePanel could have solved the problem, but ran into some bugs while attempting to apply it and had to drop it due to lack of time.

### Future improvement
Unit Tets: due to lack of time, no unit tests have been written. However, only the Damage function within Bee.cs is trully worth testing, but even then, the data passed in is bound by the .NET framework Random Next function, and the logic within GetHealthResistance is very simple.

UI Design: The grid is not styled, as my assumption was that this assignment is meant to challenge OOP concepts and design patterns, code cleanliness and ability to fluently write in C#.

Design patterns: For future improvements, I would convert this application into MVC. The reason I did not start it this way, was the lack of complexity of the application. There is no worth in over engineering a small web application, or any type of application that is meant to solve a single simple job (in my opinion). Design patterns are created with maintainability and sustainability in mind.
