using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccessController;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.Inventory
{
    internal class InventoryController : SubSystemController
    {

        public InventoryController()
        {
        }
        public async Task<DataTable> GetProductData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("product"); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<DataTable> GetProductWithInventoryData()
        {
            DataTable dt;
            string sql = @"
                SELECT p.*, pi.Qty, pi.WarehouseID, pi.Loc
                FROM product p
                LEFT JOIN productinventory pi ON p.ProductID = pi.ProductID
    ";
            // 你需要一個能執行 SQL 的方法，例如 GetDataBySql(sql)
            dt = await GetDataBySql(sql);
            return dt;
        }
        public async Task<DataTable> GetMaterialData()
        {
            DataTable dt = null;
            string sql = @"
                SELECT m.*, mi.Qty, mi.WarehouseID, mi.Loc
                FROM material m
                LEFT JOIN materialinventory mi ON m.MaterialID = mi.MaterialID
    ";
            try
            {
                dt = await GetDataBySql(sql); // specify table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task AdjustInventory(string productId, string warehouseId, int delta)
        {
            string sqlUpdate = $"UPDATE productinventory SET Qty = Qty + ({delta}) WHERE ProductID = '{productId}' AND WarehouseID = '{warehouseId}'";
            string actionType = delta > 0 ? "IN" : "OUT";
            string sqlLog = $@"
        INSERT INTO inventory_log (ProductID, WarehouseID, Qty, ActionType, ActionTime)
        VALUES ('{productId}', '{warehouseId}', {Math.Abs(delta)}, '{actionType}', NOW())
    ";
            BatchUpdate(sqlUpdate);
            BatchUpdate(sqlLog);
            
        }

        public async Task<DataTable> GetInventoryLog(DateTime? start = null, DateTime? end = null)
        {
            string sql = "SELECT * FROM inventory_log";
            if (start.HasValue && end.HasValue)
            {
                sql += $" WHERE ActionTime BETWEEN '{start:yyyy-MM-dd HH:mm:ss}' AND '{end:yyyy-MM-dd HH:mm:ss}'";
            }
            sql += " ORDER BY ActionTime DESC";
            return await GetDataBySql(sql);
        }

        public async Task AdjustMaterialQty(string materialId, int delta)
        {
            string sql = $"UPDATE material SET Qty = Qty + ({delta}) WHERE MaterialID = '{materialId}'";
            BatchUpdate(sql);
        }
        public async Task<DataTable> QueryTableBySql(string sql)
        {
            return await GetDataBySql(sql);
        }
        public async Task AdjustMaterialInventory(string materialId, string warehouseId, int delta)
        {
            string sqlUpdate = $"UPDATE materialinventory SET Qty = Qty + ({delta}) WHERE MaterialID = '{materialId}' AND WarehouseID = '{warehouseId}'";
            // 可選：新增 material_inventory_log 表記錄異動
                BatchUpdate(sqlUpdate);
            // 可加上 log
            string actionType = delta > 0 ? "IN" : "OUT";
            string sqlLog = $@"
        INSERT INTO inventory_log (MaterialID, WarehouseID, Qty, ActionType, ActionTime)
        VALUES ('{materialId}', '{warehouseId}', {Math.Abs(delta)}, '{actionType}', NOW())
    ";
            BatchUpdate(sqlLog);
        }
    }
}
