using EntityModels;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.MasterData
{
    public class MasterDataController : SubSystemController
    {
        DataTable masterDataTable;
        string masterDataTableName;
        string masterDataTableFilter_expression = string.Empty;

        internal void OpenPage(int pageIndex)
        {   //Winform : MasterDataMaintance, CustomerData, EmployeeData
            switch (pageIndex)
            {
                case 0: // Customer Data
                    MasterDataMaintance masterDataMaintance = new MasterDataMaintance(this);
                    masterDataMaintance.Show();
                    break;
                case 1: // Not used
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageIndex), "Invalid page index for Master Data Management.");
            }
        }
        internal void CloseMasterDataPage()
        {
            // Close all open forms related to Master Data Management
            foreach (Form form in Application.OpenForms)
            {
                if (form is MasterDataMaintance || form is CustomerData || form is EmployeeData)
                {
                    form.Close();
                }
            }
            
        }
        public async Task<DataTable> GetCustomerData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("customer");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public async Task<DataTable> GetEmployeeData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("employee");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        internal string[] GetTableNames()
        {
            string[] tableNames = TableColumns.tableNames;
            if (tableNames == null || tableNames.Length == 0)
            {
                throw new InvalidOperationException("No table names found.");
            }
            return tableNames;
        }



        internal DataTable reloadMasterTable()
        {
            masterDataTableFilter_expression = string.Empty;
            return masterDataTable ?? throw new InvalidOperationException("Master data table is not initialized. Please fetch data first.");
        }
        internal async Task<int> UpdateMasterTableData(DataTable dtUpdated)
        {
            if (masterDataTableName == null)
            {
                throw new InvalidOperationException("Table is not set. Please set the table before updating data.");
            }
            // Get the key columns for the specified table
            string[] keyColumns = TableColumns.GetPrimaryKeys(masterDataTableName);
            int rowsUpdated = await UpdateData(dtUpdated, masterDataTableName, keyColumns);
            return rowsUpdated;
        }




        internal async Task<DataTable> GetDataFromTable(string selectedTable)
        {
            DataTable dt = null;
            try
            {
                if (string.IsNullOrEmpty(selectedTable))
                {
                    throw new ArgumentException("Selected table cannot be null or empty.", nameof(selectedTable));
                }
                dt = await GetTableData(selectedTable);
                masterDataTable = dt; // Store the retrieved data for further operations
                masterDataTableName = selectedTable;
                masterDataTableFilter_expression = string.Empty;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error retrieving data from table '{selectedTable}': {ex.Message}", ex);
            }
            return dt;
        }

        internal object GetFilteredMasterData()
        {
            if (masterDataTable == null) return null;
            return GetFilteredTable(masterDataTable, masterDataTableFilter_expression);
        }
        internal DataTable FindMasterDataNyID(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || masterDataTable == null)
                return null;
            return FindRowsByID(id, masterDataTable, masterDataTableFilter_expression);
        }
        internal void removeMasterDataFilter(string v1, string v2)
        {
            masterDataTableFilter_expression = RemoveFilterItem(v1, v2, masterDataTable, masterDataTableFilter_expression);
        }
        internal void AddMasterDataFilter(string? filterColumn, string filterValue)
        {
            masterDataTableFilter_expression = AddFilterItem(filterColumn, filterValue, masterDataTable, masterDataTableFilter_expression);
        }


    }
}
