using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace _13.Serialization
{
    [Serializable]
    [XmlRoot(ElementName = "catalog", Namespace = "http://library.by/catalog")]
    public class Catalog
    {
        [XmlElement(ElementName = "book")]
        public List<Book> Books { get; set; }
        [XmlIgnore]
        public DateTime Date { get; set; }
        [XmlAttribute(AttributeName = "date")]
        public string DateString
        {
            get { return this.Date.ToString("yyyy-MM-dd"); }
            set { this.Date = DateTime.Parse(value); }
        }
    }
}