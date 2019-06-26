# Time Travel

**In regular debugging, once a breakpoint hits, we are able to see the state of the program as it is now. We can evaluate any expression and get its value as it is when the program hits our breakpoint. Time Travel Debugging in OzCode changes the game and allows you to Predict the Future.
While standing on any breakpoint, OzCode will run through the rest of the method and evaluate all the lines of code in the future. You will be able to see the result of the prediction with a Heads-up-display (HUD).**

## Overview 

A similar poem to the one we've used for our LINQ debugging demo is used, with the only difference being that the code is now written using a foreach loop (imperative coding style). Similarly, the sentence is split into words and grouped so that we can return the word that appears the most. The issue is that instead of "bugs" the word "code" is returned. 

## Looking into the future

When running the demo, you'll see that we've hit a breakpoint at the beginning of the method. 
OzCode simulates the execution of the entire method and is able to give you numeric indicators, showing we'll go into the foreach loop 79 times, out of which 29 will enter the if statment, etc. 

When you hover over one of those indicators, OzCode shows you what those different iterations are.

![Hover indicators](Image1.jpg)

If you click on one of those iterations, OzCode Time Travels to that iteration, and shows you exactly what happened. 

Since we are only interested in the word 'bugs', we can type that in, and click on the funnel icon to filter the results to show only this word. By clicking through the different iterations of the word bug, we can see the dict[currentWord] counts up with each appearance of the word, but fails to do so with latest appearance of "BUGS)".

![Click through indicators](gif1.gif)

We can now fix this bug, and as soon as we lift our fingers off of the keyboard, OzCode goes ahead and predicts the execution of the method, allowing you to instantly see that the bug is indeed fixed.

![Hover indicators](Image5.jpg)












