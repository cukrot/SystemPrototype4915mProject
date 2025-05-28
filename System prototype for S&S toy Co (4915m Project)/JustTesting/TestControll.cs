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
    public class TestControll
    {
        private String apiPoint = "/api/SimpleGetAPI/";
        private String companyApi = "/api/SnSToyCo_API/";
        private String[] endpoints = { "GetCustomerData", "UpdateCustomerDataTest" };

        //Useful tips       Useful tips     Useful tips
        //在不同表單中用於按鈕或載入（取得或修改資料）的每個方法中，
        //您只需指定endpoint，然後呼叫下面的通用方法即可。
        //在Common methods下面，這裡有兩個針對 Form1.cs 的範例方法，你可以看到它們是如何運作的
        //Below the common methods, here are two sample methods for Form1.cs , you can see how they work

        //Common methods
        public async Task<DataTable> GetData(String endpoint)
        {
            DataTable dt = null;
            try
            {
                APICaller apiCaller = new APICaller();
                String jsonString = await apiCaller.GetApiResponse(apiPoint + endpoint);
                dt = JsonConvert.DeserializeObject<DataTable>(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public async Task<int> UpdateData(DataTable dtUpdated, String endpoint)
        {
            APICaller apiCaller = new APICaller();
            try {
                // Serialize DataTable to JSON
                StringContent content = convertDataTableToJasonString(dtUpdated);

                // Send POST request to the Web API
                //specify endpoint
                int rowsUpdated = await apiCaller.PostAPIResponse((companyApi + endpoint), content);
                return rowsUpdated;
            }
            catch (HttpRequestException e)
            {
                // Log the exception message
                throw e;
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                throw ex;
            }
        }
        private StringContent convertDataTableToJasonString(DataTable dt)
        {
            // Serialize DataTable to JSON
            DataTable dtAdded = dt.GetChanges(DataRowState.Added);
            string jsonAdded = JsonConvert.SerializeObject(dtAdded, Formatting.Indented);
            DataTable dtModified = dt.GetChanges(DataRowState.Modified);
            string jsonModified = JsonConvert.SerializeObject(dtModified, Formatting.Indented);
            DataTable dtDeleted = dt.GetChanges(DataRowState.Deleted);
            string jsonDeleted = JsonConvert.SerializeObject(dtDeleted, Formatting.Indented);

            JsonDataTable jsonDT = new JsonDataTable();
            jsonDT.dtAdded = jsonAdded;
            jsonDT.dtModified = jsonModified;
            jsonDT.dtDeleted = jsonDeleted;
            string jsonString = JsonConvert.SerializeObject(jsonDT);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            return content;
        }

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
            int rowsUpdated = await UpdateData(dtUpdated, "UpdateCustomerDataTest"); //specify endpoint
            return rowsUpdated;
        }
    }
}
