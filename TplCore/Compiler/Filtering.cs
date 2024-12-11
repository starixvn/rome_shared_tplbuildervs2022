namespace TplCore.Compiler;

internal class Filtering
{
    #region Declaration

    private static string OpenBlockNamePrefix = "<!--";
    private static string BlockNameSuffix = "-->";
    private static string CloseBlockNamePrefix = "<!--/";
        
    #endregion


    public static void FilterTemplate(ref string text)
    {
        RemoveHiddenBlock(ref text);
    }


    #region Filter Hidden Block

    private static string HiddenBlock = "HiddenBlock";
    private static void RemoveHiddenBlock(ref string text)
    {
        var name = HiddenBlock;

        var i = text.IndexOf(OpenBlockNamePrefix + name + BlockNameSuffix, 0);
        if (-1 == i)
        {
            return;
        }

        var j = text.IndexOf(CloseBlockNamePrefix + name + BlockNameSuffix, i);
        if (-1 == j)
        {
            return;
        }


        text = text.Remove(i, j - i + (CloseBlockNamePrefix + name + BlockNameSuffix).Length);

        RemoveHiddenBlock(ref text);
    }

    #endregion
}