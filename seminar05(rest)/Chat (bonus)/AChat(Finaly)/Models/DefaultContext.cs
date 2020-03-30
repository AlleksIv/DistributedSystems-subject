using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AChat_Finaly_.Models
{
    public class DefaultContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DefaultContext() : base("name=DefaultContext")
        {
        }

        public DbSet<StoryModel> StoryModels { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
