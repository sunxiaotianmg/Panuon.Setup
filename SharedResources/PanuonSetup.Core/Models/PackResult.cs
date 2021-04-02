using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanuonSetup.Core
{
    public class PackResult
    {
        #region Ctor
        public PackResult(bool success)
        {

        }
        #endregion

        #region Properties
        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
        #endregion
    }
}
