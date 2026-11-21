# Relaciones en Entity Framework Core con ASP.NET Core MVC Client-Product-Invoce-Tb_DetailInvoce
## Base de Datos CrudApDbFirst Sql Server
## Tecnologías utilizadas
<details> 


<summary>Ver Tecnologías utilizadas</summary>

- C#
- .NET 10
- SQL Server
- Entity Framework Core
- Database-First
- MVC Client Razor
- Visual studio 2026 IDE (Desarrollo)

</details>


<details>

<summary>Ver comandos de instalación Packages</summary>

```Terminal p consola de paquetes...

  dotnet list package
  > Microsoft.EntityFrameworkCore                10.0.1       10.0.1  
  > Microsoft.EntityFrameworkCore.SqlServer      10.0.1       10.0.1  
  > Microsoft.EntityFrameworkCore.Tools          10.0.1       10.0.1  
  > System.Security.Cryptography.Pkcs            9.0.21       9.0.21   
```

</details>

<details>

<summary>Ver Diagrama de base de datos</summary>

![DiagramaBAse](Images/DiagramaBAse.png)

</details>

<details> 

<summary>Ver Script de toda la base con esquema y data</summary>

```
USE [master]
GO
/****** Object:  Database [CrudApDbFirst]    Script Date: 20/11/2026 2:55:03 ******/
CREATE DATABASE [CrudApDbFirst]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudApi26', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrudApi26.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudApi26_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CrudApi26_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CrudApDbFirst] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CrudApDbFirst].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CrudApDbFirst] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET ARITHABORT OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CrudApDbFirst] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CrudApDbFirst] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CrudApDbFirst] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CrudApDbFirst] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CrudApDbFirst] SET  MULTI_USER 
GO
ALTER DATABASE [CrudApDbFirst] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CrudApDbFirst] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CrudApDbFirst] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CrudApDbFirst] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CrudApDbFirst] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CrudApDbFirst] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CrudApDbFirst] SET QUERY_STORE = OFF
GO
USE [CrudApDbFirst]
GO
/****** Object:  Table [dbo].[Tb_Client]    Script Date: 20/11/2026 2:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Client](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_DetailInvoce]    Script Date: 20/11/2026 2:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_DetailInvoce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Invoce] [int] NOT NULL,
	[Id_Product] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Invoce]    Script Date: 20/11/2026 2:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Invoce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Id_Client] [int] NULL,
	[Total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Tb_invoce] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Product]    Script Date: 20/11/2026 2:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Tb_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tb_Client] ON 

INSERT [dbo].[Tb_Client] ([Id], [Name]) VALUES (1, N'Juan')
INSERT [dbo].[Tb_Client] ([Id], [Name]) VALUES (2, N'yuli')
INSERT [dbo].[Tb_Client] ([Id], [Name]) VALUES (3, N'Paola')
INSERT [dbo].[Tb_Client] ([Id], [Name]) VALUES (4, N'Gloria')
SET IDENTITY_INSERT [dbo].[Tb_Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_DetailInvoce] ON 

INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (9, 3, 1, 1, CAST(30.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (10, 3, 2, 2, CAST(600.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (11, 3, 3, 3, CAST(800.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (12, 3, 4, 4, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (13, 2, 1, 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (14, 2, 2, 1, CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (15, 2, 4, 1, CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (21, 1, 1, 2, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (22, 1, 2, 4, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (23, 1, 3, 1, CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (24, 1, 4, 1, CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (25, 1, 5, 1, CAST(678.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (26, 1, 6, 2, CAST(80000.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (27, 8, 3, 2, CAST(300.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (28, 8, 2, 2, CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_DetailInvoce] ([Id], [Id_Invoce], [Id_Product], [Quantity], [Price]) VALUES (29, 8, 4, 3, CAST(20.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tb_DetailInvoce] OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_Invoce] ON 

INSERT [dbo].[Tb_Invoce] ([Id], [Date], [Id_Client], [Total]) VALUES (1, CAST(N'2026-10-20' AS Date), 2, CAST(164778.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_Invoce] ([Id], [Date], [Id_Client], [Total]) VALUES (2, CAST(N'2026-10-17' AS Date), 2, CAST(3550.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_Invoce] ([Id], [Date], [Id_Client], [Total]) VALUES (3, CAST(N'2026-09-05' AS Date), 3, CAST(150.00 AS Decimal(18, 2)))
INSERT [dbo].[Tb_Invoce] ([Id], [Date], [Id_Client], [Total]) VALUES (8, CAST(N'2026-11-20' AS Date), 2, CAST(760.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Tb_Invoce] OFF
GO
SET IDENTITY_INSERT [dbo].[Tb_Product] ON 

INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (1, N'Pc', CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (2, N'Toy', CAST(50 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (3, N'Tv', CAST(300 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (4, N'radio', CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (5, N'Phone', CAST(150 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (6, N'zapatillas', CAST(40000 AS Decimal(18, 0)))
INSERT [dbo].[Tb_Product] ([Id], [Name], [Price]) VALUES (7, N'Glases', CAST(70 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Tb_Product] OFF
GO
ALTER TABLE [dbo].[Tb_DetailInvoce]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Invoce] FOREIGN KEY([Id_Invoce])
REFERENCES [dbo].[Tb_Invoce] ([Id])
GO
ALTER TABLE [dbo].[Tb_DetailInvoce] CHECK CONSTRAINT [FK_Detail_Invoce]
GO
ALTER TABLE [dbo].[Tb_DetailInvoce]  WITH CHECK ADD  CONSTRAINT [FK_Detail_Product] FOREIGN KEY([Id_Product])
REFERENCES [dbo].[Tb_Product] ([Id])
GO
ALTER TABLE [dbo].[Tb_DetailInvoce] CHECK CONSTRAINT [FK_Detail_Product]
GO
ALTER TABLE [dbo].[Tb_Invoce]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Invoce_Tb_Cliente] FOREIGN KEY([Id_Client])
REFERENCES [dbo].[Tb_Client] ([Id])
GO
ALTER TABLE [dbo].[Tb_Invoce] CHECK CONSTRAINT [FK_Tb_Invoce_Tb_Cliente]
GO
USE [master]
GO
ALTER DATABASE [CrudApDbFirst] SET  READ_WRITE 
GO

```

