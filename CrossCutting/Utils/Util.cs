using System;

namespace CrossCutting.Utils
{
    public static class Util
    {   
        public static String GetTimestamp(DateTime date)
        {
            return date.ToString("yyyyMMddHHmmssffff");
        }
    }
}
