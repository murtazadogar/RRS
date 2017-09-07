<%@ Page Title="" Language="C#" MasterPageFile="~/Application_Code/Views/RRS.Master" AutoEventWireup="true" CodeBehind="frmDeals.aspx.cs" Inherits="RRS_UI.Application_Code.Views.frmDeals" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- iCheck -->
    <script src="../../Content/plugins/iCheck/icheck.min.js"></script>

    <!-- Slick Slider -->
    <link href="../../Content/plugins/slickSlider/slick.css" rel="stylesheet" />
    <link href="../../Content/plugins/slickSlider/slick-theme.css" rel="stylesheet" />
    <script src="../../Content/plugins/slickSlider/slick.min.js"></script>

    <!--bootstrap Timepicker-->
    <%--<link href="../../Content/css/timepicker.css" rel="stylesheet" />
    <script src="../../Content/js/bootstrap-timepicker.js"></script>--%>

<link href="https://cdn.jsdelivr.net/bootstrap.timepicker/0.2.6/css/bootstrap-timepicker.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/bootstrap.timepicker/0.2.6/js/bootstrap-timepicker.min.js"></script>





      <!--bootstrap file uploader-->
    <link href="../../Content/css/fileinput.min.css" rel="stylesheet" />
    <script src="../../Content/js/fileinput.min.js"></script>

    <script src="../ViewsScript/Restaurant.js"></script>

    <script>
        $(function () {

            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });

           
            $("select").select2({
                placeholder: "Select an option"
            });

            //$('.select2-multiple2').select2MultiCheckboxes({
            //    templateSelection: function (selected, total) {
            //        return "Selected " + selected.length + " of " + total;
            //    }
            //});

            $('.timepickerControl').timepicker('showWidget').on('show.timepicker', function (e) {
                $('table').find('tr td a').find('i.icon-chevron-up').each(function (i) {
                    $(this).addClass(' fa fa-chevron-circle-up');
                });

                $('table').find('tr td a').find('i.icon-chevron-down').each(function (i) {
                    $(this).addClass(" fa fa-chevron-circle-down");
                });
            });

            LoadDishesDDL("#ddlDish");
            GetRestaurantDeals();

            $("#importImages").fileinput({
                'showPreview': false,
                'allowedFileExtensions': ["jpg", "png", "gif"],
                'elErrorContainer': '#errorBlock',
                'showUpload': false,
                'maxFilePreviewSize': 10240,
                'browseClass': "btn btn-red",
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoggedInContent" runat="server">

    <input type="hidden" id="hdnID" value="-1" />
      <input type="hidden" id="uploadValue" value="-1" />

    <div class="row gutter-5 clearfix marBottom15">
        <div class="pull-left col-md-8">
            <h2 class="pageHead">Deals</h2>
        </div>
        <div class="col-md-4 addBtns">
            <%--<button type="button" class="btn btn-round btn-red"><i class="fa fa-plus-circle" aria-hidden="true"></i>Add Menu</button>--%>
            <button type="button" class="btn btn-round btn-red marLft5" data-toggle="modal" data-target="#myModal"><i class="fa fa-plus-circle" aria-hidden="true"></i>Add Deal</button>
        </div>
    </div>

    <div class="clearfix" id="RecordListDiv">
    </div>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Deal</h4>
                </div>
                <div class="modal-body clearfix">
                    <div class="col-xs-12">
                        <div class="form-group row">
                            <div class="col-md-12 col-sm-12">
                                <label for="example-text-input" class="col-lg-2 pad-0 col-form-label">Deal Name</label>
                                <div class="col-lg-10 padRight0">
                                    <input class="form-control" type="text" value="" id="txtName" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-md-6 col-sm-6">
                                <label for="example-text-input" class="col-lg-4 pad-0 col-form-label">Number of Persons</label>
                                <div class="col-lg-8 padRight0">
                                    <input class="form-control" type="text" value="" id="txtNoOfPerson" />
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6">
                                <label for="example-search-input" class="col-lg-3 pad-0 col-form-label">Days of Week</label>
                                <div class="col-lg-9 pad-0">
                                    <select name="sel-02" id="ddlDaysOfWeek" class="js-example-basic-multiple input-full-width" multiple>
                                        <option value=""></option>
                                        <option value="Monday">Monday</option>
                                        <option value="Tuesday">Tuesday</option>
                                        <option value="Wednesday">Wednesday</option>
                                        <option value="Thursday">Thursday</option>
                                        <option value="Friday">Friday</option>
                                        <option value="Saturday">Saturday</option>
                                        <option value="Sunday">Sunday</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <h4>Deal Timings</h4>

                        <div id="DealDetails" style="padding-left:4%">
                            <div class="form-group row">
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Start Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="startTimeDiv1">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="start_time1" type="text" class="form-control input-small timepickerControl" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">End Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="endTimeDiv1">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="end_time1" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Discount %:</label>
                                    <div class="col-lg-7 padRight0">
                                        <input id="txtDiscount1" type="text" class="form-control input-small" />
                                    </div>
                                </div>

                            </div>
                            <div class="form-group row">
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Start Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="startTimeDiv2">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="start_time2" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">End Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="endTimeDiv2">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="end_time2" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Discount %:</label>
                                    <div class="col-lg-7 padRight0">
                                        <input id="txtDiscount2" type="text" class="form-control input-small" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Start Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="startTimeDiv3">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="start_time3" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 col-sm-4">

                                    <label class="col-lg-5 txtLable">End Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="endTimeDiv3">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="end_time3" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>

                                </div>
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Discount %:</label>
                                    <div class="col-lg-7 padRight0">
                                        <input id="txtDiscount3" type="text" class="form-control input-small" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Start Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="startTimeDiv4">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="start_time4" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">End Time:</label>
                                    <div class="col-lg-7 padRight0">
                                        <div class="input-group time" id="endTimeDiv4">
                                            <div class="input-group-addon">
                                                <i class="fa fa-clock-o"></i>
                                            </div>
                                            <input id="end_time4" type="text" class="form-control input-small timepickerControl">
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4 col-sm-4">
                                    <label class="col-lg-5 txtLable">Discount %:</label>
                                    <div class="col-lg-7 padRight0">
                                        <input id="txtDiscount4" type="text" class="form-control input-small" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                     <div class="form-group row" style="padding-left:3%">
                            <div class="col-md-12 col-sm-12">
                                <label for="example-text-input" class="col-lg-2 pad-0 col-form-label">Dishes</label>
                                <div class="col-lg-10 pad-0">
                                   <select name="sel-02" id="ddlDish" class="js-example-basic-multiple input-full-width" multiple>
                                </select>
                                </div>
                            </div>
                        </div>

                  
                    <div class="form-group row" style="padding-left:1%">
                        <div class="col-md-12 col-sm-12">
                            
                                <label for="example-tel-input" class="col-lg-2 col-form-label">Description</label>
                                <div class="col-lg-10 padRight0">
                                    <textarea class="form-control" rows="3" placeholder="Enter ..." id="txtDescription"></textarea>
                                </div>
                       
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-md-12 col-sm-12">
                            <div class="col-lg-12">
                                <label for="example-text-input" class="col-lg-2 pad-0 col-form-label">Upload Images</label>
                                <div class="col-lg-10 padRight0">
                                    <input id="importImages" onchange="UploadDocument(this);" multiple type="file" class="file-loading" />
                                    <div id="errorBlock" class="help-block"></div>
                                </div>
                            </div>
                        </div>

                        <div class="form-group row">
                               <div class="col-md-8 col-sm-8">

                               </div>
                            <div class="col-md-4 col-sm-4" style="padding:2%;">
                                <div class="col-lg-6 padLeft0">
                                    <button type="button" class="col-lg-11 btn btn-round btn-red" onclick="SaveDealData();">Save</button>
                                </div>
                                <div class="col-lg-6 padLeft0">
                                    <button type="button" class="col-lg-11  btn btn-round btn-danger">Cancel</button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
