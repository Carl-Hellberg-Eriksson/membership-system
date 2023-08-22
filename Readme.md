# MembershipSystem

## Working with the repository

To work on the repository, always base your work on an issue (If you want to do something that's not an issue yet, just set it up as one).
Create a branch called #<IssueId>-name-of-branch
Prefix all your commits with "#IssueId - "

## Get Started

Don't know ¯\_(ツ)_/¯ glhf

### Database

If you don't have one already, create a local server and replace the default connectionstring in appsettings.Development.json with one to your own. You will probably need to add TrustServerCertificate=True to not get SSL error.
Initiate the Database by using the Dotnet CLI and running

´´´
dotnet ef database update --project MembershipSystem.Infrastructure --startup-project MembershipSystem.WebService
´´´

If you are making changes that requires database updates run:
´´´
dotnet ef migrations add "DescriptiveNameOfChange" --project MembershipSystem.Infrastructure --startup-project MembershipSystem.WebService

dotnet ef database update --project MembershipSystem.Infrastructure --startup-project MembershipSystem.WebService
´´´

## Architecture

The backend is written in .Net Core 7(?) in what I think is called onion architecture :).
The frontend is written in React typescript and will communate with the backend via Rest API.

### MembershipSystem.Core

Includes all domain entities (basic classes) and interfaces.

### MembershipSystem.Infrastructure

Includes implementations of the interfaces defined in MembershipSystem.Core.
Handles the database integration.

### MembershipSystem.WebService

The actual API. Should not be dependent on Infrastructure for anything else than to run the service registration.

### WebClient

The React front end. Should communicate with the WebService through API
