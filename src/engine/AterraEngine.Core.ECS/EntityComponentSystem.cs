﻿// ---------------------------------------------------------------------------------------------------------------------
// Imports
// ---------------------------------------------------------------------------------------------------------------------
using AterraEngine.Contracts.ECS;
namespace AterraEngine.Core.ECS;

// ---------------------------------------------------------------------------------------------------------------------
// Code
// ---------------------------------------------------------------------------------------------------------------------
public abstract class EntityComponentSystem<T> : IEntityComponentSystem where T : IEntity {
    public T CastToEntity(IEntity entity) => (T)entity;
    public bool CheckEntity(object? entity) => entity is T;
    
    public abstract void Update(IEntity entity);
}