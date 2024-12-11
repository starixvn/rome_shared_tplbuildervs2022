using System.Text;

namespace TplCore.Element;

public abstract class Template : BaseElement
{
    protected StringBuilder Value;
    protected bool IsAssigned;
    protected bool RenderChild = true;

    private const int __tz = 1000; // Initialize StringBuilder length

    public void SetValue(string value)
    {
        Value = new StringBuilder(value);
        IsAssigned = true;
        RenderChild = false;
    }

    public void Clear()
    {
        Value = null;
        RenderChild = false;
    }

    public void Append(object obj)
    {
        if (null == obj)
        {
            return;
        }

        var text = obj.ToString();
        if (null == Value)
        {
            Value = new StringBuilder(text);
        }
        else
        {
            Value.Append(obj);
        }
    }

    public abstract void ToString(ref StringBuilder bd);

    public static implicit operator string(Template t)
    {
        if (!t.Visible)
        {
            return null;
        }

        var bd = new StringBuilder(__tz);
        t.ToString(ref bd);
        return bd.ToString();
    }

    protected List<string> RegisteredComponents = new(10);

    public override bool RegisterComponent(string name, IComponent component)
    {
        if (RegisteredComponents.Contains(name))
        {
            component.HideLinkedResources();
            return false;
        }

        RegisteredComponents.Add(name);
        return true;
    }

    public override bool RegisterComponent(IComponent component)
    {
        return RegisterComponent(component.GetType().Name, component);
    }
}