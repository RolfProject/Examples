<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Web_Exam.Views.Home" MasterPageFile="~/Site.Master"%>
<asp:content ID="Content1" runat="server" ContentPlaceHolderID="body">
        <div class="clasediv">
        <h3><%="Bienvenido:"+ Web_Exam.ClassStatic.UsuarioLogg.Nombre %></h3>

        </div>
        <div class="slider">
			        <ul>
				        <li>
                          <img src="http://youghaltennisclub.ie/wp-content/uploads/2014/06/Tennis-Wallpaper-High-Definition-700x300.jpg" alt="" />
                        </li>
				        <li>
                          <img src="http://welltechnically.com/wp-content/uploads/2013/08/android-wallpapers-700x300.jpg" alt="" />
                        </li>
				        <li>
                          <img src="http://welltechnically.com/wp-content/uploads/2013/09/android-widescreen-wallpaper-14165-hd-wallpapers-700x300.jpg" alt="" />
                        </li>
			        </ul>
        </div>
  
</asp:content>