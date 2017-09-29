using DatabaseLayer.DbData;
using Ninject;
using Ninject.Modules;
using WebAPITestApp.DBRepository;

namespace WebAPITestApp
{
    public class CommonModule : NinjectModule
    {
        public override void Load()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IDBRepository<Order>>().To<SQLRepository<Order>>();
        }
    }
}
