<%@ Page Title="" Language="C#" MasterPageFile="~/Application_Code/Views/RRS.Master" AutoEventWireup="true" CodeBehind="frmDeals.aspx.cs" Inherits="RRS_UI.Application_Code.Views.frmDeals" %>


<asp:content id="Content1" contentplaceholderid="head" runat="server">
      <!-- iCheck -->
    <script src="../../Content/plugins/iCheck/icheck.min.js"></script>

      <!-- Slick Slider -->
    <link href="../../Content/plugins/slickSlider/slick.css" rel="stylesheet" />
    <link href="../../Content/plugins/slickSlider/slick-theme.css" rel="stylesheet" />
    <script src="../../Content/plugins/slickSlider/slick.min.js"></script>

    <script src="../ViewsScript/Restaurant.js"></script>

    <script>
        $(function () {
         
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });

            $('.select2').select2();

            $('.select2-multiple2').select2MultiCheckboxes({
                templateSelection: function (selected, total) {
                    return "Selected " + selected.length + " of " + total;
                }
            });

          
            GetRestaurantDeals();
        });
    </script>

</asp:content>
<asp:content id="Content2" contentplaceholderid="LoggedInContent" runat="server">

    <div class="row gutter-5 clearfix marBottom15">
        <div class="pull-left col-md-8">
            <h2 class="pageHead">Deals</h2>
        </div>
        <div class="col-md-4 addBtns">
            <button type="button" class="btn btn-round btn-red"><i class="fa fa-plus-circle" aria-hidden="true"></i>Add Menu</button>
            <button type="button" class="btn btn-round btn-red marLft5" data-toggle="modal" data-target="#myModal"><i class="fa fa-plus-circle" aria-hidden="true"></i>Add Deal</button>
        </div>
    </div>

    <div class="clearfix" id="RecordListDiv">

     <div class='col-md-12'>

<div class='admin-deal-box'><div class='admin-deal-detail'>
<h3><a class='#'></a> <span class='pull-right save-deal'><a href = '#' ><i class='fa fa-heart' aria-hidden='true'></i></a></span></h3>
<div class='row gutter-0'>

<div class='col-xs-4'>
<div id = 'carousel-example-generic' class='carousel slide' data-ride='carousel'>
<div class='fixed-logo'><img src = '../../Content/images/hotel-logo-sm.jpg' ></div>
 <ol class='carousel-indicators'>
 <li data-target='#carousel-example-generic' data-slide-to='0' class='active'></li>
 <li data-target='#carousel-example-generic' data-slide-to='1' class=''></li>
 <li data-target='#carousel-example-generic' data-slide-to='2' class=''></li>
 <li data-target='#carousel-example-generic' data-slide-to='3' class=''></li>
 </ol>
 <div class='carousel-inner'>
 <div class='item active'><img src = '../../Content/images/hotel-1.jpg' alt = '' style = 'width: 100%; height: 150px;' /></div >
 <div class='item'><img src = '../../Content/images/hotel-2.jpg' alt = '' style = 'width: 100%; height: 150px;' /></div > 
 <div class='item'><img src = '../../Content/images/hotel-3.jpg' alt = '' style = 'width: 100%; height: 150px;' /></div >
 <div class='item'><img src = '../../Content/images/hotel-4.jpg' alt = '' style = 'width: 100%; height: 150px;' /></div > 
 </div>
 </div>
 </div>
 
 <div class='col-xs-4'>
 <div class='divText clearfix marTop30'>
 <div class='text-left'>Deal Rating: </div>
 <div class='text-right'>
 <div class='box-price-gray'>
 <div class='box-detail-price-yellow_b' style='width: 40%;'></div>
 </div>
 </div>
 </div>

 <div class='divText clearfix'>
 <div class='text-left'>Price Rating:</div>
 <div class='text-right'>
 <div class='box-detail-rating-gray'>
 <div class='box-detail-rating-yellow_b' style='width: 80%;'></div>
 </div>
 </div>
 </div>
 </div>
 <div class='col-xs-4'>
 <div class='admin-menu-list'>
 <h4>Menu Dishes:</h4>
 <ul>
 <li>ytyuttutu</li>
 <li>yrtututu</li>
 <li>rturturtu</li>
 <li>urutrtu</li>
 <li>ututyutyu</li>
 </ul>
 </div>
 </div>
 </div>
 
 
 <div class='borTop clearfix'>
 
 <div class='col-xs-2 deal-head'>Deal List:</div>
 <div class='col-xs-10'><div class='dealSlider dealsContainer'><div><a href = '#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'><div class='home-slot-time normal-font font-weight-bold'>04:00:00</div><div class='home-slot-discount'><h1 class='font-weight-bold'><span>-</span>50</h1></div><div class='home-slot-discount-pc'>%</div><div class='home-slot-off'>off</div></a></div><div><a href = '#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'><div class='home-slot-time normal-font font-weight-bold'>15:30:00</div><div class='home-slot-discount'><h1 class='font-weight-bold'><span>-</span>20</h1></div><div class='home-slot-discount-pc'>%</div><div class='home-slot-off'>off</div></a></div><div><a href = '#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'><div class='home-slot-time normal-font font-weight-bold'>09:00:00</div><div class='home-slot-discount'><h1 class='font-weight-bold'><span>-</span>30</h1></div><div class='home-slot-discount-pc'>%</div><div class='home-slot-off'>off</div></a></div></div></div></div></div> </div>



