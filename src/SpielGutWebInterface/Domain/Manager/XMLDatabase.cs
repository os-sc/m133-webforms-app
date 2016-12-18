using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SpielGutWebInterface.Domain.Manager
{
    public class XmlDatabase<TManagable>
    {
        private readonly string _databasePath;

        public XmlDatabase(string dbpath)
        {
            _databasePath = dbpath;
        }

        public void SaveData(List<TManagable> data)
        {
            var sb = new StringBuilder();
            foreach (var entity in data)
            {
                sb.AppendLine(
                    SerializeEntity(entity)
                    );
            }

            // Overwrites file if it exists
            File.WriteAllText(_databasePath, sb.ToString());
        }

        public List<TManagable> LoadData()
        {
            if (!File.Exists(_databasePath)) return new List<TManagable>();
            var serializedEntities = File.ReadAllLines(_databasePath);
            return serializedEntities.Select(DeserializeEntity).ToList();
        }

        private static string SerializeEntity(TManagable e)
        {
            var serializer = new XmlSerializer(typeof(TManagable));
            string xmlString;
            using (var sw = new StringWriter())
            {
                using (var writer = new XmlTextWriter(sw))
                {
                    writer.Formatting = Formatting.None;
                    serializer.Serialize(sw, e);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }
            return xmlString.Replace(Environment.NewLine, "");
        }

        private static TManagable DeserializeEntity(string s)
        {
            var serializer = new XmlSerializer(typeof(TManagable));
            TManagable entity;
            using (var sw = new StringReader(s))
            {
                entity = (TManagable)serializer.Deserialize(sw);
            }
            return entity;
        }
    }
}