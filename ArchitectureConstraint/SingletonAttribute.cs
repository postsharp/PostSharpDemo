using System;
using System.Reflection;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace ArchitectureConstraint
{
    [MulticastAttributeUsage(MulticastTargets.Class)]
    class SingletonAttribute : ScalarConstraint
    {
        public override void ValidateCode(object target)
        {
            Type type = (Type) target;

            if (type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length != 0)
            {
                Message.Write(type, SeverityType.Error, "SI01",
                    "Type {0} should not have any public constructor because of [Singleton]", type.FullName);
            }

            MethodInfo getInstanceMethod = type.GetMethod("GetInstance");
            if (getInstanceMethod == null)
            {
                Message.Write(type, SeverityType.Error, "SI02",
                    "Type {0} should have a public method named GetInstance.", type.FullName);
            }
            else 
            {
                if (!getInstanceMethod.IsStatic)
                {
                    Message.Write(getInstanceMethod, SeverityType.Error, "SI03",
                        "Method {0}.GetInstance should be static.", type.FullName);
                }

                if (getInstanceMethod.GetParameters().Length != 0)
                {
                    Message.Write(getInstanceMethod, SeverityType.Error, "SI04",
                        "Method {0}.GetInstance should have no parameter.", type.FullName);
                }

                if (getInstanceMethod.ReturnType != type)
                {
                    Message.Write(getInstanceMethod, SeverityType.Error, "SI05",
                        "Return type of method {0}.GetInstance should be {1}.", type.FullName, type.Name);
                }
            }

            
            
            FieldInfo instanceField = type.GetField("instance", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            if (instanceField == null)
            {
                Message.Write(type, SeverityType.Error, "SI06",
                    "Type {0} should have a private field 'instance'.", type.FullName);
            }
            else
            {
                if (!instanceField.IsStatic)
                {
                    Message.Write(instanceField, SeverityType.Error, "SI07",
                        "Field {0}.instance should be static.", type.FullName);
                }

                if (!instanceField.IsPrivate)
                {
                    Message.Write(instanceField, SeverityType.Error, "SI08",
                        "Field {0}.instance should be private.", type.FullName);
                }

                if (!instanceField.IsInitOnly)
                {
                    Message.Write(instanceField, SeverityType.Error, "SI09",
                        "Field {0}.instance should be read-only.", type.FullName);
                }

                if (instanceField.FieldType != type)
                {
                    Message.Write(instanceField, SeverityType.Error, "SI10",
                        "Type of field {0}.instance should be {1}.", type.FullName, type.Name);
                    
                }
            }

            
        }
    }
}