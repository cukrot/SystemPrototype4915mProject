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
    public class TestControll : SubSystemController
    {
        private String[] endpoints = { "GetCustomerData", "UpdateCustomerDataTest" };
        public TestControll() { setApi("/api/SnSToyCoTestAPI/"); }
        //recommend to see useable api in SubSystemController.cs

        //Useful tips       Useful tips     Useful tips
        //在不同表單中用於按鈕或載入（取得或修改資料）的每個方法中，
        //您只需指定endpoint，然後呼叫下面的通用方法 GetData() & UpdateData() 即可。
        //在Common methods下面，這裡有兩個針對 Form1.cs 的範例方法，你可以看到它們是如何運作的

        //通用方法在parent class SubSystemController.cs

        //Methods for Form1.cs
        public async Task<DataTable> GetCustomerData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetData(endpoints[0]); //specify endpoint
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<int> UpdateCustomerDataToAPI(DataTable dtUpdated)
        //This method just specify endpoint, then use the common method UpdateData() to update
        {
            int rowsUpdated = await UpdateData(dtUpdated, endpoints[1]); //specify endpoint
            return rowsUpdated;
        }
        public async Task<DataTable> GetUserData()
        {
            DataTable dt = null;
            try
            {
                dt = await GetTableData("user"); //specify table name
                //Or you can use GetData()
                //dt = await GetData("GetTableData", "customer"); //specify endpoint & table name
            }
            catch (Exception ex)
            {
                throw ex;
            } return dt;
        }
        public async Task<int> UpdateUserData(DataTable dtUpdated)
        { //specfy table name only like in TestControll2.cs
            int rowsUpdated = await UpdateData(dtUpdated, "user", new string[] { "UserID" });
            return rowsUpdated;
        }
    }
}
