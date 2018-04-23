@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "GridView"
                                settings.CallbackRouteValues = New With { .Controller = "Home", .Action = "GridViewPartial" }
                                settings.Width = Unit.Percentage(100)

                                settings.KeyFieldName = "CustomerID"
                                settings.Columns.Add("ContactName")
                                settings.Columns.Add("CompanyName")
                                settings.Columns.Add("ContactTitle")
                                settings.Columns.Add("City")
                                settings.Columns.Add("Phone")

                                settings.CustomBindingRouteValuesCollection.Add(
                                    GridViewOperationType.Sorting,
                                    New With { .Controller = "Home", .Action = "GridViewSortingAction" }
                                )
                                settings.CustomBindingRouteValuesCollection.Add(
                                    GridViewOperationType.Paging,
                                    New With { .Controller = "Home", .Action = "GridViewPagingAction" }
                                )
                            End Sub).BindToCustomData(Model).GetHtml()