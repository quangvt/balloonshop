using BalloonShop.Domain.Abstract;
using BalloonShop.Domain.Concrete;
using BalloonShop.Domain.Entities;
using BalloonShop.Infrastructure.Abstract;
using BalloonShop.Infrastructure.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BalloonShop.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this._kernel = kernel;
            AddBinding();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBinding()
        {
            // put bindings here
            // 1. Temporary Mocking
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(
            //    new List<Product>
            //    {
            //        new Product {Name = "Football", Price = 25 },
            //        new Product {Name = "Surf board", Price = 179 },
            //        new Product {Name = "Running shoes", Price = 100 }
            //    });

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            // 2. Binding to EF

            //_kernel.Bind<IDepartmentRepository>().To<EFDepartmentRepository>();
            //_kernel.Bind<IProductRepository>().To<EFProductRepository>();
            _kernel.Bind<IRepository<Department>>().To<EFDepartmentRepository>();
            //_kernel.Bind<IRepository<Category>>().To<EFCategoryRepository>();
            _kernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
            _kernel.Bind<IRepository<Product>>().To<EFProductRepository>();

            //_kernel.Bind<IProductRepository>().To<EFProductSPRepository>();

            // 3. Binding OrderProcessing
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };
            _kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

            // 4. Binding Authentication
            _kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

        }
    }
}