<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Hotel | Dashboard</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">

 <!-- Bootstrap 3.3.7 -->
    <link href="../../Content/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />

  <!-- Font Awesome -->
    <link href="../../Content/bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

  <!-- Ionicons -->
  <link rel="stylesheet" href="bower_components/Ionicons/css/ionicons.min.css">
    
    <!-- Theme style -->
    <link href="../../Content/dist/css/hotel-admin.css" rel="stylesheet" />
    <link href="../../Content/dist/css/_all-skins.min.css" rel="stylesheet" />
    <link href="../../Content/dist/css/custom-style.css" rel="stylesheet" />

   
  
  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">
  
</head>
<body class="login-page skin-red">
<div class="wrapper">

  <header class="main-header bigNav">
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
          <!-- Logo -->
    <div class="col-xs-2">
     <img src="images/logo.jpg" alt="" />
     </div> 
      <!-- Navbar Right Menu -->
    <div class="col-xs-10">
       <div id="beforeLogin">
    <div class="navbar-nav pull-right">
      <a class="nav-item nav-link" href="#">Blog</a>
      <a class="nav-item nav-link" href="#">How it Works</a>
      <a class="nav-item nav-link btnLink" href="#">Sign Up</a>
    </div>
    </div>
  </div>

    </nav>
  </header>
<div class="login-box">

  <!-- /.login-logo -->
  <div class="login-box-body">
    <div class="login-logo">
    <h2>Register</h2>
  </div>
  <div class="col-md-8 col-sm-10 col-xs-12 col-centered clearfix">
  <form action="" method="post">
  <div class="input-group">
    <span class="input-group-addon"><i class="fa fa-user"></i></span>
    <input id="fName" type="text" class="form-control" name="fName" placeholder="Full Name">
  </div>
    <div class="input-group">
    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
    <input id="email" type="text" class="form-control" name="email" placeholder="Your Email">
  </div>
  <div class="input-group">
    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
    <input id="password" type="password" class="form-control" name="password" placeholder="Your Password">
  </div>
  <div class="input-group">
    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
  <input id="confirm-password" type="password" class="form-control" name="password" placeholder="Confirm Password">
  </div>
        <div class="clearfix marBottom15 captichaDiv">
				<img src="images/capticha.jpg" alt="" />
			</div>
            <div>
          <button type="submit" class="btn btn-round btn-red btn-block">Register</button>
        </div>
            
</form>
<div class="clearfix"></div>

  <div class="social-auth-links text-center">
      <div class="marBottom15">
           <div class="login-or">
        <hr class="hr-or">
        <span class="span-or">or</span>
      </div>
      </div>
        <div>
          <a href="#" class="btn btn-round btn-block btn-social btn-facebook"><i class="fa fa-facebook-f"></i> Login with Facebook</a>
        </div>
      <!--<p class=" marTop15">Don't have an account! <a href="#">Sign Up Here</a></p>-->
    </div>
    <div class="col-xs-12">
				<p class="font18 text-center marTop15">
					Already have an account? <a href="frmLogin.aspx">Login here</a>
				</p>
			</div>
    

  </div>    
  </div>
</div>

  <footer class="main-footer">
    <div class="container">
    	<div class="row">
        	<div class="col-sm-4 col-xs-12">
            	<p>Want to receive the latest promostions from abc.com?
				<strong>Subscribe to our e-newsletter.</strong></p>
                  <div class="subscribelink row gutter-0 marBottom15">
                  <div class="col-md-9 col-sm-12">
                  <div class="input-group">
    <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
    <input id="subscribe-email" type="text" class="form-control" name="email" placeholder="Your Email ">
  </div>
  </div>
  <div class="col-md-3 col-sm-12">
  <button type="submit" class="btn btn-white marTop10-sm btn-block">Subscribe</button>
  </div>
  </div>
                <p>© 2017-18 abc.com | All rights reserved.</p>
            </div>
            <div class="col-sm-4 col-xs-12">
            	<p><strong>Want to put your restaurant on abc,com?</strong></p>
<p>It’s super easy! Just write an email to us at</p>
<p class="marTop-Bottom15"><a href="#" class="link-underline font-white">support@abc.com</a></p>


<p><a href="#" class="link-underline font-white">Click here</a> for restaurant login.</p>
            </div>
            <div class="col-sm-4 col-xs-12 footer-col">
            	<h6>Stay Updated</h6>
                <ul>
                	<li><a href="#"><i class="fa fa-facebook-f"></i> Facebook</a></li>
                    <li><a href="#"><i class="fa fa-google-plus"></i> Google +</a></li>
                    <li><a href="#"><i class="fa fa-instagram"></i> Instagram</a></li>
                    <li><a href="#"><i class="fa fa-twitter"></i> Twitter</a></li>
                </ul>
            </div>
        </div>
    </div>
  </footer>

</div>
<!-- ./wrapper -->

<!-- jQuery 3 -->
<script src="../../Content/bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
    <script src="../../Content/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- AdminLTE App -->
    <script src="../../Content/dist/js/adminlte.min.js"></script>
<!-- SlimScroll -->
    <script src="../../Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>

<!-- iCheck -->
    <script src="../../Content/plugins/iCheck/icheck.min.js"></script>

<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
</body>
</html>
