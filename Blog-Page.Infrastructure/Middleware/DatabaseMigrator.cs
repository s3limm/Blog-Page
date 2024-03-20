using Blog_Page.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Infrastructure.Middleware
{
    public class DatabaseMigrator
    {
        public static void Migrate()
        {
            var context = ServiceMiddleware.GetService<BlogContext>();
            context.Database.Migrate();
        }
    }
}
