using System.Text;

namespace TplCore.Element;

internal sealed class Tag : ICloneable
{
    private string Value;

    public override string ToString()
    {
        return Value;
    }

    public void ToString(ref StringBuilder builder)
    {
        builder?.Append(Value);
    }

    public static implicit operator Tag(string value)
    {
        var tag = new Tag
        {
            Value = value
        };
        return tag;
    }

    public static implicit operator string(Tag tag)
    {
        return tag.Value;
    }

    public object Clone()
    {
        var tag = new Tag
        {
            Value = Value
        };
        return tag;
    }
}