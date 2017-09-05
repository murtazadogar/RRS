<%@ Page Title="" Language="C#" MasterPageFile="~/Application_Code/Views/RRS.Master" AutoEventWireup="true" CodeBehind="frmReservations.aspx.cs" Inherits="RRS_UI.Application_Code.Views.frmReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <!-- iCheck -->
    <script src="../../Content/plugins/iCheck/icheck.min.js"></script>

    <!-- Select2 -->
    <link href="../../Content/bower_components/select2/dist/css/select2.min.css" rel="stylesheet" />
    <script src="../../Content/bower_components/select2/dist/js/select2.full.min.js"></script>
    <script src="../../Content/dist/js/select2-multi-checkboxes.js"></script>

<!-- DataTables -->
    <link href="../../Content/bower_components/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <script src="../../Content/bower_components/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../Content/bower_components/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
   
     <!-- bootstrap date picker -->
    <link href="../../Content/css/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../../Content/js/bootstrap-datepicker.js"></script>

    <script src="../ViewsScript/Reservation.js"></script>
    <script src="../ViewsScript/Common.js"></script>
  
    <script>
        $(document).ready(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
            /*Select 2*/
            $('.select2').select2({
                placeholder: "Select an option",
                allowClear: true
            })
            //$('.select2-multiple2').select2MultiCheckboxes({
            //    templateSelection: function (selected, total) {
            //        return "Selected " + selected.length + " of " + total;
            //    }
            //})
        
            $('.date').datepicker({ format: 'mm/dd/yyyy', autoclose: true, clearBtn:true });
            $('.date').val("");

           
          LoadStatusDDL('#sel-02');
            LoadRestaurantDealDDL('#ddlDeals');
            LoadCustomerDDL('#ddlCountry');
            GetAllReservations();
      });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoggedInContent" runat="server">
    <!-- Body Content-->
   
         <%--<div class="row gutter-10">
           <div class="col-xs-3 marBottom15">
                <div class="shadow-div hotel-info">
                    <div class="hotel-info-div">
                        <h2 id="lblRestaurantName" runat="server"></h2>
                        <p>Member since <span id="lblMemberShipDate" runat="server"></span></p>
                        <p >Last online on <span id="lblLastLogin" runat="server">23 Aug 2017</span></p>
                    </div>
                    <div class="hotel-list-div">
                        <h2>Latest Reservations</h2>
                        <ul id="ul_TopReservation">
                           
                        </ul>
                      
                    </div>
                </div>
            </div>--%>



            <%-- Record List--%>
    
                    <div class="row marBottom15">
                        <div class="col-md-12">
                            <h2 class="pageHead">Reservations</h2>
                        </div>
                    </div>

                    <%-- Filter Div--%>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box search-box">
                                <div class="box-header">
                                    <h3 class="box-title">Search Filter:</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <div class="row gutter-5">
                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">Status</label>
                                                <select class="form-control select2 select2-hidden-accessible" id="sel-02" style="width: 100%;" tabindex="-1" aria-hidden="true">
                                                    
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">Deals</label>
                                                <select class="form-control select2 select2-hidden-accessible" id="ddlDeals" style="width: 100%;" tabindex="-1" aria-hidden="true">
                                                  <%--  <option value=""></option>
                                                    <option selected="selected" value="All">All</option>
                                                    <option value="Neville">Neville</option>
                                                    <option value="Rooney">Rooney</option>
                                                    <option value="Mata">Mata</option>
                                                    <option value="Elon Musk">Elon Musk</option>
                                                    <option value="Federer">Federer</option>
                                                    <option value="Nadal">Nadal</option>--%>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">Customers</label>
                                                <select class="form-control select2 select2-hidden-accessible" id="ddlCountry" style="width: 100%;" tabindex="-1" aria-hidden="true">
                                                   <%-- <option selected="selected" value="All">All</option>
                                                    <option value="Dubai">Dubai</option>
                                                    <option value="Cairo">Cairo</option>
                                                    <option value="Jeddah">Jeddah</option>
                                                    <option value="Lahore">Lahore</option>
                                                    <option value="Riyadh">Riyadh</option>--%>
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">From</label>
                                                <div class="input-group date">
                                                    <div class="input-group date">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </div>
                                                        <input class="form-control pull-right date" id="startdate" type="text">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">To</label>
                                                    <div class="input-group date">
                                                        <div class="input-group-addon">
                                                            <i class="fa fa-calendar"></i>
                                                        </div>
                                                        <input class="form-control pull-right date" id="enddate" type="text">                                                   
                                                </div>
                                               <%-- <select class="form-control select2 select2-hidden-accessible" style="width: 100%;" tabindex="-1" aria-hidden="true">
                                                    <option selected="selected" value="All">All</option>
                                                    <option value="Due by 1 day">1 day</option>
                                                    <option value="Due by 2 days">2 days</option>
                                                    <option value="Due by 3 days">3 days</option>
                                                    <option value="Due by 4 days">4 days</option>
                                                </select>--%>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <label>&nbsp;</label>
                                            <button type="button" class="btn btn-round btn-red btn-block" onclick="Load_ReservationReport();">Search</button>
                                        </div>
                                        <!-- /.col -->
                                    </div>
                                </div>
                            </div>
                            <!-- /.box -->
                        </div>
                    </div>

            <%-- Data Table Div--%>
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box-body" id="RecordListDiv">
                             
                            </div>
                            <!-- /.box -->
                        </div>
                        <!-- /.col -->
                    </div>

     
          
      
    <%--</div>--%>

</asp:Content>
