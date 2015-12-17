#Reveal
**Focus on data that actually matters**   

##Overview
Objects can have many properties, but when debugging, not all of them are useful to you. You’re usually interested only in a select few. For a Customer class, it might be the ID and FullName properties. For a Point in 3D space, it might be the X, Y, and Z fields. With OzCode's "Reveal” feature, you can finally focus on the data that actually matters. 
##Using Reveal
In order to run this demo press the _Reveal_ button in the demo application.  
![Reveal button](Resources/RevealButton.PNG)  

Notice that a breakpoint has been triggered. 
It seems that although we're in a method that should only be used to send packages outside of the country (US), somehow we got a package that should have been shipped using local shipping method:  

![Debug break](Resources/DebuggerBreak.PNG)  
Because nobody bothered to implement `ToString` on the Customer class, the Head-Up Display (HUD) does, and traversing _Customer_ class can be a pain since it has so many fields. 
Move the cursor over customer until the watch window appears. Then expand the cutomer fields using the '+'. 

![RevealCustomerName](Resources/WatchWindow1.png) 

Lastly find "FullName" and click on the "*star*" next to it:   

![RevealCustomerName](Resources/WatchWindow2.png) 

Notice how the watch window and the HUD updated accordingly

![RevealCustomerName](Resources/RevealFullName.png)
  
Use the stacktrace window to go back to the caller of the method - use the watch window to see how many customers are from *Paris* (including Jose Duke).
Since they're all instances of _Customer_, the _FullName_ which we've previously stared is shown automatically.

![Customers from Paris](Resources/customersFromParis.png) 

Let's add some more information to each customer: From the watch window expand one of the customers, then expand the _Address_ propery and star _Country_, _State_ and _City_ properties.
Lastly toggle the Star next to Address as well - in order to show _Address_ information as part of _Customer_ (Recusrive Debug Info).

![Add address info](Resources/cutomersWithAddresses.png)

Minimize the customer and look at the customer list: Now we can see all of the selected customers and their addresses. Finding the bug and the effected customers should be simple.

![Customers with addresses](Resources/RevealCustomersAndAddresses.png)

[Back to Main](../../README.md)
