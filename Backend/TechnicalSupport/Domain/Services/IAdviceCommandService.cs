using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Services;

public interface IAdviceCommandService
{
    /// <summary>
    ///     Handle the CreateAdviceCommand
    /// </summary>
    /// <remarks>
    ///     This method will handle the CreateAdviceCommand and return the Advice
    ///     It checks if the Advice already exists in the database
    /// </remarks>
    /// <param name="command"> CreateAdviceCommand command </param>
    /// <returns></returns>
    Task<Advice?> Handle(CreateAdviceCommand command);
    
    Task<Advice> Handle(UpdateAdviceCommand command);
}