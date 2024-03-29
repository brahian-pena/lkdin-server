﻿using LKDin.DTOs;
using LKDin.IBusinessLogic;

namespace LKDin.UI.ConsoleMenu.AvailableOptions
{
    public class ShowUserOption : UserProtectedConsoleMenuOption
    {
        private readonly IWorkProfileLogic _workProfileService;

        public ShowUserOption(string messageToPrint, IWorkProfileLogic workProfileService) : base(messageToPrint)
        {
            this._workProfileService = workProfileService;
        }

        protected override async Task PerformExecution()
        {
            var userId = this.RequestUserId();

            var workProfile = await this._workProfileService.GetWorkProfileByUserId(userId);

            var resultsToPrint = new List<WorkProfileDTO>
            {
                workProfile
            };

            this.PrintResultsInTable(resultsToPrint);

            this.PrintFinishedExecutionMessage(null);
        }

        private void PrintResultsInTable(List<WorkProfileDTO> results)
        {
            var columnNames = new[]
            {
                "ID Usuario",
                "Nombre",
                "Descripción",
                "Skills"
            };

            this.PrintDataInTable<WorkProfileDTO>(results, columnNames,
                wp => wp.User.Id,
                wp => wp.User.Name,
                wp => wp.Description,
                wp => String.Join<string>(',', wp.Skills.Select(s => s.Name).ToArray()));

        }
    }
}
