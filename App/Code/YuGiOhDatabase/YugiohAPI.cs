using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace YuGiOhDatabase
{
    // IMPORTANT INFORMATION: 
    // 1) The app will not work if the API is not up.
    // 2) The app will not work if your IP is blacklisted from the API (Making too many or too large GET calls consistently). 
    // 3) The app can operate without connection to the API if there is a version and database available locally.
    public class YugiohAPI
    {
        // GET API callers
        private static string _databaseURL = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        private static string _versionURL = "https://db.ygoprodeck.com/api/v7/checkDBVer.php";

        // GET whole database from API, convert JSON to Card Model object.
        private static async Task<CardCollection> GetDatabase()
        {
            Trace.WriteLine("Downloading Database...");

            using (HttpResponseMessage response = await APICaller.APIClient.GetAsync(_databaseURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var cards = await response.Content.ReadAsAsync<CardCollection>();

                    Trace.WriteLine("Cards obtained successfully.");

                    return cards;
                }
                else
                {
                    Trace.WriteLine("Was unable to aquire database.");

                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        // GET current version from API, convert JSON to Version Model object.
        private static async Task<VersionModel> GetVersion()
        {
            Trace.WriteLine("Retrieving up-to-date database version...");

            using (HttpResponseMessage response = await APICaller.APIClient.GetAsync(_versionURL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var version = JsonConvert.DeserializeObject<List<VersionModel>>(content);

                    Trace.WriteLine("Database version obtained successfully.");

                    return version[0];
                }
                else
                {
                    Trace.WriteLine("Was unable to aquire database version.");

                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        // Checks local files for version and database. If does not exist, corrupted files, or a new version is available, get database and version from API.
        public static async Task<CardCollection> InitializeDatabase()
        {
            APICaller.InitializeClient();

            // Get current version
            VersionModel currentVersion = FileController.ReadVersion();
            VersionModel newestVersion = await GetVersion();
            CardCollection cards;

            //If no current version get newest version and database
            if (currentVersion == null)
            {
                cards = await GetDatabase();

                FileController.WriteDatabase(cards);

                FileController.WriteVersion(newestVersion);
            }
            else
            {
                //If current version is uptodate, get database
                if (currentVersion.database_version == newestVersion.database_version)
                {
                    cards = FileController.ReadDatabase();

                    //If no database pull newest database
                    if (cards == null)
                    {
                        cards = await GetDatabase();

                        FileController.WriteDatabase(cards);
                    }

                }
                //If unable to connect to API, do nothing
                else if(newestVersion == null)
                {
                    cards = null;
                }    
                //If current version is old, get newest version and database
                else
                {
                    FileController.WriteVersion(newestVersion);

                    cards = await GetDatabase();

                    FileController.WriteDatabase(cards);
                }
            }

            return cards;
        }
    }
}
