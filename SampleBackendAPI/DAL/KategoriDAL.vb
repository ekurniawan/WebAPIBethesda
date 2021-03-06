﻿Imports System.Data.SqlClient
Imports System.Configuration

Public Class KategoriDAL
    Private conn As SqlConnection
    Private cmd As SqlCommand

    Private Function GetConnStr() As String
        Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    End Function

    Public Function GetAll() As List(Of Kategori)
        Using conn As New SqlConnection(GetConnStr())
            Dim lstKategori As New List(Of Kategori)

            Dim strSql = "select * from Kategori order by NamaKategori"
            cmd = New SqlCommand(strSql, conn)
            conn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    Dim kat As New Kategori With {
                        .KategoriId = CInt(dr("KategoriId")), .NamaKategori = dr("NamaKategori").ToString
                    }
                    lstKategori.Add(kat)
                End While
            End If
            dr.Close()
            cmd.Dispose()
            conn.Close()

            Return lstKategori
        End Using
    End Function

    Public Function GetById(id As Integer) As Kategori
        Using conn As New SqlConnection(GetConnStr())
            Dim kat As New Kategori

            Dim strSql = "select * from Kategori where KategoriId=@KategoriId"
            cmd = New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@KategoriId", id)
            conn.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    kat.KategoriId = CInt(dr("KategoriId"))
                    kat.NamaKategori = dr("NamaKategori").ToString
                End While
            End If
            dr.Close()
            cmd.Dispose()
            conn.Close()

            Return kat
        End Using
    End Function

    Public Function Create(_kategori As Kategori) As Integer
        Using conn As New SqlConnection(GetConnStr)
            Dim strSql = "insert into Kategori(NamaKategori) values(@NamaKategori)"
            cmd = New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@NamaKategori", _kategori.NamaKategori)

            Try
                conn.Open()
                Dim result = cmd.ExecuteNonQuery()
                Return result
            Catch sqlEx As SqlException
                Throw New Exception("Error " & sqlEx.Message)
            Catch ex As Exception
                Throw New Exception("Error " & ex.Message)
            Finally
                cmd.Dispose()
                conn.Close()
            End Try
        End Using
    End Function

    Public Function Update(_kategori As Kategori) As Integer
        Using conn As New SqlConnection(GetConnStr())
            Dim strSql = "update Kategori set NamaKategori=@NamaKategori where KategoriId=@KategoriId"
            cmd = New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@NamaKategori", _kategori.NamaKategori)
            cmd.Parameters.AddWithValue("@KategoriId", _kategori.KategoriId)
            Try
                conn.Open()
                Dim result = cmd.ExecuteNonQuery()
                Return result
            Catch ex As Exception
                Throw New Exception("Error : " & ex.Message)
            Finally
                cmd.Dispose()
                conn.Close()
            End Try
        End Using
    End Function

    Public Function Delete(id As Integer) As Integer
        Using conn As New SqlConnection(GetConnStr())
            Dim strSql = "delete from Kategori where KategoriId=@KategoriId"
            cmd = New SqlCommand(strSql, conn)
            cmd.Parameters.AddWithValue("@KategoriId", id)
            Try
                conn.Open()
                Dim result = cmd.ExecuteNonQuery()
                Return result
            Catch ex As Exception
                Throw New Exception("Error : " & ex.Message)
            Finally
                cmd.Dispose()
                conn.Close()
            End Try
        End Using
    End Function

End Class
