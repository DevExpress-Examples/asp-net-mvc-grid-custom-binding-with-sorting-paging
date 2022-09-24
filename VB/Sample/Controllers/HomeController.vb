Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports Sample.Models

Namespace Sample.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function GridViewPartial() As ActionResult
            Dim viewModel = GridViewExtension.GetViewModel("gridView")
            If viewModel Is Nothing Then viewModel = CreateGridViewModel()
            Return GridCustomActionCore(viewModel)
        End Function

        Public Function GridViewSortingAction(ByVal column As GridViewColumnState, ByVal reset As Boolean) As ActionResult
            Dim viewModel = GridViewExtension.GetViewModel("gridView")
            viewModel.SortBy(column, reset)
            Return GridCustomActionCore(viewModel)
        End Function

        Public Function GridViewPagingAction(ByVal pager As GridViewPagerState) As ActionResult
            Dim viewModel = GridViewExtension.GetViewModel("gridView")
            viewModel.Pager.Assign(pager)
            Return GridCustomActionCore(viewModel)
        End Function

        Public Function GridCustomActionCore(ByVal gridViewModel As GridViewModel) As ActionResult
            gridViewModel.ProcessCustomBinding(New GridViewCustomBindingGetDataRowCountHandler(AddressOf GetDataRowCount), New GridViewCustomBindingGetDataHandler(AddressOf GetData))
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
End Namespace
