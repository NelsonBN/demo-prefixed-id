namespace PrefixedId;

public readonly struct SubscriptionId
{
    private const string PREFIX = "sub_";
    private readonly string _id;

    private SubscriptionId(string id) => _id = id;

    public static SubscriptionId Create()
        => new($"{PREFIX}{Guid.NewGuid():N}");


    public static bool IsValid(ReadOnlySpan<char> id)
    {
        if(id.Length != 36)
        {
            return false;
        }

        if(!id.StartsWith(PREFIX))
        {
            return false;
        }

        return Guid.TryParseExact(id[4..], "N", out _);
    }

    public static bool TryParse(ReadOnlySpan<char> id, out SubscriptionId result)
    {
        if(IsValid(id))
        {
            result = new SubscriptionId(id.ToString());
            return true;
        }

        result = default;
        return false;
    }

    public static SubscriptionId Parse(ReadOnlySpan<char> id)
    {
        if(!TryParse(id, out var result))
        {
            throw new ArgumentException($"Invalid {nameof(SubscriptionId)}", nameof(SubscriptionId));
        }

        return result;
    }


    public static implicit operator string(SubscriptionId id) => id.ToString();
    public static implicit operator SubscriptionId(string id) => Parse(id);
    public static implicit operator SubscriptionId(ReadOnlySpan<char> id) => Parse(id);


    public override string ToString() => _id;
}
