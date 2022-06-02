﻿namespace Catalog.DTOs
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}
