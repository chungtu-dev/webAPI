using System;

namespace BE_V2.Model
{
    public class HanghoaVM
    {
        public string TenHangHoa { get; set; }
        public string DonGia { get; set; }
    }

    public class Hanghoa : HanghoaVM
    {
        public Guid MaHangHoa { get; set; }
    }
}