</details>

<details>

<summary>Ver Diagrama de base de datos</summary>

![4](images/4.png)
###### Agregamos un nuevo Api controlador en blanco lo llamamos Client ya que en la base esta [dbo].[Tb_Client]

</details>

<details> 

<summary>Ver estructura del projecto </summary>

![strcuturaProjecto](Images/strcuturaProjecto.png)

</details>

<details> 

<summary>Ver Controladores  ClientController</summary>

```

using Microsoft.AspNetCore.Mvc;
using MVCWebASPCore.Data;
using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data.Model;
using Microsoft.IdentityModel.Tokens;

namespace MVCWebASPCore.Controllers
{
    public class ClientController : Controller
    {
        private readonly dbFirstContext _context;

        public ClientController(dbFirstContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var clients = await _context.TbClients.ToListAsync();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbClient client)
        {
            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        //Get Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbClient client)
        {
            if (id != client.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        private bool ClientExists(int id)
        {
            throw new NotImplementedException();
        }

        //Get Client/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        //Post Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.TbClients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.TbClients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}


``` 

<summary>InvoceController </summary>

```
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MVCWebASPCore.Data;
using MVCWebASPCore.Data.Model;
using MVCWebASPCore.DTOs;

namespace MVCWebASPCore.Controllers
{
    public class InvoceController : Controller
    {
        private readonly dbFirstContext _context;

        public InvoceController(dbFirstContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPrice(int id)
        {
            var product = await _context.TbProducts
                .Where(p => p.Id == id)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            return Json(product);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //    Regla para recordar:
            //-Si utilizas Select() para construir un DTO, normalmente no necesitas Include().
            //- Si quieres cargar las entidades relacionadas completas, utiliza Include() y ThenInclude().
            var invoices = await _context.TbInvoces

                //.Include(i => i.IdClientNavigation)
                //.Include(i => i.TbDetailInvoces)
                //    .ThenInclude(d => d.IdProductNavigation)

                .Select(i => new InvoiceDto
                {
                    Id = i.Id,
                    Date = i.Date,
                    NameClient = i.IdClientNavigation!.Name,
                    Total = i.Total ?? 0m,

                    Products = i.TbDetailInvoces.Select(d => new DetailInvoiceDto
                    {
                        IdProduct = d.IdProduct,
                        NameProduct = d.IdProductNavigation!.Name,
                        Quantity = d.Quantity,
                        Price = d.Price

                    }).ToList()

                }).ToListAsync();

           return View(invoices);

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clients = new SelectList(
                _context.TbClients.ToList(),
                "Id",
                "Name"
            );

            ViewBag.Products = new SelectList(
                _context.TbProducts.ToList(),
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InvoiceCreateDto dto)
        {
            // Validar cliente
            bool clientExists = await _context.TbClients
                .AnyAsync(c => c.Id == dto.IdClient);

            if (!clientExists)
            {
                ModelState.AddModelError("IdClient", "Cliente no válido.");
            }

            // Validar productos
            if (dto.Products == null || !dto.Products.Any())
            {
                ModelState.AddModelError("", "Debe agregar al menos un producto.");
            }
            else
            {
                var productIds = dto.Products.Select(p => p.IdProduct)
                                              .Distinct()
                                              .ToList();

                int productsExists = await _context.TbProducts
                    .CountAsync(p => productIds.Contains(p.Id));

                if (productsExists != productIds.Count)
                {
                    ModelState.AddModelError("", "Hay productos no válidos.");
                }

                if (dto.Products.Any(p => p.Quantity <= 0 || p.Price < 0))
                {
                    ModelState.AddModelError("", "Cantidad o Price no válido.");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Clients = new SelectList(
                    _context.TbClients.ToList(), "Id", "Name");

                ViewBag.Products = new SelectList(
                    _context.TbProducts.ToList(), "Id", "Name");

                return View(dto);
            }

            // Crear factura
            var invoice = new TbInvoce
            {
                Date = dto.Date,
                IdClient = dto.IdClient,

                Total = dto.Products.Sum(p => p.Quantity * p.Price),

                TbDetailInvoces = dto.Products.Select(p => new TbDetailInvoce
                {
                    IdProduct = p.IdProduct,
                    Quantity = p.Quantity,
                    Price = p.Price

                }).ToList()
            };

            // Guardar factura y detalles
            _context.TbInvoces.Add(invoice);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            var dto = new InvoiceCreateDto
            {
                Date = invoice.Date,
                IdClient = invoice.IdClient ?? 0,

                Products = invoice.TbDetailInvoces.Select(d => new DetailInvoiceDto 
                {
                    IdProduct = d.IdProduct,
                    Quantity = d.Quantity,
                    Price = d.Price
                }).ToList()
            };

            ViewBag.Clients = new SelectList(
                _context.TbClients.ToList(), "Id", "Name", dto.IdClient);

            ViewBag.Products = new SelectList(
                _context.TbProducts.ToList(), "Id", "Name");

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InvoiceCreateDto dto)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            if (dto.Products == null || !dto.Products.Any())
                ModelState.AddModelError("", "Debe agregar al menos un producto.");

            if (!ModelState.IsValid)
            {
                ViewBag.Clients = new SelectList(
                    _context.TbClients.ToList(), "Id", "Name", dto.IdClient);

                ViewBag.Products = new SelectList(
                    _context.TbProducts.ToList(), "Id", "Name");

                return View(dto);
            }

            // Actualizar factura
            invoice.Date = dto.Date;
            invoice.IdClient = dto.IdClient;

            // Eliminar detalles anteriores
            _context.TbDetailInvoces.RemoveRange(invoice.TbDetailInvoces);

            // Agregar los nuevos detalles
            invoice.TbDetailInvoces = dto.Products.Select(p => new TbDetailInvoce
            {
                IdProduct = p.IdProduct,
                Quantity = p.Quantity,
                Price = p.Price
            }).ToList();

            // Calcular total
            invoice.Total = dto.Products.Sum(p => p.Quantity * p.Price);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.IdClientNavigation)
                .Include(i => i.TbDetailInvoces)
                    .ThenInclude(d => d.IdProductNavigation)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.TbInvoces
                .Include(i => i.TbDetailInvoces)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
                return NotFound();

            // Eliminar detalles de la factura
            _context.TbDetailInvoces.RemoveRange(invoice.TbDetailInvoces);

            // Eliminar factura
            _context.TbInvoces.Remove(invoice);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}

``` 

