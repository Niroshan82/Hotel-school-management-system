using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace RMS2.Areas.Admin.Controllers
{
    public class EncryptionDetail
    {
        public object ObjectConversion(object getObject, object setObject)
        {

            // //object returnObject = "";

            //foreach (PropertyInfo getPropertyInfo in getObject.GetType().GetProperties())
            // {
            //         Type itemType = setObject.GetType();


            //         PropertyInfo setPropertyInfo = itemType.GetProperties().FirstOrDefault(m => m.Name.Equals(getPropertyInfo.Name));
            //         if (setPropertyInfo != null)
            //         {
            //             setPropertyInfo.SetValue(setObject, getPropertyInfo.GetValue(getObject, null), null);

            //         }

            // }

            //return setObject;

            try
            {



                //object returnObject = "";

                foreach (PropertyInfo getPropertyInfo in getObject.GetType().GetProperties())
                {
                    Type itemType = setObject.GetType();


                    PropertyInfo setPropertyInfo = itemType.GetProperties().FirstOrDefault(m => m.Name.Equals(getPropertyInfo.Name));
                    if (setPropertyInfo != null)
                    {
                        setPropertyInfo.SetValue(setObject, getPropertyInfo.GetValue(getObject, null), null);

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            return setObject;
        }


        public string GetEncryptedString(string password)
        {
            MD5 md5Hash = MD5.Create();
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(password.Trim());
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }

            return s.ToString(); ;
        }

    }
}