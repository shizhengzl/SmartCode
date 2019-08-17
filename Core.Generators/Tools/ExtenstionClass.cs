using Core.Tools.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public class ExtenstionClass
    {
        public static List<T> GetList<T>(DefaultDB sqlite)
        {
            var tables = FindTable<T>(sqlite);
            IEnumerable<T> query;
            try
            {
                query = (IEnumerable<T>)
                sqlite.GetType().GetProperty(tables).GetValue(sqlite, null);
            }
            catch (Exception)
            {
                query = (IEnumerable<T>)
                 sqlite.GetType().GetProperty(typeof(T).Name).GetValue(sqlite, null);
            }
            return query.ToList<T>();

        }

        public static string FindTable<T>(DefaultDB sqlite)
        {
            var metadata = ((IObjectContextAdapter)sqlite).ObjectContext.MetadataWorkspace;

            var res = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>();
            var tables = metadata.GetItemCollection(DataSpace.SSpace).GetItems<EntityContainer>().Single().BaseEntitySets.OfType<EntitySet>()
                .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            return sqlite.GetType().GetProperties().Where(x => x.Name.Contains(typeof(T).Name)).FirstOrDefault().Name;
            //return tables.FirstOrDefault(x => x.Name.Contains == typeof(T).Name).Table;
        }
    }
}
