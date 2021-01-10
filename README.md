# DictionaryFile

Dictionary File Project.

Tecnology used:
  *Asp.NET Core 3.1 ( Console App )
  *C# 8.0
  *Visual Studio 2019
  *Nuget Packages for NUnit and Moq
  *Git
Problem resolution:
  First i made my console app able to inject any kind of service provider. Then as a normal .Net Core app i saved my configurations in a appsettings file, although one of the best pratices
  now-a-days the most of the configurations should be saved in enviroment variables.
  While the program recives inputs from the user it validates straight away the existence of the file and the length of the start and end words.
Algorithim ( Design Pattern: strategy or iterator )
  Filters only the 4 letter words in the file/list and orders it alphabeticly. 
  Iterates only the list between the start word and the end because we do not need to iterate the whole file, this improves
  the performance of the algorithim.
  Then it gets the index of the changed indexs of the next iterated word. If their are more than 2 changes the word is not considered. If the index has already been changed the
  word is also not considered.
Problems encountered:
  *Understanding what the algorithim had to do. For example, if it could have more than one change in the same charcter index.
  *If the list had to be ordered alphabethicly of not. ( I considered it had to be...)
  *If Unit testing had to be in all used methods
  *Did not use repository pattern, but most DDD i would have.
  
  
  
