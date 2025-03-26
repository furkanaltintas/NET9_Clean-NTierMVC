namespace Core.Helpers;

public static class Properties
{
    /// <summary>
    /// Herhangi bir özelliğin değeri null ise 'isProperty değişkeni' true olur.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entity"></param>
    public static Boolean GetPropertiesIsNull<TEntity>(TEntity entity)
        where TEntity : class, new()
    {
        Boolean isProperty = entity.GetType().GetProperties().Where(p => p.GetValue(entity) == null).Any();
        return isProperty;
    }
}
