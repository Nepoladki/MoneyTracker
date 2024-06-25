# FoodDelivery API


## Auth


### Register

#### Register Request
```js
POST {{host}}/auth/register
```
```json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "generic@email.ru",
    "password": "pass123"
}
```
#### Register Response

```js
200 OK
```
```json
{
    "id": "09431d92-0ce7-46a4-80da-c0f509b1bd7e",
    "firstName": "John",
    "lastName": "Doe",
    "email": "generic@email.ru",
    "token": "sdaf..z1sadf"
}
```



### Login

#### Login Request

```js
POST {{host}}/auth/login
```
```json
{
    "firstName": "John",
    "lastName": "Doe",
    "email": "generic@email.ru",
    "password": "pass123"
}
```
#### Login Response

```js
200 OK
```
```json
{
    "id": "09431d92-0ce7-46a4-80da-c0f509b1bd7e",
    "firstName": "John",
    "lastName": "Doe",
    "email": "generic@email.ru",
    "token": "sdaf..z1sadf"
}
```