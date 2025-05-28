# S&S Toy Co. 4915m 專案 - 控制器說明

## 概述
本專案包含兩個控制器類別：`TestControll` 和 `TestControll2`，位於 `System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting` 命名空間中。這兩個控制器用於處理與 Web API 的資料交互，包括取得資料 (`Get`) 和更新資料 (`Update`)。以下介紹它們的功能、差異以及使用建議。

## 推薦
**強烈建議使用 `TestControll2`**，因為：
1. **更高的靈活性**：可以動態指定資料表名稱，無需為每個資料表建立專用端點。
2. **更強的控制力**：支援自訂鍵（如 `customerNumber`），確保資料更新的準確性。
3. **更好的可維護性**：通用方法設計更簡潔，減少重複程式碼，方便後續擴展。
4. **與現有系統相容**：與 `TestControll` 的功能相容，易於替換且不會影響既有表單（如 `Form1.cs`）。

若需在 `Form1.cs` 中使用 `TestControll2`，只需稍作調整即可。例如，將 `GetCustomerData` 的端點改為 `GetTableData` 並指定表名。


## TestControll
### 功能
- **GetData**: 從指定的 API 端點 (`/api/SimpleGetAPI/`) 取得資料，回傳 `DataTable`。
- **UpdateData**: 將更新後的 `DataTable` 透過 POST 請求發送到指定的 API 端點 (`/api/SnSToyCo_API/`)，回傳受影響的資料列數。
- **GetCustomerData**: 專為 `Form1.cs` 設計，呼叫 `GetData` 取得客戶資料。
- **UpdateCustomerDataToAPI**: 專為 `Form1.cs` 設計，呼叫 `UpdateData` 更新客戶資料。
- **convertDataTableToJasonString**: 將 `DataTable` 的新增、修改、刪除資料序列化為 JSON 格式。

### 使用方式
在表單中，只需指定端點名稱（如 `GetCustomerData` 或 `UpdateCustomerDataTest`），即可透過通用方法 `GetData` 或 `UpdateData` 與 API 交互。例如：
```csharp
var controller = new TestControll();
DataTable dt = await controller.GetCustomerData();
int rowsUpdated = await controller.UpdateCustomerDataToAPI(dtUpdated);
```

### 限制
- 僅支援固定端點，無法動態指定資料表名稱。
- 更新資料時不支援自訂 WHERE 子句的鍵，靈活性較低。

## TestControll2
### 功能
- **GetData (兩個重載)**:
  - 基本版本：與 `TestControll` 的 `GetData` 類似，從 `/api/TestAPI/` 取得資料。
  - 進階版本：支援指定資料表名稱（如 `customers`），允許更精確的資料查詢。
- **UpdateData**: 支援指定資料表名稱和 WHERE 子句的鍵（如 `customerNumber`），透過 `/api/TestAPI/UpdateData` 更新資料。
- **GetCustomerData**: 專為 `Form2.cs` 設計，呼叫進階的 `GetData` 取得指定資料表（如 `customers`）的資料。
- **UpdateCustomerDataToAPI**: 專為 `Form2.cs` 設計，呼叫 `UpdateData` 更新客戶資料，支援指定鍵。
- **convertDataTableToJasonString**: 除了序列化 `DataTable`，還包含資料表名稱和鍵名稱，支援更靈活的 API 請求。

### 使用方式
在表單中，指定資料表名稱和鍵名稱，然後呼叫通用方法。例如：
```csharp
var controller = new TestControll2();
DataTable dt = await controller.GetCustomerData(); // 取得 customers 表的資料
int rowsUpdated = await controller.UpdateCustomerDataToAPI(dtUpdated); // 更新 customers 表
```

### 優勢
- **靈活性**：支援動態指定資料表名稱，適用於多個資料表。
- **精確性**：支援自訂 WHERE 子句的鍵（如 `customerNumber`），確保更新操作更精準。
- **擴展性**：進階的 `GetData` 方法允許根據表名查詢資料，適合未來功能擴展。


## 注意事項
- 確保 API 伺服器正確配置（如 `/api/TestAPI/` 和 `/api/SnSToyCoTest/`），以避免連線問題。
- 在使用 `UpdateData` 時，確認 `keysName` 陣列包含正確的主鍵欄位，以避免更新錯誤。

## 聯絡
如有任何問題或需要進一步支援，請使用 discord 聯繫專案負責人或開發團隊。
