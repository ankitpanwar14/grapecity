# Blogpost Web APi 

##Software Requirements
Postman, Soap UI or similar clients are required to run the web API.

## Project Architecture
WEB API 2.0 based apis built using .Net core 2.1 and appropriate packages.

###Folder Structure
Controllers
Handlers
Migrations
Models
Services

###Tech stack 
These APIs are built using following technologies/tools -
1. .Net core 2.1
2. EFcore 2.1
3. WEB Api 2.0
3. Swagger
4. Postman
5. SQLLite
6. Basic Authentication

####Development Procedure 
1. Used Microsoft visual studio 2017 in a windows 10 running machine for the web API development.
2. GitHUb Repository :- https://github.com/ankitpanwar14/grapecity/tree/master
3. Used basic authentication for user authentication 

####Authentication
For any API to work an Authentication key will be needed in the request header.

- Use Authorization as the key and value as Basic followed by a "Base 64 encoded string which is a combination of user email address concatenated with a colon and user password"

Below credentials can only be used for now as they are the only details available in database

for e.g - User email address is  ankitpanwar14@email.com and password is 987654321 then header will look like-
Authorization - Basic YW5raXRwYW53YXIxNEBnbWFpbC5jb206OTg3NjU0MzIx - 

User email address is  grapecity@email.com and password is 987654321 then header will look like-
Authorization - Basic Z3JhcGVjaXR5QGdtYWlsLmNvbTo5ODc2NTQzMjE=



