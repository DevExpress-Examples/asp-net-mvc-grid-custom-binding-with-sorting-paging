Imports DevExpress.Web.Mvc
Imports Sample.Sample.Models

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Index() As ActionResult
        Return View()
    End Function
    Public Function GridViewPartial() As ActionResult
        Dim viewModel = GridViewExtension.GetViewModel("GridView")
        If viewModel Is Nothing Then
            viewModel = CreateGridViewModel()
        End If
        Return GridCustomActionCore(viewModel)
    End Function

    Public Function GridViewSortingAction(ByVal column As GridViewColumnState, ByVal reset As Boolean) As ActionResult
        Dim viewModel = GridViewExtension.GetViewModel("GridView")
        viewModel.SortBy(column, reset)
        Return GridCustomActionCore(viewModel)
    End Function
    Public Function GridViewPagingAction(ByVal pager As GridViewPagerState) As ActionResult
        Dim viewModel = GridViewExtension.GetViewModel("GridView")
        viewModel.Pager.Assign(pager)
        Return GridCustomActionCore(viewModel)
    End Function

    Public Function GridCustomActionCore(ByVal gridViewModel As GridViewModel) As ActionResult
        gridViewModel.ProcessCustomBinding(AddressOf CustomBindingHandlers.GetDataRowCount, AddressOf CustomBindingHandlers.GetData)
        Return PartialView("GridViewPartial", gridViewModel)
    End Function

    Private Shared Function CreateGridViewModel() As GridViewModel
        Dim viewModel = New GridViewModel()
        viewModel.KeyFieldName = "CustomerID"
        viewModel.Columns.Add("ContactName")
        viewModel.Columns.Add("CompanyName")
        viewModel.Columns.Add("ContactTitle")
        viewModel.Columns.Add("City")
        viewModel.Columns.Add("Phone")
        viewModel.Pager.PageSize = 20
        Return viewModel
    End Function
End Class