using TplCore.Compiler;

namespace TplBuilderForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuildTemplate(FilePathTextBox.Text, NameSpaceTextBox.Text);
        }

        void BuildTemplate(string filePath, string projectPath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            var fileName = Path.GetFileName(filePath);
            var dirPath = Path.GetDirectoryName(filePath);
            var relativePath = dirPath.Remove(0, projectPath.Length);
            var projectName = Path.GetFileName(projectPath);
            var namespaceName = string.IsNullOrEmpty(relativePath)
                ? projectName
                : projectName + "." + relativePath;

            // Render
            var templateName = Path.GetFileNameWithoutExtension(fileName);
            var g = new Generator(templateName, namespaceName);

            // Load data
            var data = File.ReadAllText(filePath);
            var content = g.RenderTemplate(data);

            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            var outputFile = Path.Combine(dirPath, fileName + Config.CsExt);
            File.WriteAllText(outputFile, content);
        }

    }
}
