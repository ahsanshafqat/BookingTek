using Bookingtek.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookingtek.Core.Command
{
	public class QuitCommand : ICommand
	{
		public void CommandValidation(List<string> cmd)
		{
			if (cmd == null)
				throw new ArgumentNullException("missing command arguments");

			if (cmd.Any())
				throw new ArgumentException("should have no arguments");
		}

		public void ExecuteCommand()
		{
			Environment.Exit(Environment.ExitCode);

		}
	}
}
