# Security Policy

## Configuration

Do not commit connection strings, Cloudinary credentials, SMTP credentials, or
other secrets. Store local development values with .NET user-secrets or
environment variables. `src/DevHunter.Web/appsettings.example.json` documents
the required configuration keys.

Credentials previously committed to the repository should be considered
compromised and rotated with their providers.

## Reporting a Vulnerability

Please report suspected vulnerabilities privately to the repository owner.
Include reproduction steps and the affected feature where possible. Do not
open a public issue containing credentials or exploit details.
