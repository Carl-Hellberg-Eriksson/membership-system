# MembershipSystem

## Working with the repository

To work on the repository, always base your work on an issue (If you want to do something that's not an issue yet, just set it up as one).
Create a branch called #<IssueId>-name-of-branch
Prefix all your commits with "#IssueId - "

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
