FROM mcr.microsoft.com/dotnet/sdk:9.0 AS test

WORKDIR /app

# Copy global configuration files
COPY global.json ./
COPY common.props ./
COPY common.test.props ./
COPY Directory.Build.props ./
COPY Directory.Packages.props ./
COPY configureawait.props ./
COPY NuGet.Config ./

# Copy solution files and project structure for restore
COPY framework/Volo.Abp.sln ./framework/
COPY framework/src/ ./framework/src/
COPY framework/test/ ./framework/test/

# Restore dependencies
WORKDIR /app/framework
RUN dotnet restore

# Copy the rest of the code
WORKDIR /app
COPY . .

# Install ReportGenerator tool for test coverage reports
RUN dotnet tool install -g dotnet-reportgenerator-globaltool

# Add dotnet tools to PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Set working directory to framework for test execution
WORKDIR /app/framework

# Run tests with coverage
CMD ["bash", "-c", "echo GLIBC VERSION && ldd --version && echo GLIBC VERSION CHECK && dotnet test --no-build --collect:'XPlat Code Coverage' --results-directory ./TestResults && find ./TestResults -name 'coverage.cobertura.xml' -exec cp {} ./TestResults/coverage.cobertura.xml \\;"]
