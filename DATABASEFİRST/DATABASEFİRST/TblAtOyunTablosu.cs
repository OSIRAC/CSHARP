using System;
using System.Collections.Generic;

namespace DATABASEFİRST;

public partial class TblAtOyunTablosu
{
    public int? KacinciOyunu { get; set; }

    public string? OyuncuAdi { get; set; }

    public int? Bahis { get; set; }

    public int? BitirmeSuresi { get; set; }

    public int? SecilenAt { get; set; }

    public bool? KazanmaDurumu { get; set; }

    public int? Bakiye { get; set; }
}
