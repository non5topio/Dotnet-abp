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

# Run tests with coverage
CMD ["bash", "-c", "echo GLIBC VERSION && ldd --version && echo GLIBC VERSION CHECK && dotnet test --no-build --collect:'XPlat Code Coverage' --results-directory ./TestResults && find ./TestResults -name 'coverage.cobertura.xml' -exec cp {} ./TestResults/coverage.cobertura.xml \\;"]
