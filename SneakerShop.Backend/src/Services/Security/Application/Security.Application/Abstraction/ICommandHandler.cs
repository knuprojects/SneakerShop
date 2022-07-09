﻿using System.Threading.Tasks;

namespace Security.Application.Abstraction
{
    public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
