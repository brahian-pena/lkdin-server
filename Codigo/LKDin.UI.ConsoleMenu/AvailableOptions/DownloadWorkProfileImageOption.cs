﻿using LKDin.IBusinessLogic;

namespace LKDin.UI.ConsoleMenu.AvailableOptions
{
    public class DownloadWorkProfileImageOption : UserProtectedConsoleMenuOption
    {
        private readonly IWorkProfileLogic _workProfileService;

        public DownloadWorkProfileImageOption(string messageToPrint, IWorkProfileLogic workProfileService) : base(messageToPrint)
        {
            this._workProfileService = workProfileService;
        }

        protected override async Task PerformExecution()
        {
            var userId = this.RequestUserId();

            var path = await this._workProfileService.DownloadWorkProfileImage(userId);

            this.PrintFinishedExecutionMessage($"Se descargó la imagen correctamente en {path}");
        }
    }
}
