# 基於 TestControll 的控制器與 UI 實現

## 概述
`TestControll` 是繼承自 `SubSystemController` 的控制器，位於 `System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting` 命名空間。它通過指定 API 端點來獲取和更新數據表，適用於簡單的端點驅動場景。UI 實現參考 `Form1.cs`。

## 建立控制器
1. **創建控制器類**：
   - 繼承 `SubSystemController`：
     ```csharp
     public class YourControll : SubSystemController
     {
         private string[] endpoints = { "YourGetEndpoint", "YourUpdateEndpoint" };
         public YourControll() { setApi("/api/YourAPI/"); }
     }
     ```
   - 定義端點數組（如 `endpoints`），用於指定 API 路徑的具體操作。

2. **實現數據操作方法**：
   - **獲取數據**：
     ```csharp
     public async Task<DataTable> GetYourData()
     {
         return await GetData(endpoints[0]); // 使用端點
     }
     ```
   - **更新數據**：
     ```csharp
     public async Task<int> UpdateYourData(DataTable dtUpdated)
     {
         return await UpdateData(dtUpdated, endpoints[1]); // 使用端點
     }
     ```

3. **注意事項**：
   - 確保端點名稱與後端 API 一致。
   - 方法使用 `SubSystemController` 的通用方法 `GetData` 和 `UpdateData`。

## 建立 UI
1. **創建 Windows Forms 表單**：
   - 在 Visual Studio 中添加新表單（如 `YourForm.cs`）。
   - 添加 `DataGridView`（顯示數據表）、`Button`（觸發操作）和 `Label`（顯示信息）。

2. **實現表單邏輯**（參考 `Form1.cs`）：
   - **初始化**：
     ```csharp
     private YourControll controll;
     public YourForm()
     {
         InitializeComponent();
         controll = new YourControll();
     }
     ```
   - **載入數據**（表單載入或按鈕點擊）：
     ```csharp
     private async void Form_Load(object sender, EventArgs e)
     {
         try
         {
             DataTable dt = await controll.GetYourData();
             dataGridView1.DataSource = dt;
             dt.AcceptChanges();
         }
         catch (Exception ex)
         {
             MessageBox.Show($"錯誤：{ex.Message}");
         }
     }
     ```
   - **更新數據**（按鈕點擊）：
     ```csharp
     private async void buttonUpdate_Click(object sender, EventArgs e)
     {
         DataTable dtUpdated = (DataTable)dataGridView1.DataSource;
         dtUpdated = dtUpdated.GetChanges();
         if (dtUpdated != null)
         {
             int rowsUpdated = await controll.UpdateYourData(dtUpdated);
             if (rowsUpdated > 0)
             {
                 dtUpdated.AcceptChanges();
                 dataGridView1.DataSource = dtUpdated.Copy();
                 MessageBox.Show($"{rowsUpdated} 行更新成功。");
             }
         }
     }
     ```

3. **UI 提示**：
   - 使用 `DataGridView` 綁定 `DataTable` 以顯示和編輯數據。
   - 確保在更新後調用 `AcceptChanges` 以同步數據狀態。

## 適用場景
- 適合後端 API 已定義明確端點（如 `GetCustomerData`、`UpdateCustomerDataTest`）的情況。
- 控制器邏輯簡單，僅需指定端點即可。