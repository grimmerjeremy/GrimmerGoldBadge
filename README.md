# GrimmerGoldBadge
Within the Gold Bage Solution you will find three challenges.
1. Cafe Menu
2. Claims
3. Badges
Each challenge has three assemblies.
1. Library
  a.Class
  b.Repository
3. Console Application
  a.Program
  b.ProgramUI
5. UnitTest
Each are labeled accordingly.
Below are the instructions for each challenge.

Challenge 1: Cafe
Komodo Cafe
Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.
The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price
Your Task:
Create a Menu Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
Notes:
We don't need to be able to update items right now.

Challenge 2: Claims
Komodo Claims Department
Komodo has a bug in its software and needs some new code.
The Claim has the following properties:
ClaimID
ClaimType
Description
ClaimAmount
DateOfIncident
DateOfClaim
IsValid
Komodo allows an insurance claim to be made up to 30 days after an incident took place. If the claim is not in the proper time limit, it is not valid.
A ClaimType could be the following:
Car
Home
Theft
The app will need methods to do the following:
Show a claims agent a menu:
Choose a menu item:
1. See all claims
2. Take care of next claim
3. Enter a new claim
For #1, a claims agent could see all items in the queue listed out like this:
ClaimID	Type	Description	Amount	DateOfAccident	DateOfClaim	IsValid
1	Car	Car accident on 465.	$400.00	4/25/18	4/27/18	true
2	Home	House fire in kitchen.	$4000.00	4/11/18	4/12/18	true
3	Theft	Stolen pancakes.	$4.00	4/27/18	6/01/18	false
For #2, when a claims agent needs to deal with an item they see the next item in the queue.
Here are the details for the next claim to be handled:
ClaimID: 1
Type: Car
Description: Car Accident on 464.
Amount: $400.00
DateOfAccident: 4/25/18
DateOfClaim: 4/27/18
IsValid: True
Do you want to deal with this claim now(y/n)? y
When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.
For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:
Enter the claim id: 4
Enter the claim type: Car
Enter a claim description: Wreck on I-70.
Amount of Damage: $2000.00
Date Of Accident: 4/27/18
Date of Claim: 4/28/18
This claim is valid.
Your goal is to do the following:
1. Create a Claim class with properties, constructors, and any necessary fields.
2. Create a ClaimRepository class that has proper methods.
3. Create a Test Class for your repository methods.
4. Create a Program file that allows a claims manager to manage items in a list of claims.

Challenge 3: Badges
Komodo Insurance
Komodo Insurance is fixing their badging system.
Here's what they need:
An app that maintains a dictionary of details about employee badge information. (Hint: A dictionary is a collection type in C#. You'll want to use that.)
Essentially, an badge will have a badge number that gives access to a specific list of doors. For instance, a developer might have access to Door A1 & A5. A claims agent might have access to B2 & B4.
Your task will be to create the following:
A badge class that has the following properties:
BadgeID
List of door names for access
A badge repository that will have methods that do the following:
Create a dictionary of badges.
The key for the dictionary will be the BadgeID.
The value for the dictionary will be the List of Door Names.
The Program will allow a security staff member to do the following:
create a new badge
update doors on an existing badge.
delete all doors from an existing badge.
show a list with all badge numbers and door access, like this:
Here are some views:
Menu
Hello Security Admin, What would you like to do?
Add a badge
Edit a badge.
List all Badges
#1 Add a badge
What is the number on the badge: 12345
List a door that it needs access to: A5
Any other doors(y/n)? y
List a door that it needs access to: A7
Any other doors(y/n)? n
(Return to main menu.)
#2 Update a badge
What is the badge number to update? 12345
12345 has access to doors A5 & A7.
What would you like to do?
Remove a door
Add a door
> 1
Which door would you like to remove? A5
Door removed.
12345 has access to door A7.
#3 List all badges view
Key	
Badge #	Door Access
12345	A7
22345	A1, A4, B1, B2
32345	A4, A5
Out of scope:
You do not need to consider tying an individual badge to a particular user. Just the Badge # will do.
Be sure to Unit Test your Repository methods.
