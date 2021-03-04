using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);     // generic Metodlar
        object Get(string key);             // generic olmayan versiyonu
        void add(string key, object value, int duration);  // her tipi kapysayacak sekilde yazilir, cach süresi de belirtilir

        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
