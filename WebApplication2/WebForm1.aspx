<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <label>Name:</label>
        <input type="text" id="txtName" runat="server" /><br />

        <label>Designation:</label>
        <input type="text" id="txtdes" runat="server" /><br />

        <label>Salary:</label>
        <input type="text" id="txtsalary" runat="server" /><br />


        <label>Address:</label>
        <input type="text" id="txtAddress" runat="server" /><br />

        <label>Phone:</label>
        <input type="text" id="txtPhone" runat="server" /><br />


        <asp:HiddenField ID="id" runat="server" />

        <input type="button" id="btnAdd" onclick="function_Add()" value="Add/Update" />
        <input type="button" id="btnview" onclick="function_View_OutputParameter()" value="View_OutputParameter" />
        <input type="button" id="btngrid" onclick="function_GridView()" value="Gridview_display" />


        <table id="tblgrid">
            <thead>
                <tr>
                    <th></th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Designation</th>
                    <th>Salary</th>
                    <th>Address</th>
                    <th>PhoneNo</th>
                </tr>
            </thead>
            <tbody id="tblFamilyData"></tbody>
        </table>
    </form>

</body>
</html>


<script src="jquery.min.js"></script>
<script src="jquery-1.10.2.min.js"></script>
<script src="jquery.dataTables.js"></script>
<link href="jquery.dataTables.css" rel="stylesheet" />
<%--<link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.4/css/jquery.dataTables.css">--%>
<script type="text/javascript">


    $(document).ready(function () {
    });

    //To Add 
    function function_Add() {
        var objcls = {
            intmode: 2,
            intID: $('#id').val() == "" ? 0 : $('#id').val(),
            strName: $('#txtName').val(),
            strDesignsation: $('#txtdes').val(),
            intSalary: $('#txtsalary').val(),
            strAddress: $('#txtAddress').val(),
            intphone: $('#txtPhone').val(),
        }

        $.ajax({
            url: "WebForm1.aspx/function_Add",
            type: "POST",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            cache: false,
            async: false,
            data: "{objclsdata:" + JSON.stringify(objcls) + "}",
            success: function () {
                clear();
            }
        });
    }

    //To get output parameter
    function function_View_OutputParameter() {
        var objcls = {
            intmode: 3,
            intID: 0,
            strName: ' ',
            strDesignsation: ' ',
            intSalary: 0,
            strAddress: ' ',
            intphone: 0,
        }

        $.ajax({
            url: "WebForm1.aspx/function_View_OutputParameter",
            type: "POST",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            cache: false,
            async: false,
            data: "{objclsdata:" + JSON.stringify(objcls) + "}",
            success: function (outputvalue) {
                alert(outputvalue.d);
            }
        });
    }

    //To View the grid 
    function function_GridView() {
        debugger;
        var objcls = {
            intmode: 1,
            intID: 0,
            strName: ' ',
            strDesignsation: ' ',
            intSalary: 0,
            strAddress: ' ',
            intphone: 0,
        }

        $.ajax({
            url: "WebForm1.aspx/function_GridView",
            type: "POST",
            datatype: "json",
            contentType: "application/json; charset=utf-8",
            cache: false,
            async: false,
            data: "{objclsdata:" + JSON.stringify(objcls) + "}",
            success: function (dataset) {
                var DataSource = JSON.parse(dataset.d).Table;
                $('#tblgrid').DataTable({
                    "destroy": true,
                    "data": DataSource,
                    "pageLength": 10,
                    "columns": [
                        {
                            "data": "ID",
                            "render": function (data, type, full, meta) {
                                return '<button type="button" id="btnEdit" onclick="function_Edit(' + full.ID + ",'" + full.Name.trim() + "','" + full.Designation.trim() + "'," + full.Salary + ",'" + full.Address.trim() + "'," + full.Phone + ")" + '">Edit</button> ';
                            }
                        },
                        { "data": "ID" },
                        { "data": "Name" },
                        { "data": "Designation" },
                        { "data": "Salary" },
                        { "data": "Address" },
                        { "data": "Phone" },

                    ],
                });
            }
        })
    }

    // To get the Edit record
    function function_Edit(intid, strname, strdesignation, intsalary, straddress, intphone) {
        debugger;
        $('#id').val(intid);
        $('#txtName').val(strname);
        $('#txtdes').val(strdesignation);
        $('#txtsalary').val(intsalary);
        $('#txtAddress').val(straddress);
        $('#txtPhone').val(intphone);
    }

    //To clear the fields
    function clear() {
        $('#id').val(0);
        $('#txtName').val('');
        $('#txtdes').val('');
        $('#txtsalary').val('');
        $('#txtAddress').val('');
        $('#txtPhone').val('');

        function_GridView();
    }

</script>
