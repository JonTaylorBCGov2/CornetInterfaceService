using System.Collections.Generic;

namespace CASInterfaceService.Pages.Models
{
    public class CASSupplierQueryRegistration
    {
        List<CASSupplierQuery> casSupplierQueryList;
        static CASSupplierQueryRegistration casregd = null;

        private CASSupplierQueryRegistration()
        {
            casSupplierQueryList = new List<CASSupplierQuery>();
        }

        public static CASSupplierQueryRegistration getInstance()
        {
            if (casregd == null)
            {
                casregd = new CASSupplierQueryRegistration();
                return casregd;
            }
            else
            {
                return casregd;
            }
        }

        public List<CASSupplierQuery> getCASSupplierQuery()
        {
            return casSupplierQueryList;
        }
    }
}
