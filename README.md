# CSharp Project

## Requirements
```
Visual Studio Code
Dotnet SDK 7.0
```

## Install
```
1> Update the database connection string:

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Repos\\Zip.InstallmentsService\\Zip.InstallmentsService\\Zip.InstallmentsService\\db\\InstallmentDB.mdf;Integrated Security=True");

2> add your first migration! Instruct EF Core to create a migration named InitialCreate:

3> Add-Migration InitialCreate

4> Update-Database

DB - Script

CREATE TABLE [PaymentPlan] (
    [Id] uniqueidentifier NOT NULL,
    [purchase_amount] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_PaymentPlan] PRIMARY KEY CLUSTERED ([Id])
);
GO


CREATE TABLE [Installment] (
    [Id] uniqueidentifier NOT NULL,
    [due_date] datetime2 NOT NULL,
    [amount] decimal(18,2) NOT NULL,
    [payment_plan_id] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Installment] PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT [FK_service_id] FOREIGN KEY ([payment_plan_id]) REFERENCES [PaymentPlan] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Installment_payment_plan_id] ON [Installment] ([payment_plan_id]);
GO
```

## Quick Start
```
cd Zip.InstallmentsService
dotnet run
```

## Run Tests
```
cd Zip.InstallmentsService
dotnet test Zip.InstallmentsService.sln
```
