﻿using RepoDb.Attributes;
using RepoDb.Interfaces;
using System.Data;
using System.Reflection;

namespace RepoDb.Resolvers
{
    /// <summary>
    /// A class that is used to resolve the equivalent <see cref="DbType"/> object of the property.
    /// </summary>
    public class TypeMapPropertyLevelResolver : IResolver<PropertyInfo, DbType?>
    {
        /// <summary>
        /// Creates a new instance of <see cref="TypeMapPropertyLevelResolver"/> object.
        /// </summary>
        public TypeMapPropertyLevelResolver() { }

        /// <summary>
        /// Resolves the equivalent <see cref="DbType"/> object of the property.
        /// </summary>
        /// <param name="propertyInfo">The instance of <see cref="PropertyInfo"/> to be resolved.</param>
        /// <returns>The equivalent <see cref="DbType"/> object of the property.</returns>
        public DbType? Resolve(PropertyInfo propertyInfo)
        {
            var dbType = (DbType?)null;

            // Attribute Level
            var attribute = propertyInfo.GetCustomAttribute<TypeMapAttribute>();
            if (attribute != null)
            {
                dbType = attribute.DbType;
            }

            // Property Level
            if (dbType == null)
            {
                dbType = TypeMapper.Get(propertyInfo.DeclaringType, propertyInfo);
            }

            // Type Level
            if (dbType == null)
            {
                dbType = TypeMapper.Get(propertyInfo.PropertyType);
            }

            // Return the value
            return dbType;
        }
    }
}
