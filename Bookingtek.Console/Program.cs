using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bookingtek.Core;
using Bookingtek.Core.Command;
using Bookingtek.Core.Model;
using Ninject;

namespace Bookingtek.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.LoadFrom("Bookingtek.Core.DLL"));

            while (true)
            {
                try
                {
                    var input = System.Console.ReadLine().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
                    if (input == null || !input.Any())
                        throw new ArgumentNullException("wrong command");

                    var command = kernel.Get<ICommand>(input[0].ToLower());
                    var param = input.Skip(1).ToList();
                    command.CommandValidation(param);
                    command.ExecuteCommand();
                    System.Console.WriteLine(Canvas.Instance.ToString());
                }
                catch (ArgumentNullException ex)
                {
                    System.Console.WriteLine(ex.ParamName);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
