Public Class Form1
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        Try

            Create("INSERT INTO Utilizadores1(nome, utilizador, senha, nivel) VALUES
                    ('" & txtNome.Text & "','" &
                    txtUtilizador.Text & "','" &
                    txtSenha.Text & "'," &
                    cbNivel.SelectedIndex + 1 & ")")

        Catch ex As Exception

            MessageBox.Show("ERRO" & ex.Message,
                            "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try

            Updates("UPDATE Utilizadores1 SET nome ='" & txtNome.Text & "'," &
                   "utilizador ='" & txtUtilizador.Text & "', " &
                   "senha='" & txtSenha.Text & "' " &
                   "nivel=" & cbNivel.SelectedIndex & " WHERE ID =" & CInt(Label1.Text))

        Catch ex As Exception

            MessageBox.Show("ERRO" & ex.Message,
                            "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try

            Delete("DELETE FROM Utilizadores1 WHERE ID= " & Label1.Text)
        Catch ex As Exception

            MessageBox.Show("ERRO" & ex.Message,
                            "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub


    Private Sub dgLista_DoubleClick(sender As Object, e As EventArgs) Handles dgLista.DoubleClick

        Label1.Text = dgLista.CurrentRow.Cells(0).Value
        txtNome.Text = dgLista.CurrentRow.Cells(1).Value
        txtUtilizador.Text = dgLista.CurrentRow.Cells(2).Value
        txtSenha.Text = dgLista.CurrentRow.Cells(3).Value
        cbNivel.SelectedIndex = dgLista.CurrentRow.Cells(4).Value

    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click

        Try
            Reload("SELECT * FROM Utilizadores1 ORDER BY ID ASC", dgLista)

        Catch ex As Exception

            MessageBox.Show("ERRO" & ex.Message,
                            "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
End Class
