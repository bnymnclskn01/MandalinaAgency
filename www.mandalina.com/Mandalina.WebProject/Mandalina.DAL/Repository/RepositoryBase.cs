using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandalina.DAL.Repository
{
    public class RepositoryBase
    {
        private static object _lockSync = new object();
        protected RepositoryBase()
        {
            //Bu sınıfdan instance alınamayacak.

        }
        [ThreadStatic]
        private static DataBaseContext _db;

        public static DataBaseContext CreateContext() //static yapma sebebimiz newleyemediğimiz için.
        {
            if (_db == null)
            {
                lock (_lockSync) //Lock aynı threadın aynı anda çalıştırılamayacağını ifade eder.lock bizden nesne ister yukarıda tanımlayacağım 
                {
                    _db = new DataBaseContext();
                }

            }
            return _db;
        }
    }
}
