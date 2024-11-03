using Backend.TechnicalSupport.Domain.Model.Command;

namespace Backend.TechnicalSupport.Domain.Services;

public interface ITechnicalSupportCommandService
{
    /// <summary>
    ///     Handle the CreateTechnicalSupportCommand
    /// </summary>
    /// <remarks>
    ///     This method will handle the CreateTechnicalSupportCommand and return the TechnicalSupport
    ///     It checks if the TechnicalSupport already exists in the database
    /// </remarks>
    /// <param name="command"> CreateTechnicalSupportCommand command </param>
    /// <returns></returns>
    Task<TechnicalSupport?> Handle(CreateTechnicalSupportCommand command);
    
    Task<TechnicalSupport> Handle(UpdateTechnicalSupportCommand command);
    
    Task<bool> Handle(DeleteTechnicalSupportCommand command);
}