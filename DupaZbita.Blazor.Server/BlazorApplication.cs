using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;

namespace DupaZbita.Blazor.Server;

public class DupaZbitaBlazorApplication : BlazorApplication
{
    public DupaZbitaBlazorApplication()
    {
        ApplicationName = "DupaZbita";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += DupaZbitaBlazorApplication_DatabaseVersionMismatch;
    }
    protected override void OnSetupStarted()
    {
        base.OnSetupStarted();

        if (System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema)
        {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }

    }
    private void DupaZbitaBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e)
    {

        e.Updater.Update();
        e.Handled = true;

    }
}
