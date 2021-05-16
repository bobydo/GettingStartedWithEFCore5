# Pluralsight Getting Started With EF Core 5  
Exercise files for my Dec 2020 course, Getting Started with EF Core (5) on Pluralsight  

This course will teach you how to use Entity Framework Core 5 to perform data access in your .NET applications.
  
https://bit.ly/EFCore5Start

EF 7.0  
Microsoft.EntityFrameworkCore.SqlServer  
Migration  
Microsoft.EntityFrameworkCore.Tools (command) -- Script-Migration : Generate a sql script from migrations  
Microsoft.EntityFrameworkCore.Design (API)  
a) Override OnConfiguration  
b) OnModelCreating (Fluent API)  
Reverse EF (generate codes from DB)  
scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlSderver -connection "...."    
  
https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools  
  
<div align="left">
    <img src="/image/4.png" width="700"</img> 
</div>
<div align="left">
    <img src="/image/4ManyToMany.png" width="700"</img> 
</div>
<div align="left">
    <img src="/image/4JoinTable.png" width="700"</img> 
</div>
<div align="left">
    <img src="/image/4JoinExtra.png" width="700"</img> 
</div>
Bulk operation from SQL command  
MERGE [Samurais] USING (......)  
https://github.com/dotnet/efcore/blob/179a2ddaa922fdd123fb58216becdb980ef44999/src/EFCore.SqlServer/Update/Internal/SqlServerModificationCommandBatch.cs#L23  
private const int MaxParameterCount = 2100;  
private const int MaxRowCount = 1000; 
  
var samurais = _context.Samurais  
                .Where(s => EF.Functions.Like(s.Name, filter)).ToList();  
  
Batch process ：  
_context.Samurais.AddRange(...)  
var samurais = _context.Samurais.Skip(1).Take(4).ToList();  
samurais.ForEach(s=>s.Name += "San");  
_context.SaveChanges();  
  
<div align="left">
    <img src="/image/5NoTrack.png" width="700"</img> 
</div>
5NoTrack.png