<summary>ProductController </summary>

```

using Microsoft.AspNetCore.Mvc;
using MVCWebASPCore.Data;
using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data.Model;
using Microsoft.IdentityModel.Tokens;

namespace MVCWebASPCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbFirstContext _context;

        public ProductController(dbFirstContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Products = await _context.TbProducts.ToListAsync();
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbProduct Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }


        //Get Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, TbProduct Product)
        {
            if (id != Product.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }

        private bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        //Get Product/Edit/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        //Post Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Product = await _context.TbProducts.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            _context.TbProducts.Remove(Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}


```
</details>

<details>

<summary>Ver Modelos TbClient </summary>

```
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebASPCore.Data.Model;

public partial class TbClient
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]

    public string? Name { get; set; }

    //relación uno a muchos (1:N), 1: Un cliente (TbClient). N: Muchas facturas (TbInvoce).
    public virtual ICollection<TbInvoce> TbInvoces { get; set; } = new List<TbInvoce>();
}

```

<summary>Ver TbProduct  </summary>

```
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCWebASPCore.Data.Model;

public partial class TbProduct
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")] //using System.ComponentModel.DataAnnotations;
    public string? Name { get; set; }
    [Required(ErrorMessage = "Price is required")]
    public decimal? Price { get; set; }

    //relación uno a muchos (1:N) entre TbInvoce y TbDetailInvoce.1 (Uno): TbInvoce (una factura).
    //N(Muchos) : TbDetailInvoce(muchos detalles de esa factura).
    public virtual ICollection<TbDetailInvoce> TbDetailInvoces { get; set; } = new List<TbDetailInvoce>();
}

```

<summary>Ver TbDetailInvoce  </summary>

