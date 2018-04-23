<!DOCTYPE html>

<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets( 
        New StyleSheet With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout }, _
        New StyleSheet With { .ExtensionSuite = ExtensionSuite.Editors }, _
        New StyleSheet With { .ExtensionSuite = ExtensionSuite.GridView } _
    )
    <script src="@Url.Content("~/Scripts/jquery-1.6.2.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.min.js")" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")" type="text/javascript"></script>

    @Html.DevExpress().GetScripts( 
        New Script With { .ExtensionSuite = ExtensionSuite.NavigationAndLayout }, _ 
        New Script With { .ExtensionSuite = ExtensionSuite.HtmlEditor }, _ 
        New Script With { .ExtensionSuite = ExtensionSuite.GridView } _
    )
</head>
<body>
    @RenderBody()
</body>
</html>