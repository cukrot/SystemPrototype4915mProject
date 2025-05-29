# SubSystemController 使用指南

## 概述
`SubSystemController` 是用於與 API 交互的核心類，負責處理數據表的獲取和更新操作。它位於 `System_prototype_for_S_S_toy_Co__4915m_Project_` 命名空間中，支援 JSON 序列化和異步 API 調用。

## 如何基於 TestControll 和 TestControll2 建立 Controller(your SubSytem) 和 UI
- **[基於 TestControll 的控制器與 UI 實現](基於 TestControll 的控制器與 UI 實現.md)**
- **[基於 TestControll2 的控制器與 UI 實現](基於 TestControll2 的控制器與 UI 實現.md)**

## 如何使用
1. **創建實例**：
   - 默認構造函數：`SubSystemController controller = new SubSystemController();`（使用預設 API 路徑 `/api/TestAPI/`）。
   - 自定義 API 路徑：`SubSystemController controller = new SubSystemController("/api/YourAPI/");`。
   - 動態設置 API 路徑：`controller.setApi("/api/YourAPI/");`。

2. **主要方法**：
   - **獲取數據**：
     - `GetTableData(string tableName)`：根據表名獲取數據表。
     - `GetData(string endpoint)`：通過指定端點獲取數據。
     - `GetData(string endpoint, string tableName)`：通過端點和表名獲取數據。
   - **更新數據**：
     - `UpdateData(DataTable dtUpdated, string tableName, string[] keysName)`：更新數據表，指定表名和主鍵。
     - `UpdateData(DataTable dtUpdated, string endpoint)`：通過指定端點更新數據表。

3. **注意事項**：
   - 所有方法都是異步的，使用 `await` 調用。
   - 確保傳入的 `DataTable` 已正確設置表名和主鍵。
   - 異常處理：方法會拋出異常，需在調用時使用 `try-catch`。

## 如何繼承
1. **創建子類**：
   - 繼承 `SubSystemController`：`public class YourController : SubSystemController`。
   - 在構造函數中設置 API 路徑：`setApi("/api/YourAPI/");`。

2. **擴展方法**：
   - 封裝特定業務邏輯，例如：
     ```csharp
     public async Task<DataTable> GetYourData()
     {
         return await GetTableData("yourTableName");
     }
     ```
   - 為更新操作指定表名和主鍵：
     ```csharp
     public async Task<int> UpdateYourData(DataTable dt)
     {
         string[] keys = { "yourKey" };
         return await UpdateData(dt, "yourTableName", keys);
     }
     ```

3. **範例**：
   - 參考 `TestControll` 和 `TestControll2` 的實現，位於 `JustTesting` 命名空間。
   - 它們展示了如何通過繼承封裝針對特定表（如 `customers`）的操作。

## 提示
- 檢查 `SubSystemController.cs` 中的 API 路徑（`simpleApi`, `testApi`, `companyApi`）以選擇正確的端點。
- 確保 API 服務正常運行，避免 `HttpRequestException`。
- 在 Windows Forms 中，結合 `DataGridView` 使用 `DataTable` 來顯示和編輯數據。