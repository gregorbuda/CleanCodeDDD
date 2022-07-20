using System;
using System.Collections.Generic;
using System.Text;

namespace xss.ComplianceManagementBackEnd.Interface
{
    internal interface ICRUData<T>
    {
        List<T> ItemList();
        List<T> ItemFullDataList();

        Boolean CreateItem(T item);

        Boolean UpdateItem(T item);

        Boolean DeleteItem(T item);

        T GetById(Int32 id);
        T GetFullDataById(Int32 id);

        Int32 CreateAndReturnId(T item);

        Boolean SaveBatch(IEnumerable<T> itemList);
        Boolean UpdateBatch(IEnumerable<T> itemList);
    }
}
