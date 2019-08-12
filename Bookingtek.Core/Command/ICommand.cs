using Bookingtek.Core.Model;
using System.Collections.Generic;

namespace Bookingtek.Core.Command
{
    //public static class CommandType
    //{
    //    public static string C { get { return "C"; } }
    //    public static string L { get { return "L"; } }
    //    public static string R { get { return "R"; } }
    //    public static string Q { get { return "Q"; } }


    //}

    public interface ICommand
	{
		void CommandValidation(List<string> cmd);

		void ExecuteCommand();
	}
}
