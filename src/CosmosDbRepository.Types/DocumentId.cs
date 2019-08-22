﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CosmosDbRepository.Types
{
    [JsonConverter(typeof(DocumentIdJsonConverter))]
    public struct DocumentId : IEquatable<DocumentId>
    {
        public string Id { get; }

        private DocumentId(string id)
        {
            Id = id;
        }

        public override string ToString() => Id;

        public static implicit operator DocumentId(string id) => new DocumentId(id);

        public static explicit operator string(DocumentId id) => id.Id;

        public static implicit operator DocumentId(Guid id) => new DocumentId(id.ToString());

        public static explicit operator Guid(DocumentId id) => Guid.Parse(id.Id);

        public static implicit operator DocumentId(int id) => new DocumentId(id.ToString());

        public static explicit operator int(DocumentId id) => int.Parse(id.Id);

        public static bool operator ==(DocumentId left, DocumentId right) => left.Equals(right);

        public static bool operator !=(DocumentId left, DocumentId right) => !(left == right);

        public bool Equals(DocumentId other) => Id == other.Id;

        public override bool Equals(object obj)
        {
            return obj is DocumentId id && Equals(id) ||
                    obj is string stringId && Equals(stringId) ||
                    obj is Guid guidId && Equals(guidId) ||
                    obj is int intId && Equals(intId);
        }

        public static bool IsNullOrEmpty(DocumentId id) => string.IsNullOrEmpty(id.Id);

        public override int GetHashCode()
        {
            return 2108858624 + EqualityComparer<string>.Default.GetHashCode(Id);
        }
    }
}