```
using System;
using System.Collections.Generic;

namespace MVCWebASPCore.Data.Model;

public partial class TbDetailInvoce
{
    public int Id { get; set; }

    public int IdInvoce { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    //Muchos a Uno (N:1): muchos detalles de factura pueden pertenecer a una misma factura.
    public virtual TbInvoce IdInvoceNavigation { get; set; } = null!;
    //Muchos a Uno (N:1): muchos detalles de factura pueden pertenecer a un mismo producto.
    public virtual TbProduct IdProductNavigation { get; set; } = null!;
}

```

<summary>Ver TbInvoce  </summary>

```

using System;
using System.Collections.Generic;

namespace MVCWebASPCore.Data.Model;

public partial class TbInvoce
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int? IdClient { get; set; }

    public decimal? Total { get; set; }

    //Muchos a Uno (N:1): muchas facturas pueden pertenecer a un mismo cliente.
    public virtual TbClient? IdClientNavigation { get; set; }

    //relación uno a muchos (1:N), 1: Una factura (TbInvoce). N: Muchos detalles (TbDetailInvoce).
    public virtual ICollection<TbDetailInvoce> TbDetailInvoces { get; set; } = new List<TbDetailInvoce>();
}



```
</details>

<details> 

<summary>Ver  dbFirstContext : DbContext  </summary>

```
using System;
using System.Collections.Generic;
using MVCWebASPCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace MVCWebASPCore.Data;

public partial class dbFirstContext : DbContext
{
    public dbFirstContext()
    {
    }

    public dbFirstContext(DbContextOptions<dbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbClient> TbClients { get; set; }

    public virtual DbSet<TbDetailInvoce> TbDetailInvoces { get; set; }

    public virtual DbSet<TbInvoce> TbInvoces { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Clien__3214EC0718482CAE");

            entity.ToTable("Tb_Client");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbDetailInvoce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Detai__3214EC07DD6F1FC9");

            entity.ToTable("Tb_DetailInvoce");

            entity.Property(e => e.IdInvoce).HasColumnName("Id_Invoce");
            entity.Property(e => e.IdProduct).HasColumnName("Id_Product");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdInvoceNavigation).WithMany(p => p.TbDetailInvoces)
                .HasForeignKey(d => d.IdInvoce)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Invoce");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TbDetailInvoces)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Product");
        });

        modelBuilder.Entity<TbInvoce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tb_invoce");

            entity.ToTable("Tb_Invoce");

            entity.Property(e => e.IdClient).HasColumnName("Id_Client");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.TbInvoces)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Tb_Invoce_Tb_Cliente");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.ToTable("Tb_Product");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

```
</details>

<details> 

<summary>Ver DTOs DetailInvoiceDto </summary>

```
namespace MVCWebASPCore.DTOs
{
    public class DetailInvoiceDto
    {
        public int IdProduct { get; set; }

        public string? NameProduct { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}


```

<summary>Ver DTOs InvoiceCreateDto </summary>

```
namespace MVCWebASPCore.DTOs
{
    public class InvoiceCreateDto
    {
        public DateOnly? Date { get; set; }

        public int IdClient { get; set; }

        //representa la lista de productos que se van a agregar a la factura
        public List<DetailInvoiceDto> Products { get; set; }
            = new List<DetailInvoiceDto>();
    }
}

```

<summary>Ver DTOs InvoiceDto </summary>

```
using MVCWebASPCore.DTOs;

namespace MVCWebASPCore.DTOs
{

    public class InvoiceDto
    {
        public int Id { get; set; }

        public DateOnly? Date { get; set; }

        public string? NameClient { get; set; }

        public decimal Total { get; set; }
        //refers to the list of products associated with the invoice
        public List<DetailInvoiceDto> Products { get; set; }
            = new List<DetailInvoiceDto>();
    }
}

```

<summary>Ver DTOs InvoiceDto</summary>

```

namespace MVCWebASPCore.DTOs
{

    public class InvoiceDto
    {
        public int Id { get; set; }

        public DateOnly? Date { get; set; }

        public string? NameClient { get; set; }

        public decimal Total { get; set; }
        //refers to the list of products associated with the invoice
        public List<DetailInvoiceDto> Products { get; set; }
            = new List<DetailInvoiceDto>();
    }
}
 </summary>


```
</details>

<details> 

<summary>Ver Views  TbProduct-Index</summary>

```
@model IEnumerable<MVCWebASPCore.Data.Model.TbProduct>
<h2>Products</h2>

<a asp-action="Create" class="btn btn-primary">Create New Product</a>

<table class="table" table-striped>
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>   
            <th>Price</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Id</td>
                <td>@product.Name</td>
                <td>@product.Price</td>
                <td>
                    <a asp-action="Edit" asp-route-id="@product.Id" class="btn btn-sm btn-warning">Edit</a>
                    <a asp-action="Delete" asp-route-id="@product.Id" class="btn btn-sm btn-danger">Delete</a>


                </td>
            </tr>
        }
    </tbody>
</table> 


```

