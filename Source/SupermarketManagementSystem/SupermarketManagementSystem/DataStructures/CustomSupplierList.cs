using SupermarketManagementSystem.Models;

namespace SupermarketManagementSystem.DataStructures
{
    public class CustomSupplierList
    {
        private Supplier[] suppliers;
        private int count;

        public CustomSupplierList()
        {
            suppliers = new Supplier[100];
            count = 0;
        }

        public void AddSupplier(Supplier supplier)
        {
            if (count < suppliers.Length)
            {
                suppliers[count] = supplier;
                count++;
            }
        }

        public Supplier SearchByName(string supplierName)
        {
            for (int i = 0; i < count; i++)
            {
                if (suppliers[i].SupplierName == supplierName)
                {
                    return suppliers[i];
                }
            }

            return null;
        }

        public Supplier SearchById(string supplierId)
        {
            for (int i = 0; i < count; i++)
            {
                if (suppliers[i].SupplierId.ToString() == supplierId)
                {
                    return suppliers[i];
                }
            }

            return null;
        }

        public int GetCount()
        {
            return count;
        }
    }
}