<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="salonmanagement.view.Clients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="../assets/img/favicon.png">
    <title></title>
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900|Roboto+Slab:400,700" />
  <!-- Nucleo Icons -->
  <link href="../assets/css/nucleo-icons.css" rel="stylesheet" />
  <link href="../assets/css/nucleo-svg.css" rel="stylesheet" />
  <!-- Font Awesome Icons -->
  <script src="https://kit.fontawesome.com/42d5adcbca.js" crossorigin="anonymous"></script>
  <!-- Material Icons -->
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Round" rel="stylesheet">
  <!-- CSS Files -->
  <link id="pagestyle" href="../assets/css/material-dashboard.css?v=3.0.4" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
             <aside class="sidenav navbar navbar-vertical navbar-expand-xs border-0 border-radius-xl my-3 fixed-start ms-3 " style="background-color:black;" id="sidenav-main">
    <div class="sidenav-header">
      <i class="fas fa-times p-3 cursor-pointer text-white opacity-5 position-absolute end-0 top-0 d-none d-xl-none" aria-hidden="true" id="iconSidenav"></i>
      <a class="navbar-brand m-0" >
          <img src="../assets/img/stylette.png" class="navbar-brand-img h-100" style="width:200px;" />
        <span class="ms-1 font-weight-bold text-white"></span>
      </a>
    </div>
    <hr class="horizontal light mt-0 mb-2">
    <div class="collapse navbar-collapse  w-auto " id="sidenav-collapse-main">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link text-white" href="../view/AdminDashboard.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Dashboard</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white " href="../view/Services.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Services</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white active bg-gradient-primary" href="../view/Clients.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Clients</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white " href="../view/Appointments.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Appointments</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white " href="../view/purchases.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Purchases</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white " href="../view/Expenses.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Expenses</span>
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link text-white " href="../view/Profile.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Profile</span>
          </a>
        </li>
      </ul>
    </div>
    <div class="sidenav-footer position-absolute w-100 bottom-0 ">
      <div class="mx-3">
          <asp:Button ID="Button3" class="btn bg-gradient-primary mt-4 w-100" runat="server" Text="Logout" OnClick="Button3_Click" />
      </div>
    </div>
  </aside>
     <main class="main-content position-relative max-height-vh-100 h-100 border-radius-lg" />
    <!-- Navbar -->
    <nav class="navbar navbar-main navbar-expand-lg px-0 mx-4 shadow-none border-radius-xl" id="navbarBlur" data-scroll="true">
      <div class="container-fluid py-1 px-3" />
        <nav aria-label="breadcrumb">
          <h6 class="font-weight-bolder mb-0" style="font-size: 30px;">Clients&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Label ID="lblname" runat="server"></asp:Label>
          </h6>
                    <a href="../Login.aspx" runat="server" ><asp:Label ID="lblerrmsg" runat="server"></asp:Label></a>

        </nav>

    </nav>
    <!-- End Navbar -->
    <div class="container-fluid py-4">
      <div class="row">
        <div class="col-12">
          <div class="card my-4">
            <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
              <div class="bg-gradient-primary shadow-primary border-radius-lg pt-4 pb-3">
                <h6 class="text-white text-capitalize ps-3" style="font-size: 20px;">Clients</h6>
              </div>
            </div>
            <div class="card-body px-4 pb-4">
            

              <div class="table-responsive p-0">
                <table class="table align-items-center mb-0">
                    <asp:GridView CellPadding="4" Class="table" ID="GridView1" runat="server" DataKeyNames="cid" OnRowDataBound="OnRowDataBound"
        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit" OnRowUpdating="OnRowUpdating"
        OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." AutoGenerateEditButton="true"
        ShowHeaderWhenEmpty="true" AutoGenerateDeleteButton="true">
    </asp:GridView>
                    <%--<asp:Table runat="server" ID="table" class="table" BorderStyle="Dotted" BorderColor="#ff00ff">
    <asp:TableHeaderRow>
        <asp:TableCell>Name</asp:TableCell>
        <asp:TableCell>User Name</asp:TableCell>
        <asp:TableCell>Email</asp:TableCell>
        <asp:TableCell>Phone</asp:TableCell>
        <asp:TableCell>Date Of Birth</asp:TableCell>
        <asp:TableCell>Password</asp:TableCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell ID="cell1"></asp:TableCell>
        <asp:TableCell ID="cell3"></asp:TableCell>
        <asp:TableCell ID="cell2"></asp:TableCell>
        <asp:TableCell ID="cell4"></asp:TableCell>
        <asp:TableCell ID="cell5"></asp:TableCell>
        <asp:TableCell ID="cell6"></asp:TableCell>
    </asp:TableRow>
</asp:Table>--%>
                    


                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
      
            </div>

        <div class="container-fluid py-4">
      <div class="row">
        <div class="col-12">
          <div class="card my-4">
            <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
              <div class="bg-gradient-primary shadow-primary border-radius-lg pt-4 pb-3">
                <h6 class="text-white text-capitalize ps-3" style="font-size: 20px;">Add Client</h6>
              </div>
            </div>
              
            <div class="card-body px-4 pb-4">
            

              <div class="table-responsive p-0">
                

                    
                  <div class="card-body max-width-500">
              <label class="form-label">Client Name</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="add_name" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
          </div>
              <label class="form-label">Client User Name:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="add_username" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>
          </div>
                      <label class="form-label">Client email:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="add_email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
          </div>

                      <label class="form-label">Client Phone:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="add_phone" runat="server" CssClass="form-control" placeholder="number"></asp:TextBox>
          </div>


                      <label class="form-label">Client Date Of Birth:</label>
          <div class="input-group input-group-outline mb-3">

              <asp:TextBox ID="add_date" runat="server" CssClass="form-control" TextMode="Date" placeholder="dateofbirth"></asp:TextBox>
          </div>

                      <label class="form-label">Client Password:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="add_password" runat="server" CssClass="form-control" placeholder="password"></asp:TextBox>
          </div>


              
          <div class="text-center">
              <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0" Text="Save" OnClick="Button1_Click" />
<%--              <asp:Button ID="btn_add" runat="server" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0" Text="Save" />--%>
          </div>
    
                    
                      </div>
                        
                
              </div>
            </div>
          </div>
        </div>
      </div>
      
      </div>


        
      <%--</div>
    </div>
  </div>--%>
  <!--   Core JS Files   -->
  <script src="../assets/js/core/popper.min.js"></script>
  <script src="../assets/js/core/bootstrap.min.js"></script>
  <script src="../assets/js/plugins/perfect-scrollbar.min.js"></script>
  <script src="../assets/js/plugins/smooth-scrollbar.min.js"></script>
  <script>
    var win = navigator.platform.indexOf('Win') > -1;
    if (win && document.querySelector('#sidenav-scrollbar')) {
      var options = {
        damping: '0.5'
      }
      Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
    }
  </script>
    </form>
</body>
</html>
