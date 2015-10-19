#Search
**Find that needle in a haystack of data**

##Overview
When debugging objects and collections, you are often looking for a specific property or field, or a value held within a property or field. Unfortunately, this usually involves either a lot of clicking and scrolling, or writing custom debug-specific code. Finding items even in simple structures is not easy, not to mention doing so in a complex object graph. With our “Search” feature, this is no longer the case. Quickly and effortlessly search member names and values, no matter the size of the collection or complexity of the object graph!

##Using Search
In order to run this demo press the _Search_ button in the demo application.  
![Search button](Resources/SearchButton.png)

Immediately A messagebox pops since an exception was thrown:
 
![Exception](Resources/exception.png)

Since we want to break execution when the exception thrown we have two options - either use Visual Studio built in exception settings dialog or simply press "Break on all CLR excetions" button:

![Break on all CLR exceptions](Resources/breakonexceptions.png)

Run the Search demo again - this time the debugger would break mon the line that throws the exception.   
Move the cursor to _container and wait for the wathc window to open. At the bottom of the watch window write "Test" to search for objects/properties with the word "Test" in them.

![Search for Test](Resources/searchfortest.png)

There are two components with very similar names inside _container_ but in order to mkae sure we need to dig deeper. Search again this time look for ITestComponent. 

![Search for ITestContainer](Resources/searchforitestcomponent.png)

At first no results would show. Press "Search deeper" to reveal the components that are registered under the _ITestComponent_ contract

![Search deeper](Resources/searchforitestcomponentdeeper.png)

[Back to Main](../../README.md)