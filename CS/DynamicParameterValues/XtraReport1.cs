#region #Reference
using DevExpress.Utils;
using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
// ...
#endregion #Reference

namespace DynamicParameterValues {
#region #Code
public partial class XtraReport1 : XtraReport {
    public XtraReport1() {
        InitializeComponent();

        // Create a parameter and define its main properties.
        Parameter parameter1 = new Parameter();
        parameter1.Type = typeof(System.Int32);
        parameter1.Name = "parameterProduct";
        parameter1.Visible = true;
        parameter1.Description = "Product Name: ";

        // Adjust the look-up settings to obtain 
        // the parameter values from the report's data source.
        DynamicListLookUpSettings lookUpSettings = new DynamicListLookUpSettings();

        lookUpSettings.DataSource = this.DataSource;
        lookUpSettings.DataAdapter = this.DataAdapter;
        lookUpSettings.DataMember = "Products";
        lookUpSettings.DisplayMember = "ProductName";
        lookUpSettings.ValueMember = "ProductID";

        parameter1.LookUpSettings = lookUpSettings;

        // Add the parameter to the report's collection,
        // and filter the report based on the parameter's value.
        this.Parameters.Add(parameter1);
        this.FilterString = "[ProductID] = ?parameterProduct";

        // Display the current parameter value in the report.
        XRLabel label = new XRLabel();
        this.Detail.Controls.Add(label);
        label.DataBindings.Add(new XRBinding(parameter1, "Text", ""));
        label.LocationFloat = new PointFloat(377.0833F, 10.00001F);

        // Pass a value to the parameter and publish the report.
        parameter1.Value = 1;
        this.RequestParameters = false;
    }
}
#endregion #Code
}
