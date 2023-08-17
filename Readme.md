# MembershipSystem

## Architecture

The backend is written in .Net Core 7(?) in what I think is called onion architecture :).
The frontend is written in React typescript and will communate with the backend via Rest API.

### MembershipSystem.Core

Includes all domain entities (basic classes) and interfaces.

### MembershipSystem.Infrastructure

Includes implementations of the interfaces defined in MembershipSystem.Core

### MembershipSystem.WebService

The actual API. Should not be dependent on Infrastructure for anything else than to run the service registration.
