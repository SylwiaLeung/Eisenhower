# Einsenhower Matrix

## Story

The Eisenhower Matrix is a simple, but really effective tool for planning,
widely use in the IT industry. It can be really helpful to save your time during
your solo and team projects.

Eisenhower Matrix was invented by one of the presidents of the USA - Dwight
Eisenhower. You can find a nice description under this [artice]
(https://jamesclear.com/eisenhower-box).

## What are you going to learn?

You will learn how to:

- design object oriented code
- use inheritance 
- structure your code based on composition
- work with lists and dictionaries 

## Tasks

1. Implement `TodoItem` class instance that should consists of title, deadline, booleans indicate whenether  item is done or not and if is important or not. `TodoItem` instance is able to format visually its content within `ToString()` method.
    - Method `ToString()` provides user with readable output containing task item details. Output format is up to you.
    - Methods `Mark()` and `UnMark()` enables user to mark if task was accomplished or unmark if not. 

2. Implement `TodoQuarter` class. Every instance of `TodoQuarter` should consists of list of items. `TodoQuarter` instance is able to add  single `TodoItem` instance, remove it or archive all done items. `TodoQuarter` instance is able to format visually its content within `ToString()` method.
    - 'TodoQuarter' class contains List as a class member. List stores `TodoItem` class instances. 
    - `AddItem()` method is implemented and enables user to create new instance of `TodoItem` and add to list of existing `TodoItem` instances for given `TodoQuarter` instance.
    - `SortToDoItems()` method is implemented. Method sorts items in ascending order according to item`s deadline.
    - Method `ToString()` provides user with readable output containing task item details. Output format is up to you.

3. Implement `TodoMatrix` class which serves  as a main "engine" for the einsenhower application. `TodoMatrix`: 
   1. Creates new tasks from input (user keyboard) and assigning it to proper quarter.
   2. Archives items that are already done from all 4 quarters
   3. Load tasks from file and adds them to proper quarter
   4. Saves task to file in given format
   5. `TodoMatrix` instance is able to format visually its content within `ToString()` method.
    - dictionary within `TodoMatrix` class is created and contains four quarter instances responsible for storing items. Quarters stores:
     1.Urgent & important items
     2.Not urgent & important items 
     3.Urgent & not important items 
     4.Not urgent & not important items
 "Urgent" means that there`s 3 days (72 hours) to deadline for given task at most.
 Quarters are responsible for specific item's group. Ex. Quarter under UI stores urgent and important items only
    - `AddItem()` method is implemented within `TodoMatrix` class and enables user to add an item with its deadline and priority. Created `TodoItem` instance is automatically assign to a proper quarter.
    - `ArchiveItems()` method enables user to delete all items marked as a done.  
    - Method `ToString()` provides user with readable output containing task item details. Output format is up to you.

4. Create database layer that allows einsenhower matrix to save and load tasks from file.
    - User keeps all TODO items in a .csv files. Expected format of each task: 
 "Task name" | "deadline day - deadline month" | "important" if task is marked as a important.
    - User loads saved items from .csv file to existing `TodoMatrix` instance. 

5. Implement `EinsenhowerMain` class which is used as an entry point for user.
    - `EinsenhowerMain` class within method `Run()` aggregates possible interaction with human user from the requirements below.          
    - User can display all quarter with theirs items.
    - User can display specific quarter with its items.
    - User is able to create task from keyboard input. New Item is automatically assigned based on its content.
    - User is able to delete existing task from any available quarter.
    - User is able to delete existing task from any available quarter.
    - User is able to archive all done task.

## General requirements

None

## Hints

- Focus on how are classes separate their responsibilities from each other. E.g. what
  is the purpose of method `add` both in the `TodoQuarter` and `TodoMatrix` class?
- You don't have to create nice-looking UI for this task. The matrix can be
  displayed even in the simplest possible form.
- The solution uses concept of object composition, which is sometimes describes
  as a fifth pillar of OOP. Why we should use composition over inheritance? Look
  it up!

## Background materials

- <i class="far fa-exclamation"></i> [C# Lists] (https://www.dotnetperls.com/list)
- <i class="far fa-exclamation"></i> [C# Dictionaries] (https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/)
- <i class="far fa-exclamation"></i> [Composition vs inheritance in c#] (https://www.codeproject.com/articles/80045/composition-vs-inheritance)
- <i class="far fa-exclamation"></i> [OOP pillars introduction] (https://www.c-sharpcorner.com/UploadFile/84c85b/object-oriented-programming-using-C-Sharp-net/)
