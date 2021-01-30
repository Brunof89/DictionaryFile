# DictionaryFile

<strong>Dictionary File Project.<strong>
</br></br>
<ul>
	<li>
		<strong>Tecnology used</strong>
		<ul>
		  <li>
			Asp.NET Core 3.1 ( Console App )
		  </li>
		  <li>
			*C# 8.0
		  </li>
		  <li>
			Visual Studio 2019
		  </li>
		  <li>
			Nuget Packages for NUnit and Moq
		  </li>
			Git	
		  </li>
	  </ul>
	</li>
	<li>
		<strong>Problem resolution:</strong></br>
		<ul>
		  <li>
			First i made my console app able to inject any kind of service provider. Then as a normal .Net Core app i saved my configurations in a appsettings file, although one of     &nbsp;the best   pratices
  &nbsp;now-a-days the most of the configurations should be saved in enviroment variables.
  &nbsp;While the program recives inputs from the user it validates straight away the existence of the file and the length of the start and end words.
		  </li>		  
	  </ul>
	</li>
	<li>
		<strong>Algorithim ( Breadth-first search )</strong>
		<ul>
		  <li>
			&nbsp;Filters only the 4 letter words in the file/list and orders it alphabeticly.</br> 
			Used the pseudo code in https://en.wikipedia.org/wiki/Breadth-first_search
		  </li>		  
	  </ul>
	</li>
	<li>	
	<strong>Problems encountered:</strong></br>		
		<ul>
		  <li>
			Understanding what the algorithim had to do. For example, if it could have more than one change in the same charcter index.
		  </li>
		  <li>
			If the list had to be ordered alphabethicly of not. ( I considered it had to be...)
		  </li>
		  <li>
			If Unit testing had to be in all used methods
		  </li>
		  <li>
			Did not use repository pattern, but most DDD i would have.
		  </li>
			Git	
		  </li>
	  </ul>
	</li>
</ul>  
  
  
