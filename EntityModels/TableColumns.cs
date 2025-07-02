using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class TableColumns
    {
        private static Dictionary<string, string[]> allcolumns = new Dictionary<string, string[]>
        {
            { "customer", new string[] { "CustomerID", "Name", "PhoneNum", "Address", "Email" } },
            { "delivery", new string[] { "DeliveryID", "Method", "Date", "OrderID", "EmployeeID" } },
            { "employee", new string[] { "EmployeeID", "Name", "PhoneNum" } },
            { "file", new string[] { "FileID", "ProductID", "FileName", "FileLoc", "AddDate" } },
            { "ingredient", new string[] { "MaterialID", "MaterialQty", "Desc" } },
            { "material", new string[] { "MaterialID", "Name", "Category", "Desc" } },
            { "meeting", new string[] { "MeetingID", "Date", "Time", "Loc" } },
            { "meetingparticipant", new string[] { "MeetingID", "EmpID", "CustomerID" } },
            { "order", new string[] { "OrderID", "OrderDate", "Status", "SaleID", "CustomerID" } },
            { "orderline", new string[] { "OrderID", "ProductID", "Qty" } },
            { "payment", new string[] { "PaymentID", "OrderID", "PaymentDate", "Due", "Amount", "Type", "Status", "Method" } },
            { "product", new string[] { "ProductID", "Name", "Desc" } },
            { "productinventory", new string[] { "ProductID", "WarehouseID", "Qty", "Loc" } },
            { "productorder", new string[] { "POrderID", "ProductID", "LineProductID", "StartDate", "Due", "Qty" } },
            { "purchase", new string[] { "PurchaseID", "Date", "Amount" } },
            { "purchaseline", new string[] { "PurchaseID", "SupplierID", "MaterialID", "Qty" } },
            { "supplier", new string[] { "SupplierID", "Name", "PhoneNum", "Address", "Email" } },
            { "warehouse", new string[] { "WarehouseID", "Name", "Address" } }
        };
        public static Dictionary<string, string[]> AllColumns
        {
            get { return allcolumns; }
        }
        public static string[] GetColumns(string tableName)
        {
            if (allcolumns.ContainsKey(tableName))
            {
                return allcolumns[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not exist.");
            }
        }
        private static Dictionary<string, string[]> primaryKeys = new Dictionary<string, string[]>
        {
            { "customer", new[] { "CustomerID" } },
            { "delivery", new[] { "DeliveryID" } },
            { "employee", new[] { "EmployeeID" } },
            { "file", new[] { "FileID" } },
            { "ingredient", new[] { "MaterialID" } },
            { "material", new[] { "MaterialID" } },
            { "meeting", new[] { "MeetingID" } },
            { "meetingparticipant", new[] { "MeetingID", "EmpID" } },
            { "order", new[] { "OrderID" } },
            { "orderline", new[] { "OrderID", "ProductID" } },
            { "payment", new[] { "PaymentID" } },
            { "product", new[] { "ProductID" } },
            { "productinventory", new[] { "ProductID", "WarehouseID" } },
            { "productorder", new[] { "POrderID" } },
            { "purchase", new[] { "PurchaseID" } },
            { "purchaseline", new[] { "PurchaseID", "SupplierID", "MaterialID" } },
            { "supplier", new[] { "SupplierID" } },
            { "warehouse", new[] { "WarehouseID" } }
        };
        public static Dictionary<string, string[]> PrimaryKeys
        {
            get { return primaryKeys; }
        }
        public static string[] GetPrimaryKeys(string tableName)
        {
            if (primaryKeys.ContainsKey(tableName))
            {
                return primaryKeys[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not have a primary key defined.");
            }
        }
        private static Dictionary<string, string[]> foreignKeys = new Dictionary<string, string[]>
        {
            { "delivery", new[] { "OrderID", "EmployeeID" } },
            { "meetingparticipant", new[] { "MeetingID", "EmpID", "CustomerID" } },
            { "order", new[] { "SaleID", "CustomerID" } },
            { "orderline", new[] { "OrderID", "ProductID" } },
            { "payment", new[] { "OrderID" } },
            { "productinventory", new[] { "ProductID", "WarehouseID" } },
            { "productorder", new[] { "ProductID" } },
            { "purchaseline", new[] { "SupplierID", "MaterialID" } }
        };
        public static Dictionary<string, string[]> ForeignKeys
        {
            get { return foreignKeys; }
        }
        public static string[] GetForeignKeys(string tableName)
        {
            if (foreignKeys.ContainsKey(tableName))
            {
                return foreignKeys[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not have foreign keys defined.");
            }
        }
        private static Dictionary<string, string[]> uniqueKeys = new Dictionary<string, string[]>
        {
            { "customer", new[] { "Email" } },
            { "employee", new[] { "PhoneNum" } },
            { "file", new[] { "FileName" } },
            { "material", new[] { "Name" } },
            { "product", new[] { "Name" } },
            { "supplier", new[] { "Email" } }
        };
        public static Dictionary<string, string[]> UniqueKeys 
        {
            get { return uniqueKeys; }
        }
        public static string[] GetUniqueKeys(string tableName)
        {
            if (uniqueKeys.ContainsKey(tableName))
            {
                return uniqueKeys[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not have unique keys defined.");
            }
        }
        private static Dictionary<string, string[]> columnWithoutPrimaryKey = new Dictionary<string, string[]>
        {
            { "customer", new[] { "Name", "PhoneNum", "Address", "Email" } },
            { "delivery", new[] { "Method", "Date", "OrderID", "EmployeeID" } },
            { "employee", new[] { "Name", "PhoneNum" } },
            { "file", new[] { "ProductID", "FileName", "FileLoc", "AddDate" } },
            { "ingredient", new[] { "MaterialQty", "Desc" } },
            { "material", new[] { "Name", "Category", "Desc" } },
            { "meeting", new[] { "Date", "Time", "Loc" } },
            { "meetingparticipant", new[] { "EmpID", "CustomerID" } },
            { "order", new[] { "OrderDate", "Status", "SaleID", "CustomerID" } },
            { "orderline", new[] { "Qty" } },
            { "payment", new[] { "OrderID", "PaymentDate", "Due", "Amount", "Type", "Status", "Method" } },
            { "productinventory", new[] { "Qty", "Loc" } },
            { "productorder", new[] { "ProductID", "LineProductID", "StartDate", "Due", "Qty" } },
            { "purchase", new[] { "Date", "Amount" } },
            { "purchaseline", null }, // No columns without primary key
            { "supplier", null }, // No columns without primary key
            { "warehouse", new[] {"Name","Address"} }
        };
        public static Dictionary<string, string[]> ColumnWithoutPrimaryKey
        {
            get { return columnWithoutPrimaryKey; }
        }
        public static string[] GetColumnsWithoutPrimaryKey(string tableName)
        {
            if (columnWithoutPrimaryKey.ContainsKey(tableName))
            {
                return columnWithoutPrimaryKey[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not have columns defined without primary key.");
            }
        }
        private static Dictionary<string, Dictionary<string, string>> tableColumnTypes = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "customer", new Dictionary<string, string>
                {
                    { "CustomerID", "varchar(10)" },
                    { "Name", "varchar(50)" },
                    { "PhoneNum", "int(11)" },
                    { "Address", "varchar(200)" },
                    { "Email", "varchar(200)" }
                }
            },
            {
                "delivery", new Dictionary<string, string>
                {
                    { "DeliveryID", "varchar(10)" },
                    { "Method", "varchar(30)" },
                    { "Date", "date" },
                    { "OrderID", "varchar(10)" },
                    { "EmployeeID", "varchar(10)" }
                }
            },
            {
                "employee", new Dictionary<string, string>
                {
                    { "EmployeeID", "varchar(10)" },
                    { "Name", "varchar(50)" },
                    { "PhoneNum", "int(11)" }
                }
            },
            {
                "file", new Dictionary<string, string>
                {
                    { "FileID", "varchar(10)" },
                    { "ProductID", "varchar(10)" },
                    { "FileName", "varchar(100)" },
                    { "FileLoc", "varchar(100)" },
                    { "AddDate", "date" }
                }
            },
            {
                "ingredient", new Dictionary<string, string>
                {
                    { "MaterialID", "varchar(10)" },
                    { "MaterialQty", "varchar(10)" },
                    { "Desc", "varchar(200)" }
                }
            },
            {
                "material", new Dictionary<string, string>
                {
                    { "MaterialID", "varchar(10)" },
                    { "Name", "varchar(50)" },
                    { "Category", "varchar(50)" },
                    { "Desc", "varchar(200)" }
                }
            },
            {
                "meeting", new Dictionary<string, string>
                {
                    { "MeetingID", "varchar(10)" },
                    { "Date", "date" },
                    { "Time", "time" },
                    { "Loc", "varchar(100)" }
                }
            },
            {
                "meetingparticipant", new Dictionary<string, string>
                {
                    { "MeetingID", "varchar(10)" },
                    { "EmpID", "varchar(10)" },
                    { "CustomerID", "varchar(10)" }
                }
            },
            {
                "order", new Dictionary<string, string>
                {
                    { "OrderID", "varchar(10)" },
                    { "OrderDate", "varchar(15)" },
                    { "Status", "varchar(15)" },
                    { "SaleID", "varchar(10)" },
                    { "CustomerID", "varchar(10)" }
                }
            },
            {
                "orderline", new Dictionary<string, string>
                {
                    { "OrderID", "varchar(10)" },
                    { "ProductID", "varchar(10)" },
                    { "Qty", "int(11)" }
                }
            },
            {
                "payment", new Dictionary<string, string>
                {
                    { "PaymentID", "varchar(10)" },
                    { "OrderID", "varchar(10)" },
                    { "PaymentDate", "date" },
                    { "Due", "date" },
                    { "Amount", "int(11)" },
                    { "Type", "varchar(15)" },
                    { "Status", "varchar(15)" },
                    { "Method", "varchar(15)" }
                }
            },
            {
                "product", new Dictionary<string, string>
                {
                    { "ProductID", "varchar(10)" },
                    { "Name", "varchar(30)" },
                    { "Desc", "varchar(200)" }
                }
            },
            {
                "productinventory", new Dictionary<string, string>
                {
                    { "ProductID", "varchar(10)" },
                    { "WarehouseID", "varchar(10)" },
                    { "Qty", "int(11)" },
                    { "Loc", "varchar(30)" }
                }
            },
            {
                "productorder", new Dictionary<string, string>
                {
                    { "POrderID", "varchar(10)" },
                    { "ProductID", "varchar(10)" },
                    { "LineProductID", "varchar(10)" },
                    { "StartDate", "date" },
                    { "Due", "date" },
                    { "Qty", "int(11)" }
                }
            },
            {
                "purchase", new Dictionary<string, string>
                {
                    { "PurchaseID", "varchar(10)" },
                    { "Date", "date" },
                    { "Amount", "int(11)" }
                }
            },
            {
                "purchaseline", new Dictionary<string, string>
                {
                    { "PurchaseID", "varchar(10)" },
                    { "SupplierID", "varchar(10)" },
                    { "MaterialID", "varchar(10)" },
                    { "Qty", "int(11)" }
                }
            },
            {
                "supplier", new Dictionary<string, string>
                {
                    { "SupplierID", "varchar(10)" },
                    { "Name", "varchar(50)" },
                    { "PhoneNum", "int(11)" },
                    { "Address", "varchar(200)" },
                    { "Email", "varchar(200)" }
                }
            },
            {
                "warehouse", new Dictionary<string, string>
                {
                    { "WarehouseID", "varchar(10)" },
                    { "Name", "varchar(50)" },
                    { "Address", "varchar(200)" }
                }
            }
        };
        public static Dictionary<string, Dictionary<string, string>> TableColumnTypes
        {
            get { return tableColumnTypes; }
        }
        public static Dictionary<string, string> GetColumnTypes(string tableName)
        {
            if (tableColumnTypes.ContainsKey(tableName))
            {
                return tableColumnTypes[tableName];
            }
            else
            {
                throw new ArgumentException($"Table '{tableName}' does not have column types defined.");
            }
        }
        public static string GetColumnType(string tableName, string columnName)
        {
            if (tableColumnTypes.ContainsKey(tableName) && tableColumnTypes[tableName].ContainsKey(columnName))
            {
                return tableColumnTypes[tableName][columnName];
            }
            else
            {
                throw new ArgumentException($"Column '{columnName}' does not exist in table '{tableName}'.");
            }
        }
        public static readonly string[] tableNames = new string[]
        {
            "customer", "delivery", "employee", "file", "ingredient", "material",
            "meeting", "meetingparticipant", "order", "orderline", "payment",
            "product", "productinventory", "productorder", "purchase",
            "purchaseline", "supplier", "warehouse"
        };
    }
}
