<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageToAgent.aspx.cs" Inherits="RemaxApplication.MessageToAgent" %>

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
    <div class="w3-container" id="contact" runat="server">
    <h2>Contact</h2>
    <i class="fa fa-users" style="width:30px"></i> <asp:Label runat="server" ID="lblAgent"></asp:Label><br>
    <i class="fa fa-phone" style="width:30px"></i> <asp:Label runat="server" ID="lblPhone"></asp:Label><br>
    <i class="fa fa-envelope" style="width:30px"> </i> <asp:Label runat="server" ID="lblEmail"></asp:Label><br>
    <p>Questions? Go ahead, ask them:</p>
    <form action="SendMessage.aspx" target="_blank" runat="server">
      <p><input class="w3-input w3-border" type="text" placeholder="Your Name" required name="Name"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Your Email" required name="Email"></p>
      <p><input class="w3-input w3-border" type="text" placeholder="Message" required name="Message"></p>
    <button type="submit" class="w3-button w3-green w3-third">Send a Message</button>
    </form>
  </div>
</body>
</html>
