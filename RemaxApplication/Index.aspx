<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RemaxApplication.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<title>Remax Simulator - Real Estate Agency</title>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body,h1,h2,h3,h4,h5,h6 {font-family: "Raleway", Arial, Helvetica, sans-serif}
.mySlides {display: none}
</style>

<body class="w3-content w3-border-left w3-border-right" runat="server">
    <!-- Sidebar/menu -->
<nav class="w3-sidebar w3-light-grey w3-collapse w3-top" style="z-index:3;width:260px" id="mySidebar" runat="server">
  <div class="w3-container w3-display-container w3-padding-16">
    <i onclick="w3_close()" class="fa fa-remove w3-hide-large w3-button w3-transparent w3-display-topright"></i>
    <h3>Find Your</h3>
    <h3>Dream Home</h3>
    
    <hr/>
    <form action="Index.aspx" runat="server">
       <p><label> Types : </label></p> 
      <asp:CheckBoxList runat="server" class="w3-input w3-border" ID="chkTypes"> </asp:CheckBoxList>
      <p><label> Regions : </label></p> 
      <asp:CheckBoxList runat="server" class="w3-input w3-border" ID="chkRegions"> </asp:CheckBoxList>
        <p><label> For : </label></p>
        <asp:CheckBoxList runat="server" class="w3-input w3-border" ID="chkFor"></asp:CheckBoxList>
      <p><label>Price (From): </label></p>
      <asp:DropDownList runat="server" class="w3-input w3-border" ID="cboPriceFrom"></asp:DropDownList>  
        <p><label>Price (To): </label></p>
      <asp:DropDownList runat="server" class="w3-input w3-border" ID="cboPriceTo"></asp:DropDownList>  
      <p><label>Rooms : </label></p>
      <asp:DropDownList runat="server" class="w3-input w3-border" ID="cboRooms"></asp:DropDownList>          
      <p><label>Bathrooms : </label></p>
      <asp:DropDownList runat="server" class="w3-input w3-border" ID="cboBathrooms"></asp:DropDownList>
        <br /><br />
      <asp:Button runat="server" class="w3-button w3-block w3-green w3-left-align" Text="Search" OnClick="Unnamed1_Click" ID="Button1" />
        <br />
        <asp:Button runat="server" class="w3-button w3-block w3-green w3-left-align" Text="All Properties" ID="btnAllProperties" OnClick="btnAllProperties_Click" />
    </form>
  </div>
  <div class="w3-bar-block" runat="server">
    <a href="ShowAgents.aspx" class="w3-bar-item w3-button w3-padding-16"><i class="fa fa-envelope"></i> Contact Our Agents</a>
  </div>
</nav>

<!-- Top menu on small screens -->
<header class="w3-bar w3-top w3-hide-large w3-black w3-xlarge">
  <span class="w3-bar-item">Rental</span>
  <a href="javascript:void(0)" class="w3-right w3-bar-item w3-button" onclick="w3_open()"><i class="fa fa-bars"></i></a>
</header>

<!-- Overlay effect when opening sidebar on small screens -->
<div class="w3-overlay w3-hide-large" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

<!-- !PAGE CONTENT! -->
<div class="w3-main w3-white" style="margin-left:260px">

  <!-- Push down content on small screens -->
  <div class="w3-hide-large" style="margin-top:80px"></div>

  <!-- Slideshow Header -->
  <div class="w3-container" id="apartment" runat="server">
    <h2 class="w3-text-green"><asp:Literal runat="server" ID="litPropertyCount"></asp:Literal></h2>
  </div>
  
  <div class="w3-container" runat="server">
    <div class="w3-row w3-large" runat="server">
      <div class="w3-col s12" runat="server">
        <asp:Literal runat="server" ID="litHouses"></asp:Literal>  
      </div>
    </div>
      <asp:Literal runat="server" ID="litSql"></asp:Literal>
<!-- End page content -->
</div>


<script>
// Script to open and close sidebar when on tablets and phones
function w3_open() {
  document.getElementById("mySidebar").style.display = "block";
  document.getElementById("myOverlay").style.display = "block";
}
 
function w3_close() {
  document.getElementById("mySidebar").style.display = "none";
  document.getElementById("myOverlay").style.display = "none";
}

// Slideshow Apartment Images
var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
  showDivs(slideIndex += n);
}

function currentDiv(n) {
  showDivs(slideIndex = n);
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("demo");
  if (n > x.length) {slideIndex = 1}
  if (n < 1) {slideIndex = x.length}
  for (i = 0; i < x.length; i++) {
    x[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" w3-opacity-off", "");
  }
  x[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " w3-opacity-off";
}
</script>

</body>
</html>
