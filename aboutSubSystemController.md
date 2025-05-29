# TestControll 和 TestControll2 使用指南

## 概述
本專案包含兩個控制器類別：`TestControll` 和 `TestControll2`，位於命名空間 `System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting` 中。這兩個控制器用於與後端 API 交互，處理資料的獲取和更新操作，適用於不同的表單（如 `Form1.cs` 和 `Form2.cs`）。

以下將介紹這兩個控制器的功能、用法，並推薦使用 `TestControll2` 的原因。

---

## TestControll

### 功能
- **資料獲取**：透過 `GetData` 方法從指定 API 端點獲取資料，返回 `DataTable`。
- **資料更新**：透過 `UpdateData` 方法將更新的 `DataTable` 序列化為 JSON 並發送至 API，執行新增、修改或刪除操作。
- **專用方法**：為 `Form1.cs` 提供了兩個範例方法：`GetCustomerData` 和 `UpdateCustomerDataToAPI`，展示如何使用通用方法。

### API 路徑
- 基礎 API 路徑：`/api/SimpleGetAPI/`（用於獲取資料）
- 公司 API 路徑：`/api/SnSToyCo_API/`（用於更新資料）
- 支援的端點：`GetCustomerData` 和 `UpdateCustomerDataTest`

### 使用方法
1. **獲取資料**：
   - 呼叫 `GetData` 方法並指定端點，例如：
     ```csharp
     DataTable dt = await testControll.GetData("GetCustomerData");
     ```
   - 範例方法 `GetCustomerData` 已封裝此邏輯，可直接使用：
     ```csharp
     DataTable dt = await testControll.GetCustomerData();
     ```

2. **更新資料**：
   - 準備一個包含新增、修改或刪除資料的 `DataTable`。
   - 呼叫 `UpdateData` 方法並指定端點，例如：
     ```csharp
     int rowsUpdated = await testControll.UpdateData(dtUpdated, "UpdateCustomerDataTest");
     ```
   - 範例方法 `UpdateCustomerDataToAPI` 已封裝此邏輯：
     ```csharp
     int rowsUpdated = await testControll.UpdateCustomerDataToAPI(dtUpdated);
     ```

### 注意事項
- 確保 `APICaller` 類別已正確實作並可用。
- 異常處理已在方法中實現，呼叫時需使用 `try-catch` 捕獲可能的錯誤。
- 僅支援預定義的端點，擴展性較低。

---

## TestControll2（推薦）

### 功能
- **資料獲取**：提供兩個 `GetData` 方法：
  - 基本版本：與 `TestControll` 類似，透過端點獲取資料。
  - 進階版本：允許指定表單名稱（`tableName`），提供更靈活的資料查詢。
- **資料更新**：透過 `UpdateData` 方法，支援指定表單名稱（`tableName`）和主鍵名稱（`keysName`），使更新操作更通用。
- **專用方法**：為 `Form2.cs` 提供了範例方法：`GetCustomerData` 和 `UpdateCustomerDataToAPI`，展示如何使用進階功能。

### API 路徑
- 測試 API 路徑：`/api/TestAPI/`（用於獲取和更新資料）
- 公司 API 路徑：`/api/SnSToyCoTest/`（備用）
- 支援的端點：`GetTableData`（用於獲取資料）、`UpdateData`（用於更新資料）

### 使用方法
1. **獲取資料**：
   - 使用基本 `GetData` 方法：
     ```csharp
     DataTable dt = await testControll2.GetData("GetTableData");
     ```
   - 使用進階 `GetData` 方法，指定表單名稱：
     ```csharp
     DataTable dt = await testControll2.GetData("GetTableData", "customers");
     ```
   - 範例方法 `GetCustomerData` 已封裝進階邏輯：
     ```csharp
     DataTable dt = await testControll2.GetCustomerData();
     ```

2. **更新資料**：
   - 準備一個包含新增、修改或刪除資料的 `DataTable`。
   - 呼叫 `UpdateData` 方法，指定表單名稱和主鍵名稱：
     ```csharp
     String[] keysName = { "customerNumber" };
     int rowsUpdated = await testControll2.UpdateData(dtUpdated, "customers", keysName);
     ```
   - 範例方法 `UpdateCustomerDataToAPI` 已封裝此邏輯：
     ```csharp
     int rowsUpdated = await testControll2.UpdateCustomerDataToAPI(dtUpdated);
     ```

### 為什麼推薦 TestControll2？
- **更高的靈活性**：支援指定表單名稱和主鍵名稱，適用於多種表單和資料結構。
- **更通用**：`GetData` 和 `UpdateData` 方法允許動態指定參數，減少硬編碼端點的需求。
- **更好的擴展性**：透過表單名稱和主鍵的配置，易於適應新的資料表或 API 端點。
- **一致的 API 路徑**：使用單一測試 API 路徑（`/api/TestAPI/`），簡化配置和管理。

---

## 擴展建議
若需擴展這兩個控制器，建議：
1. **使用 TestControll2 作為基礎**：
   - 複製 `TestControll2` 的結構，根據新表單的需求新增專用方法。
   - 利用 `GetData` 和 `UpdateData` 的進階版本，動態傳入表單名稱和主鍵名稱。
2. **新增端點**：
   - 在 `endpoints` 陣列中添加新的端點名稱。
   - 確保後端 API 支援新增的端點。
3. **異常處理**：
   - 根據專案需求，擴展異常處理邏輯，例如記錄錯誤日誌或顯示用戶友好的錯誤訊息。
4. **API 配置**：
   - 若需要切換不同的 API 環境（如測試或生產環境），可在控制器中新增配置參數。

---

## 注意事項
- 確保 `APICaller` 和 `JsonDataTable` 類別已正確實作並包含在專案中。
- 使用 `TestControll2` 時，需提供正確的表單名稱和主鍵名稱，否則可能導致 API 請求失敗。
- 測試所有 API 請求，確保後端端點與控制器的配置一致。

若有任何問題，請聯繫專案負責人或參考程式碼中的註解。