<summary>Ver Views  TbProduct-Edit</summary>

```

@model MVCWebASPCore.Data.Model.TbProduct

<h2>Edit Product</h2>

<form asp-action="Edit" method="post">

    <input type="hidden" asp-for="Id" />

    <div class="form-group">
        <label asp-for="Name">Name</label>
        <input asp-for="Name" class="form-control" placeholder="Add name Product" />
        <span asp-validation-for="Name" class="text-danger"></span>

        
        <label asp-for="Price"></label>
        <input asp-for="Price" class="form-control" placeholder="Add Price Product" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>
   
    <button type="submit" class="btn btn-primary">Edit</button>
    <a class="btn btn-secondary" asp-action="Index">Back to List</a>
</form>


```
<summary>Ver Views  TbProduct-Edit-Create</summary>

```
@model MVCWebASPCore.Data.Model.TbProduct

<h2>Create Product</h2>

<form asp-action="Create" method="post">
    <div class="form-group">
        <label asp-for="Name"></label>
        <input asp-for="Name" class="form-control" placeholder="Add Name Product" />
        <span asp-validation-for="Name" class="text-danger"></span>

        <label asp-for="Price"></label>
        <input asp-for="Price" class="form-control" placeholder="Add Price Product" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>
   
    <button type="submit" class="btn btn-primary">Create</button>
    <a class="btn btn-secondary" asp-action="Index">Back to List</a>
</form>




```
<summary>Ver Views  TbProduct-Delete</summary>

```

@model MVCWebASPCore.Data.Model.TbProduct       


<h2>Delete Product</h2>

<form asp-action="Delete" method="post">

    <input type="hidden" asp-for="Id" />
    <h3 class="text-xl-start text-danger">@Model.Name</h3>
 
    <button type="submit" class="btn btn-primary">Delete</button>
    <a class="btn btn-secondary" asp-action="Index">Back to List</a>
</form>


 </summary>
```
</details>


<details> 

<summary>Ver Views  TbProduct-Invoice</summary>

```

@using MVCWebASPCore.DTOs

@model IEnumerable<InvoiceDto>

<div class="mb-3">
    <a asp-controller="Invoce"
       asp-action="Create"
       class="btn btn-primary">
        <i class="bi bi-plus-circle"></i>
        Create Invoice
    </a>
</div>

<h2>Listado de Facturas</h2>

<table class="table table-bordered">
    <thead>
        <tr>
            <th>Id</th>
            <th>Fecha</th>
            <th>Cliente</th>
            <th>Total</th>
            <th>Productos</th>
            <th>Acciones</th>
        </tr>
    </thead>

    <tbody>
        @foreach (var invoice in Model)
        {
            <tr>
                <td>@invoice.Id</td>
                <td>@invoice.Date?.ToString("dd/MM/yyyy")</td>
                <td>@invoice.NameClient</td>
                <td>@invoice.Total</td>

                <td>
                    <table class="table table-sm">
                        <thead>
                            <tr>
                                <th>Producto</th>
                                <th>Cantidad</th>
                                <th>Price</th>
                            </tr>
                        </thead>

                        <tbody>
                            @foreach (var product in invoice.Products)
                            {
                                <tr>
                                    <td>@product.NameProduct</td>
                                    <td>@product.Quantity</td>
                                    <td>@product.Price</td>
                                </tr>
                            }
                        </tbody>
                    </table>
                </td>

                <!-- Botón Edit -->
                <td>
                    <a asp-controller="Invoce"
                       asp-action="Edit"
                       asp-route-id="@invoice.Id"
                       class="btn btn-warning btn-sm">
                        <i class="bi bi-pencil-square"></i>
                        Edit
                    </a>

                    <a asp-controller="Invoce"
                       asp-action="Delete"
                       asp-route-id="@invoice.Id"
                       class="btn btn-danger btn-sm">
                        <i class="bi bi-trash"></i>
                        Delete
                    </a>
                </td>

             

            </tr>
        }
    </tbody>
</table>



```

<summary>Ver Views  TbProduct-Edit</summary>

