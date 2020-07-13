using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holywood.Resources
{
    public class AutoMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Soure</typeparam>
        /// <typeparam name="V">Destination</typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static V MapItem<T, V>(T item)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, V>());
            
            var iMappper = config.CreateMapper();

            return iMappper.Map<T, V>(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Source</typeparam>
        /// <typeparam name="V">Destination</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<V> MapItems<T, V>(List<T> list)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<T, V>());
            var iMappper = config.CreateMapper();

            return iMappper.Map<List<T>, List<V>>(list);
        }
    }
}
