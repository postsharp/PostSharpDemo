using Microsoft.Win32;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Reflection;

namespace CustomAspectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Count);
            Count = Count + 1;
            Console.WriteLine(Count);
        }

        [PersistInRegistry]
        public static int Count;


    }

    [PSerializable]
    [LinesOfCodeAvoided(5)]
    class PersistInRegistryAttribute : LocationInterceptionAspect
    {
        bool isFetched;
        string keyName;
        string valueName;

        public override void CompileTimeInitialize(LocationInfo targetLocation, AspectInfo aspectInfo)
        {
            this.keyName = "HKEY_CURRENT_USER\\Software\\CustomAspectDemo\\" + targetLocation.DeclaringType.FullName.Replace('.', '\\');
            this.valueName = targetLocation.Name;
        }


        public override void OnGetValue(LocationInterceptionArgs args)
        {
            if (this.isFetched)
            {
                args.ProceedGetValue();
                return;
            }
            else
            {
                this.isFetched = true;

                Console.WriteLine("Reading from registry");
                string stringValue = Registry.GetValue(this.keyName, this.valueName, null) as string;
                if (stringValue != null )
                {
                    object value = Convert.ChangeType(stringValue, args.Location.LocationType);
                    args.SetNewValue(value);
                    args.Value = value;
                }
                else
                {
                    args.ProceedGetValue();
                }
            }
        }

        public override void OnSetValue(LocationInterceptionArgs args)
        {
            args.ProceedSetValue();
            Console.WriteLine("Writing to registry");
            Registry.SetValue(this.keyName, this.valueName, Convert.ToString(args.Value));
            this.isFetched = true;

        }

    }
}
