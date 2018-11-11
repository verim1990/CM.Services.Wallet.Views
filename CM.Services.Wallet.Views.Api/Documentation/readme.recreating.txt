1.1) Prerequisites

1.2) References

CM.Services.Wallet.Views.Concrete
CM.Services.Wallet.Views.Infrastracture
CM.Shared.Web

1.3) Dependencies

cm.infrastracture.postgres
cm.infrastracture.kong
cm.infrastracture.kafka
cm.infrastracture.redis
cm.infrastracture.rabbitmq

2) Recreating microservice
2.1) Run `dotnet new webapi -o CM.Services.Wallet.Views.API`
2.2) Move: 
	- directories:
		- Controllers
		- Documentation
	- files:
		- AppSettings.cs
2.3) Modify:
	- Startup.cs
	- Program.cs
	- appSettings.json 
		- add Local section
2.4) Add docker support (linux)
2.5) Alter:
	- docker-compose.yml
		- add dependencies
	- docker-compose.override.yml
		- add network section to container configuration
		- add variables.env file to container configuration