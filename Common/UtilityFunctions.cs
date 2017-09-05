using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UtilityFunctions
    {
        /// <summary>amaraafzal
        /// Local Setting
        /// </summary>
        public static string Connection_String = @"Data Source=LAP0068-PC;Initial Catalog=RRS_DB;Persist Security Info=True;User ID=sa;Password=ebryx1234";   
        public static readonly String Creation_Date_Format = "MM/dd/yyyy HH':'mm";

        /// <summary>
        /// Return List using LINQ
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static List<S> GetListFromDB<S>(SqlCommand cmd, Func<IDataRecord, S> selector)
        {
            var items = new List<S>();
            try
            {

                using (var r = cmd.ExecuteReader())
                {

                    while (r.Read())
                    {
                        items.Add(selector(r));
                    }
                    return items;
                }
            }
            catch (Exception e)
            {
                return items;
            }
        }

        #region Password Encryption
        //Decrypting the String
        public static String DecryptMethod(String SearchAlphabet)
        {
            string[] Alphabets = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] RandomAlphabets = new string[] { "z", "y", "d", "e", "c", "h", "g", "f", "j", "i", "n", "p", "m", "k", "o", "l", "q", "w", "s", "v", "u", "t", "r", "x", "b", "a", "Z", "Y", "W", "X", "V", "U", "T", "R", "S", "Q", "P", "N", "O", "M", "L", "K", "J", "I", "H", "F", "G", "D", "E", "C", "B", "A" };
            if (Alphabets.Contains(SearchAlphabet))
            {
                bool result = SearchAlphabet.Any(c => char.IsUpper(c));

                int index = Array.IndexOf<string>(Alphabets, SearchAlphabet);
                String NewValue = RandomAlphabets.GetValue(index).ToString();
                if (result)
                {
                    return NewValue.ToUpper();
                }
                return NewValue;
            }
            else
                return "-1";
        }


        public static String DecryptMethodNumber(int Num)
        {

            int[] Number = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] RandomNumber = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int index = Array.IndexOf<int>(Number, Num);
            String NewValue = RandomNumber.GetValue(index).ToString();

            return NewValue;
        }

        public static String DecryptPassword(String Password)
        {
            String DecryptPass = "";
            foreach (char element in Password)
            {
                int result;
                if (int.TryParse(element.ToString(), out result))
                {
                    DecryptPass = DecryptPass + DecryptMethodNumber(int.Parse(element.ToString()));
                }
                else
                {
                    String DecryptedValue = DecryptMethod(element.ToString());
                    if (DecryptedValue == "-1")
                        DecryptPass = DecryptPass + element.ToString();
                    else
                        DecryptPass = DecryptPass + DecryptedValue;
                }
            }

            return DecryptPass;
        }

        //Encrypting the string
        public static String EncryptPassword(String PasswordText)
        {
            String EncryptedPassword = string.Empty;
            foreach (char element in PasswordText)
            {
                int result;
                if (int.TryParse(element.ToString(), out result))
                {
                    EncryptedPassword = EncryptedPassword + EncryptMethodNumeric(int.Parse(element.ToString()));
                }
                else
                {

                    String DecryptedValue = EncryptMethod(element.ToString());
                    if (DecryptedValue == "-1")
                        EncryptedPassword = EncryptedPassword + element.ToString();
                    else
                        EncryptedPassword = EncryptedPassword + DecryptedValue;
                }
            }
            return EncryptedPassword;
        }
        public static String EncryptMethod(String SearchAlphabet)
        {
            // SearchAlphabet = SearchAlphabet.ToLower();

            string[] Alphabets = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] RandomAlphabets = new string[] { "z", "y", "d", "e", "c", "h", "g", "f", "j", "i", "n", "p", "m", "k", "o", "l", "q", "w", "s", "v", "u", "t", "r", "x", "b", "a", "Z", "Y", "W", "X", "V", "U", "T", "R", "S", "Q", "P", "N", "O", "M", "L", "K", "J", "I", "H", "F", "G", "D", "E", "C", "B", "A" };

            if (Alphabets.Contains(SearchAlphabet))
            {
                bool result = SearchAlphabet.Any(c => char.IsUpper(c));

                int index = Array.IndexOf<string>(Alphabets, SearchAlphabet);
                String NewValue = RandomAlphabets.GetValue(index).ToString();
                if (result)
                {
                    return NewValue.ToUpper();
                }
                return NewValue;
            }
            else
                return "-1";
        }

        public static String EncryptMethodNumeric(int SearchNum)
        {

            int[] Number = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] RandomNumber = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };


            int index = Array.IndexOf<int>(Number, SearchNum);
            String NewValue = RandomNumber.GetValue(index).ToString();

            return NewValue;
        }
        #endregion

        /// <summary>
        /// Formate Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FormateDate(string date)
        {
            ///date(MM/dd/yyyy)
            string[] arra = date.Split('/');
            date = arra[1] + "/" + arra[0] + "/" + arra[2];
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        #region Encode/decode base64 staring
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }


        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        #endregion
    }
}
