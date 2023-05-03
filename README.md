# ASP.NET CORE 6.0

### Table of Contents

- [About Project & Features](#about-project--features)
- [First API](#first-api-userlogin)
- [Second API](#second-api-redditjsonget)
- [API Endpoints](#api-endpoints)
- [3rd Party Libraries](#3rd-party-libraries)
- [Credits](#credits)

### About Project & Features

- This is an Asp.Net Core Api project. There are 2 APIs in this case. First API is for authentication [UserLogin], second API gets data from Reddit [RedditJsonGet]. 

Main features of the application:

- Users can be authenticated in the application by providing their username and password as json format in the request body.
- After authentication, the application sends jwt token to users and marks them as authenticated.
- Only authenticated users can access data got from the public service by sending get requests to the Reddit url by adding query parameters as keyword.

### First API [UserLogin]

- First API creates JWT token if User logins succesfully. There is no database in this project. Users' datas are in [UserService]. So there is a [User] entity in Entities and a [LoginModel] model in Models.
- There is a class for JWT setting [JwtSettings] and settings values can be found in [appsettings].
- [JwtHelper] has a method which creates tokens. This method is used in the controller if Login is successful.

### Second API [RedditJsonGet]

- Second API gets data from public service. The url which belongs to Reddit can be found in the api's controller [RedditController]. 
- If authorization is granted with token, json deserialization will be done and datas will return.   
- In the controller, Get() method expects a string parameter. This value is required for [subreddit].
- Json data is specialized as below.

Example:
```json
{
"subreddit": "rome",
    "children": [
        {
            "title": "The baths of Caracalla are a gem",
            "url": "https://imgur.com/a/cdYFZZv",
            "author_fullname": "t2_7fl3m"
        },
    ]
     "numberOfImages": 1
}
```

### API Endpoints
| API            | HTTP Verbs | Endpoints        | Action                            |
| -------------- | ---------- | ---------------- | --------------------------------- |
| UserLogin      | POST       | /account/login   | To login an existing user account |
| RedditJsonGet  | GET        | /reddit/:keyword  | To get data from a public service |

### 3rd Party Libraries

The following libraries are used in the application:

- Microsoft.AspNetCore.Authentication.JwtBearer : to receive an OpenID Connect bearer token.
- System.IdentityModel.Tokens.Jwt : support for creating, serializing and validating JSON Web Tokens.

### Credits

Deniz Demirdöven

- [Github](https://github.com/DenizDemirdoven)
- [LinkedIn](https://www.linkedin.com/in/denizdemirdoven)
- [Email](mailto:denizdemirdoven@gmail.com)
- [Web](https://www.denizdemirdoven.com/)
