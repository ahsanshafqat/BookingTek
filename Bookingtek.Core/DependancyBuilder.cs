
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookingtek.Core.Command;
using Bookingtek.Core.Model;
using Ninject.Modules;

namespace Bookingtek.Core
{
    public class DependancyBuilder : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommand>().To<CanvasCommand>().Named("c");
            Bind<ICommand>().To<LineCommand>().Named("l");
            Bind<ICommand>().To<QuitCommand>().Named("q");
            Bind<ICommand>().To<RectangleCommand>().Named("r");
        }
    }
   
}
