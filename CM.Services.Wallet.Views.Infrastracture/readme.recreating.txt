1.1) Prerequisites

install-package Autofac
install-package Microsoft.EntityFrameworkCore
install-package Microsoft.EntityFrameworkCore.Relational
install-package Npgsql.EntityFrameworkCore.PostgreSQL

1.2) References

CM.Services.Wallet.Views.Contract

2) Recreating library

2.1) Run `dotnet new classlib  -o CM.Services.Wallet.Views.Infrastracture -f netcoreapp2.1`
2.2) Move: 
	- directories:
		- *
	- files:
		- readme.recreating.txt
