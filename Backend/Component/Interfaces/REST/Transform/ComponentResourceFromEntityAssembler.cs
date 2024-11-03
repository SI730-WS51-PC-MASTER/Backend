using Backend.Component.Domain.Model.ValueObjects;
using Backend.Component.Interfaces.REST.Resources;

namespace Backend.Component.Interfaces.REST.Transform;

public class ComponentResourceFromEntityAssembler
{
        public static ComponentResource ToResource(Domain.Model.Aggregates.Component component)
        {
            return new ComponentResource(
                component.ComponentId,
                component.Name,
                component.Description,
                component.Price,
                component.Stock,
                component.ProviderId,
                new Image(component.Image.Main, component.Image.Secondary),
                component.Ratings,
                new Categories(component.Categories.Type),
                new Attributes(component.Attributes.AttributeList),
                component.Country
            );
        }
}
