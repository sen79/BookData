namespace BookData.Models
{
    public class clsCommon
    {
        static string _APIURL;

        public static string APIURL
        {
            get
            {
                return _APIURL;
            }
            set
            {
                _APIURL = value;
            }
        }
    }
}
