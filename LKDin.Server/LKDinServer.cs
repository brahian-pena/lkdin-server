﻿using LKDin.Helpers.Configuration;
using LKDin.IUI;
using LKDin.Server.BusinessLogic;
using LKDin.UI.ConsoleMenu;
using LKDin.UI.ConsoleMenu.AvailableOptions;

namespace LKDin.Server;

public class LKDinServer
{
    private static string UI_THREAD_NAME = "LKDIN_SERVER_UI";

    private static void InitServerUI()
    {
        var userService = new UserService();

        var workProfileService = new WorkProfileService(userService);

        var chatMessageService = new ChatMessageService(userService);

        var enabledOptions = new List<IMenuOption>()
        {
            new CreateUserOption("Crear Usuario", userService),
            new CreateWorkProfileOption("Crear Perfil de Trabajo", workProfileService),
            new AssignImageToWorkProfile("Asignar Imagen a Perfil de Trabajo", workProfileService),
            new SendChatMessageOption("Enviar Mensaje", chatMessageService),
            new CheckChatMessagesOption("Revisar Mensajes", chatMessageService),
            new SearchWorkProfilesBySkillsOption("Buscar Perfiles por Habilidades", workProfileService),
            new SearchWorkProfilesByDescriptionOption("Buscar Perfiles por Descripción", workProfileService),
            new ShowUserOption("Buscar Perfil por ID", workProfileService),
            new ExitOption("Salir")
        };

        IUIService uiService = new ConsoleMenuService(enabledOptions);

        uiService.Render();
    }

    private static void InitBackgroundService()
    {
        var port = LKDinConfigManager.GetConfig("PORT");

        var ip = LKDinConfigManager.GetConfig("IP_ADDRESS");

        Console.WriteLine(ip);

        Console.WriteLine(port);
    }

    public static void Main()
    {
        Thread serverUIThread = new(InitServerUI);

        serverUIThread.Name = UI_THREAD_NAME;

        serverUIThread.Start();

        Thread backgroundService = new(InitBackgroundService);

        backgroundService.Start();
    }
}

