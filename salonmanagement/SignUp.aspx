<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="salonmanagement.SignUp" %>


<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="apple-touch-icon" sizes="76x76" href="../assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="../assets/img/favicon.png">
  <title>
    Sign Up
  </title>
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

<body class="">
  <main class="main-content  mt-0">
    <section>
      <div class="page-header min-vh-100">
        <div class="container">
          <div class="row">
            <div class="col-6 d-lg-flex d-none h-100 my-auto pe-0 position-absolute top-0 start-0 text-center justify-content-center flex-column">
              <div class="position-relative bg-gradient-primary h-100 m-3 px-7 border-radius-lg d-flex flex-column justify-content-center" style="background-image:url('../assets/img/illustrations/illustration-signup.jpg'); background-size: cover;">
              </div>
            </div>
            <div class="col-xl-4 col-lg-5 col-md-7 d-flex flex-column ms-auto me-auto ms-lg-auto me-lg-5">
              <div class="card card-plain">
                <div class="card-header">
                  <h4 class="font-weight-bolder">Registration</h4>
                  
                </div>
                <div class="card-body">
                  <form role="form" runat="server">

                      <label class="form-label">Name:</label>
                    <div class="input-group input-group-outline mb-3">
                        <asp:TextBox ID="txt_name" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
                    </div>

                      <label class="form-label">User Name:</label>
                    <div class="input-group input-group-outline mb-3">
                      <asp:TextBox ID="txt_username" runat="server" CssClass="form-control" placeholder="Username" ></asp:TextBox>
                    </div>

                      <label class="form-label">Email:</label>
                    <div class="input-group input-group-outline mb-3">
                      <asp:TextBox ID="txt_eml" runat="server" CssClass="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                    </div>

                      <label class="form-label">Date Of Birth:</label>
                    <div class="input-group input-group-outline mb-3">
                       
                      <asp:TextBox ID="txt_dob" runat="server" CssClass="form-control" placeholder="Date Of Birth" TextMode="Date" Text="Date of Birth"></asp:TextBox>
                    </div>

                      <label class="form-label">Mobile Number:</label>
                    <div class="input-group input-group-outline mb-3">
                        <asp:TextBox ID="txt_mbl" runat="server" CssClass="form-control" placeholder="Mobile Number "></asp:TextBox>
                    </div>

                      <label class="form-label">Password:</label>
                      <div class="input-group input-group-outline mb-3">
                        <asp:TextBox ID="txt_password" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                    </div>

                      <label class="form-label">Upload Image:</label>
                      <div class="input-group input-group-outline mb-3">
                          <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                          <asp:Label ID="imagefail" runat="server"></asp:Label>
                    </div>

                           
                    
                    <div class="text-center">
                        <asp:Button ID="btn_signup" runat="server" CssClass="btn btn-lg bg-gradient-primary btn-lg w-100 mt-4 mb-0" Text="Register" OnClick="btn_signup_Click" />
                    </div>
                  </form>

                </div>
                <div class="card-footer text-center pt-0 px-lg-2 px-1">
                  <p class="mb-2 text-sm mx-auto">
                    Already have an account?
                    <a href="Login.aspx" class="text-primary text-gradient font-weight-bold">Sign in</a>
                  </p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </main>
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
</body>

</html>