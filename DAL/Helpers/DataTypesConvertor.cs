using System;

namespace DAL.Helpers
{
    public class DataTypesConvertor
    {
        public static DateTime ConvertToDateTime(object datetimeval)
        {

            DateTime result = DateTime.MaxValue;

            if (datetimeval != null)
            {
                DateTime.TryParse(datetimeval.ToString(), out result);
            }

            return result;
        }

        public static Guid ConvertToGuid(string stringGuid)
        {
            Guid result = new Guid("00000000-0000-0000-0000-000000000000");
            if (stringGuid != null)
            {
                Guid.TryParse(stringGuid, out result);
            }

            return result;
        }
    }
}
