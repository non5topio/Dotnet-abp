FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test

WORKDIR /app

# Copy global configuration files and solution structure
COPY global.json ./
COPY common.props ./
COPY common.test.props ./
COPY Directory.Build.props ./
COPY Directory.Packages.props ./
COPY configureawait.props ./
COPY NuGet.Config ./
COPY framework/Volo.Abp.sln ./framework/

# Copy project files for restore
COPY framework/src/ ./framework/src/
COPY framework/test/ ./framework/test/

# Restore dependencies
RUN dotnet restore ./framework/Volo.Abp.sln

# Copy the rest of the code
COPY . .

# Install ReportGenerator tool for test coverage reports
RUN dotnet tool install -g dotnet-reportgenerator-globaltool

# Add dotnet tools to PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Run the specific test command from test-gen-config.json
CMD ["sh", "-c", "dotnet test ./framework/test/Volo.Abp.Core.Tests/Volo.Abp.Core.Tests.csproj --filter \"FullyQualifiedName~Volo.Abp.RandomHelper_Tests\" --collect:'XPlat Code Coverage' --results-directory ./TestResults && find ./TestResults -name 'coverage.cobertura.xml' -exec cp {} ./TestResults/coverage.cobertura.xml \\;"]
