Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Web.Mvc
Imports System.Runtime.CompilerServices

Namespace Sample.Models

    Public Module CustomBindingHandlers

        Private ReadOnly Property Model As IQueryable
            Get
                Return GetCustomers()
            End Get
        End Property

        Public Sub GetDataRowCount(ByVal e As GridViewCustomBindingGetDataRowCountArgs)
            e.DataRowCount = Model.Count()
        End Sub

        Public Sub GetData(ByVal e As GridViewCustomBindingGetDataArgs)
            e.Data = Model.ApplySorting(e.State.SortedColumns).Skip(e.StartDataRowIndex).Take(e.DataRowCount)
        End Sub
    End Module

    Public Module GridViewCustomOperationDataHelper

        Private ReadOnly Property Converter As ICriteriaToExpressionConverter
            Get
                Return New CriteriaToExpressionConverter()
            End Get
        End Property

        <Extension()>
        Public Function [Select](ByVal query As IQueryable, ByVal fieldName As String) As IQueryable
            Return query.MakeSelect(Converter, New OperandProperty(fieldName))
        End Function

        <Extension()>
        Public Function ApplySorting(ByVal query As IQueryable, ByVal sortedColumns As IEnumerable(Of GridViewColumnState)) As IQueryable
            For Each column As GridViewColumnState In sortedColumns
                query = query.ApplySorting(column.FieldName, column.SortOrder)
            Next

            Return query
        End Function

        <Extension()>
        Public Function ApplySorting(ByVal query As IQueryable, ByVal fieldName As String, ByVal order As ColumnSortOrder) As IQueryable
            Return query.MakeOrderBy(Converter, New ServerModeOrderDescriptor(New OperandProperty(fieldName), order = ColumnSortOrder.Descending))
        End Function

        <Extension()>
        Public Function ApplyFilter(ByVal query As IQueryable, ByVal filterExpression As String) As IQueryable
            Return query.AppendWhere(Converter, CriteriaOperator.Parse(filterExpression))
        End Function
    End Module
End Namespace
