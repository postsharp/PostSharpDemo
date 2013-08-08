using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArchitectureUnitTest
{
    public abstract class TypeLevelPatternTest<T>
    {
        readonly List<Assembly> assemblies = new List<Assembly>();

        protected TypeLevelPatternTest()
        {
            assemblies.Add(this.GetType().Assembly);
        }

        [TestMethod]
        public void Test()
        {
            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    TestType(type);

                }
            }
        }

        private void TestType(Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof (T), true);
            foreach (object attribute in attributes)
            {
                this.TestPattern(type, (T) attribute);
            }

            foreach (Type nestedType in type.GetNestedTypes(BindingFlags.Public|BindingFlags.NonPublic))
            {
                this.TestType(nestedType);
            }
        }

        protected abstract void TestPattern(Type type, T attribute);
    
    }
}