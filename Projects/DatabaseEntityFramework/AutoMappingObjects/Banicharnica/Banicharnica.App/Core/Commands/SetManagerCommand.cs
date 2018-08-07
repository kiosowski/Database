using Banicharnica.App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banicharnica.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly IManagerController managerController;
        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }
        public string Execute(string[] args)
        {
            var employeeId = int.Parse(args[0]);
            var managerId = int.Parse(args[1]);

            this.managerController.SetManager(employeeId, managerId);
            return "Command accomplished successfully!";
        }
    }
}
