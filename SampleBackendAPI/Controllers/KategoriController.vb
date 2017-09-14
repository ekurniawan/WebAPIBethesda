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
        Public Function PostValue(_kategori As Kategori) As IHttpActionResult
            Dim kategoriDal As New KategoriDAL
            Try
                kategoriDal.Create(_kategori)
                Return Ok("Berhasil menambahkan data")
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ' PUT: api/Kategori/5
        Public Function PutValue(ByVal id As Integer, _kategori As Kategori) As IHttpActionResult
            Dim kategoriDal As New KategoriDAL
            Try
                kategoriDal.Update(_kategori)
                Return Ok("Berhasil update data")
            Catch ex As Exception
                Return BadRequest(ex.Message)
            End Try
        End Function

        ' DELETE: api/Kategori/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace