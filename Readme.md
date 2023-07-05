<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128551586/19.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4394)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Grid View for ASP.NET MVC - How to implement a simple custom binding scenario
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/128551586/)**
<!-- run online end -->

This example demonstrates how to implement a simple custom binding scenario for the [GridView](https://docs.devexpress.com/AspNetMvc/8966/components/grid-view) extension and handle sorting and paging operations in the corresponding Action methods.

You can modify this approach to use it with any data source object that implements the `IQueryable` interface.


## Implementation details

Custom data binding requires that the [DevExpressEditorsBinder](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.DevExpressEditorsBinder) is used instead of the default model binder to correctly transfer values from DevExpress editors back to the corresponding data model fields. 
Assign `DevExpressEditorsBinder`  to the `ModelBinders.Binders.DefaultBinder` property in the **Global.asax** file to override the default model binder.

```csharp
ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
```

### Grid partial view

The [CustomBindingRouteValuesCollection](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewSettings.CustomBindingRouteValuesCollection) property allows you to assign particular handling Actions for four data operations - paging, sorting, grouping, and filtering. In this example, the property specifies custom routing for sorting and paging operations.

```razor
settings.CustomBindingRouteValuesCollection.Add(
    GridViewOperationType.Sorting,
    new { Controller = "Home", Action = "GridViewSortingAction" }
);
settings.CustomBindingRouteValuesCollection.Add(
    GridViewOperationType.Paging,
    new { Controller = "Home", Action = "GridViewPagingAction" }
);
```

The [CallbackRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridSettingsBase.CallbackRouteValues) property specifies the action that handles all other (standard) grid callbacks.

```razor
settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartial" };
```

### Controller

Action methods update the [GridViewModel](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewModel) object with the information from the performed operation. The [ProcessCustomBinding](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewModel.ProcessCustomBinding.overloads) method delegates the binding implementation to specific model-layer methods pointed by the method's parameters.

```csharp
public ActionResult GridViewPartial() {
    var viewModel = GridViewExtension.GetViewModel("GridView");
    if (viewModel == null)
        viewModel = CreateGridViewModel();
        return GridCustomActionCore(viewModel);
}
public ActionResult GridViewSortingAction(GridViewColumnState column, bool reset) {
    var viewModel = GridViewExtension.GetViewModel("GridView");
    viewModel.SortBy(column, reset);
    return GridCustomActionCore(viewModel);
}
public ActionResult GridViewPagingAction(GridViewPagerState pager) {
    var viewModel = GridViewExtension.GetViewModel("GridView");
    viewModel.Pager.Assign(pager);
    return GridCustomActionCore(viewModel);
}
```

### Model

The specified delegates populate the Grid View model with data. To bind the Grid to your particular model object, modify the following code line:

```cs
static IQueryable Model { get { return NorthwindDataProvider.GetCustomers(); } }
```

The Grid View model object is passed from the Controller to the grid's Partial View as a Model. In the Partial View, the [BindToCustomData](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.GridViewExtension.BindToCustomData(DevExpress.Web.Mvc.GridViewModel)) method binds the grid to the Model.

## Files to Review

* [HomeController.cs](./CS/Sample/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Sample/Controllers/HomeController.vb))
* [Global.asax.cs](./CS/Sample/Global.asax.cs) (VB: [Global.asax.vb](./VB/Sample/Global.asax.vb))
* [CustomBindingModel.cs](./CS/Sample/Models/CustomBindingModel.cs) (VB: [CustomBindingModel.vb](./VB/Sample/Models/CustomBindingModel.vb))
* [Northwind.cs](./CS/Sample/Models/Northwind.cs) (VB: [Northwind.vb](./VB/Sample/Models/Northwind.vb))
* [GridViewPartial.cshtml](./CS/Sample/Views/Home/GridViewPartial.cshtml) (VB: [GridViewPartial.vbhtml](./VB/Sample/Views/Home/GridViewPartial.vbhtml))
* [Index.cshtml](./CS/Sample/Views/Home/Index.cshtml) (VB: [Index.vbhtml](./VB/Sample/Views/Home/Index.vbhtml))
* [_Layout.cshtml](./CS/Sample/Views/Shared/_Layout.cshtml) (VB: [_Layout.vbhtml](./VB/Sample/Views/Shared/_Layout.vbhtml))

## Documentation

* [Custom Data Binding](https://docs.devexpress.com/AspNetMvc/14321/components/grid-view/binding-to-data/custom-data-binding)

## More Examples

* [Grid View for ASP.NET MVC - How to implement a master-detail grid with a simple custom binding scenario](https://github.com/DevExpress-Examples/how-to-create-a-master-detail-gridview-with-paging-and-sorting-using-custom-data-binding-e4398)
