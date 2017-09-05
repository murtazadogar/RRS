<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSignUp.aspx.cs" Inherits="RRS_UI.Appplication_Code.Views.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <!-- Bootstrap 3.3.7 -->
    <link href="../../Content/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Font Awesome -->
    <link href="../../Content/bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <!-- Theme style -->
    <link href="../../Content/dist/css/hotel-admin.css" rel="stylesheet" />
    <link href="../../Content/dist/css/_all-skins.min.css" rel="stylesheet" />
    <link href="../../Content/dist/css/custom-style.css" rel="stylesheet" />

    <link href="../../Content/dist/css/RRS.css" rel="stylesheet" />
    <script src="../ViewsScript/Common.js"></script>

    <!-- Google Font -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />

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

     <!-- client_captcha -->
    <script src="../../Content/js/client_captcha.js"></script>
  
      <script>

       $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });          
       });

    </script>
    
      <!-- include validation css/js-->
    <link href="../../Content/css/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../../Content/js/jquery.validationEngine-en.js"></script>
    <script src="../../Content/js/jquery.validationEngine.js"></script>
  
    <script src="../ViewsScript/UserInfo.js"></script>

<style>
      p.wrong {
        display: none;
    }
    
    p.wrong.shake {
        display: block;
    }
    
    p.wrong.shake {
        animation: shake .4s cubic-bezier(.36, .07, .19, .97) both;
        transform: translate3d(0, 0, 0);
        backface-visibility: hidden;
        perspective: 1000px;
    }
    
    @keyframes shake {
        10%,
        90% {
            transform: translate3d(-1px, 0, 0);
        }
        20%,
        80% {
            transform: translate3d(1px, 0, 0);
        }
        30%,
        50%,
        70% {
            transform: translate3d(-2px, 0, 0);
        }
        40%,
        60% {
            transform: translate3d(2px, 0, 0);
        }
    }
    
    .controls img {
        height: 20px;
    }
</style>
</head>
<body class="login-page skin-red">
     <input type="hidden" id="hdnUserID" value="-1" />
     <input type="hidden" id="isCaptchaValidate" value="-1" />


    <div class="wrapper">
        <header class="main-header bigNav">
            <!-- Header Navbar: style can be found in header.less -->
            <nav class="navbar navbar-static-top">
                <!-- Logo -->
                <div class="col-xs-2">
                    <img src="../../Content/images/logo.jpg" alt="" />
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
             <div id="result"></div>

            <!-- /.login-logo -->
            <div class="login-box-body">
                <div class="login-logo">
                    <h2>Register</h2>
                </div>
                <div class="col-md-8 col-sm-10 col-xs-12 col-centered clearfix">
                    <form runat="server" id="input_form">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                            <input id="user_name" type="text" class="form-control validate[required]" name="fName" placeholder="Full Name" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope"></i></span>
                            <div class="pad-0" id="user_nameDiv">
                                <input id="email" type="text" class="form-control validate[required]" name="email" placeholder="Your Email" />
                            </div>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            <input id="password" type="password" class="form-control validate[required]" name="password" placeholder="Your Password" />
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                            <input id="confirm-password" type="password" class="form-control validate[required,equals[password]]]" name="password" placeholder="Confirm Password" />
                        </div>
                        <div class="clearfix marBottom15 captichaDiv">
                            <div class="captcha-chat">
                                <div class="captcha-container media">
                                    <div class="media-body">
                                        <p class="security">Security Check:</p>
                                    </div>
                                    <div id="captcha">
                                        <div class="controls">
                                            <input id="captcha_txt" class="user-text btn-common validate[required]" placeholder="Type here" type="text" />
                                            <button type="button" class="validate btn-common" id="btnValidateCaptcha">
                                                <!-- this image should be converted into inline svg -->
                                                <img src="../../Content/images/enter_icon.png" alt="submit icon" />
                                            </button>
                                            <button type="button" class="refresh btn-common">
                                                <!-- this image should be converted into inline svg -->
                                                <img src="../../Content/images/refresh_icon.png" alt="refresh icon" />
                                            </button>
                                            <img src="../../Content/images/tick-icon.jpg" style="visibility:hidden" id="captichaSuccessImg" alt="refresh icon" />
                                        </div>
                                    </div>
            <p class="wrong info">Wrong!, please try again.</p>
        </div>
    </div>
                        </div>
                        <div>
                            <button type="button" class="btn btn-round btn-red btn-block" onclick="SaveUserInfoData();">Register</button>
                           <%-- <button class="btn btn-round btn-red btn-block" onclick="SaveUserInfoData();">Register</button>--%>
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
                            <a href="#" class="btn btn-round btn-block btn-social btn-facebook"><i class="fa fa-facebook-f"></i>Login with Facebook</a>
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
                        <p>
                            Want to receive the latest promostions from abc.com?
				<strong>Subscribe to our e-newsletter.</strong>
                        </p>
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
                            <li><a href="#"><i class="fa fa-facebook-f"></i>Facebook</a></li>
                            <li><a href="#"><i class="fa fa-google-plus"></i>Google +</a></li>
                            <li><a href="#"><i class="fa fa-instagram"></i>Instagram</a></li>
                            <li><a href="#"><i class="fa fa-twitter"></i>Twitter</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </footer>

    </div>
    <!-- ./wrapper -->

  
</body>
</html>
