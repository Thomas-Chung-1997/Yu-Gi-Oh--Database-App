using System;
using System.Collections.Generic;
using System.Text;

namespace YuGiOhDatabase
{
    // Json structure of the version api caller.
    class VersionModel
    {
        public string database_version { get; set; }
        public string last_update { get; set; }
    }
}
