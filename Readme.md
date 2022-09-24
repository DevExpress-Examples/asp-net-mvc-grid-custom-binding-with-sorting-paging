<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551586/12.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4394)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [Global.asax.cs](./CS/Sample/Global.asax.cs)
* [CustomBindingModel.cs](./CS/Sample/Models/CustomBindingModel.cs) (VB: [CustomBindingModel.vb](./VB/Sample/Models/CustomBindingModel.vb))
* [Northwind.cs](./CS/Sample/Models/Northwind.cs) (VB: [Northwind.vb](./VB/Sample/Models/Northwind.vb))
* [GridViewPartial.cshtml](./CS/Sample/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Sample/Views/Home/Index.cshtml)
* [_Layout.cshtml](./CS/Sample/Views/Shared/_Layout.cshtml)
<!-- default file list end -->
# How to implement a simple custom binding scenario for GridView
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4394/)**
<!-- run online end -->


<p>This sample demonstrates how to implement a simple custom binding scenario for the GridView extension by handling only sorting and paging operations in the corresponding Action methods.</p>
<p>To learn more on the GridView's custom data binding feature, please refer to the <a href="https://docs.devexpress.com/AspNetMvc/14321/components/grid-view/concepts/binding-to-data/custom-data-binding?p=netframework"><u>Custom Data Binding</u></a> help topic.</p>
<br>
<p>Note that this sample provides a universal implementation approach - it can be easily adopted and used for every data source object that implements the <strong>IQueryable</strong> interface.</p>
<p> </p>
<p>In short, the logic of this custom binding implementation is as follows:</p>
<br>
<p>In the GridView's Partial View (Views > Home > GridViewPartial.cshtml), the grid's <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewSettings.CustomBindingRouteValuesCollection?p=netframework"><u>CustomBindingRouteValuesCollection</u></a> property is used to define handling actions for sorting and paging operations; the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GanttSettings.CallbackRouteValues?p=netframework"><u>CallbackRouteValues</u></a> property defines the action to handle all other (standard) grid callbacks.</p>
<br>
<p>In the Controller (Controller > HomeController.cs), the specified Action methods are implemented to update a specific grid view model object (<a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewModel?p=netframework"><u>GridViewModel</u></a> that maintains the grid state) with the information of the performed operation (if required). Then, the grid view model's <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewModel.ProcessCustomBinding.overloads?p=netframework"><u>ProcessCustomBinding</u></a> method is called to delegate a binding implementation to specific model-layer methods pointed by the method's certain parameters.</p>
<br>
<p>At the Model layer (Models > CustomBindingModel.cs), the two specified delegates are implemented to populate the grid view mode with the required data. Generally, in the provided implementation of model-level binding delegates, you just need to modify a single code line to point to your particular model object:</p>


```cs
        static IQueryable Model { get { return NorthwindDataProvider.GetCustomers(); } }


```


<p>Finally, the resulting grid view model object is passed from the Controller to the grid's Partial View as a Model. In the Partial View, the grid binds to the Model via the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewExtension.BindToCustomData(DevExpress.Web.Mvc.GridViewModel)?p=netframework"><u>BindToCustomData</u></a> method.</p>
<p>Note that when implementing the grid's custom data binding, the <a href="https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.DevExpressEditorsBinder?p=netframework"><u>DevExpressEditorsBinder</u></a> must be used instead of the default model binder to correctly transfer values from DevExpress editors back to the corresponding data model fields. In this code example, the DevExpressEditorsBinder is assigned to the ModelBinders.Binders.DefaultBinder property within the Global.asax file, thus overriding the default model binder.</p>
<p> </p>
<p><strong>See Also:<br> </strong><a href="https://supportcenter.devexpress.com/ticket/details/e4398/how-to-create-a-master-detail-gridview-with-paging-and-sorting-using-custom-data-binding">E4398: How to create a master-detail GridView with paging and sorting using Custom Data Binding</a></p>

<br/>


