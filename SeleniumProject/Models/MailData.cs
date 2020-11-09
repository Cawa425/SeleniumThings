namespace SeleniumProject.Models
{
    public class MailData
    {
        public MailData(string adress, string text)
        {
            Text = text;
            Adress = adress;
        }

        public string Text { get; set; }

        public string Adress { get; set; }
    }
}