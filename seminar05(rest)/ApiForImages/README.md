Previously it was done as non REST`ful API as my own project
now reworked as REST

ImageStats API REST
========

ALL METHODS RETURN'S BASE64 REPRESENTATION OF PICTURE

- Statistic of used colors by url: 
 POST ​ /GetStatsByUrl body: { "url":"https://s.ftcdn.net/v2013/pics/all/curated/RKyaEDwp8J7JKeZWQPuOVWvkUjGQfpCx_ cover_580.jpg" } 

- Statistic of used colors by base64: 
 POST  ​ /GetStatsByBase64 body: { "base64string":"/9j/4AAQSkZJRgABAQEASABIAAD/............." } 

- Swap color in image by url(returns image in base64): 
 POST  ​ /SwapColorsByUrl body: { "url":"https://s.ftcdn.net/v2013/pics/all/curated/RKyaEDwp8J7JKeZWQPuOVWvkUjGQfpCx_ cover_580.jpg", "from":"Indigo", "to":"Red" } 

- Swap color in image by base64 string(returns image in base64): 
 POST /SwapColorsByBase64 body: { "base64string":"/9j/4AAQSkZJRgABAQEASABIAAD/............." "from":"Indigo", "to":"Red" } 
 
List of available colors:  
Red, Orange, Yellow, Green, Blue, Indigo, Violet 
 
- - 

Pictures in this folder is example of how it works

Here you can find step-by-step tutorial how to host it
https://www.c-sharpcorner.com/UploadFile/2b481f/how-to-host-Asp-Net-web-api-on-iis-server/

