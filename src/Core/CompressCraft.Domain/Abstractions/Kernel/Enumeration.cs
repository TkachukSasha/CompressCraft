using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CompressCraft.Domain.Abstractions.Kernel;

public abstract class Enumeration<TEnum> : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<string, TEnum> Enumerations = CreateEnumerations();

    protected Enumeration(string value, string name)
    {
        Value = value;
        Name = name;
    }

    [Column("value")]
    public string Value { get; protected init; }

    [Column("name")]
    public string Name { get; protected init; }

    #region methods
    public static TEnum? FromValue(string value)
        => Enumerations.TryGetValue(
            value,
            out TEnum? enumeration) ? enumeration
                                    : default;

    public static TEnum? FromName(string name)
        => Enumerations.Values.SingleOrDefault(x => x.Name == name);

    public static IEnumerable<TEnum> GetValues()
        => Enumerations.Values;
    #endregion

    #region overrides
    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null) return false;

        return GetType() == other.GetType() && Value == other.Value;
    }

    public override bool Equals(object? obj)
        => obj is Enumeration<TEnum> other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();
    #endregion

    private static Dictionary<string, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        return enumerationType.GetFields(
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy)
                .Where(fieldInfo =>
                    enumerationType.IsAssignableFrom(fieldInfo.FieldType))
                .Select(fieldInfo =>
                    (TEnum)fieldInfo.GetValue(default)!)
                .ToDictionary(x => x.Value);
    }
}
