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
                component.Image,
                component.Ratings,
                new AttributesResource(component.Attributes.AttributeList),
                new CategoriesResource(component.Categories.CategoriesList),
                component.Country
            );
        }
}
