using Plugly.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly
{
    static class TypeHelper
    {
        static Dictionary<int, Type> delegateTypes = new Dictionary<int, Type>
        {
            { 100, typeof(Func<>) },     { 105, typeof(Func<,,,,,>) },     { 110, typeof(Func<,,,,,,,,,,>) },     { 115, typeof(Func<,,,,,,,,,,,,,,,>) }, 
            { 101, typeof(Func<,>) },    { 106, typeof(Func<,,,,,,>) },    { 111, typeof(Func<,,,,,,,,,,,>) },    { 116, typeof(Func<,,,,,,,,,,,,,,,,>) }, 
            { 102, typeof(Func<,,>) },   { 107, typeof(Func<,,,,,,,>) },   { 112, typeof(Func<,,,,,,,,,,,,>) },   
            { 103, typeof(Func<,,,>) },  { 108, typeof(Func<,,,,,,,,>) },  { 113, typeof(Func<,,,,,,,,,,,,,>) },  
            { 104, typeof(Func<,,,,>) }, { 109, typeof(Func<,,,,,,,,,>) }, { 114, typeof(Func<,,,,,,,,,,,,,,>) }, 

            { 200, typeof(Action<>) },     { 205, typeof(Action<,,,,,>) },     { 210, typeof(Action<,,,,,,,,,,>) },     { 215, typeof(Action<,,,,,,,,,,,,,,,>) }, 
            { 201, typeof(Action<,>) },    { 206, typeof(Action<,,,,,,>) },    { 211, typeof(Action<,,,,,,,,,,,>) },    
            { 202, typeof(Action<,,>) },   { 207, typeof(Action<,,,,,,,>) },   { 212, typeof(Action<,,,,,,,,,,,,>) },   
            { 203, typeof(Action<,,,>) },  { 208, typeof(Action<,,,,,,,,>) },  { 213, typeof(Action<,,,,,,,,,,,,,>) },  
            { 204, typeof(Action<,,,,>) }, { 209, typeof(Action<,,,,,,,,,>) }, { 214, typeof(Action<,,,,,,,,,,,,,,>) }, 

            { 300, null },                          { 305, typeof(FuncInterceptor<,,,,,>) },     { 310, typeof(FuncInterceptor<,,,,,,,,,,>) },     { 315, typeof(FuncInterceptor<,,,,,,,,,,,,,,,>) }, 
            { 301, typeof(FuncInterceptor<,>) },    { 306, typeof(FuncInterceptor<,,,,,,>) },    { 311, typeof(FuncInterceptor<,,,,,,,,,,,>) },    { 316, typeof(FuncInterceptor<,,,,,,,,,,,,,,,,>) }, 
            { 302, typeof(FuncInterceptor<,,>) },   { 307, typeof(FuncInterceptor<,,,,,,,>) },   { 312, typeof(FuncInterceptor<,,,,,,,,,,,,>) },   
            { 303, typeof(FuncInterceptor<,,,>) },  { 308, typeof(FuncInterceptor<,,,,,,,,>) },  { 313, typeof(FuncInterceptor<,,,,,,,,,,,,,>) },  
            { 304, typeof(FuncInterceptor<,,,,>) }, { 309, typeof(FuncInterceptor<,,,,,,,,,>) }, { 314, typeof(FuncInterceptor<,,,,,,,,,,,,,,>) }, 

            { 400, typeof(ActionInterceptor<>) },     { 405, typeof(ActionInterceptor<,,,,,>) },     { 410, typeof(ActionInterceptor<,,,,,,,,,,>) },     { 415, typeof(ActionInterceptor<,,,,,,,,,,,,,,,>) }, 
            { 401, typeof(ActionInterceptor<,>) },    { 406, typeof(ActionInterceptor<,,,,,,>) },    { 411, typeof(ActionInterceptor<,,,,,,,,,,,>) },    
            { 402, typeof(ActionInterceptor<,,>) },   { 407, typeof(ActionInterceptor<,,,,,,,>) },   { 412, typeof(ActionInterceptor<,,,,,,,,,,,,>) },   
            { 403, typeof(ActionInterceptor<,,,>) },  { 408, typeof(ActionInterceptor<,,,,,,,,>) },  { 413, typeof(ActionInterceptor<,,,,,,,,,,,,,>) },  
            { 404, typeof(ActionInterceptor<,,,,>) }, { 409, typeof(ActionInterceptor<,,,,,,,,,>) }, { 414, typeof(ActionInterceptor<,,,,,,,,,,,,,,>) }, 

        };

        public static Type GetFuncDelegateType(int typeParamsCount)
        {
            return delegateTypes[99 + typeParamsCount];
        }

        public static Type GetActionDelegateType(int typeParamsCount)
        {
            return delegateTypes[199 + typeParamsCount];
        }

        public static Type GetFuncInterceptorType(int typeParamsCount)
        {
            return delegateTypes[299 + typeParamsCount];
        }

        public static Type GetActionInterceptorType(int typeParamsCount)
        {
            return delegateTypes[399 + typeParamsCount];
        }
    }
}
