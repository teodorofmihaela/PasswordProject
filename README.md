#  <p align="center"> <img src="https://github.com/FortAwesome/Font-Awesome/blob/6.x/svgs/solid/lock.svg" width="30px" height="30px"/> PasswordProject </p>


<p align="center">Using a user Id you can generate a one-time password that expires in 30 seconds that can be verified by logging in.</p>



# 💻 Technologies used
A website that I developed using:

<img src="https://github.com/devicons/devicon/blob/master/icons/css3/css3-original.svg" alt="CSS3  Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/html5/html5-original.svg" alt="HTML5 Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/javascript/javascript-original.svg" alt="JavaScript Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/react/react-original.svg" alt="React Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/materialui/materialui-original.svg" alt="Material UI Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/csharp/csharp-original.svg" alt="C# Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/dotnetcore/dotnetcore-original.svg" alt=".Net Core Logo" width="50px" height="50px"> <img src="https://github.com/devicons/devicon/blob/master/icons/mysql/mysql-original-wordmark.svg" alt="MySQL  Logo" width="50px" height="50px">  <img src="https://github.com/devicons/devicon/blob/master/icons/github/github-original.svg" alt="GitHub Logo" width="50px" height="50px">


|  Front-end | Back-end  |  Database | Tests  |
| :-------:| :-----: | :-----: | :------: | 
| HTML     | C#      |   MySQL |   NUnit  |
| CSS      | Entity Framework | |   Moq   |
| JavaScript |       |         |          |
| Material UI |      |         |          | 



# :telescope: Description
To generate a new password you need to introduce your user id. If you try to generate multiple passwords in less than 30 seconds an error alert will announce you that you have to wait 30 seconds to generate a new password.
 
You can verify you auto-generated password by logging in. You introduce your user id and your valid password and the response body for the http request that was made to back-end will be evaluated in order to validated. 

There are two cases for the response body: 

true  :arrow_right: an alert will let you know that the login was successful; 

false :arrow_right: an alert will show up and announce you that login failed (because the password is not correct);

All the alerts last for 3 seconds using Fade element from MUI and timeout.


# :bookmark_tabs: Interface

<p align="center">Home screen </p>

![home screen](https://user-images.githubusercontent.com/80603330/201520033-de0be387-2927-4937-b9a4-aebc0005b39e.PNG)

<p align="center"> Password generated</p>

![password generated](https://user-images.githubusercontent.com/80603330/201520024-f8761f53-2c47-4a78-a6df-2323bf0224a5.PNG)

<p align="center"> Generating password failed because the user didn't wait 30 seconds</p>

![Login failed](https://user-images.githubusercontent.com/80603330/201520026-331678b9-b19d-4f06-af59-f380e65cc5a1.PNG)

<p align="center">Login successful </p>

![Login succesful](https://user-images.githubusercontent.com/80603330/201520027-0d4049a4-434c-4c69-8a6e-aa658316229a.PNG)

<p align="center">Login failed because the password epired </p>

![password generated error](https://user-images.githubusercontent.com/80603330/201520028-b4560fd4-6af1-4e11-941b-e70696aca18f.PNG)



# :unlock: Project status:

In development
