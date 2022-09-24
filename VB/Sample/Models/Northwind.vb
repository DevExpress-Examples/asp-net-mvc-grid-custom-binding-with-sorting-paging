Imports System.Linq
Imports System.Web

Namespace Sample.Models

    Public Module NorthwindDataProvider

        Const NorthwindDataContextKey As String = "DXNorthwindDataContext"

        Public ReadOnly Property DB As NorthwindDataContext
            Get
                If HttpContext.Current.Items(NorthwindDataContextKey) Is Nothing Then HttpContext.Current.Items(NorthwindDataContextKey) = New NorthwindDataContext()
                Return CType(HttpContext.Current.Items(NorthwindDataContextKey), NorthwindDataContext)
            End Get
        End Property

        Public Function GetCustomers() As IQueryable(Of Customer)
            Return DB.Customers
        End Function
    End Module
End Namespace
