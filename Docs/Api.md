# MoneyTracker API


## Auth


### Register

#### Register request
```js
POST {{host}}/auth/register
```
```json
{
    "userName": "John",
    "email": "generic@email.ru",
    "password": "pass123", 
    "passwordCopy" : "pass123"
}
```
#### Register response

```js
200 OK
```
```json
{
    "id": "09431d92-0ce7-46a4-80da-c0f509b1bd7e",
    "userName": "John",
    "email": "generic@email.ru",
    "token": "sdaf..z1sadf"
}
```



### Login

#### Login request

```js
POST {{host}}/auth/login
```
```json
{
    "userName": "John",
    "lastName": "Doe",
    "email": "generic@email.ru",
    "password": "pass123"
}
```
#### Login response

```js
200 OK
```
```json
{
    "id": "09431d92-0ce7-46a4-80da-c0f509b1bd7e",
    "userName": "John",
    "email": "generic@email.ru",
    "token": "sdaf..z1sadf"
}
```

### Users

#### Create user request
```js
POST {{host}}/users/
```
```json
{
    "userName": "John",
    "email": "generic@email.ru",
    "password": "pass123", 
    "passwordCopy" : "pass123"
}
```
#### Create User Response
```js
200 OK
```
```json
{
    "creadedId": "09431d92-0ce7-46a4-80da-c0f509b1bd7e"
}
```

#### Get all users request
```js
GET {{host}}/users/
```

#### Get all users response
```js
200 OK
```
```json
{
    "userId" : "09431d92-0ce7-46a4-80da-c0f509b1bd7e",
    "userName" : "John",
    "email" : "generic@email.ru",
    "isActive" : "true",
}
```

#### Delete specific user request
```js 
DELETE {{host}}/users/{userId}
```

#### Delete specific user Response
```js
200 OK
```
```json
{
    "deletedId" : "09431d92-0ce7-46a4-80da-c0f509b1bd7e"
}
```