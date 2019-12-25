using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Core.Generators;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;
using Core.UsuallyCommon;

namespace VsCodeGenerator
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CodeGenerator
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;
        public const int CommandRightProject = 0x0200;
        public const int CommandRightNote = 0x0300;
        public const int RightMenuFloder = 0x0400;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("66d33b4a-42bc-4584-9c79-9b0a132d4df8");
        public static readonly Guid CommandSetNote = new Guid("66d33b4a-42bc-4584-9c79-9b0a132d4df7");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeGenerator"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private CodeGenerator(AsyncPackage package, OleMenuCommandService commandService)
        {
            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.Execute, menuCommandID);
            commandService.AddCommand(menuItem);

            var menuCommandRightProjectID = new CommandID(CommandSet, CommandRightProject);
            var menuItemRightProject = new MenuCommand(this.Execute, menuCommandRightProjectID);
            commandService.AddCommand(menuItemRightProject);

            var menuCommandRightNoteID = new CommandID(CommandSet, CommandRightNote);
            var menuItemRightNote = new MenuCommand(this.Execute, menuCommandRightNoteID);
            commandService.AddCommand(menuItemRightNote);

            var menuCommandRightFloderID = new CommandID(CommandSet, RightMenuFloder);
            var menuItemRightFloder = new MenuCommand(this.Execute, menuCommandRightFloderID);
            commandService.AddCommand(menuItemRightFloder);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CodeGenerator Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Switch to the main thread - the call to AddCommand in CodeGenerator's constructor requires
            // the UI thread.
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new CodeGenerator(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private  void Execute(object sender, EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            string message = string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.GetType().FullName); 
            DTE2 dte = (DTE2)this.ServiceProvider.GetServiceAsync(typeof(DTE)).Result;
            MenuStatus menuStatus = (sender as MenuCommand).CommandID.ID.ToString().ToEnum<MenuStatus>();
            GeneratorTools tools = new GeneratorTools(dte, menuStatus);
            tools.Show();

            //if (menuStatus == MenuStatus.Floder)
            //{
               
            //    SelectEntitys entitys = new SelectEntitys(dte);
            //    entitys.Show();
            //}

         

            //DTE2 dte2 = await package.GetServiceAsync(typeof(DTE)).ConfigureAwait(false) as DTE2;

            //DTE2 dte = (DTE2)this.ServiceProvider.GetServiceAsync(typeof(DTE)).Result;
            //DTE2 dte = (DTE2)this.package.GetServiceAsync(typeof(DTE));
            //GeneratorTools tools = new GeneratorTools(dte);
            //tools.Show();
            //// Show a message box to prove we were here
            //VsShellUtilities.ShowMessageBox(
            //    this.package,
            //    message,
            //    title,
            //    OLEMSGICON.OLEMSGICON_INFO,
            //    OLEMSGBUTTON.OLEMSGBUTTON_OK,
            //    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

      
    }
}
