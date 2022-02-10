# OrderManager API
The project is a .Net Core Web API application and it is developed using C# .Net 6.0

# About the Application
In-memory database used in this application, OrderManager.API solution can be started directly

# API Docunmatation
Endpoints and explanations:

**orders**\
-> **api/orders/{id}**  [HttpGet] method will return selected orders requiredBinWidth and related products and it's quantities as a list.\
-> **api/orders**   [HttpPost] will save a new order record

**products**\
-> **api/products** [HttpGet] will return all products

# How to test API methods
To test API methods easily with using SwaggerUI. Test data is imported to test Get method. Sample request screenshots are shared below:

![image](https://user-images.githubusercontent.com/9204813/153308792-a2d62b5b-2eb8-4af7-8e7a-0ab3e7335efa.png)
![image](https://user-images.githubusercontent.com/9204813/153308891-08f7b6a6-8117-4e86-90fa-fdf01026a362.png)
![image](https://user-images.githubusercontent.com/9204813/153308911-1bc07baa-11d8-4eb6-b81d-857cfe5b5997.png)

![image](https://user-images.githubusercontent.com/9204813/153369568-37f263d9-7637-4f9c-9ecf-10142588c319.png)



