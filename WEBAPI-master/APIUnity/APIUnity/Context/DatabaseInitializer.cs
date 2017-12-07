using APIUnity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIUnity.Context
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //base.Seed(context);

            for (int i = 0; i < 2; i++)
            {
                Users user = new Users();
                user.Username = "unity" + i;
                user.Password = "123456";

                context.Users.Add(user);
            }
            context.SaveChanges();

            List<Users> allUser = context.Users.ToList();

            foreach (var user in allUser)
            {
                for (int i = 0; i < 5; i++)
                {
                    Scores score = new Scores();
                    score.Score = "100";
                    score.User = user;

                    context.Scores.Add(score);
                }
            }

            context.SaveChanges();

        }
    }
}