using System;

namespace CMS_API_BO
{
    public static class Extensions
    {
        public static string NulllToString(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToString(value);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static int NulllToInt(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToInt32(value);
                }
                else
                {
                    return default(int);
                }
            }
            catch (Exception)
            {
                return default(int);
            }
        }

        public static DateTime NulllToDateTime(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDateTime(value);
                }
                else
                {
                    return default(DateTime);
                }
            }
            catch (Exception)
            {
                return default(DateTime);
            }
        }

        public static Int64 NulllToLong(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToInt64(value);
                }
                else
                {
                    return default(Int64);
                }
            }
            catch (Exception)
            {
                return default(Int64);
            }
        }

        public static bool NulllToBoolean(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToBoolean(value);
                }
                else
                {
                    return default(bool);
                }
            }
            catch (Exception)
            {
                return default(bool);
            }
        }

        //Added on 2016-09-22
        public static Double NulllToDouble(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDouble(value);
                }
                else
                {
                    return default(Double);
                }
            }
            catch (Exception)
            {
                return default(Double);
            }
        }

        public static Decimal NulllToDecimal(this object value)
        {
            try
            {
                if (value != null && !string.IsNullOrWhiteSpace(Convert.ToString(value)))
                {
                    return Convert.ToDecimal(value);
                }
                else
                {
                    return default(Decimal);
                }
            }
            catch (Exception)
            {
                return default(Decimal);
            }
        }
    }
}
