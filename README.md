# RapidPay
# code challenge

Api using sqllite for database and identity for authentication 

Steps to use it using swagger :

1. run the appilication locally using VS this will show swagger page
2. crete a new user using /register endpoint providing email and password
   request example :
   {
      "email": "something@gmail.com",
      "password": "String!1"
   }

3. login using created credentials usig /login endpoint
  request example (ignore twofactor properties) :
  {
    "email": "something@gmail.com",
    "password": "String!1",
    "twoFactorCode": "string",
    "twoFactorRecoveryCode": "string"
  }

  This will return an access token 

4. copy access token value click on the authorize button at the top of the swagger page, add the word "Bearer" space, paste the access and click on authorize,
   this will add the bearer token to the authorization header for all the calls to the api

5. use the POST endpoint api/cards to create a new card related to the logged user
6. use the POST endpoint api/payments to add a new payment to the card
7. use the GET endpoint api/card to get the card and its balance

