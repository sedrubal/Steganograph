using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Steganograph.PlugIns
{
    public class PlugInConnector
    {

        public static List<CryptImgPlugIn> LoadImgPlugIns(string strDir)
        {
            List<CryptImgPlugIn> vPlugIn = new List<CryptImgPlugIn>();

            foreach (string f in Directory.GetFiles(strDir))
            {
                if (f.EndsWith(".dll"))
                {
                    System.Reflection.Assembly a = System.Reflection.Assembly.LoadFile(f);
                    Type[] types = null;
                    types = a.GetTypes();

                    foreach (Type pType in types)
                    {
                        //hier wird versucht die dll zu laden.
                        //dies funktioniert nur, wenn die dll auch das selbe interface implementiert
                        //wie der host vorgiebt

                        try
                        {
                            if (pType.ContainsGenericParameters == false)
                            {
                                //if (pType.GetConstructors().Count > 0)
                                //{
                                    System.Object instance = a.CreateInstance(pType.FullName);
                                    if ((instance) is CryptImgPlugIn)
                                    {
                                        vPlugIn.Add((CryptImgPlugIn) instance);
                                    }
                                //}
                            }

                        }
                        catch (Exception)
                        {
                        }
                    }

                }
            }


            return vPlugIn;
        }

        public static bool TypeFilter(Type t, object filterCriteria)
        {
            // Return true if interface is defined in the same 
            // assembly identified by the filterCriteria object.
            return t.Assembly.GetName().ToString() == Convert.ToString(filterCriteria);
        }
    }

}