<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAgents.aspx.cs" Inherits="RemaxApplication.ShowAgents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
 <title></title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://www.w3schools.com/lib/w3-theme-blue-grey.css">
<link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans'>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
html, body, h1, h2, h3, h4, h5 {font-family: "Open Sans", sans-serif}
</style>
<body class="w3-theme-l5" runat="server">
   
<h1 class="w3-center">Remax Agents</h1>

<!-- Page Container -->
<div class="w3-container w3-content" style="max-width:1400px;margin-top:80px" runat="server">    
  <!-- The Grid -->
  <div class="w3-row" runat="server">
    <!-- Left Column -->
    <div class="w3-col m3" runat="server">
      <!-- Profile -->
      <div class="w3-card w3-round w3-white" runat="server">
        <div class="w3-container">
         <h4 class="w3-center">Find Agents</h4>
         <p class="w3-center"></p>
         <hr/>
            <form runat="server" action="ShowAgents.aspx">
         <p><i class="fa fa-language fw w3-margin-right w3-text-theme"></i> Languages : <asp:CheckBoxList runat="server" ID="chkLanguages"></asp:CheckBoxList></p>
         <p><i class="fa fa-male fa-fw w3-margin-right w3-text-theme"></i> Gender : <asp:RadioButtonList runat="server" ID="radGender"></asp:RadioButtonList></p>
         <p><i class="fa fa-map-marker fa-fw w3-margin-right w3-text-theme"></i> City : <asp:CheckBoxList runat="server" ID="chkCity"></asp:CheckBoxList></p>
         <asp:Button runat="server" ID="btnSearch" class="w3-button w3-block w3-theme-l1 w3-left-align" Text="Find" OnClick="btnSearch_Click" />
                <br />

                <br />
                <asp:Button runat="server" ID="btnAll" class="w3-button w3-block w3-theme-l1 w3-left-align" Text="All Agents" OnClick="btnAll_Click"  />
                <br />
                <br />
            </form>
         
        </div>
      </div>
      <br/>
      
      <!-- Alert Box -->
        <div class="w3-container w3-display-container w3-round w3-theme-l4 w3-border w3-theme-border w3-margin-bottom w3-hide-small">
        <span onclick="this.parentElement.style.display='none'" class="w3-button w3-theme-l3 w3-display-topright">
          <i class="fa fa-remove"></i>
        </span>
        <p><strong>Hey!</strong></p>
        <p>Look for our best agents!</p>
      </div>

        <div class="w3-bar-block" runat="server">
            <a href="Index.aspx" class="w3-button w3-block w3-theme-l1 w3-left-align"><i class="fa fa-home"></i> Go to Remax Real Estate</a>
        </div>
      
    
    <!-- End Left Column -->
    </div>
    
    <!-- Middle Column -->
    <div class="w3-col m7" runat="server">
 
      <div class="w3-container w3-card w3-white w3-round w3-margin"><br>
        <asp:Literal runat="server" ID="litAgents"></asp:Literal> <br />
        
      </div>  

    <!-- End Middle Column -->
    </div>
    
    <!-- Right Column -->
    <div class="w3-col m2">
      <div class="w3-card w3-round w3-white w3-center">
        <div class="w3-container">
          <p>Upcoming Events:</p>
          
          <p><strong>Holiday</strong></p>
          <p>Friday 15:00</p>
          <p><button class="w3-button w3-block w3-theme-l4">Info</button></p>
        </div>
      </div>
      <br>
      
      <div class="w3-card w3-round w3-white w3-center">
        <div class="w3-container">
          <p>Friend Request</p>
          <img src="/w3images/avatar6.png" alt="Avatar" style="width:50%"><br>
          <span>Jane Doe</span>
          <div class="w3-row w3-opacity">
            <div class="w3-half">
              <button class="w3-button w3-block w3-green w3-section" title="Accept"><i class="fa fa-check"></i></button>
            </div>
            <div class="w3-half">
              <button class="w3-button w3-block w3-red w3-section" title="Decline"><i class="fa fa-remove"></i></button>
            </div>
          </div>
        </div>
      </div>
      <br>
      
      <div class="w3-card w3-round w3-white w3-padding-16 w3-center">
        <p>ADS</p>
      </div>
      <br>
      
      <div class="w3-card w3-round w3-white w3-padding-32 w3-center">
        <p><i class="fa fa-bug w3-xxlarge"></i></p>
      </div>
      
    <!-- End Right Column -->
    </div>
    
  <!-- End Grid -->
  </div>
  
<!-- End Page Container -->
</div>
<br>

<!-- Footer -->
<footer class="w3-container w3-theme-d3 w3-padding-16">
  <h5>Footer</h5>
</footer>

<footer class="w3-container w3-theme-d5">
  <p>Powered by <a href="https://www.w3schools.com/w3css/default.asp" target="_blank">w3.css</a></p>
</footer>
 
<script>
// Accordion
function myFunction(id) {
  var x = document.getElementById(id);
  if (x.className.indexOf("w3-show") == -1) {
    x.className += " w3-show";
    x.previousElementSibling.className += " w3-theme-d1";
  } else { 
    x.className = x.className.replace("w3-show", "");
    x.previousElementSibling.className = 
    x.previousElementSibling.className.replace(" w3-theme-d1", "");
  }
}

// Used to toggle the menu on smaller screens when clicking on the menu button
function openNav() {
  var x = document.getElementById("navDemo");
  if (x.className.indexOf("w3-show") == -1) {
    x.className += " w3-show";
  } else { 
    x.className = x.className.replace(" w3-show", "");
  }
}
</script>

</body>
</html>
