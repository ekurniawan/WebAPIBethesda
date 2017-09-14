Imports System.Net
Imports System.Web.Http

Namespace Controllers
    Public Class KategoriController
        Inherits ApiController

        ' GET: api/Kategori
        Public Function GetValues() As IEnumerable(Of Kategori)
            Dim kategoriDal As New KategoriDAL
            Return kategoriDal.GetAll()
        End Function

        ' GET: api/Kategori/5
        Public Function GetValue(ByVal id As Integer) As Kategori
            Dim kategoriDal As New KategoriDAL
            Return kategoriDal.GetById(id)
        End Function

        ' POST: api/Kategori
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/Kategori/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Kategori/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace