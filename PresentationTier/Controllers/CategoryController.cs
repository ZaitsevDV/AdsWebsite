using Common.Models;
using LogicTier.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PresentationTier.Controllers
{
    public class CategoryController : Controller
    {
        public log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CategoryController));
        public IAdProvider _adProvider;
        public CategoryController(IAdProvider adProvider) { _adProvider = adProvider; }

        public ActionResult _Categories()
        {
            ViewBag.Tree = GetAllCategoriesForTree();
            return PartialView();
        }


        public string GetAllCategoriesForTree()
        {
            if (_adProvider.GetCategories != null)
            {
                List<Category> categories = _adProvider.GetCategories;

                List<TreeNode> headerTree = FillRecursive(categories);

                #region BindingHeaderMenus

                string rootLi = string.Empty;
                string down1Names = string.Empty;
                string down2Names = string.Empty;

                foreach (var item in headerTree)
                {
                    rootLi += "<li class=\"dropdown mega-menu-fullwidth\">"
                               + "<a href=\"/Product/ListProduct?cat=" + item.CategoryId + "\" class=\"dropdown-toggle\" data-hover=\"dropdown\" data-toggle=\"dropdown\">" + item.CategoryName + "</a>";

                    down1Names = "";
                    foreach (var down1 in item.Children)
                    {
                        down2Names = "";
                        foreach (var down2 in down1.Children)
                        {
                            down2Names += "<li><a href=\"/Product/ListProduct?cat=" + down2.CategoryId + "\">" + down2.CategoryName + "</a></li>";
                        }
                        down1Names += "<div class=\"col-sm-7\">"
                                        + "<h4><a href=\"/Product/ListProduct?cat=" + down1.CategoryId + "\">" + down1.CategoryName + "</a></h4>"
                                        + "<ul>"
                                        + down2Names
                                        + "</ul>"
                                    + "</div>";
                    }
                    rootLi += "<ul class=\"dropdown-menu\">"
                                + "<li>"
                                    + "<div class=\"container-fluid\">"
                                         + down1Names
                                    + "<div>"
                                + "</li>"
                            + "</ul>"
                         + "</li>";
                }
                #endregion

                return "<ul class=\"nav navbar-nav\">" + rootLi + "</ul>";
            }
            return "Record Not Found!!";
        }

        private static List<TreeNode> FillRecursive(List<Category> flatObjects, int parentId = 0)
            {
                return flatObjects.Where(x => x.ParentCategoryId.Equals(parentId)).Select(item => new TreeNode
                {
                    CategoryName = item.CategoryName,
                    CategoryId = item.CategoryId,
                    Children = FillRecursive(flatObjects, item.CategoryId)
                }).ToList();
            }
        }
    }

