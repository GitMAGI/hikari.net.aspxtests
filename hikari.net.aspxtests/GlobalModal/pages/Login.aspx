<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="hikari.net.aspxtests.GlobalModal.pages.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    
    <meta charset="utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title><%= this.projectShortName %> - <%= this.projectDisplayName %></title>

	<!-- Global stylesheets -->
	<link href="https://fonts.googleapis.com/css?family=Roboto:400,300,100,500,700,900" rel="stylesheet" type="text/css" />
	<link href="../assets/css/icons/icomoon/styles.css" rel="stylesheet" type="text/css" />
	<link href="../assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="../assets/css/components.css" rel="stylesheet" type="text/css" />
	<link href="../assets/css/colors.css" rel="stylesheet" type="text/css" />
	<link href="../assets/css/core.css" rel="stylesheet" type="text/css" />
	<!-- /Global stylesheets --> 

    <!-- Core JS files -->
    <script type="text/javascript" src="../assets/js/core/libraries/jquery.min.js"></script>
    <script type="text/javascript" src="../assets/js/plugins/loaders/pace.min.js"></script>
	<script type="text/javascript" src="../assets/js/core/libraries/bootstrap.min.js"></script>
	<script type="text/javascript" src="../assets/js/plugins/loaders/blockui.min.js"></script>
	<!-- /core JS files -->

    <!-- Validator JS files -->
    <script type="text/javascript" src="../assets/js/core/validator.js"></script>
    <!-- /validatore JS files -->

	<!-- Theme JS files -->
	<script type="text/javascript" src="../assets/js/core/app.js"></script>
	<!-- /theme JS files -->

    <!-- Page related JS files -->
    <script type="text/javascript" src="../js/Login.js"></script>
    <!-- /page related JS files -->

    <script type="text/javascript">
        var fieldsToValidate = [
            {
                name: "<%= this.UserName.ClientID %>",
                rules: [
                    {
                        op: "notNullOrVoidInputText",
                        err: "Il campo non può essere vuoto"
                    }, 
                ]
            },
            {
                name: "<%= this.Password.ClientID %>",
                rules: [
                    {
                        op: "notNullOrVoidInputText",
                        err: "Il campo non può essere vuoto"
                    },
                ]
            }
        ];

        var LoginAlertBoxID = "<%= this.alertLogin.ClientID %>";
        var LoginAlertHeaderID = "<%= this.alertLoginHeader.ClientID %>";
        var LoginAlertBodyID = "<%= this.alertLoginBody.ClientID %>";

    </script>

</head>

<body class="login-container login-cover">

    <!-- Page container -->
	<div class="page-container">

		<!-- Page content -->
		<div class="page-content">

			<!-- Main content -->
			<div class="content-wrapper">

				<!-- Content area -->
				<div class="content">

                    <div class="row">
                        <div id="alertLogin" style="display:none" class="col-md-4 col-md-offset-4 alert " runat="server">
                            <strong id="alertLoginHeader" runat="server"></strong>
                            <br/>
                            <div id="alertLoginBody" runat="server">
                            </div>
                        </div>
                    </div>  
                
                    <form id="form1" runat="server">

                        <div class="panel panel-body login-form">
			                <div class="text-center">
                                <h1><span class="text-black"><%= this.projectShortName %></span><br /><span class="text-light"><%= this.projectDisplayName %></span></h1>
                                <h6 class="text-slate-400 mt-5 mb-20"><%= this.projectDescriptionName %></h6>
			                </div>

                            <div class="form-group has-feedback has-feedback-left">
                                <input type="text" id="UserName" runat="server" placeholder="Username" class="form-control" />                                
                                <div class="form-control-feedback">
					                <i class="icon-user text-muted"></i>
				                </div>
                            </div>

                            <div class="form-group has-feedback has-feedback-left">
                                <input type="password" id="Password" runat="server" placeholder="Password" class="form-control" />
                                <div class="form-control-feedback">
					                <i class="icon-lock2 text-muted"></i>
				                </div>
                            </div>

                            <asp:Button CssClass="btn btn-primary btn-block" runat="server" ID="btnLogin" OnClientClick="return validate(fieldsToValidate);" OnClick="btnLogin_Click" Text="Accedi" />
                                        
                        </div>

                    </form>

                    <!-- Footer -->
					<div class="footer text-center">
						<small>&copy; <%= this.devYear %> - <%: DateTime.Now.Year %>. <a href="<%= this.devCompanyWebSiteURL %>" target="_blank"><%= this.devCompanyName %></a></small>
					</div>
					<!-- /footer -->

				</div>
				<!-- /content area -->

			</div>
			<!-- /main content -->

		</div>
		<!-- /page content -->

	</div>
	<!-- /page container -->
</body>
</html>