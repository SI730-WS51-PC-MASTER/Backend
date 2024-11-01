namespace Backend.TechnicalSupport.Domain.Services;

public interface IFavoriteTechnicianCommandService
{
    /// <summary>
    ///     Handle the CreateFavoriteTechnicianCommand
    /// </summary>
    /// <remarks>
    ///     This method will handle the CreateFavoriteTechnicianCommand and return the FavoriteTechnician
    ///     It checks if the FavoriteTechnician already exists in the database
    /// </remarks>
    /// <param name="command"> CreateFavoriteTechnicianCommand command </param>
    /// <returns></returns>
    Task<FavoriteTechnician?> Handle(CreateFavoriteTechnicianCommand command);
}