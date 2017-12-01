using APIUnity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIUnity.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var uye = new Uyeler
            {
                    kullaniciAdi = "Unity",
                    parola = "123456"
            };
            context.uyeler.Add(uye);
            context.SaveChanges();
        }
    }
}