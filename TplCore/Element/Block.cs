using System.Reflection;
using System.Text;
using System.Collections;

namespace TplCore.Element;

public abstract class Block : BaseElement, ICloneable
{
    protected StringBuilder Value;
    protected bool IsAssigned;
    protected bool RenderChild = true;
    private const int __bz = 1000;
    private static Hashtable __hashTypes = new();

    public void SetValue(string value)
    {
        Value = new StringBuilder(value);
        IsAssigned = true;
        RenderChild = false;
    }

    public void Append(string value)
    {
        if (null == Value)
        {
            Value = new StringBuilder(__bz);
        }

        Value.Append(value);
        IsAssigned = true;
    }

    public void Append(Block b)
    {
        if (null == Value)
        {
            Value = new StringBuilder(__bz);
        }

        b.ToString(ref Value);
        IsAssigned = true;
    }

    public void Append(Template t)
    {
        if (null == Value)
        {
            Value = new StringBuilder(__bz);
        }

        t.ToString(ref Value);
        IsAssigned = true;
    }

    public override string ToString()
    {
        if (!Visible)
        {
            return null;
        }

        var bd = new StringBuilder();
        ToString(ref bd);
        return bd.ToString();
    }

    public abstract void ToString(ref StringBuilder bd);

    public void Clear()
    {
        Value = null;
        RenderChild = false;
    }

    public object Clone()
    {
        var type = GetType();

        // Create instance
        var b = type.GetConstructor(Type.EmptyTypes).Invoke(null);

        // Copy fields
        FieldInfo[] f;
        if (!__hashTypes.Contains(type.Name))
        {
            f = type.GetFields(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);
            __hashTypes.Add(type.Name, f);
        }
        else
        {
            f = (FieldInfo[])__hashTypes[type.Name];
        }

        foreach (var fi in f)
        {
            var obj = fi.GetValue(this);
            fi.SetValue(b, ((ICloneable)obj)?.Clone());
        }

        return b;
    }

    public static implicit operator string(Block b)
    {
        var bd = new StringBuilder(__bz);
        b.ToString(ref bd);
        return bd.ToString();
    }
}