using CustomerAccountServer.Data.Entities;

namespace CustomerAccountServer.Data.Helpers
{
    //let’s add an extension method for the IEntity type to validate against null value. 
    //Because the Owner and the Account inherit from the IEntity, we can extend any of those types and validate them
    public static class EntityExtension
    {
        public static bool IsObjectNull(this IEntity entity)
        {
            return entity == null;
        }

        public static bool IsObjectEmpty(this IEntity entity)
        {
            return entity.Id.Equals(default);
        }
    }
}
