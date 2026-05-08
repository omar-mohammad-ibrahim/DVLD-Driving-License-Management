# DVLD - Driving and Vehicle License Department Management System 🚗

A comprehensive desktop application designed to manage the operations of a Driving and Vehicle License Department. 

## 🏗️ Architecture
This project is built strictly using the **3-Tier Architecture** approach to ensure separation of concerns, scalability, and maintainability:
1. **Presentation Layer (UI):** Built with Windows Forms.
2. **Business Layer (Logic):** Handles rules and data validation.
3. **Data Access Layer (Database):** Handles database connections and queries.

## 🛠️ Technologies Used
* **Language:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET

## 🚀 How to Run the Project
1. Clone the repository to your local machine.
2. Open **SQL Server Management Studio (SSMS)** and run the provided `DatabaseScript.sql` file to generate the database and its data.
3. Open the `.sln` file using **Visual Studio**.
4. Go to the `DataAccessLayer` project -> open `clsDataAccessSettings.cs`.
5. Update the `connectionString` to match your local SQL Server instance.
6. Build and Run the project.

## 🔑 Default Login
* **Username:** Msaqer77
* **Password:** 1234
