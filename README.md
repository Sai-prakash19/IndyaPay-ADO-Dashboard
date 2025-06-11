# IndyaPay Dashboard (ADO.NET Version)

A web-based recharge dashboard built using ASP.NET Web Forms and ADO.NET. This project simulates mobile recharges, logs API requests, and displays recharge history with filtering — designed as an interview assessment task.

---

## 🚀 Features

- 📲 Recharge form with dummy API integration (`jsonplaceholder.typicode.com`)
- 🔌 API logs stored in `APILogs` table using **ADO.NET**
- 💳 Recharge entries stored in `Recharge` table using **ADO.NET**
- 📊 Recharge history with filters (operator, date range)
- 🧭 Clean Bootstrap-based UI with green + white + blue branding
- 📁 Local database stored in `App_Data`

---

## 🛠️ Tech Stack

- ASP.NET Web Forms (.NET Framework)
- ADO.NET (SqlClient)
- SQL Server LocalDB (`.mdf`)
- HTML, CSS, Bootstrap
- Visual Studio 2022

---

## 📁 Project Structure

FinServices_ADO_Dashboard/
├── App_Data/ # LocalDB .mdf file
├── Pages/
│ ├── Dashboard.aspx # Summary & navigation
│ ├── RechargeAPI.aspx # Recharge form + API logging
│ └── RechargeHistory.aspx # Recharge records with filters
├── Logs/
│ └── APILogging.cs # ADO.NET logging class
├── Content/ # CSS + logo
├── Site.Master # Master layout
└── Web.config # Connection string config


---

## 🗃️ Database Schema

```sql
CREATE TABLE APILogs (
    Id INT PRIMARY KEY IDENTITY,
    RequestData NVARCHAR(MAX),
    ResponseData NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Recharge (
    Id INT PRIMARY KEY IDENTITY,
    MobileNumber NVARCHAR(20),
    Operator NVARCHAR(50),
    Amount DECIMAL(10,2),
    RechargedAt DATETIME DEFAULT GETDATE()
);


