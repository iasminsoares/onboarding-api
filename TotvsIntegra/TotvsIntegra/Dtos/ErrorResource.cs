using IntegraApi.Application.Domain.Services.Comunication;

namespace IntegraApi.Application.Dtos
{
    public class ErrorResource
    {
        public List<ErrorMessage> _messages { get; private set; }

        public ErrorResource(List<ErrorMessage> messages)
        {
            _messages = messages ?? [];
        }

        public ErrorResource(ErrorMessage message)
        {
            _messages = [];

            this._messages.Add(message);

        }
    }
}
