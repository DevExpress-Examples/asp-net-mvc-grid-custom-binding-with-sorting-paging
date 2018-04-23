# How to implement a simple custom binding scenario for GridView


<p>This sample demonstrates how to implement a simple custom binding scenario for the GridView extension by handling only sorting and paging operations in the corresponding Action methods.</p>
<p>To learn more on the GridView's custom data binding feature, please refer to the <a href="http://documentation.devexpress.com/#AspNet/CustomDocument14374"><u>Custom Data Binding - Overview</u></a> help topic.</p>
<br>
<p>Note that this sample provides a universal implementation approach - it can be easily adopted and used for every data source object that implements the <strong>IQueryable</strong> interface.</p>
<p> </p>
<p>In short, the logic of this custom binding implementation is as follows:</p>
<br>
<p>In the GridView's Partial View (Views > Home > GridViewPartial.cshtml), the grid's <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_CustomBindingRouteValuesCollectiontopic"><u>CustomBindingRouteValuesCollection</u></a> property is used to define handling actions for sorting and paging operations; the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_CallbackRouteValuestopic"><u>CallbackRouteValues</u></a> property defines the action to handle all other (standard) grid callbacks.</p>
<br>
<p>In the Controller (Controller > HomeController.cs), the specified Action methods are implemented to update a specific grid view model object (<a href="http://documentation.devexpress.com/#AspNet/clsDevExpressWebMvcGridViewModeltopic"><u>GridViewModel</u></a> that maintains the grid state) with the information of the performed operation (if required). Then, the grid view model's <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewModel_ProcessCustomBindingtopic"><u>ProcessCustomBinding</u></a> method is called to delegate a binding implementation to specific model-layer methods pointed by the method's certain parameters.</p>
<br>
<p>At the Model layer (Models > CustomBindingModel.cs), the two specified delegates are implemented to populate the grid view mode with the required data. Generally, in the provided implementation of model-level binding delegates, you just need to modify a single code line to point to your particular model object:</p>


```cs
        static IQueryable Model { get { return NorthwindDataProvider.GetCustomers(); } }


```


<p>Finally, the resulting grid view model object is passed from the Controller to the grid's Partial View as a Model. In the Partial View, the grid binds to the Model via the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewExtension_BindToCustomDatatopic"><u>BindToCustomData</u></a> method.</p>
<p>Note that when implementing the grid's custom data binding, the <a href="http://help.devexpress.com/#AspNet/clsDevExpressWebMvcDevExpressEditorsBindertopic"><u>DevExpressEditorsBinder</u></a> must be used instead of the default model binder to correctly transfer values from DevExpress editors back to the corresponding data model fields. In this code example, the DevExpressEditorsBinder is assigned to the ModelBinders.Binders.DefaultBinder property within the Global.asax file, thus overriding the default model binder.</p>
<p> </p>
<p><strong>See Also:<br> </strong><a href="https://www.devexpress.com/Support/Center/p/E4398">E4398: How to create a master-detail GridView with paging and sorting using Custom Data Binding</a></p>

<br/>


