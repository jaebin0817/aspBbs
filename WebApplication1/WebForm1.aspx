<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link rel="stylesheet" href="/Content/bootstrap.css"/>
  <link rel="stylesheet" href="/Content/bootstrap-theme.css"/> 
  <link rel="stylesheet" href="/Content/style.css"/>

    <title></title>
</head>
<body>

    <nav class="navbar navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
           <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
               <img src="/Images/more.png" alt="MENU" />
           </button>
	       <a href="Main.aspx">
	          <img src="/Images/home.png" alt="HOME" />
	       </a>
        </div>
        <div class="collapse navbar-collapse" id="myNavbar">
          <ul class="nav navbar-nav navbar-left">
	      	    <li><a href="BbsList.aspx?bbs_cat=카테고리1">카테고리1</a></li>
	      	    <li><a href="BbsList.aspx?bbs_cat=카테고리2">카테고리2</a></li>
	      	    <li><a href="BbsList.aspx?bbs_cat=카테고리3">카테고리3</a></li>
          </ul>        
          <div class="nav navbar-nav navbar-right">
            <form id="searchfrm" action="BbsList.aspx" method="get">  
              <input class="navsearch" id="navsearch" type="search" required="required" />
              <input class="navbtn" id="navbtn" type="submit" value="검색"/>
            </form>
          </div>
        </div>
      </div>
    </nav>

    <!-- 본문 시작 -->
  <div id="body-wrapper"> 
    <div class="wrap">



        
    </div>
   </div>   <!-- 본문 끝 -->


    <footer>
      <div class="container">
        <p>Copyright &copy; 사이트명</p> 
      </div>
    </footer>


</body>
</html>