```

@model MVCWebASPCore.DTOs.InvoiceCreateDto

@{
    ViewData["Title"] = "Edit Invoice";
}

<h2>Edit Invoice</h2>

<hr />

<form asp-action="Edit"
      asp-route-id="@ViewContext.RouteData.Values["id"]"
      method="post">

    @Html.AntiForgeryToken()

    <div asp-validation-summary="All" class="text-danger"></div>

    <!-- Fecha -->
    <div class="mb-3">
        <label asp-for="Date" class="form-label">Date</label>
        <input asp-for="Date" type="date" class="form-control" />
        <span asp-validation-for="Date" class="text-danger"></span>
    </div>

    <!-- Cliente -->
    <div class="mb-3">
        <label asp-for="IdClient" class="form-label">Client</label>

        <select asp-for="IdClient"
                asp-items="ViewBag.Clients"
                class="form-select">
            <option value="">Select a client</option>
        </select>

        <span asp-validation-for="IdClient" class="text-danger"></span>
    </div>

    <hr />

    <h4>Products</h4>

    <div class="row mb-3">

        <div class="col-md-4">
            <label class="form-label">Product</label>

            <select id="product" class="form-select"
                    asp-items="ViewBag.Products">
                <option value="">Select a product</option>
            </select>
        </div>

        <div class="col-md-2">
            <label class="form-label">Quantity</label>
            <input type="number" id="quantity"
                   class="form-control" value="1" min="1" />
        </div>

        <div class="col-md-2">
            <label class="form-label">Price</label>
            <input type="number" id="price"
                   class="form-control" min="0" step="0.01" />
        </div>

        <div class="col-md-2 d-flex align-items-end">
            <button type="button" class="btn btn-success"
                    onclick="addProduct()">
                Add Product
            </button>
        </div>

    </div>

    <!-- Tabla de productos -->
    <table class="table table-bordered table-striped">
        <thead>
            <tr>
                <th>Product</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Subtotal</th>
                <th>Action</th>
            </tr>
        </thead>

        <tbody id="productList">

            @for (int i = 0; i < Model.Products.Count; i++)
            {
                <tr>
                    <td>
                        <input type="hidden"
                               name="Products[@i].IdProduct"
                               value="@Model.Products[i].IdProduct" />

                   
                        ID: @Model.Products[i].IdProduct
                        <br />
                        Producto: @Model.Products[i].NameProduct


                    </td>

                    <td>
                        <input type="number"
                               name="Products[@i].Quantity"
                               class="form-control quantity"
                               value="@Model.Products[i].Quantity"
                               min="1"
                               onchange="calculateTotal()" />
                    </td>

                    <td>
                        <input type="number"
                               name="Products[@i].Price"
                               class="form-control price"
                               value="@Model.Products[i].Price"
                               min="0"
                               step="0.01"
                               onchange="calculateTotal()" />
                    </td>

                    <td class="subtotal">
                        @(Model.Products[i].Quantity * Model.Products[i].Price)
                    </td>

                    <td>
                        <button type="button"
                                class="btn btn-danger btn-sm"
                                onclick="removeProduct(this)">
                            Delete
                        </button>
                    </td>
                </tr>
            }

        </tbody>

        <tfoot>
            <tr>
                <th colspan="3" class="text-end">Total:</th>
                <th id="total">0.00</th>
                <th></th>
            </tr>
        </tfoot>
    </table>

    <button type="submit" class="btn btn-primary">
        Save Changes
    </button>

    <a asp-action="Index" class="btn btn-secondary">
        Cancel
    </a>

</form>

@section Scripts {

    <partial name="_ValidationScriptsPartial" />

    <script>

        let index = @Model.Products.Count;

        function addProduct() {

            const select = document.getElementById("product");
            const productId = select.value;

            if (!productId) {
                alert("Select a product");
                return;
            }

            const productName =
                select.options[select.selectedIndex].text;

            const quantity =
                parseInt(document.getElementById("quantity").value);

            const price =
                parseFloat(document.getElementById("price").value);

            if (!Number.isInteger(quantity) || quantity <= 0 ||
                !Number.isFinite(price) || price < 0) {
                alert("Enter a valid quantity and price");
                return;
            }

            // Evitar productos repetidos
            const existing = document.querySelectorAll(
                'input[name$=".IdProduct"]'
            );

            for (const input of existing) {
                if (input.value === productId) {
                    alert("This product is already added");
                    return;
                }
            }

            const subtotal = quantity * price;

            const row = document.createElement("tr");

            const tdProduct = document.createElement("td");

            const hidden = document.createElement("input");
            hidden.type = "hidden";
            hidden.name = `Products[${index}].IdProduct`;
            hidden.value = productId;

            tdProduct.appendChild(hidden);
            tdProduct.appendChild(document.createTextNode(productName));

            const tdQuantity = document.createElement("td");
            tdQuantity.innerHTML = `
                        <input type="number"
                               name="Products[${index}].Quantity"
                               class="form-control quantity"
                               value="${quantity}" min="1"
                               onchange="calculateTotal()" />
                    `;

            const tdPrice = document.createElement("td");
            tdPrice.innerHTML = `
                        <input type="number"
                               name="Products[${index}].Price"
                               class="form-control price"
                               value="${price}" min="0" step="0.01"
                               onchange="calculateTotal()" />
                    `;

            const tdSubtotal = document.createElement("td");
            tdSubtotal.className = "subtotal";
            tdSubtotal.textContent = subtotal.toFixed(2);

            const tdAction = document.createElement("td");
            tdAction.innerHTML = `
                        <button type="button"
                                class="btn btn-danger btn-sm"
                                onclick="removeProduct(this)">
                            Delete
                        </button>
                    `;

            row.append(tdProduct, tdQuantity, tdPrice,
                tdSubtotal, tdAction);

            document.getElementById("productList").appendChild(row);

            index++;

            select.value = "";
            document.getElementById("quantity").value = 1;
            document.getElementById("price").value = "";

            calculateTotal();
        }

        function removeProduct(button) {
            button.closest("tr").remove();
            renumberProducts();
            calculateTotal();
        }

        function renumberProducts() {

            const rows = document.querySelectorAll("#productList tr");

            rows.forEach((row, i) => {

                row.querySelectorAll("input").forEach(input => {

                    input.name = input.name.replace(
                        /Products\[\d+\]/,
                        `Products[${i}]`
                    );

                });

            });

            index = rows.length;
        }

        function calculateTotal() {

            let total = 0;

            document.querySelectorAll("#productList tr").forEach(row => {

                const quantity =
                    parseFloat(row.querySelector(".quantity").value) || 0;

                const price =
                    parseFloat(row.querySelector(".price").value) || 0;

                const subtotal = quantity * price;

                row.querySelector(".subtotal").textContent =
                    subtotal.toFixed(2);

                total += subtotal;

            });

            document.getElementById("total").textContent =
                total.toFixed(2);
        }

        document.querySelector("form").addEventListener("submit", function(e) {

            const rows = document.querySelectorAll("#productList tr");

            if (rows.length === 0) {
                e.preventDefault();
                alert("Add at least one product");
            }

        });

        // Calcular el total al cargar la factura
        calculateTotal();

    </script>
}


```
<summary>Ver Views  TbProduct-Edit-Create</summary>

