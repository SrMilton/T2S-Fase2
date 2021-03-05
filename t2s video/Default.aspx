<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="t2s_video.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css"rel="stylesheet" href="Content/bootstrap.css"/>
</head>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        #REGISTRAR CONTÊINER
                    </td>
                </tr>
                <tr>
                    <td>
                        Cliente:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCliente" CssClass="form-control" placeholder="Nome" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Número do Contêiner:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConteinerNum" CssClass="form-control" placeholder="TEST1234567" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipo:
                    </td>
                    <td>
                        <asp:DropDownList ID="listTipo" runat="server" Width="128px">
                          <asp:ListItem Selected="True" Value="20"> 20 </asp:ListItem>
                          <asp:ListItem Value="40"> 40 </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status:
                    </td>
                    <td>
                         <asp:DropDownList ID="listStatus" runat="server" Width="128px">
                          <asp:ListItem Selected="True" Value="Cheio"> Cheio </asp:ListItem>
                          <asp:ListItem Value="Vazio"> Vazio </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Categoria:
                    </td>
                    <td>
                        <asp:DropDownList ID="listCategoria" runat="server" Width="128px">
                          <asp:ListItem Selected="True" Value="Importação"> Importação </asp:ListItem>
                          <asp:ListItem Value="Exportação"> Exportação </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Adicionar" CssClass="btn btn-primary" Width="80px" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Atualizar" CssClass="btn btn-primary" Width="80px" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Deletar" CssClass="btn btn-primary" Width="80px" OnClick="btnDelete_Click" />  
                    </td>
                    <td>
                        <asp:Label ID="labelAdd" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        ----------------------------------------------
                    </td>
                </tr>
                <tr>
                    <td>
                        #REGISTRAR MOVIMENTAÇÃO
                    </td>
                </tr>
                <tr>
                    <td>
                        Número do Contêiner:
                    </td>
                    <td>
                        <asp:TextBox ID="txtConteinerMov" CssClass="form-control" placeholder="TEST1234567" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tipo da movimentação:
                    </td>
                    <td>
                        <asp:DropDownList ID="listMovimentacao" runat="server" Width="128px">
                          <asp:ListItem Selected="True" Value="Embarque"> Embarque </asp:ListItem>
                          <asp:ListItem Value="Descarga"> Descarga </asp:ListItem>
                          <asp:ListItem Value="Gate In"> Gate In </asp:ListItem>
                          <asp:ListItem Value="Gate Out"> Gate Out </asp:ListItem>
                          <asp:ListItem Value="Posicionamento Pilha"> Posicionamento Pilha </asp:ListItem>
                          <asp:ListItem Value="Pesagem"> Pesagem </asp:ListItem>
                          <asp:ListItem Value="Scanner"> Scanner </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Início:
                    </td>
                    <td>
                        <asp:TextBox ID="txtinicio" CssClass="form-control" placeholder="24/05/2020 22:38" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fim:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFim" CssClass="form-control" placeholder="25/05/2020 18:46" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRegistrarMovimentacao" runat="server" Text="Registrar" CssClass="btn btn-primary" Width="80px" OnClick="btnRegistrarMovimentacao_Click" />
                        <asp:Button ID="btnUpdateMovimentacao" runat="server" Text="Atualizar" CssClass="btn btn-primary" Width="80px" OnClick="btnUpdateMovimentacao_Click" />
                        <asp:Button ID="btnDeleteMovimentacao" runat="server" Text="Deletar" CssClass="btn btn-primary" Width="80px" OnClick="btnDeleteMovimentacao_Click" />
                    </td>
                    <td>
                        <asp:Label ID="labelMovimentacao" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRelatorio" runat="server" Text="Gerar Relatório" CssClass="btn btn-primary" OnClick="btnRelatorio_Click" />
                    </td>
                </tr>
            </table>
            <table>
            <tr>
                <td>
            
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>
                 </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped"></asp:GridView>
                    </td>
                </tr>
            
                
             </table>
        </div>
    </form>
</body>
</html>
