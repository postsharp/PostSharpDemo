using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.FxCop.Sdk;

namespace FxCopExample.Rules
{
    public class Singleton : BaseRule
    {
        public Singleton() : base("Singleton")
        {
        }

        public override ProblemCollection Check(TypeNode type)
        {
          
            if (!type.HasCustomAttribute("FxCopExample.SingletonAttribute"))
                return this.Problems;

            // Validate constructors.
            foreach (Member constructor in type.GetConstructors())
            {
                if ((constructor.IsPublic || constructor.IsAssembly) && constructor.IsStatic )
                {
                    this.Problems.Add(
                        new Problem(
                            new Resolution(
                                string.Format(
                                    "Change the visibility of the instance constructor {0} to 'private' or 'protected'.",
                                    type)), constructor));
                }
            }

            // Validate GetInstance.
            Member getInstanceMethod = type.GetMethod(Identifier.For("GetInstance"));
            if (getInstanceMethod == null)
            {
                this.Problems.Add(
                      new Problem(
                          new Resolution(
                              string.Format(
                                  "Type {0} must contain a parameterless method named GetInstance.",
                                  type)), type));
            }
            else 
            {
                if (!getInstanceMethod.IsStatic)
                {
                    this.Problems.Add(
                      new Problem(
                          new Resolution(
                              string.Format(
                                  "Method GetInstance of type {0} must be static.", type)), type));
                }

                if (!getInstanceMethod.IsPublic && !getInstanceMethod.IsAssembly)
                {
                    this.Problems.Add(
                      new Problem(
                          new Resolution(
                              string.Format(
                                  "Method GetInstance of type {0} must be public or internal.", type)), type));
                }

                
            }

            // TODO: Check return type and field.


            return this.Problems;

        }
    }
}
