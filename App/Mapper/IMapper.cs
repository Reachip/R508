namespace App.Mapper;

public interface IMapper<Entity, DTO>
{
    Entity? FromDTO(DTO dto);
    DTO? FromEntity(Entity entity);

    IEnumerable<DTO?> ToDTOs(IEnumerable<Entity> entities)
    {
        return entities.Select(e => FromEntity(e));
    }
    
    IEnumerable<Entity?> ToEntities(IEnumerable<DTO> entities)
    {
        return entities.Select(e => FromDTO(e));
    }
}
