# 基於 TestControll2 的控制器與 UI 實現

## 概述
`TestControll2` 是繼承自 `SubSystemController` 的控制器，位於 `System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting` 命名空間。它通過指定表名和主鍵來操作數據表，適用於靈活的表驅動場景。UI 實現參考 `Form2.cs`。 

## 建立控制器
1. **創建控制器類**：
   - 繼承 `SubSystemController`：
     ```csharp
     public class YourControll2 : SubSystemController
     {
         public YourControll2() { setApi("/api/YourAPI/"); }
     }
     ```
   - 無需定義端點數組，直接使用表名和主鍵。

2. **實現數據操作方法**：
   - **獲取數據**：
     ```csharp
     public async Task<DataTable> GetYourData()
     {
         return await GetTableData("yourTableName"); // 指定表名
     }
     ```
   - **更新數據**：
     ```csharp
     public async Task<int> UpdateYourData(DataTable dtUpdated)
     {
         string[] keysName = { "yourKey" }; // 指定主鍵
         return await UpdateData(dtUpdated, "yourTableName", keysName);
     }
     ```

3. **注意事項**：
   - 確保表名和主鍵與數據庫一致。
   - 方法使用 `SubSystemController` 的通用方法 `GetTableData` 和 `UpdateData`。

## 建立 UI
1. **創建 Windows Forms 表單**：
   - 在 Visual Studio 中添加新表單（如 `YourForm2.cs`）。
   - 添加 `DataGridView`（顯示數據表）、`Button`（觸發操作）和 `Label`（顯示信息）。

2. **實現表單邏輯**（參考 `Form2.cs`）：
   - **初始化**：
     ```csharp
     private YourControll2 controll;
     public YourForm2()
     {
         InitializeComponent();
         controll = new YourControll2();
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
- 適合需要靈活指定表名和主鍵的情況，無需依賴固定端點。
- 控制器邏輯更通用，適合多表操作。
