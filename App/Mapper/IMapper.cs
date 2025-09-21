namespace App.Mapper;

public interface IMapper<Entity, DTO>
{
    Entity ToEntity(DTO dto);
    DTO ToDTO(Entity entity);

    IEnumerable<DTO> ToDTOs(IEnumerable<Entity> entities)
    {
        return entities.Select(e => ToDTO(e));
    }
    
    IEnumerable<Entity> ToEntities(IEnumerable<DTO> entities)
    {
        return entities.Select(e => ToEntity(e));
    }
}
