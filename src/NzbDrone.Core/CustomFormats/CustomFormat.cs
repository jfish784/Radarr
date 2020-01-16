﻿using System;
using System.Collections.Generic;
using System.Linq;
using NzbDrone.Core.Datastore;

namespace NzbDrone.Core.CustomFormats
{
    public class CustomFormat : ModelBase, IEquatable<CustomFormat>
    {
        public CustomFormat()
        {
        }

        public CustomFormat(string name, params string[] tags)
        {
            Name = name;
            FormatTags = tags.Select(t => new FormatTag(t)).ToList();
        }

        public static CustomFormat None => new CustomFormat("None");

        public string Name { get; set; }

        public List<FormatTag> FormatTags { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(CustomFormat other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return int.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((CustomFormat)obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
