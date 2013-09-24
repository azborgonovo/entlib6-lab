using EntLib6Lab.Application.Services;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EntLib6Lab.Web
{
    public class ConfigurationBootstrapper
    {
        public static void Configure(IUnityContainer container)
        {
            // Get Entlib config source (Current is in Web.EnterpriseLibrary.config)
            IConfigurationSource source = ConfigurationSourceFactory.Create();

            // Get factories from config
            var policyFactory = new ExceptionPolicyFactory(source);
            var validationFactory = ConfigurationValidatorFactory.FromConfigurationSource(source);

            // Set default locator
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            container
                // Add extensions
                // .AddNewExtension<Interception>()

                // Register Entlib types with appropiate factory  
                .RegisterType<ExceptionManager>(new InjectionFactory(c => policyFactory.CreateManager()))
                .RegisterInstance<ValidatorFactory>(validationFactory)
                
                // Use registration by convention extension for registering app types; IProductsService
                .RegisterTypes(AllClasses.FromAssemblies(typeof(IProductsService).Assembly),
                               WithMappings.FromAllInterfacesInSameAssembly,
                               WithName.Default,
                               WithLifetime.ContainerControlled);

                // Register types with interception 
                //.RegisterType<AExpense.Model.User>(new Interceptor<VirtualMethodInterceptor>(),
                //                                   new InterceptionBehavior<TracingBehavior>())
                //.RegisterType<IExpenseRepository, ExpenseRepository>(new Interceptor<VirtualMethodInterceptor>(),
                //                                                     new InterceptionBehavior<PolicyInjectionBehavior>());

        }
    }
}