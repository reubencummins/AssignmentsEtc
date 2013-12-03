<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolForm.aspx.cs" Inherits="WebAssignment1.SchoolForm" MaintainScrollPositionOnPostback="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Preschool Registration</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
</head>
<body>

    <form id="form1" runat="server">
    <div class="form">
            
                    
            <h1 style="text-align: left">Registration</h1>
            <h2>Child's Details</h2>
                    <p>
                        <asp:Label ID="lblName" runat="server" Text="First Name" CssClass="formLabel"></asp:Label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="formBox"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter the child's first name." Display="Dynamic">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblSName" runat="server" Text="Surname" CssClass="formLabel"></asp:Label>
                        <asp:TextBox ID="txtName2" runat="server" CssClass="formBox"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName2" ErrorMessage="Please enter the child's surname." Display="Dynamic">*</asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblPPS" runat="server" Text="PPS Number" CssClass="formLabel"></asp:Label>
                        <asp:TextBox ID="txtPPS" runat="server" CssClass="formBox"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPPS" ErrorMessage="Please enter a PPS number." Display="Dynamic">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="validator" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPPS" ErrorMessage="Please enter a valid PPS number." ValidationExpression="\d{7}\d?[a-tA-T]" Display="Dynamic">*</asp:RegularExpressionValidator>
                    </p>
                    <p>
                        &nbsp;</p>
            <p>
                    <asp:Label ID="lblDOB" runat="server" Text="Date of Birth" CssClass="formLabel"></asp:Label>
                    <asp:TextBox ID="txtDOB" runat="server" CssClass="formBox"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOB" ErrorMessage="Please enter a date of birth." Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator CssClass="validator" ID="RangeValidator1" runat="server" ControlToValidate="txtDOB" ErrorMessage="Please enter a valid date of birth." MaximumValue="1-1-2030" MinimumValue="1-1-2000" Type="Date" Display="Dynamic">*</asp:RangeValidator>
                    </p>
                    <p>
                    <asp:Label ID="lblGender" runat="server" Text="Gender" CssClass="formLabel"></asp:Label>
                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" CssClass="formBox" RepeatLayout="Flow">
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator CssClass="validator" ID="RequiredFieldValidator4" runat="server" ControlToValidate="rblGender" ErrorMessage="Please select a gender." Display="Dynamic">*</asp:RequiredFieldValidator>
                    </p>
            
        </div>
        <div class="form">
        
            <h2>Parent's Details</h2>
            
                
                <p>
                    <asp:Label ID="lblPName" runat="server" Text="First Name" CssClass="formLabel"></asp:Label>
                    <asp:TextBox ID="txtPName" runat="server" CssClass="formBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter your first name." ControlToValidate="txtPname" CssClass="validator" ValidationGroup="adult">*</asp:RequiredFieldValidator>
                </p>
                
                <p>
                    <asp:Label ID="lblPSName" runat="server" Text="Surname" CssClass="formLabel"></asp:Label>
                    <asp:TextBox ID="txtPSName" runat="server" CssClass="formBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter your surname." ControlToValidate="txtPSName" CssClass="validator" ValidationGroup="adult">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblParRel" runat="server" Text="Relationship to child" CssClass="formLabel"></asp:Label>
                        <asp:RadioButtonList ID="rdbPRel" runat="server" CssClass="formBox" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rdbPRel_SelectedIndexChanged">
                        <asp:ListItem Value="1">Father</asp:ListItem>
                        <asp:ListItem Value="2">Mother</asp:ListItem>
                        <asp:ListItem Value="3">Other (Please Specify)</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:TextBox ID="txtPRel" runat="server" CssClass="formBox" Enabled="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredRel" runat="server" ErrorMessage="Please specify your relationship with the child." ControlToValidate="rdbPRel" CssClass="validator" ValidationGroup="adult">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="lblAddress" runat="server" Text="Address Line 1" CssClass="formLabel"></asp:Label>
                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="formBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="validator" ErrorMessage="Please enter your address" ControlToValidate="txtAddress1" Display="Dynamic">*</asp:RequiredFieldValidator>
                </p>
                <p>
                        <asp:Label ID="lblAddress2" runat="server" Text="Address Line 2 (Optional)" CssClass="formLabel"></asp:Label>
                    
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="formBox"></asp:TextBox>
                    </p>
                
                <p>
                    
                        <asp:Label ID="lblAddress3" runat="server" Text="Town" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtAddress3" runat="server" CssClass="formBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" CssClass="validator" ErrorMessage="Please enter a town." ControlToValidate="txtAddress3" Display="Dynamic">*</asp:RequiredFieldValidator>
                   </p> 
                
                
                    <p>
                        <asp:Label ID="lblAddress4" runat="server" Text="County" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtAddress4" runat="server" CssClass="formBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="validator" ErrorMessage="Please enter a county." ControlToValidate="txtAddress4" Display="Dynamic">*</asp:RequiredFieldValidator>
                    </p>
                
                
                    <p>
                        <asp:Label ID="lblPhone" runat="server" Text="Mobile Phone Number" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" CssClass="formBox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredPhone" runat="server" ErrorMessage="Please enter a mobile phone number" ControlToValidate="txtPhone" CssClass="validator" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please enter a valid mobile number." ControlToValidate="txtPhone" CssClass="validator" ValidationExpression="(\+?3538|08)\d-?\d{7}" Height="19px" Display="Dynamic">*</asp:RegularExpressionValidator>
                    </p>
                
                
                    <p>
                        <asp:Label ID="lblPhone2" runat="server" Text="Second Contact Number" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtPhone2" runat="server" TextMode="Phone" CssClass="formBox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredPhone2" runat="server" ErrorMessage="Please enter a second contact number." ControlToValidate="txtPhone" CssClass="validator" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please enter a valid phone number" ControlToValidate="txtPhone2" CssClass="validator" ValidationExpression="(\+?353|0)\d\d-?\d{7}" Display="Dynamic">*</asp:RegularExpressionValidator>
                    
                </p>
                <p>
                        <asp:Label ID="lblPhone3" runat="server" Text="Other Number (Optional)" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtPhone3" runat="server" TextMode="Phone" CssClass="formBox"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Please enter a valid phone number" ControlToValidate="txtPhone3" CssClass="validator" ValidationExpression="(\+?353|0)\d\d-?\d{7}" Display="Dynamic">*</asp:RegularExpressionValidator>
                   </p> 
                
                
                    <p>
                        <asp:Label ID="lblEmail" runat="server" Text="Email Address" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="formBox"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ErrorMessage="Please enter an email address" ControlToValidate="txtEmail" CssClass="validator" Display="Dynamic">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularEmail" runat="server" ErrorMessage="Please enter a valid email address" ControlToValidate="txtEmail" CssClass="validator" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </p>
                
                
                    <p>
                        <asp:Label ID="lblEmail2" runat="server" Text="Second Email (Optional)" CssClass="formLabel"></asp:Label>
                    
                    
                        <asp:TextBox ID="txtEmail2" runat="server" TextMode="Email" CssClass="formBox"></asp:TextBox><asp:RegularExpressionValidator ID="RegularEmail2" runat="server" ErrorMessage="Please enter a valid email address" ControlToValidate="txtEmail2" CssClass="validator" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </p>
                
            
        </div>
        <div class="form">
            <h2>Times Requested</h2>
            <p>
            <asp:RadioButtonList ID="rblTime" runat="server" CssClass="formBox">
                <asp:ListItem Value="Full Time">Full Time</asp:ListItem>
                <asp:ListItem Value="Part Time">Part Time</asp:ListItem>
            </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please choose full or part time." CssClass="validator" Display="Dynamic" ControlToValidate="rblTime">*</asp:RequiredFieldValidator>
              
                <asp:CheckBoxList ID="cblDays" runat="server">
                    <asp:ListItem>Monday</asp:ListItem>
                    <asp:ListItem>Tuesday</asp:ListItem>
                    <asp:ListItem>Wednesday</asp:ListItem>
                    <asp:ListItem>Thursday</asp:ListItem>
                    <asp:ListItem>Friday</asp:ListItem>
                </asp:CheckBoxList>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please select at least one day." ClientValidationFunction="ValidateCheckBoxList" CssClass="validator">*</asp:CustomValidator>
                <script type="text/javascript">
                    function ValidateCheckBoxList(sender, args) {
                        var checkBoxList = document.getElementById("<%=cblDays.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
                       
            args.IsValid = isValid;
                    }
                    </script>
            </p>
        
        
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validator" />
            
            
                <div class="form">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button" OnClick="btnClear_Click" CausesValidation="false" />
                </div>
            </div>
    </form>
</body>
</html>