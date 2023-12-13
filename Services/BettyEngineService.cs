using Betty.Models.Results;
using Betty.Services.Contracts;
using Betty.Shared;

namespace Betty.Services
{
    public class BettyEngineService : IEngineService
    {
        private ICommandService _commandService;
        private IClient _client;
        private bool _exitGame;

        public BettyEngineService(
            ICommandService commandService, 
            IClient client)
        {
            this._commandService = commandService;
            this._client = client;
            this._exitGame = false;
        }

        public void RunEngine()
        {
            try
            {
                Log.WriteToLog("Betty engine started!");
                while (!this._exitGame)
                {
                    var input = this._client.GetUserInput();
                    var currentCommand = this._commandService.GetCommand(input);
                    var commandResult = currentCommand.Execute();
                    if (IsExitCommand(commandResult))
                        this._exitGame = true;

                    this._client.ReturnResult(commandResult);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog(ex);
            }
            finally
            {
                Log.WriteToLog("Betty engine exited!");
            }
        }

        private bool IsExitCommand(ICommandResult result) 
            => result.Success && result.IsExitCommand();
    }
}
