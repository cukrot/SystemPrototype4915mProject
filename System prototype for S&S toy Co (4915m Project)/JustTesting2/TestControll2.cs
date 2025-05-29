using EntityModels;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_prototype_for_S_S_toy_Co__4915m_Project_.JustTesting
{
    public class TestControll2 : SubSystemController
    {
        public TestControll2() { setApi("/api/TestAPI/"); }
        //recommend to see useable api in SubSystemController.cs

        //Useful tips       Useful tips     Useful tips
        //在不同表單中用於按鈕或載入（取得或修改資料）的每個方法中，
        //您只需指定table & keysName，然後呼叫下面的通用方法 GetData() & UpdateData() 即可。
        //這裡有兩個針對 Form2.cs 的範例方法，你可以看到它們是如何運作的

        //通用方法在parent class SubSystemController.cs

        //Methods for Form2.cs
        public async Task<DataTable> GetCustomerData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("customers"); //specify table name
                //Or you can use GetData()
                //dt = await GetData("GetTableData", "customers"); //specify endpoint & table name
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<int> UpdateCustomerDataToAPI(DataTable dtUpdated)
            //This method just specify table name ane keysName, then use the common method UpdateData() to update
        {
            String[] keysName = {"customerNumber" }; //specify keys
            int rowsUpdated = await UpdateData(dtUpdated, "customers", keysName); //table name ane keysName
            return rowsUpdated;
        }
    }
}
