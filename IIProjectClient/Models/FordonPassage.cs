using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IIProjectClient.Models
{
    public class FordonPassage
    {
        string fordonEpc { get; set; }
        string platsEpc { get; set; }
        DateTime tid { get; set; }
        string plats { get; set; }
        long evn { get; set; }
        string fordonsinnehavaren { get; set; }
        string undershallsansvarigtForetag { get; set; }
        string fordonsTyp { get; set; }
        bool giltigtGodkannande { get; set; }
        DateTime godkannandeStarttid { get; set; }
        DateTime godkannandeSluttid { get; set; }
    }
}