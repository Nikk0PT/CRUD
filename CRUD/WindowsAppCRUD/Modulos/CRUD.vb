Imports System.Data.SqlClient

Module CRUD

    Public Function StrLigacao() As SqlConnection

        Return New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBusers.mdf;Integrated Security=True")

    End Function

    Public strConexao As SqlConnection = StrLigacao()

    Public resultado As String
    Public cmd As New SqlCommand
    Public da As New SqlDataAdapter
    Public dt As New DataTable

    Public Sub Create(ByVal Comando As String)
        Try
            strConexao.Open()

            With cmd
                .Connection = strConexao
                .CommandText = Comando

                resultado = cmd.ExecuteNonQuery

                If resultado = 0 Then
                    MessageBox.Show("Falhou a operação de inserir os dados.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Os dados foram submetidos com sucesso.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("ERRO" & vbNewLine & ex.Message,
                        "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        strConexao.Close()
    End Sub

    Public Sub Reload(ByVal Comando As String, Grelha As Object)
        Try
            dt = New DataTable
            strConexao.Open()
            With cmd
                .Connection = strConexao
                .CommandText = Comando
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            Grelha.DataSource = dt
        Catch ex As Exception

            MessageBox.Show("ERRO" & vbNewLine & ex.Message, "Erro!",
MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        strConexao.Close()

        da.Dispose()
End Sub

    Public Sub Updates(ByVal Comando As String)
        Try
            strConexao.Open()
            With cmd
                .Connection = strConexao
                .CommandText = Comando
                resultado = cmd.ExecuteNonQuery
                'verificar se a instrução foi corretamente executada
                If resultado = 8 Then
                    MessageBox.Show("Falhou a operação de atualizar os dados.",
            "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Os dados foram atualizados com sucesso.",
            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MsgBox(Comando)
            MessageBox.Show("Erro" & vbNewLine & ex.Message,
            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        strConexao.Close()
    End Sub

    Public Sub Delete(ByVal Comando As String)
        Try
            strConexao.Open()
            With cmd
                .Connection = strConexao
                .CommandText = Comando

                resultado = cmd.ExecuteNonQuery

                If resultado = 6 Then
                    MessageBox.Show("Falhou a operação de eliminar os dados.”,
                    “Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Os dados foram eliminados com sucesso.”,
                    “Aviso”, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception

            MessageBox.Show("ERRO" & vbNewLine & ex.Message, "Erro!",
MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        strConexao.Close()
    End Sub
End Module

