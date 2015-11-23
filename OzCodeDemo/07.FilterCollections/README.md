#Filter Collections
**With our Filter Collections feature, you can apply a filter expression to any collection**
##Overview
Filtering a collection in code is relatively easy and there are plenty of ways to do it. But how do you filter while debugging? For example, you have a collection of Customer objects and you’d like to filter the ones that are older than 35 years. Visual Studio’s immediate window and watch windows don’t support lambdas. With our Filter Collections feature, you can apply a filter expression to any collection. To solve the customer problem, choose the collection of customers and set its filter to: DateTime.Today.Year – [obj].Birthday.Year > 35, press Enter and see the results right away. Once a collection is filtered, all the other features work on the filtered results as well.
##Using Filter Collections
In order to run this demo press the _Filter Collections_ button in the demo application.  

![Filter Collections button](Resources/filterCollectionsButton.PNG)

A message box with exception will appear (unless you've set break on exceptions - in which case you can skip the next step)

Close the messagebox and use "Break on all CLR excetions" button to stop once an exception is thrown.

![Break on all CLR exceptions](Resources/breakonexceptions.png)

Run the demo again. This time you should stop at the following method. Now it's simple unsderstanding why the exception was thrown - we only have one eligable customer:

![Exception origin](Resources/exception.PNG)

Looking at the code we see 31 customers going on the Linq statement but only one coming out.
Going through the customer collection one by one could take a while - instead let's filter it to show only the objects that follow a specific creteria.  
- Hover over _customers_ collection 
- Click on the magic wand
- Choose __Edit Filter__

![Edit Filter](Resources/editFilter.PNG)

Now we can update the collection filter. using _[obj]_ as the filtered object with intellisense support.

In this case we can use the following filter to try and see if the problem is that we do not have enough customers under 62 by using:

```
[obj].Age < 62
```

Opening the watch dialog (hover over _customers_) would show a small funnel.  
Moving the pointer over the funnel would show thatn only 5 customers are below 62.

![Age < 62](Resources/ageLessThan62.PNG)

Clearly we have a problem. Now let's replace the filter condition to show all of the customers over 62.

![Age > 62](Resources/ageMoreThan62.PNG)

We got quite a lot of customers there. Use _Reveal_ to show the customer Age by starring the Age property on one of the customers:

![Customers with Age](Resources/customersWithAge.PNG)

Now all we need to do is find how the Age property was calculated and fix the bug.  

 [Back to Main](../../README.md)  