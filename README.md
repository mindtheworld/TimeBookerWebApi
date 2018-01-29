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
