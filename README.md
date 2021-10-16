# dotnet-aspnet-identity
DotNet 5 | Asp.Net MVC | Identity

## Commands:
```
dotnet new classlib -o .\src\Core\Domain -f net5.0

rm .\src\Core\Domain\Class1.cs
mkdir .\src\Core\Domain\Entities
echo 'namespace Domain { }' > .\src\Core\Domain\Entities\Account.cs

dotnet add .\src\Core\Domain package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

```
dotnet new classlib -o .\src\Core\Application -f net5.0

rm .\src\Core\Application\Class1.cs

dotnet add .\src\Core\Application reference .\src\Core\Domain
```

```
dotnet new classlib -o .\src\Infrastructure\Infrastructure.Identity -f net5.0

rm .\src\Infrastructure\Infrastructure.Identity\Class1.cs
mkdir .\src\Infrastructure\Infrastructure.Identity\Identity

echo 'namespace Infrastructure.Identity { }' > .\src\Infrastructure\Infrastructure.Identity\Identity\IdentityDataContext.cs
echo 'namespace Infrastructure.Identity { }' > .\src\Infrastructure\Infrastructure.Identity\Identity\ExternalAccounts.cs
echo 'namespace Infrastructure.Identity { }' > .\src\Infrastructure\Infrastructure.Identity\DependencyInjection.cs

dotnet add .\src\Infrastructure\Infrastructure.Identity package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add .\src\Infrastructure\Infrastructure.Identity package Microsoft.AspNetCore.Identity.UI
dotnet add .\src\Infrastructure\Infrastructure.Identity package Microsoft.EntityFrameworkCore.SqlServer
dotnet add .\src\Infrastructure\Infrastructure.Identity package Microsoft.EntityFrameworkCore.Tools

dotnet add .\src\Infrastructure\Infrastructure.Identity reference .\src\Core\Application
```
```
dotnet add .\src\Infrastructure\Infrastructure.Identity package Microsoft.AspNetCore.Authentication.MicrosoftAccount

```

```
dotnet new mvc -o .\src\Presentation\Presentation.WebApp -f net5.0 -au Individual -uld

rd .\src\Presentation\Presentation.WebApp\Data

dotnet add .\src\Presentation\Presentation.WebApp package Microsoft.VisualStudio.Web.CodeGeneration.Design

dotnet add .\src\Presentation\Presentation.WebApp reference .\src\Core\Application
dotnet add .\src\Presentation\Presentation.WebApp reference .\src\Infrastructure\Infrastructure.Identity

dotnet aspnet-codegenerator -p .\src\Presentation\Presentation.WebApp identity --files "Account.Register;Account.Login;Account.Logout"
rd .\src\Presentation\Presentation.WebApp\Areas\Identity\Data
rm .\src\Presentation\Presentation.WebApp\Areas\Identity\IdentityHostingStartup.cs
```


```
Qwert12345@
```

```
dotnet new sln
dotnet sln add (ls -r .\**\*.csproj)
```