using Autofac;
using Autofac.Core;
using TodoListMVC.Models;

namespace TodoListMVC
{
   // The class inherits from Module and overrides the load method.
   // The Load metjod takes an instance of ContainerBuilder.
   public class DataModule : Module
    {
        private string _connStr;
        public DataModule(string connStr)
        {
            _connStr = connStr;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new PGDbContext(_connStr)).InstancePerRequest();

            base.Load(builder);
        }
    }
}