```

@model MVCWebASPCore.DTOs.InvoiceCreateDto

@{
    ViewData["Title"] = "Create Invoice";
}

<h2>Create Invoice</h2>

<hr />

<form asp-action="Create" method="post">

    @Html.AntiForgeryToken()

    <div asp-validation-summary="All" class="text-danger"></div>



    <!-- DATE -->
    <div class="mb-3">
        <label asp-for="Date" class="form-label">Date</label>

        <input asp-for="Date"
               type="date"
               value="@DateTime.Today.ToString("yyyy-MM-dd")"
               class="form-control" 
               readonly
               />

        <span asp-validation-for="Date" class="text-danger"></span>
    </div>

    <!-- CLIENT -->
    <div class="mb-3">
        <label asp-for="IdClient" class="form-label">Client</label>

        <select asp-for="IdClient"
                asp-items="ViewBag.Clients"
                class="form-select">
            <option value="">Select Client</option>
        </select>

        <span asp-validation-for="IdClient" class="text-danger"></span>
    </div>

    <hr />

    <h4>Products</h4>

    <!-- PRODUCT -->
    <div class="row">

        <div class="col-md-4 mb-3">
            <label>Product</label>

            <select id="product"
                    asp-items="ViewBag.Products"
                    class="form-select">
                <option value="">Select Product</option>
            </select>
        </div>

        <div class="col-md-2 mb-3">
            <label>Quantity</label>
            <input id="quantity" type="number"
                   class="form-control" value="1" min="1" />
        </div>

        <div class="col-md-3 mb-3">
            <label>Price</label>
            <input id="price" type="number"
                   class="form-control" min="0" step="0.01" 
                   readonly />
        </div>

        <div class="col-md-3 mb-3 d-flex align-items-end">
            <button type="button"
                    class="btn btn-success w-100"
                    onclick="addProduct()">
                Add Product
            </button>
        </div>

    </div>

    <!-- PRODUCT TABLE -->
    <table class="table table-bordered table-striped">

        <thead>
            <tr>
                <th>ID / Product</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Subtotal</th>
                <th>Action</th>
            </tr>
        </thead>

        <tbody id="productList">
        </tbody>

        <tfoot>
            <tr>
                <th colspan="3" class="text-end">TOTAL:</th>
                <th id="total">0.00</th>
                <th></th>
            </tr>
        </tfoot>

    </table>

    <hr />

    <button type="submit" class="btn btn-primary">
        Save Invoice
    </button>

    <a asp-action="Index" class="btn btn-secondary">
        Back
    </a>

</form>

<script>

    let index = 0;

    function addProduct() {

        const select = document.getElementById("product");

        const productId = select.value;

        if (!productId) {
            alert("Select a product");
            return;
        }

        const productName =
            select.options[select.selectedIndex].text;

        const quantity =
            parseInt(document.getElementById("quantity").value);

        const price =
            parseFloat(document.getElementById("price").value);

        if (!Number.isInteger(quantity) || quantity <= 0 ||
            !Number.isFinite(price) || price < 0) {
            alert("Enter a valid quantity and price");
            return;
        }

        const subtotal = quantity * price;

        const tbody = document.getElementById("productList");

        const row = document.createElement("tr");

        row.innerHTML = `
            <td>
                ${productName}
                <input type="hidden"
                       name="Products[${index}].IdProduct"
                       value="${productId}" />
            </td>

            <td>
                ${quantity}
                <input type="hidden"
                       name="Products[${index}].Quantity"
                       value="${quantity}" />
            </td>

            <td>
                ${price.toFixed(2)}
                <input type="hidden"
                       name="Products[${index}].Price"
                       value="${price}" />
            </td>

            <td class="subtotal">
                ${subtotal.toFixed(2)}
            </td>

            <td>
                <button type="button"
                        class="btn btn-danger btn-sm"
                        onclick="removeProduct(this)">
                    Delete
                </button>
            </td>
        `;

        tbody.appendChild(row);

        index++;

        calculateTotal();

        select.value = "";

        document.getElementById("quantity").value = 1;
        document.getElementById("price").value = "";
    }

    function removeProduct(button) {

        button.closest("tr").remove();

        renumberProducts();

        calculateTotal();
    }

    function renumberProducts() {

        const rows =
            document.querySelectorAll("#productList tr");

        rows.forEach((row, i) => {

            row.querySelectorAll("input").forEach(input => {

                input.name = input.name.replace(
                    /Products\[\d+\]/,
                    `Products[${i}]`
                );

            });

        });

        index = rows.length;
    }

    function calculateTotal() {

        let total = 0;

        document.querySelectorAll("#productList tr")
            .forEach(row => {

                const subtotal =
                    parseFloat(row.querySelector(".subtotal").textContent);

                total += subtotal;

            });

        document.getElementById("total").textContent =
            total.toFixed(2);
    }

    document.querySelector("form").addEventListener("submit", function(e) {

        if (document.querySelectorAll("#productList tr").length === 0) {

            e.preventDefault();

            alert("Add at least one product");
        }

    });


        document.getElementById("product").addEventListener("change", async function () {

        const productId = this.value;
        const priceInput = document.getElementById("price");

        priceInput.value = "";

        if (!productId)
            return;

        const response = await fetch(`/Invoce/GetProductPrice?id=${productId}`);

        if (response.ok) {
            const price = await response.json();
            priceInput.value = price ?? "";
        }
    });

</script>

```
<summary>Ver Views  TbProduct-Delete</summary>

