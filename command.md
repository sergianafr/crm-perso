dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.0 
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0 
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Database=crm;User=root;Password=root;" Pomelo.EntityFrameworkCore.MySql --output-dir Models --context-dir Data --context ApplicationDbContext --force