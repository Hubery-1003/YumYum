namespace YumYum.Models
{
    public class BreadcrumbItem
    {
        public string Text { get; set; }
        public string Url { get; set; }

        public BreadcrumbItem(string text, string url)
        {
            Text = text;
            Url = url;
        }
    }
}
