namespace FonTech.Domain.Interfaces;

public interface IEntityId<T> where T : struct
{
    public T Id { get; set; }
}