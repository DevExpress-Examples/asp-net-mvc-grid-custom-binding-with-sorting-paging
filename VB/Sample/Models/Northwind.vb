Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Web

Namespace Sample.Models
	Public NotInheritable Class NorthwindDataProvider
		Private Const NorthwindDataContextKey As String = "DXNorthwindDataContext"

		Private Sub New()
		End Sub
		Public Shared ReadOnly Property DB() As NorthwindDataContext
			Get
				If HttpContext.Current.Items(NorthwindDataContextKey) Is Nothing Then
					HttpContext.Current.Items(NorthwindDataContextKey) = New NorthwindDataContext()
				End If
				Return CType(HttpContext.Current.Items(NorthwindDataContextKey), NorthwindDataContext)
			End Get
		End Property

		Public Shared Function GetCustomers() As IQueryable(Of Customer)
			Return DB.Customers
		End Function
	End Class
End Namespace