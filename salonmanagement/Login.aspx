<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="salonmanagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png"/>
    <link rel="icon" type="image/png" href="../assets/img/favicon.png"/>
    <title>Login</title>
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
    <main class="main-content  mt-0" textmode="Time">
    <div class="page-header align-items-start min-vh-100" style="background-image: url('https://images.unsplash.com/photo-1497294815431-9365093b7331?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1950&q=80');">
      <span class="mask bg-gradient-dark opacity-6"></span>
      <div class="container my-auto">
        <div class="row">
          <div class="col-lg-4 col-md-8 col-12 mx-auto">
            <div class="card z-index-0 fadeIn3 fadeInBottom">
              <div class="card-header p-0 position-relative mt-n4 mx-3 z-index-2">
                <div class="bg-gradient-primary shadow-primary border-radius-lg py-3 pe-1">
                  <h4 class="text-white font-weight-bolder text-center mt-2 mb-0">Login</h4>
                </div>
              </div>
                <div class="card-body">
                <form role="form" class="text-start" runat="server">
                  <div class="input-group input-group-outline my-3">
                      <asp:TextBox ID="txt_uname" runat="server" CssClass="form-control" placeholder="Username" ControlToValidate="txt_email"></asp:TextBox>
                  </div>
                  <div class="input-group input-group-outline mb-3">
                      <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>                  </div>
                  <div class="text-center">
                      <asp:Button ID="btn_signin" runat="server" CssClass="btn bg-gradient-primary w-100 my-4 mb-2" Text="Login" OnClick="btn_signin_Click" />
                  </div>
                    <label id="ErrMsg" class="text-danger" runat="server"></label>
                  <p class="mt-4 text-sm text-center">
                    Don't have an account?
                    <a href="../SignUp.aspx" class="text-primary text-gradient font-weight-bold">Register</a>
                  </p>
                </form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
   </main>
</body>
</html>
