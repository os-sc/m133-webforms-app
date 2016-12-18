using System.Collections.Generic;

namespace SpielGutWebInterface.Domain.Interface
{
    public interface IDatabase
    {
        void SaveData(List<IManagable> data);

        List<IManagable> LoadData();
    }
}