```

@model MVCWebASPCore.Data.Model.TbInvoce

<h2>Delete Invoice</h2>

<h4>Are you sure you want to delete this invoice?</h4>

<hr />

<dl class="row">
    <dt class="col-sm-2">Id</dt>
    <dd class="col-sm-10">@Model.Id</dd>

    <dt class="col-sm-2">Date</dt>
    <dd class="col-sm-10">@Model.Date</dd>

    <dt class="col-sm-2">Client</dt>
    <dd class="col-sm-10">@Model.IdClientNavigation?.Name</dd>

    <dt class="col-sm-2">Total</dt>
    <dd class="col-sm-10">@Model.Total</dd>
</dl>

<form asp-action="Delete" method="post">
    @Html.AntiForgeryToken()

    <input type="hidden" name="id" value="@Model.Id" />

    <button type="submit" class="btn btn-danger">
        Confirm Delete
    </button>

    <a asp-action="Index" class="btn btn-secondary">
        Cancel
    </a>
</form>



```
<summary>Ver Views  TbProduct-_ViewStart</summary>

```
@{
    Layout = "_Layout";
}


<ul class="nav-item d-flex gap-2 list-unstyled">

    <li>
        <a asp-controller="Client"
           asp-action="Index"
           class="btn btn-primary">
            List of Clients
        </a>
    </li>

    <li>
        <a asp-controller="Product"
           asp-action="Index"
           class="btn btn-primary">
            List of Products
        </a>
    </li>

    <li>
        <a asp-controller="Invoce"
           asp-action="Index"
           class="btn btn-primary">
            List of Invoices
        </a>
    </li>

</ul>

<partial name="_ValidationScriptsPartial" />


 </summary>
```
</details>

<details> 

<summary>Ver Program.cs  </summary>

```
using Microsoft.EntityFrameworkCore;
using MVCWebASPCore.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<dbFirstContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


```
</details>

<details> 

<summary>Ver appsettings.json  </summary>

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConnectionString": "Data Source=DESKTOP-SO605I4\\SQLEXPRESS;Database=CrudApDbFirst;Integrated Security=True;TrustServerCertificate=Yes"
  }
  }

```
</details>


