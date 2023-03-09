<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="salonmanagement.view.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png"/
  <link rel="icon" type="image/png" href="../assets/img/favicon.png"/>
  
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700,900|Roboto+Slab:400,700" />
  <!-- Nucleo Icons -->
  <link href="../assets/css/nucleo-icons.css" rel="stylesheet" />
  <link href="../assets/css/nucleo-svg.css" rel="stylesheet" />
  <!-- Font Awesome Icons -->
  <script src="https://kit.fontawesome.com/42d5adcbca.js" crossorigin="anonymous"></script>
  <!-- Material Icons -->
  <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Round" rel="stylesheet"/>
  <!-- CSS Files -->
  <link id="pagestyle" href="../assets/css/material-dashboard.css?v=3.0.4" rel="stylesheet" />
</head>
<body>
    <form role="form" runat="server">
    <%--<form id="form1" runat="server">--%>
    <aside class="sidenav navbar navbar-vertical navbar-expand-xs border-0 border-radius-xl my-3 fixed-start ms-3 " style="background-color:black;" id="sidenav-main">
    <div class="sidenav-header">
      <i class="fas fa-times p-3 cursor-pointer text-white opacity-5 position-absolute end-0 top-0 d-none d-xl-none" aria-hidden="true" id="iconSidenav"></i>
      <a class="navbar-brand m-0" >
          <img src="../assets/img/stylette.png" class="navbar-brand-img h-100" style="width:200px;" />
        <span class="ms-1 font-weight-bold text-white"></span>
      </a>
    </div>
    <hr class="horizontal light mt-0 mb-2"/>
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
          <a class="nav-link text-white " href="../view/Clients.aspx">
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
          <a class="nav-link text-white active bg-gradient-primary" href="../view/Profile.aspx">
            <div class="text-white text-center me-2 d-flex align-items-center justify-content-center">
            </div>
            <span class="nav-link-text ms-1">Profile</span>
          </a>
        </li>
      </ul>
    </div>
    <div class="sidenav-footer position-absolute w-100 bottom-0 ">
      <div class="mx-3">
          <asp:Button ID="Button1" class="btn bg-gradient-primary mt-4 w-100" runat="server" Text="Logout" OnClick="Button1_Click" />
          
      </div>
    </div>
  </aside>
     <main class="main-content position-relative max-height-vh-100 h-100 border-radius-lg " />
    <!-- Navbar -->
    <nav class="navbar navbar-main navbar-expand-lg px-0 mx-4 shadow-none border-radius-xl" id="navbarBlur" data-scroll="true">
      <div class="container-fluid py-1 px-3" />
        <nav aria-label="breadcrumb">
          <h6 class="font-weight-bolder mb-0" style="font-size: 30px;">Profile</h6>
                    <a href="../Login.aspx" runat="server" ><asp:Label ID="lblerrmsg" runat="server"></asp:Label></a>

        </nav>

    </nav>
    <!-- End Navbar -->
    <div class="container-fluid px-2 px-md-4">
      <div class="page-header min-height-300 border-radius-xl mt-4" style="background-image: url('https://images.unsplash.com/photo-1531512073830-ba890ca4eba2?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1920&q=80');">
        <span class="mask  bg-gradient-primary  opacity-6"></span>
      </div>
      <div class="card card-body mx-3 mx-md-4 mt-n6">
        <div class="row gx-4 mb-2">
          <div class="col-auto">
            <div class="avatar avatar-xl position-relative">
                <asp:Image runat="server" ID="Image1" BorderStyle="Groove" Width="110px" AlternateText="Loading..." />
<%--              <img src="../assets/img/bruce-mars.jpg" alt="profile_image" class="w-100 border-radius-lg shadow-sm"/>--%>
            </div>
          </div>
          <div class="col-auto my-auto">
            <div class="h-100">
              <asp:Label runat="server" ID="lblprofile"></asp:Label>
            </div>
          </div>
        </div>
          <div class="col-xl-6 col-lg-7 col-md-11 d-flex flex-column me-auto ">
              <div class="card card-plain">
          <div class="card-body">
          
              <label class="form-label">Name:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
          </div>
              <label class="form-label">Username:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="txt_username" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
          </div>
              <label class="form-label">Email:</label>
          <div class="input-group input-group-outline mb-3">
            <asp:TextBox ID="txt_email" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
          </div>
              <label class="form-label">Mobile No.:</label>
          <div class="input-group input-group-outline mb-3">
            <asp:TextBox ID="txt_mno" runat="server" CssClass="form-control" placeholder="Mobile No."></asp:TextBox>
          </div>
              <label class="form-label">Date of birth:</label><br />
              <label class="form-label">Current Date:</label>
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
          <div class="input-group input-group-outline mb-3">
            <asp:TextBox ID="txt_dob" runat="server" CssClass="form-control" TextMode="Date" Text="Date of Birth"></asp:TextBox>
          </div>
              

              <label class="form-label">Password:</label>
          <div class="input-group input-group-outline mb-3">
              <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
          </div>
          <%--<div class="form-check form-switch d-flex align-items-center mb-3">
          <input class="form-check-input" runat="server" type="checkbox" id="admin" />
          <label class="form-check-label mb-0 ms-3" for="rememberMe">Admin</label>
        </div>--%>
          <div class="text-center">
              <asp:Button ID="Button2" runat="server" Text="Update" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0"  OnClick="Button2_Click" />
<%--              <asp:Button ID="upadte_register" runat="server" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0" Text="Update" OnClick="upadte_register_Click" />--%>
<%--              <asp:Button ID="btn_signup" runat="server" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0" Text="Update" OnClick="btn_signup_Click" />--%>
          </div>
        </form>
        </div>
        </div>
        </div>
       </div>
     </div>
</body>
</html>
