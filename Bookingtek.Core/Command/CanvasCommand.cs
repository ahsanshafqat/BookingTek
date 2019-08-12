using Bookingtek.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookingtek.Core.Command
{
    public class CanvasCommand : ICommand
    {
        private int _width;
        private int _height;

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 2)
                throw new ArgumentException("only accept 2 arguments: width & height");

            if ((!int.TryParse(cmd[0], out _width) || _width <= 0) ||
                (!int.TryParse(cmd[1], out _height) || _height <= 0))
                throw new ArgumentException("arguments should be a positive int");
        }

        public void ExecuteCommand()
        {
            Canvas.Instance.SetCanvas(_width, _height);
        }
    }
}
