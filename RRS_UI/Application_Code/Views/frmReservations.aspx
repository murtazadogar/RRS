<%@ Page Title="" Language="C#" MasterPageFile="~/Application_Code/Views/RRS.Master" AutoEventWireup="true" CodeBehind="frmReservations.aspx.cs" Inherits="RRS_UI.Application_Code.Views.frmReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
     <!-- bootstrap date picker -->
    <link href="../../Content/css/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="../../Content/js/bootstrap-datepicker.js"></script>

    <script src="../ViewsScript/Reservation.js"></script>
    <script src="../ViewsScript/Common.js"></script>
  
    <script>
        $(document).ready(function () {
          
        
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
                                               
                                                </select>
                                            </div>
                                        </div>

                                        <div class="col-sm-4 col-md-2">
                                            <div class="form-group">
                                                <label class="font-gray">Customers</label>
                                                <select class="form-control select2 select2-hidden-accessible" id="ddlCountry" style="width: 100%;" tabindex="-1" aria-hidden="true">
                                                  
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
</asp:Content>
