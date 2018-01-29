# TimeBookerWebApi

## How to run:

	```
	git clone https://github.com/mindtheworld/TimeBookerWebApi.git
	build
	set TestWebApi as startup project
	run (F5)
	```
## Solution structure:
- TestDb (DB project to manage DB schema)
- DataAccessLib (EF + DAL: manage DB CRUD operations)
- TestWebApi (RESTful webapi)
- TestWebApi.Tests (To test webapi)

## How to fix CORS isse: OPTIONS 405 (Method Not Allowed)
- *Note: https://enable-cors.org/server_aspnet.html

##  Limitations:
- Better api design.
- More unit tests.
- Error handling. 

