
using System.Collections.Generic;
using System.Xml.Serialization;
[XmlRoot("nominations")]
public class Nominations
    {
        [XmlElement("nomination")]
        public List<Nomination> winners;

        public Nominations(List<Nomination> winners)
        {
            this.winners = winners;
        }

        public Nominations()
        {
            winners = new List<Nomination>();
        }
    }
