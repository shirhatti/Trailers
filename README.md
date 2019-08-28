# Trailers

```powershell
# Install the version of dotnet pinned to in the global.json
.\build\get-dotnet.ps1

# Source the activate script to set the right dotnet on your PATH
. .\activate.ps1

# Install a development certificate (required for HTTPS)
dotnet dev-certs https --trust

# Build the solution
dotnet build

# Run the server
dotnet run -p .\Server\

# Run the client
dotnet run -p .\Client\

# Launch VS (if desired)
.\startvs.cmd

```