namespace YumYum.Models.DataTransferObject
{
    public class CherishFilter
    {
        public List<byte>? SortAttr { get; set; }
        public List<byte>? SortCont { get; set; }
        public List<byte>? SortDay { get; set; }
        public CherishMatchSearch? Search { get; set; }
    }
}
