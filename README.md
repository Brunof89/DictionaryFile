# DictionaryFile

<strong>Dictionary File Project.<strong>
</br></br>
<strong>Tecnology used:</strong></br>
  &nbsp;*Asp.NET Core 3.1 ( Console App )</br>
  &nbsp;*C# 8.0</br>
  &nbsp;*Visual Studio 2019</br>
  &nbsp;*Nuget Packages for NUnit and Moq</br>
  &nbsp;&nbsp;*Git</br>
<strong>Problem resolution:</strong></br>
  &nbsp;First i made my console app able to inject any kind of service provider. Then as a normal .Net Core app i saved my configurations in a appsettings file, although one of     &nbsp;the best   pratices
  &nbsp;now-a-days the most of the configurations should be saved in enviroment variables.
  &nbsp;While the program recives inputs from the user it validates straight away the existence of the file and the length of the start and end words.</br>
<strong>Algorithim ( Design Pattern: strategy or iterator )</strong></br>
  &nbsp;Filters only the 4 letter words in the file/list and orders it alphabeticly.</br> 
  &nbsp;Iterates only the list between the start word and the end because we do not need to iterate the whole file, this improves
  &nbsp;the performance of the algorithim.</br>
  &nbsp;Then it gets the index of the changed indexs of the next iterated word. If their are more than 2 changes the word is not considered. If the index has already been changed the
  &nbsp;word is also not considered.</br>
<strong>Problems encountered:</strong></br>
  &nbsp;*Understanding what the algorithim had to do. For example, if it could have more than one change in the same charcter index.</br>
  &nbsp;*If the list had to be ordered alphabethicly of not. ( I considered it had to be...)</br>
  &nbsp;*If Unit testing had to be in all used methods</br>
  &nbsp;*Did not use repository pattern, but most DDD i would have.</br>
  
  
  
