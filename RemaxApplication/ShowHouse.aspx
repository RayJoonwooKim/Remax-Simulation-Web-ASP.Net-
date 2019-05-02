<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowHouse.aspx.cs" Inherits="RemaxApplication.ShowHouse" %>

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

<!-- Overlay effect when opening sidebar on small screens -->
<div class="w3-overlay w3-hide-large" onclick="w3_close()" style="cursor:pointer" title="close side menu" id="myOverlay"></div>

<!-- !PAGE CONTENT! -->
<div class="w3-main w3-white" >

  <!-- Push down content on small screens -->
  <div class="w3-hide-large" style="margin-top:80px"></div>

  <!-- Slideshow Header -->
  <div class="w3-container" id="apartment">
    <h2 class="w3-text-green"><asp:Label runat="server" ID="lblTitle" Text="Hi"></asp:Label></h2>
    
    <div class="w3-display-container mySlides">
    
  </div>
  

  <div class="w3-container" runat="server">
    <h4><strong>Property Details</strong></h4>
    <div class="w3-row w3-large" runat="server">
      <div class="w3-col s6" runat="server">
        <p><i class="fa fa-fw fa-home"></i> Type :  <asp:Label runat="server" ID="lblType"></asp:Label> </p> 
        <p><i class="fa fa-fw fa-bath"></i> Number of Bathrooms: <asp:Label runat="server" ID="lblBathroom"></asp:Label> </p>
        <p><i class="fa fa-fw fa-bed"></i> Number of Rooms: <asp:Label runat="server" ID="lblRoom"></asp:Label> </p>
        
      </div>
      <div class="w3-col s6" runat="server">
        <p><i class="fa fa-map-marker"></i> Region : <asp:Label runat="server" ID="lblRegion"></asp:Label> </p>
        <p><i class="fa fa-fw fa-money"></i> Price : <asp:Label runat="server" ID="lblprice"></asp:Label> </p>
        <p><i class="fa fa-fw fa-building-o"></i> Year Built : <asp:Label runat="server" ID="lblYear"></asp:Label> </p>
      </div>
    </div>
    <hr/>
    
    <h4><strong>Description</strong></h4>
    <p><asp:Label runat="server" ID="lblDescription"></asp:Label></p>
    <p>We accept: <i class="fa fa-credit-card w3-large"></i> <i class="fa fa-cc-mastercard w3-large"></i> <i class="fa fa-cc-amex w3-large"></i> <i class="fa fa-cc-cc-visa w3-large"></i><i class="fa fa-cc-paypal w3-large"></i></p>
    <hr/>   
  </div>
  <hr/>
  
  <!-- Contact -->
  <div class="w3-container" id="contact" runat="server">
    <h2>Contact</h2>
    <i class="fa fa-users" style="width:30px"></i> <asp:Label runat="server" ID="lblAgent"></asp:Label><br>
    <i class="fa fa-phone" style="width:30px"></i> <asp:Label runat="server" ID="lblPhone"></asp:Label><br>
    <i class="fa fa-envelope" style="width:30px"> </i> <asp:Label runat="server" ID="lblEmail"></asp:Label><br>
    <p>Questions? Go ahead, ask them:</p>
    <form action="/action_page.php" target="_blank" runat="server">
      <p><input class="w3-input w3-border" type="text" placeholder="Name" required name="Name"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Email" required name="Email"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Message" required name="Message"></p>
    <button type="submit" class="w3-button w3-green w3-third">Send a Message</button>
    </form>
  </div>
  
  <footer class="w3-container w3-padding-16" style="margin-top:32px">Powered by <a href="https://www.w3schools.com/w3css/default.asp" title="W3.CSS" target="_blank" class="w3-hover-text-green">w3.css</a></footer>

<!-- End page content -->
</div>

<!-- Subscribe Modal -->
<div id="subscribe" class="w3-modal">
  <div class="w3-modal-content w3-animate-zoom w3-padding-large">
    <div class="w3-container w3-white w3-center">
      <i onclick="document.getElementById('subscribe').style.display='none'" class="fa fa-remove w3-button w3-xlarge w3-right w3-transparent"></i>
      <h2 class="w3-wide">SUBSCRIBE</h2>
      <p>Join our mailing list to receive updates on available dates and special offers.</p>
      <p><input class="w3-input w3-border" type="text" placeholder="Enter e-mail"></p>
      <button type="button" class="w3-button w3-padding-large w3-green w3-margin-bottom" onclick="document.getElementById('subscribe').style.display='none'">Subscribe</button>
    </div>
  </div>
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
