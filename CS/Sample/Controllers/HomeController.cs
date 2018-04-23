using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Sample.Models;

namespace Sample.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();	
        }
        public ActionResult GridViewPartial() {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if(viewModel == null)
                viewModel = CreateGridViewModel();
            return GridCustomActionCore(viewModel);
        }

        public ActionResult GridViewSortingAction(GridViewColumnState column, bool reset) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.SortBy(column, reset);
            return GridCustomActionCore(viewModel);
        }
        public ActionResult GridViewPagingAction(GridViewPagerState pager) {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.Pager.Assign(pager);
            return GridCustomActionCore(viewModel);
        }

        public ActionResult GridCustomActionCore(GridViewModel gridViewModel) {
            gridViewModel.ProcessCustomBinding(
                CustomBindingHandlers.GetDataRowCount,
                CustomBindingHandlers.GetData
            );
            return PartialView("GridViewPartial", gridViewModel);
        }

        static GridViewModel CreateGridViewModel() {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "CustomerID";
            viewModel.Columns.Add("ContactName");
            viewModel.Columns.Add("CompanyName");
            viewModel.Columns.Add("ContactTitle");
            viewModel.Columns.Add("City");
            viewModel.Columns.Add("Phone");
            viewModel.Pager.PageSize = 20;
            return viewModel;
        }
	}
}