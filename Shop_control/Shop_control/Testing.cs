namespace Shop_control
{
    public class Testing
    {
        bool TestForNullOrEmpty(string s)
        {
            bool result;
            result = s == null || s == string.Empty;
            return result;
        }
    }
}
