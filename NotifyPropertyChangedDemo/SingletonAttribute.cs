using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace NotifyPropertyChangedDemo
{
    [MulticastAttributeUsage(MulticastTargets.Class)]
    class SingletonAttribute : ScalarConstraint
    {
        public override void ValidateCode(object target)
        {
            Type type = (Type) target;

            if (type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length > 0)
            {
                Message.Write(type, SeverityType.Error, "MY01", "Type {0} should not have any public constructor because of [Singleton]", type.FullName);
            }

            MethodInfo getInstanceMethod = type.GetMethod("GetInstance");
            if (getInstanceMethod == null)
            {
                Message.Write(type, SeverityType.Error, "MY02",
                              "Type {0} should have a public method named GetInstance.", type.FullName);
            }
            else
            {
                if (!getInstanceMethod.IsStatic)
                {
                    Message.Write(type, SeverityType.Error, "MY02",
                                    "Method {0}.GetInstance should be static.", type.FullName);
                }
            }
            
            /*
            Assert.IsTrue(getInstanceMethod.IsStatic, string.Format("Method {0}.GetInstance should be static.", type.FullName));
            Assert.AreEqual(0, getInstanceMethod.GetParameters().Length, string.Format("Method {0}.GetInstance should have no parameter.", type.FullName));
            Assert.AreEqual(type, getInstanceMethod.ReturnType, string.Format("Return type of method {0}.GetInstance should be {0}.", type.FullName, type.Name));

            FieldInfo instanceField = type.GetField("instance", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            Assert.IsNotNull(instanceField, string.Format("Type {0} should have a private field 'instance'.", type.FullName));
            Assert.IsTrue(instanceField.IsPrivate, string.Format("Field {0}.instance should be static.", type.FullName));
            Assert.IsTrue(instanceField.IsStatic, string.Format("Field {0}.instance should be static.", type.FullName));
            Assert.IsTrue(instanceField.IsInitOnly, string.Format("Field {0}.instance should be read-only.", type.FullName));
            Assert.AreEqual(type, instanceField.FieldType, string.Format("Type of field {0}.instance should be {1}.", type.FullName, type.Name));
             */
        }
    }
}