</div>

        <%--<div class="col-md-12">
            <div class='admin-deal-box'>
                <div class='admin-deal-detail'>
                    <h3><a class='#'></a><span class='pull-right save-deal'><a href='#'><i class='fa fa-heart' aria-hidden='true'></i></a></span></h3>
                    <div class='row gutter-0'>
                        <div class='col-xs-4'>
                            <div id='carousel-example-generic' class='carousel slide' data-ride='carousel'>
                                <div class='fixed-logo'>
                                    <img src='../../Content/images/hotel-logo-sm.jpg'>
                                </div>
                                <ol class='carousel-indicators'>
                                    <li data-target='#carousel-example-generic' data-slide-to='0' class='active'></li>
                                    <li data-target='#carousel-example-generic' data-slide-to='1' class=''></li>
                                    <li data-target='#carousel-example-generic' data-slide-to='2' class=''></li>
                                    <li data-target='#carousel-example-generic' data-slide-to='3' class=''></li>
                                </ol>
                                <div class='carousel-inner'>
                                    <div class='item active'>
                                        <img src='../../Content/images/hotel-1.jpg' alt='' style='width: 100%; height: 150px;' />
                                    </div>
                                    <div class='item'>
                                        <img src='../../Content/images/hotel-2.jpg' alt='' style='width: 100%; height: 150px;' />
                                    </div>
                                    <div class='item'>
                                        <img src='../../Content/images/hotel-3.jpg' alt='' style='width: 100%; height: 150px;' />
                                    </div>
                                    <div class='item'>
                                        <img src='../../Content/images/hotel-4.jpg' alt='' style='width: 100%; height: 150px;' />
                                    </div>
                                </div>
                            </div>
                            <div class='col-xs-4'>
                                <div class='divText clearfix marTop30'>
                                    <div class='text-left'>Deal Rating: </div>
                                    <div class='text-right'>
                                        <div class='box-price-gray'>
                                            <div class='box-detail-price-yellow_b' style='width: 40%;'></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class='divText clearfix'>
                                <div class='text-left'>Price Rating:</div>
                                <div class='text-right'>
                                    <div class='box-detail-rating-gray'>
                                        <div class='box-detail-rating-yellow_b' style='width: 80%;'></div>
                                    </div>
                                </div>
                            </div>
                            <div class='col-xs-4'>
                                <div class='admin-menu-list'>
                                    <h4>Menu Dishes:</h4>
                                    <ul>
                                        <li></li>
                                        <li></li>
                                        <li></li>
                                        <li></li>
                                        <li></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class='borTop clearfix'>
                            <div class='col-xs-2 deal-head'>Deal List:</div>
                            <div class='col-xs-10'>
                                <div class='dealSlider dealsContainer'>
                                    <div>
                                        <a href='#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'>
                                            <div class='home-slot-time normal-font font-weight-bold'>04:00:00</div>
                                            <div class='home-slot-discount'>
                                                <h1 class='font-weight-bold'><span>-</span>50</h1>
                                            </div>
                                            <div class='home-slot-discount-pc'>%</div>
                                            <div class='home-slot-off'>off</div>
                                        </a>
                                    </div>
                                    <div>
                                        <a href='#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'>
                                            <div class='home-slot-time normal-font font-weight-bold'>15:30:00</div>
                                            <div class='home-slot-discount'>
                                                <h1 class='font-weight-bold'><span>-</span>20</h1>
                                            </div>
                                            <div class='home-slot-discount-pc'>%</div>
                                            <div class='home-slot-off'>off</div>
                                        </a>
                                    </div>
                                    <div>
                                        <a href='#' class='swiper-slide red-slide swiper-slide-visible swiper-slide-active' style='width: 82.6667px; height: 75px;'>
                                            <div class='home-slot-time normal-font font-weight-bold'>09:00:00</div>
                                            <div class='home-slot-discount'>
                                                <h1 class='font-weight-bold'><span>-</span>30</h1>
                                            </div>
                                            <div class='home-slot-discount-pc'>%</div>
                                            <div class='home-slot-off'>off</div>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


        </div>--%>

    </div>
</asp:content>
