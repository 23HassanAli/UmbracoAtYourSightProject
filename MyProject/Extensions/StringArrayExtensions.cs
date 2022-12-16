using Examine;
using Examine.Search;
using System.Collections.Generic;

namespace MyProject.Extensions
{
    public static class StringArrayExtensions
    {
        public static IExamineValue[] Fuzzy(this string[] terms)
        {
            if (terms == null) return null;
            List<IExamineValue> values = new List<IExamineValue>();
            foreach ( var term in terms ) { 
                values.Add(term.Fuzzy());   
            }
            return values.ToArray();    
            
        }
        public static IExamineValue[] Boost(this string[] terms, float boost)
        {
            if (terms == null) return null;
            List<IExamineValue> values = new List<IExamineValue>();
            foreach ( var term in terms )
            {
                values.Add(term.Boost(boost));
            }
            return values.ToArray();    
        }
    }
}
