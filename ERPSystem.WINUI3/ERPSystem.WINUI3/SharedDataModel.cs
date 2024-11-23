using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.WINUI3.Includes
{
    public class SharedDataModel
    {
        private static SharedDataModel? _instance;
        public static SharedDataModel Instance => _instance ??= new SharedDataModel();

        public string SharedPropertyString { get; set; }
        public bool SharedPropertyBool { get; set; }

        private SharedDataModel() { }
    }

}
